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
    public partial class index : System.Web.UI.Page
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
                        ViewState["marks"] = grdMarks.DataSource = reportBLL.viewMarksGrid(sessionId);
                        grdMarks.DataBind();
                    }
                }
            }
        }

        protected void btnAddMarks_Click(object sender, EventArgs e)
        {
            Response.Redirect("MarksEntry.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void grdMarks_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                //Collection<MarksEntryGridCL> getMarksCol = reportBLL.viewMarksGrid();

                var marksCol = (Collection<MarksEntryGridCL>)ViewState["marks"];
                IEnumerable<MarksEntryGridCL> classmarksColGet = marksCol;
                Collection<MarksEntryGridCL> newmarksCol = new Collection<MarksEntryGridCL>();

                if (classmarksColGet != null)
                {
                    var param = Expression.Parameter(typeof(MarksEntryGridCL), e.SortExpression);
                    var sortExpression = Expression.Lambda<Func<MarksEntryGridCL, object>>(Expression.Convert(Expression.Property(param, e.SortExpression), typeof(object)), param);
                    if (GridViewSortDirection == SortDirection.Ascending)
                    {
                        classmarksColGet = classmarksColGet.AsQueryable<MarksEntryGridCL>().OrderBy(sortExpression);
                        GridViewSortDirection = SortDirection.Descending;
                    }
                    else
                    {
                        classmarksColGet = classmarksColGet.AsQueryable<MarksEntryGridCL>().OrderByDescending(sortExpression);
                        GridViewSortDirection = SortDirection.Ascending;
                    }
                    foreach (MarksEntryGridCL item in classmarksColGet)
                    {
                        newmarksCol.Add(new MarksEntryGridCL()
                        {
                            classId = item.classId,
                            classSection = item.classSection,
                            id = item.id,
                            examinationId = item.examinationId,
                            examinationName = item.examinationName,
                            subjectId = item.subjectId,
                            subjectName = item.subjectName,
                            classSubjectId = item.classSubjectId,
                        });
                    }
                }
                ViewState["marks"] = grdMarks.DataSource = newmarksCol;
                grdMarks.DataBind();
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

        protected void grdMarks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                string combinedId = e.CommandArgument.ToString();
                int classId = Convert.ToInt32(combinedId.Split('-').FirstOrDefault());
                int examId = Convert.ToInt32(combinedId.Split('-')[1]);
                int subjectId = Convert.ToInt32(combinedId.Split('-')[2]);
                Response.Redirect("MarksEntry.aspx?classId=" + classId + "&examId=" + examId + "&subjectId=" + subjectId);
            }
        }

        protected void grdMarks_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdMarks.PageIndex = e.NewPageIndex;
                grdMarks.DataSource = (Collection<MarksEntryGridCL>)ViewState["marks"];
                grdMarks.DataBind();
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
                ViewState["marks"] = grdMarks.DataSource = reportBLL.viewMarksGrid(sessionId);
                grdMarks.DataBind();
            }
            else
            {
                sessionId = Convert.ToInt32(Session["sessionId"]);
                var marksQuery = reportBLL.viewMarksGrid(sessionId);
                Collection<MarksEntryGridCL> newMarks = new Collection<MarksEntryGridCL>();
                IEnumerable<MarksEntryGridCL> marksFilter = marksQuery;
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
                foreach (MarksEntryGridCL item in marksFilter)
                {
                    newMarks.Add(new MarksEntryGridCL()
                    {
                        classId = item.classId,
                        classSection = item.classSection,
                        id = item.id,
                        examinationId = item.examinationId,
                        examinationName = item.examinationName,
                        subjectId = item.subjectId,
                        subjectName = item.subjectName,
                        classSubjectId = item.classSubjectId,
                    });
                }
                ViewState["marks"] = grdMarks.DataSource = newMarks;
                grdMarks.DataBind();
            }
        }
    }
}