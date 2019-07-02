using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunicationLayer;
using BusinessLogicLayer;
using System.Web.Security;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace RAINBOW_ERP.ReportCard
{
    public partial class Subject : System.Web.UI.Page
    {
        SubjectBLL subjectBLL = new SubjectBLL();
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
                    grdSubject.DataSource = subjectBLL.viewSubjects();
                    ViewState["subjects"] = subjectBLL.viewSubjects();
                    grdSubject.DataBind();
                }
            }
        }

        protected void btnAddSubject_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageSubject.aspx");
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            if (ftSubject.Text == string.Empty)
            {
                grdSubject.DataSource = subjectBLL.viewSubjects();
                ViewState["subjects"] = subjectBLL.viewSubjects();
                grdSubject.DataBind();
            }
            else
            {
                var subjectQuery = subjectBLL.viewSubjects();
                Collection<SubjectCL> newSubject = new Collection<SubjectCL>();
                IEnumerable<SubjectCL> subjectFilter = subjectQuery;
                if (ftSubject.Text != string.Empty)
                {
                    subjectFilter = from x in subjectFilter where x.name.ToLower().Contains(ftSubject.Text.ToLower()) select x;
                }
                foreach (SubjectCL item in subjectFilter)
                {
                    newSubject.Add(new SubjectCL()
                    {
                        name = item.name,
                        dateCreated = item.dateCreated,
                        dateModified = item.dateModified,
                        id = item.id,
                        isDeleted = item.isDeleted,
                        totalClasses = item.totalClasses,
                    });
                }
                grdSubject.DataSource = newSubject;
                ViewState["subjects"] = newSubject;
                grdSubject.DataBind();
            }
        }

        protected void grdSubject_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                //Collection<SubjectCL> getSubjectCol = subjectBLL.viewSubjects();

                var subjectCol = (Collection<SubjectCL>)ViewState["subjects"];
                IEnumerable<SubjectCL> subjectColGet = subjectCol;
                Collection<SubjectCL> newSubjectCol = new Collection<SubjectCL>();

                if (subjectColGet != null)
                {
                    var param = Expression.Parameter(typeof(SubjectCL), e.SortExpression);
                    var sortExpression = Expression.Lambda<Func<SubjectCL, object>>(Expression.Convert(Expression.Property(param, e.SortExpression), typeof(object)), param);
                    if (GridViewSortDirection == SortDirection.Ascending)
                    {
                        subjectColGet = subjectColGet.AsQueryable<SubjectCL>().OrderBy(sortExpression);
                        GridViewSortDirection = SortDirection.Descending;
                    }
                    else
                    {
                        subjectColGet = subjectColGet.AsQueryable<SubjectCL>().OrderByDescending(sortExpression);
                        GridViewSortDirection = SortDirection.Ascending;
                    }
                    foreach (SubjectCL item in subjectColGet)
                    {
                        newSubjectCol.Add(new SubjectCL()
                        {
                            name = item.name,
                            dateCreated = item.dateCreated,
                            dateModified = item.dateModified,
                            id = item.id,
                            isDeleted = item.isDeleted,
                            totalClasses = item.totalClasses,
                        });
                    }
                    grdSubject.DataSource = newSubjectCol;
                    ViewState["subjects"] = newSubjectCol;
                    grdSubject.DataBind();
                }
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

        protected void grdSubject_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdSubject.PageIndex = e.NewPageIndex;
                grdSubject.DataSource = (Collection<SubjectCL>)ViewState["subjects"];
                grdSubject.DataBind();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }

        protected void grdSubject_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int subjectId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("ManageSubject.aspx?subjectId=" + subjectId);
            }
            else if (e.CommandName == "Delete")
            {
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {
                    int subjectId = Convert.ToInt32(e.CommandArgument);
                    subjectBLL.deleteSubject(subjectId);
                    Response.Redirect("Subject.aspx");
                }
                else
                {
                    Response.Redirect("Subject.aspx");
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}