using BusinessLogicLayer;
using CommunicationLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAINBOW_ERP.ReportCard
{
    public partial class MarksEntry : System.Web.UI.Page
    {
        StudentBLL studentBLL = new StudentBLL();
        ReportCardEntryBLL reportBLL = new ReportCardEntryBLL();
        SubjectBLL subjectBLL = new SubjectBLL();
        ExaminationBLL examBLL = new ExaminationBLL();
        ClassBLL classBLL = new ClassBLL();
        SessionBLL sessionBLL = new SessionBLL();
        public int sessionId;
        public int classId = 0;
        public int classSubjectId = 0;
        public int examId = 0;
        public int subjectId = 0;
        public int count = 4;
        public int subjectCount = 0;

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
                        grdStudent.DataSource = FetchControls();
                        grdStudent.DataBind();
                    }
                }
            }
        }

        protected class MarksUpdateEntry
        {
            public int id { get; set; }
            public int admissionNo { get; set; }
            public int studentId { get; set; }
            public string studentName { get; set; }
            public string marks { get; set; }
            public int examinationId { get; set; }
            public int subjectId { get; set; }
            public bool gender { get; set; }
            public int sessionId { get; set; }
            public int classId { get; set; }
            public string studentCategory { get; set; }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            sessionId = Convert.ToInt32(Session["sessionId"]);
            int classId = Convert.ToInt32(ddlClass.SelectedValue);
            int examId = Convert.ToInt32(ddlExamination.SelectedValue);
            int subjectId = Convert.ToInt32(ddlSubjectName.SelectedValue);
            if (Request.QueryString["classId"] != null)
            {
                Collection<MarksEntryCL> marksCol = new Collection<MarksEntryCL>();
                foreach (GridViewRow item in grdStudent.Rows)
                {
                    string txtMarksUpdate = ((TextBox)item.FindControl("txtMarks")).Text;
                    if (txtMarksUpdate == string.Empty)
                    {
                        continue;
                    }
                    else
                    {
                        int studentId = Convert.ToInt32(grdStudent.DataKeys[item.RowIndex].Value);
                        marksCol.Add(new MarksEntryCL()
                        {
                            studentId = studentId,
                            marks = txtMarksUpdate,
                            sessionId = sessionId,
                        });
                    }
                }
                reportBLL.updateMarksFromSubjectExam(classId, subjectId, examId, marksCol);
            }
            else
            {
                bool result= reportBLL.CheckMarksEntry(classId, examId, subjectId);
                if (result==true)
                {
                    Collection<MarksEntryCL> marksCol = new Collection<MarksEntryCL>();
                    foreach (GridViewRow item in grdStudent.Rows)
                    {
                        string txtMarksUpdate = ((TextBox)item.FindControl("txtMarks")).Text;
                        if (txtMarksUpdate == string.Empty)
                        {
                            continue;
                        }
                        else
                        {
                            int studentId = Convert.ToInt32(grdStudent.DataKeys[item.RowIndex].Value);
                            marksCol.Add(new MarksEntryCL()
                            {
                                studentId = studentId,
                                marks = txtMarksUpdate,
                                sessionId = sessionId,

                            });
                        }
                    }
                    reportBLL.addMarksFromSubjectExam(classId, subjectId, examId, marksCol);
                    Response.Redirect("MarksEntry.aspx?classId=" + classId + "&examId=" + examId + "&subjectId=" + subjectId); 
                }
                else
                {
                    lblUpdate.Text = "Entry is already done for this Subject.";
                    lblUpdate1.Text = "Entry is already done for this Subject.";
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            classId = Convert.ToInt32(Request.QueryString["classId"]);
            examId = Convert.ToInt32(Request.QueryString["examId"]);
            subjectId = Convert.ToInt32(Request.QueryString["subjectId"]);
            reportBLL.deleteMarksFromSubjectExam(classId, subjectId, examId);
            Response.Redirect("index.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void grdStudent_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                Collection<StudentCL> getMarksCol = studentBLL.viewStudentsByClassId(classId);
                var param = Expression.Parameter(typeof(StudentCL), e.SortExpression);
                var sortExpression = Expression.Lambda<Func<StudentCL, object>>(Expression.Convert(Expression.Property(param, e.SortExpression), typeof(object)), param);
                if (GridViewSortDirection == SortDirection.Ascending)
                {
                    grdStudent.DataSource = getMarksCol.AsQueryable<StudentCL>().OrderBy(sortExpression);
                    GridViewSortDirection = SortDirection.Descending;
                }
                else
                {
                    grdStudent.DataSource = getMarksCol.AsQueryable<StudentCL>().OrderByDescending(sortExpression);
                    GridViewSortDirection = SortDirection.Ascending;
                }
                grdStudent.DataBind();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }

        public SortDirection GridViewSortDirection
        {
            get
            {
                if (ViewState["sortDirection"] == null)
                    ViewState["sortDirection"] = SortDirection.Ascending;

                return (SortDirection)ViewState["sortDirection"];
            }
            set { ViewState["sortDirection"] = value; }
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            classId = Convert.ToInt32(ddlClass.SelectedValue);
            Collection<ExaminationCL> examCL = examBLL.viewExaminationsByClassId(classId);
            Collection<StudentCL> studentCL = studentBLL.viewStudentsByClassId(classId);
            Collection<SubjectCL> subjectCL = subjectBLL.viewSubjectMarksByClassId(classId);
            ddlExamination.DataSource = examCL;
            ddlExamination.DataTextField = "name";
            ddlExamination.DataValueField = "id";
            ddlExamination.DataBind();
            if (examCL == null)
            {
                //Enter Dropdown Clear Query.
            }
            ddlExamination.Items.Insert(0, new ListItem("Select", "-1"));
            ddlSubjectName.DataSource = subjectCL;
            ddlSubjectName.DataValueField = "id";
            ddlSubjectName.DataTextField = "name";
            ddlSubjectName.DataBind();
            if (subjectCL == null)
            {
                //Enter Dropdown Clear Query.
            }
            ddlSubjectName.Items.Insert(0, new ListItem("Select", "-1"));
            grdStudent.DataSource = studentCL;
            grdStudent.DataBind();
        }

        protected void grdStudent_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Request.QueryString["classId"] != null)
                {
                    //Update Marks Query
                    classId = Convert.ToInt32(Request.QueryString["classId"]);
                    examId = Convert.ToInt32(Request.QueryString["examId"]);
                    subjectId = Convert.ToInt32(Request.QueryString["subjectId"]);
                    //Collection<SubjectCL> subjectCol = subjectBLL.viewSubjectByClassId(classId);
                    //TextBox txtMarks = new TextBox();
                    //txtMarks.ID = subjectCol[subjectCount].id.ToString();
                    //txtMarks.Text = (e.Row.DataItem as DataRowView).Row[subjectCol[subjectCount].name].ToString();
                    //e.Row.Cells[count].Controls.Add(txtMarks);
                    //Collection<StudentCL> studentCol = studentBLL.viewStudentsByClassId(classId);
                    TextBox txtMarksUpdate = e.Row.FindControl("txtMarks") as TextBox;
                    int studentId = ((StudentCL)e.Row.DataItem).id;
                    string marksUpdate = reportBLL.viewMarksByStudentSubjectExam(studentId, subjectId, examId);
                    txtMarksUpdate.Text = marksUpdate;
                    //count++;
                    //subjectCount++;
                }
                else
                {
                    //Add Marks Query
                    //Collection<SubjectCL> subjectCol = subjectBLL.viewSubjectByClassId(Convert.ToInt32(ddlClass.SelectedValue));
                    //TextBox txtMarks = new TextBox();
                    //txtMarks.ID = subjectCol[subjectCount].id.ToString();
                    //txtMarks.Text = subjectCol[subjectCount].name.ToString();
                    //e.Row.Cells[count].Controls.Add(txtMarks);
                    //count++;
                    //subjectCount++;
                }
            }
        }

        protected Collection<StudentCL> FetchControls()
        {
            if (Request.QueryString["classId"] != null)
            {
                classId = Convert.ToInt32(Request.QueryString["classId"]);
                Collection<SubjectCL> subjectCol = subjectBLL.viewSubjectMarksByClassId(classId);
                Collection<ClassCL> classCol = classBLL.viewClasses(classBLL.getSessionIdByClassId(classId));
                examId = Convert.ToInt32(Request.QueryString["examId"]);
                subjectId = Convert.ToInt32(Request.QueryString["subjectId"]);
                Collection<StudentCL> studentCol = studentBLL.viewStudentsByClassId(classId);
                Collection<ExaminationCL> examCL = examBLL.viewExaminationsByClassId(classId);
                Collection<MarksUpdateEntry> marksUpdateEntry = new Collection<MarksUpdateEntry>();
                lblHeading.Text = "Update Marks Entry";
                btnSubmit.Text = "Update";
                grdStudent.DataSource = studentCol;
                ddlExamination.DataSource = examCL;
                ddlExamination.DataValueField = "id";
                ddlExamination.DataTextField = "name";
                ddlExamination.DataBind();
                ddlExamination.SelectedValue = examId.ToString();
                ddlSubjectName.DataSource = subjectCol;
                ddlSubjectName.DataValueField = "id";
                ddlSubjectName.DataTextField = "name";
                ddlSubjectName.DataBind();
                ddlSubjectName.SelectedValue = subjectId.ToString();
                ddlClass.DataSource = classCol;
                ddlClass.DataValueField = "id";
                ddlClass.DataTextField = "classSection";
                ddlClass.DataBind();
                ddlClass.SelectedValue = classId.ToString();
                ddlClass.Enabled = false;
                ddlExamination.Enabled = false;
                ddlSubjectName.Enabled = false;
                return studentCol;
            }
            else
            {
                sessionId = Convert.ToInt32(Session["sessionId"]);
                lblHeading.Text = "Add Marks Entry";
                btnSubmit.Text = "Submit";
                btnDelete.Visible = false;
                Collection<ClassCL> classCol = classBLL.viewClasses(sessionId);
                ddlClass.DataSource = classCol;
                ddlClass.DataValueField = "id";
                ddlClass.DataTextField = "classSection";
                ddlClass.DataBind();
                ddlClass.Items.Insert(0, new ListItem("Select", "-1"));
                classId = Convert.ToInt32(ddlClass.SelectedValue);
                Collection<StudentCL> studentCol = studentBLL.viewStudentsByClassId(classId);
                Collection<MarksUpdateEntry> studentGrid = new Collection<MarksUpdateEntry>();
                grdStudent.DataSource = studentCol;
                return studentCol;
            }
        }
    }
}