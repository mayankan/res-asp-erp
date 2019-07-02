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
    public partial class ManageGradeEntryPrimary : System.Web.UI.Page
    {
        ReportCardEntryBLL reportBLL = new ReportCardEntryBLL();
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
                    else if (role.ToLower() != "su")
                    {
                        Response.Redirect("../UnAuthorized.aspx");
                    }
                    else
                    {
                        sessionId = Convert.ToInt32(Session["sessionId"]);
                        grdGrades.DataSource = reportBLL.viewGradesGridPrimary();
                        grdGrades.DataBind();
                    }
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void btnAddGrades_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageGradeEntryPrimary.aspx");
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            if (ftExaminationName.Text == string.Empty && ftClassSection.Text == string.Empty)
            {
                grdGrades.DataSource = reportBLL.viewGradesGridPrimary();
                grdGrades.DataBind();
            }
            else
            {
                var gradesQuery = reportBLL.viewGradesGridPrimary();
                Collection<GradeEntryGridCL> newGrades = new Collection<GradeEntryGridCL>();
                IEnumerable<GradeEntryGridCL> marksFilter = gradesQuery;
                if (ftExaminationName.Text != string.Empty)
                {
                    marksFilter = from x in marksFilter where x.examinationName.ToLower().Contains(ftExaminationName.Text.ToLower()) select x;
                }
                if (ftClassSection.Text != string.Empty)
                {
                    marksFilter = from x in marksFilter where x.classSection.ToLower().Contains(ftClassSection.Text.ToLower()) select x;
                }
                foreach (GradeEntryGridCL item in marksFilter)
                {
                    newGrades.Add(new GradeEntryGridCL()
                    {
                        classId = item.classId,
                        classSection = item.classSection,
                        id = item.id,
                        examinationId = item.examinationId,
                        examinationName = item.examinationName,
                        subjectId = item.subjectId,
                        classSubjectId = item.classSubjectId,
                        subjectName = item.subjectName,
                    });
                }
                grdGrades.DataSource = newGrades;
                grdGrades.DataBind();
            }
        }

        protected void grdGrades_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                Collection<GradeEntryGridCL> getGradesCol = reportBLL.viewGradesGridPrimary();
                var param = Expression.Parameter(typeof(GradeEntryGridCL), e.SortExpression);
                var sortExpression = Expression.Lambda<Func<GradeEntryGridCL, object>>(Expression.Convert(Expression.Property(param, e.SortExpression), typeof(object)), param);
                if (GridViewSortDirection == SortDirection.Ascending)
                {
                    grdGrades.DataSource = getGradesCol.AsQueryable<GradeEntryGridCL>().OrderBy(sortExpression);
                    GridViewSortDirection = SortDirection.Descending;
                }
                else
                {
                    grdGrades.DataSource = getGradesCol.AsQueryable<GradeEntryGridCL>().OrderByDescending(sortExpression);
                    GridViewSortDirection = SortDirection.Ascending;
                }
                grdGrades.DataBind();
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

        protected void grdGrades_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                string combinedId = e.CommandArgument.ToString();
                int classId = Convert.ToInt32(combinedId.Split('-').FirstOrDefault());
                int examId = Convert.ToInt32(combinedId.Split('-')[1]);
                int subjectId = Convert.ToInt32(combinedId.Split('-')[2]);
                Response.Redirect("ManageGradeEntryPrimary.aspx?classId=" + classId + "&examId=" + examId + "&subjectId=" + subjectId);
            }
        }

        protected void grdGrades_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdGrades.PageIndex = e.NewPageIndex;
                grdGrades.DataSource = reportBLL.viewGradesGridPrimary();
                grdGrades.DataBind();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }
    }
}