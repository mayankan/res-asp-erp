using BusinessLogicLayer;
using CommunicationLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAINBOW_ERP.ReportCard
{
    public partial class ClassSubjectMap : System.Web.UI.Page
    {
        SubjectBLL subjectBLL = new SubjectBLL();
        ClassSubjectBLL classSubjectBLL = new ClassSubjectBLL();
        SessionBLL sessionBLL = new SessionBLL();
        public int sessionId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Request.IsAuthenticated)
                {
                    FormsAuthentication.RedirectToLoginPage();
                }
                else
                {
                    FormsAuthenticationTicket ticket = (FormsAuthentication.Decrypt(Session["auth"].ToString()));
                    string userId = ticket.UserData.Split(';')[0];
                    string role = ticket.UserData.Split(';')[1];
                    if (Session["sessionId"] == null)
                    {
                        Response.Redirect("index.aspx");
                    }
                    else if (role.ToLower() == "teacher" || role.ToLower() == "attendanceo")
                    {
                        Response.Redirect("../UnAuthorized.aspx");
                    }
                    else
                    {
                        if (Session["sessionId"] == null)
                        {
                            SessionCL sessionCL = sessionBLL.addorCheckSession();
                            Session["sessionId"] = sessionCL.id;
                        }
                        else
                        {
                            sessionId = Convert.ToInt32(Session["sessionId"]);
                            ViewState["classSubjects"] = grdClassSubject.DataSource = classSubjectBLL.viewClassSubjectMaps(sessionId);
                            grdClassSubject.DataBind();
                        }
                    }
                }
            }
        }

        protected void btnAddClassSubject_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageClassSubjectMap.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void grdClassSubject_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                //Collection<ClassSubjectMapGridCL> getClassSubjectCol = classSubjectBLL.viewClassSubjectMaps();

                var classSubjectCol = (Collection<ClassSubjectMapGridCL>)ViewState["classSubjects"];
                IEnumerable<ClassSubjectMapGridCL> classSubjectColGet = classSubjectCol;
                Collection<ClassSubjectMapGridCL> newClassSubjectCol = new Collection<ClassSubjectMapGridCL>();

                var param = Expression.Parameter(typeof(ClassSubjectMapGridCL), e.SortExpression);
                var sortExpression = Expression.Lambda<Func<ClassSubjectMapGridCL, object>>(Expression.Convert(Expression.Property(param, e.SortExpression), typeof(object)), param);
                if (GridViewSortDirection == SortDirection.Ascending)
                {
                    classSubjectColGet = classSubjectColGet.AsQueryable<ClassSubjectMapGridCL>().OrderBy(sortExpression);
                    GridViewSortDirection = SortDirection.Descending;
                }
                else
                {
                    classSubjectColGet = classSubjectColGet.AsQueryable<ClassSubjectMapGridCL>().OrderByDescending(sortExpression);
                    GridViewSortDirection = SortDirection.Ascending;
                }
                foreach (ClassSubjectMapGridCL item in classSubjectColGet)
                {
                    newClassSubjectCol.Add(new ClassSubjectMapGridCL()
                    {
                        classId = item.classId,
                        classSection = item.classSection,
                        id = item.id,
                        noOfSubjects = item.noOfSubjects,
                        sessionId = item.sessionId,
                        subject = item.subject,
                        subjectId = item.subjectId,
                        dateCreated = item.dateCreated,
                        dateModified = item.dateModified,
                        isDeleted = item.isDeleted,
                    });
                }
                ViewState["classSubjects"] = grdClassSubject.DataSource = newClassSubjectCol;
                grdClassSubject.DataBind();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }

        protected SortDirection GridViewSortDirection
        {
            get
            {
                if (ViewState["sortDirection"] == null)
                    ViewState["sortDirection"] = SortDirection.Ascending;

                return (SortDirection)ViewState["sortDirection"];
            }
            set { ViewState["sortDirection"] = value; }
        }

        protected void grdClassSubject_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int classId = Convert.ToInt32(e.CommandArgument);
                //Response.Redirect("ManageGClassSubjectMap.aspx?classId=" + classId);
                Response.Redirect("ManageClassSubjectMap.aspx?classId=" + classId);
            }
        }

        protected void grdClassSubject_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdClassSubject.PageIndex = e.NewPageIndex;
                grdClassSubject.DataSource = (Collection<ClassSubjectMapGridCL>)ViewState["classSubjects"];
                grdClassSubject.DataBind();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            if (ftSubjectName.Text == string.Empty && ftClass.Text == string.Empty && ftSection.Text == string.Empty)
            {
                sessionId = Convert.ToInt32(Session["sessionId"]);
                ViewState["classSubjects"] = grdClassSubject.DataSource = classSubjectBLL.viewClassSubjectMaps(sessionId);
                grdClassSubject.DataBind();
            }
            else
            {
                sessionId = Convert.ToInt32(Session["sessionId"]);
                var classSubjectQuery = classSubjectBLL.viewClassSubjectMaps(sessionId);
                Collection<ClassSubjectMapGridCL> newClassSubject = new Collection<ClassSubjectMapGridCL>();
                IEnumerable<ClassSubjectMapGridCL> classSubjectFilter = classSubjectQuery;
                if (ftSubjectName.Text != string.Empty)
                {
                    classSubjectFilter = from x in classSubjectFilter where x.subject.ToLower().Contains(ftSubjectName.Text.ToLower()) select x;
                }
                if (ftClass.Text != string.Empty)
                {
                    classSubjectFilter = from x in classSubjectFilter where x.classSection.Split('-')[0].ToLower().Contains(ftClass.Text.ToLower()) select x;
                }
                if (ftSection.Text != string.Empty)
                {
                    classSubjectFilter = from x in classSubjectFilter where x.classSection.Split('-')[1].ToLower().Contains(ftSection.Text.ToLower()) select x;
                }
                foreach (ClassSubjectMapGridCL item in classSubjectFilter)
                {
                    newClassSubject.Add(new ClassSubjectMapGridCL()
                    {
                        classId = item.classId,
                        classSection = item.classSection,
                        id = item.id,
                        noOfSubjects = item.noOfSubjects,
                        sessionId = item.sessionId,
                        subject = item.subject,
                        subjectId = item.subjectId,
                        dateCreated = item.dateCreated,
                        dateModified = item.dateModified,
                        isDeleted = item.isDeleted,
                    });
                }
                ViewState["classSubjects"] = grdClassSubject.DataSource = newClassSubject;
                grdClassSubject.DataBind();
            }
        }
    }
}