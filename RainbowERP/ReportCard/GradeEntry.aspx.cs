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
    public partial class ManageGradeEntry : System.Web.UI.Page
    {
        ReportCardEntryBLL reportBLL = new ReportCardEntryBLL();
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
                        SessionCL sessionCL = sessionBLL.addorCheckSession();
                        Session["sessionId"] = sessionCL.id;
                    }
                    else
                    {
                        sessionId = Convert.ToInt32(Session["sessionId"]);
                        ViewState["grades"] = grdGrades.DataSource = reportBLL.viewGradesGrid(sessionId);
                        grdGrades.DataBind();
                    }
                }
            }
        }

        protected void btnAddGrades_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageGradeEntry.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void grdGrades_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdGrades.PageIndex = e.NewPageIndex;
                grdGrades.DataSource = (Collection<GradeEntryGridCL>)ViewState["grades"];
                grdGrades.DataBind();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }

        protected void grdGrades_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                string combinedId = e.CommandArgument.ToString();
                int classId = Convert.ToInt32(combinedId.Split('-').FirstOrDefault());
                int examId = Convert.ToInt32(combinedId.Split('-')[1]);
                int subjectId = Convert.ToInt32(combinedId.Split('-')[2]);
                Response.Redirect("ManageGradeEntry.aspx?classId=" + classId + "&examId=" + examId + "&subjectId=" + subjectId);
            }
        }

        protected void grdGrades_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                var gradesCol = (Collection<GradeEntryGridCL>)ViewState["grades"];
                IEnumerable<GradeEntryGridCL> gradeColGet = gradesCol;
                Collection<GradeEntryGridCL> newGradeCol = new Collection<GradeEntryGridCL>();

                //Collection<GradeEntryGridCL> getGradesCol = reportBLL.viewGradesGrid();

                if (gradeColGet != null)
                {
                    var param = Expression.Parameter(typeof(MarksEntryGridCL), e.SortExpression);
                    var sortExpression = Expression.Lambda<Func<GradeEntryGridCL, object>>(Expression.Convert(Expression.Property(param, e.SortExpression), typeof(object)), param);
                    if (GridViewSortDirection == SortDirection.Ascending)
                    {
                        gradeColGet = gradeColGet.AsQueryable<GradeEntryGridCL>().OrderBy(sortExpression);
                        GridViewSortDirection = SortDirection.Descending;
                    }
                    else
                    {
                        gradeColGet = gradeColGet.AsQueryable<GradeEntryGridCL>().OrderByDescending(sortExpression);
                        GridViewSortDirection = SortDirection.Ascending;
                    }
                    foreach (GradeEntryGridCL item in gradeColGet)
                    {
                        newGradeCol.Add(new GradeEntryGridCL()
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
                }
                ViewState["grades"] = grdGrades.DataSource = newGradeCol;
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

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            if (ftExaminationName.Text == string.Empty && ftClass.Text == string.Empty && ftSection.Text == string.Empty)
            {
                sessionId = Convert.ToInt32(Session["sessionId"]);
                ViewState["grades"] = grdGrades.DataSource = reportBLL.viewGradesGrid(sessionId);
                grdGrades.DataBind();
            }
            else
            {
                sessionId = Convert.ToInt32(Session["sessionId"]);
                var gradesQuery = reportBLL.viewGradesGrid(sessionId);
                Collection<GradeEntryGridCL> newGrades = new Collection<GradeEntryGridCL>();
                IEnumerable<GradeEntryGridCL> marksFilter = gradesQuery;
                if (ftExaminationName.Text != string.Empty)
                {
                    marksFilter = from x in marksFilter where x.examinationName.ToLower().Contains(ftExaminationName.Text.ToLower()) select x;
                }
                if (ftClass.Text != string.Empty)
                {
                    marksFilter = from x in marksFilter where x.classSection.Split('-')[0].ToLower().Contains(ftClass.Text.ToLower()) select x;
                }
                if (ftSection.Text != string.Empty)
                {
                    marksFilter = from x in marksFilter where x.classSection.Split('-')[1].ToLower().Contains(ftSection.Text.ToLower()) select x;
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
                ViewState["grades"] = grdGrades.DataSource = newGrades;
                grdGrades.DataBind();
            }
        }
    }
}