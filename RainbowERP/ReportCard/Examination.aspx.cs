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
    public partial class Examination : System.Web.UI.Page
    {

        ExaminationBLL examinationBLL = new ExaminationBLL();
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
                    if (Session["sessionId"] == null)
                    {
                        Response.Redirect("index.aspx");
                    }
                    else
                    {
                        FormsAuthenticationTicket ticket = (FormsAuthentication.Decrypt(Session["auth"].ToString()));
                        string userId = ticket.UserData.Split(';')[0];
                        string role = ticket.UserData.Split(';')[1];
                        if (Session["sessionId"] == null)
                        {
                            SessionCL sessionCL = sessionBLL.addorCheckSession();
                            Session["sessionId"] = sessionCL.id;
                        }
                        else if (role.ToLower() == "teacher" || role.ToLower() == "attendanceo")
                        {
                            Response.Redirect("../UnAuthorized.aspx");
                        }
                        else
                        {
                            sessionId = Convert.ToInt32(Session["sessionId"]);
                            ViewState["examination"] = grdExamination.DataSource = examinationBLL.viewExaminations(sessionId);
                            grdExamination.DataBind();
                        }
                    }
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void btnAddExamination_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageExamination.aspx");
        }

        protected void grdExamination_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                //Collection<ExaminationCL> getExaminationCol = examinationBLL.viewExaminations();

                var examCol = (Collection<ExaminationCL>)ViewState["examination"];
                IEnumerable<ExaminationCL> examColGet = examCol;
                Collection<ExaminationCL> newExamCol = new Collection<ExaminationCL>();

                if (examColGet != null)
                {
                    var param = Expression.Parameter(typeof(ExaminationCL), e.SortExpression);
                    var sortExpression = Expression.Lambda<Func<ExaminationCL, object>>(Expression.Convert(Expression.Property(param, e.SortExpression), typeof(object)), param);
                    if (GridViewSortDirection == SortDirection.Ascending)
                    {
                        examColGet = examColGet.AsQueryable<ExaminationCL>().OrderBy(sortExpression);
                        GridViewSortDirection = SortDirection.Descending;
                    }
                    else
                    {
                        examColGet = examColGet.AsQueryable<ExaminationCL>().OrderByDescending(sortExpression);
                        GridViewSortDirection = SortDirection.Ascending;
                    }
                    foreach (ExaminationCL item in examColGet)
                    {
                        newExamCol.Add(new ExaminationCL()
                        {
                            name = item.name,
                            classSection = item.classSection,
                            classId = item.classId,
                            dateCreated = item.dateCreated,
                            dateModified = item.dateModified,
                            id = item.id,
                            isDeleted = item.isDeleted,
                        });
                    }
                    ViewState["examination"] = grdExamination.DataSource = newExamCol;
                    grdExamination.DataBind();
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

        protected void grdExamination_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int examId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("ManageExamination.aspx?examinationId=" + examId);
            }
            //else if (e.CommandName == "Delete")
            //{
            //    string confirmValue = Request.Form["confirm_value"];
            //    if (confirmValue == "Yes")
            //    {
            //        int examId = Convert.ToInt32(e.CommandArgument);
            //        examinationBLL.deleteExamination(examId);
            //        Response.Redirect("Examination.aspx");
            //    }
            //    else
            //    {
            //        Response.Redirect("Examination.aspx");
            //    }
            //}
        }

        protected void grdExamination_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdExamination.PageIndex = e.NewPageIndex;
                grdExamination.DataSource = (Collection<ExaminationCL>)ViewState["examination"];
                grdExamination.DataBind();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            if (ftExaminationName.Text == string.Empty && ftClass.Text == string.Empty && ftSection.Text == string.Empty)
            {
                sessionId = Convert.ToInt32(Session["sessionId"]);
                ViewState["examination"] = grdExamination.DataSource = examinationBLL.viewExaminations(sessionId);
                grdExamination.DataBind();
            }
            else
            {
                sessionId = Convert.ToInt32(Session["sessionId"]);
                var examQuery = examinationBLL.viewExaminations(sessionId);
                Collection<ExaminationCL> newExamination = new Collection<ExaminationCL>();
                IEnumerable<ExaminationCL> examFilter = examQuery;
                if (ftExaminationName.Text != string.Empty)
                {
                    examFilter = from x in examFilter where x.name.ToLower().Contains(ftExaminationName.Text.ToLower()) select x;
                }
                if (ftClass.Text != string.Empty)
                {
                    examFilter = from x in examFilter where x.classSection.Split('-')[0].ToLower().Contains(ftClass.Text.ToLower()) select x;
                }
                if (ftSection.Text != string.Empty)
                {
                    examFilter = from x in examFilter where x.classSection.Split('-')[1].ToLower().Contains(ftSection.Text.ToLower()) select x;
                }
                foreach (ExaminationCL item in examFilter)
                {
                    newExamination.Add(new ExaminationCL()
                    {
                        name = item.name,
                        classId = item.classId,
                        classSection = item.classSection,
                        dateCreated = item.dateCreated,
                        dateModified = item.dateModified,
                        id = item.id,
                        isDeleted = item.isDeleted,
                    });
                }
                ViewState["examination"] = grdExamination.DataSource = newExamination;
                grdExamination.DataBind();
            }
        }
    }
}