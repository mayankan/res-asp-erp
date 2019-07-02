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
    public partial class MiscellaneousEntry : System.Web.UI.Page
    {
        ReportCardEntryBLL reportBLL = new ReportCardEntryBLL();
        public int sessionId;
        SessionBLL sessionBLL = new SessionBLL();
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
                        ViewState["misc"] = grdMisc.DataSource = reportBLL.viewMiscellaneous(sessionId);
                        grdMisc.DataBind();
                    }
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void btnAddMisc_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageMiscellaneousEntry.aspx");
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            if (ftExaminationName.Text == string.Empty && ftClass.Text == string.Empty && ftSection.Text != string.Empty)
            {
                sessionId = Convert.ToInt32(Session["sessionId"]);
                ViewState["misc"] = grdMisc.DataSource = reportBLL.viewMiscellaneous(sessionId);
                grdMisc.DataBind();
            }
            else
            {
                sessionId = Convert.ToInt32(Session["sessionId"]);
                var miscQuery = reportBLL.viewMiscellaneous(sessionId);
                Collection<MiscEntryGridCL> newMisc = new Collection<MiscEntryGridCL>();
                IEnumerable<MiscEntryGridCL> miscFilter = miscQuery;
                if (ftExaminationName.Text != string.Empty)
                {
                    miscFilter = from x in miscFilter where x.examinationName.ToLower().Contains(ftExaminationName.Text.ToLower()) select x;
                }
                if (ftClass.Text != string.Empty)
                {
                    miscFilter = from x in miscFilter where x.classSection.Split('-')[0].ToLower().Contains(ftClass.Text.ToLower()) select x;
                }
                if (ftSection.Text != string.Empty)
                {
                    miscFilter = from x in miscFilter where x.classSection.Split('-')[1].ToLower().Contains(ftSection.Text.ToLower()) select x;
                }
                foreach (MiscEntryGridCL item in miscFilter)
                {
                    newMisc.Add(new MiscEntryGridCL()
                    {
                        classId = item.classId,
                        classSection = item.classSection,
                        id = item.id,
                        examinationId = item.examinationId,
                        examinationName = item.examinationName,
                        subjectId = item.subjectId,
                        subjectName = item.subjectName,
                        classSubjectId = item.classSubjectId,
                        attendance = item.attendance,
                        remarks = item.remarks,

                    });
                }
                ViewState["misc"] = grdMisc.DataSource = newMisc;
                grdMisc.DataBind();
            }
        }

        protected void grdMisc_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                ///Collection<MiscEntryGridCL> getMiscCol = reportBLL.viewMiscellaneous();

                var miscCol = (Collection<MiscEntryGridCL>)ViewState["misc"];
                IEnumerable<MiscEntryGridCL> miscColGet = miscCol;
                Collection<MiscEntryGridCL> newMiscCol = new Collection<MiscEntryGridCL>();

                if (miscColGet != null)
                {
                    var param = Expression.Parameter(typeof(MiscEntryGridCL), e.SortExpression);
                    var sortExpression = Expression.Lambda<Func<MiscEntryGridCL, object>>(Expression.Convert(Expression.Property(param, e.SortExpression), typeof(object)), param);
                    if (GridViewSortDirection == SortDirection.Ascending)
                    {
                        miscColGet = miscColGet.AsQueryable<MiscEntryGridCL>().OrderBy(sortExpression);
                        GridViewSortDirection = SortDirection.Descending;
                    }
                    else
                    {
                        miscColGet = miscColGet.AsQueryable<MiscEntryGridCL>().OrderByDescending(sortExpression);
                        GridViewSortDirection = SortDirection.Ascending;
                    }
                    foreach (MiscEntryGridCL item in miscColGet)
                    {
                        newMiscCol.Add(new MiscEntryGridCL()
                        {
                            classId = item.classId,
                            classSection = item.classSection,
                            id = item.id,
                            examinationId = item.examinationId,
                            examinationName = item.examinationName,
                            subjectId = item.subjectId,
                            subjectName = item.subjectName,
                            classSubjectId = item.classSubjectId,
                            attendance = item.attendance,
                            remarks = item.remarks,

                        });
                    }
                }
                ViewState["misc"] = grdMisc.DataSource = newMiscCol;
                grdMisc.DataBind();
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

        protected void grdMisc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                string combinedId = e.CommandArgument.ToString();
                int classId = Convert.ToInt32(combinedId.Split('-').FirstOrDefault());
                int examId = Convert.ToInt32(combinedId.Split('-')[1]);
                Response.Redirect("ManageMiscellaneousEntry.aspx?classId=" + classId + "&examId=" + examId);
            }
        }

        protected void grdMisc_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdMisc.PageIndex = e.NewPageIndex;

                grdMisc.DataSource = (Collection<MiscEntryGridCL>)ViewState["misc"];
                grdMisc.DataBind();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }
    }
}