using BusinessLogicLayer;
using CommunicationLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAINBOW_ERP.ReportCard
{
    public partial class ManageMiscellaneousEntry : System.Web.UI.Page
    {
        ClassBLL classBLL = new ClassBLL();
        ExaminationBLL examBLL = new ExaminationBLL();
        StudentBLL studentBLL = new StudentBLL();
        ReportCardEntryBLL reportBLL = new ReportCardEntryBLL();
        SessionBLL sessionBLL = new SessionBLL();
        public int sessionId;
        public int classId = 0;
        public int examId = 0;
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

        protected Collection<StudentCL> FetchControls()
        {
            if (Request.QueryString["classId"] != null)
            {
                classId = Convert.ToInt32(Request.QueryString["classId"]);
                Collection<ClassCL> classCol = classBLL.viewClasses(Convert.ToInt32(Session["sessionId"]));
                examId = Convert.ToInt32(Request.QueryString["examId"]);
                Collection<StudentCL> studentCol = studentBLL.viewStudentsByClassId(classId);
                Collection<ExaminationCL> examCL = examBLL.viewExaminationsByClassId(classId);
                lblHeading.Text = "Update Miscellaneous Entry";
                btnSubmit.Text = "Update";
                grdStudent.DataSource = studentCol;
                ddlExamination.DataSource = examCL;
                ddlExamination.DataValueField = "id";
                ddlExamination.DataTextField = "name";
                ddlExamination.DataBind();
                ddlExamination.SelectedValue = examId.ToString();
                ddlClass.DataSource = classCol;
                ddlClass.DataValueField = "id";
                ddlClass.DataTextField = "classSection";
                ddlClass.DataBind();
                ddlClass.SelectedValue = classId.ToString();
                ddlClass.Enabled = false;
                ddlExamination.Enabled = false;
                return studentCol;
            }
            else
            {
                sessionId = Convert.ToInt32(Session["sessionId"]);
                lblHeading.Text = "Add Miscellaneous Entry";
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
                grdStudent.DataSource = studentCol;
                return studentCol;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("MiscellaneousEntry.aspx");
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            classId = Convert.ToInt32(ddlClass.SelectedValue);
            Collection<ExaminationCL> examCL = examBLL.viewExaminationsByClassId(classId);
            Collection<StudentCL> studentCL = studentBLL.viewStudentsByClassId(classId);
            ddlExamination.DataSource = examCL;
            ddlExamination.DataTextField = "name";
            ddlExamination.DataValueField = "id";
            ddlExamination.DataBind();
            if (examCL == null)
            {
                //Enter Dropdown Clear Query.
            }
            ddlExamination.Items.Insert(0, new ListItem("Select", "-1"));
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
                    TextBox txtRemarksUpdate = e.Row.FindControl("txtRemarks") as TextBox;
                    TextBox txtAttendanceUpdate = e.Row.FindControl("txtAttendance") as TextBox;
                    int studentId = ((StudentCL)e.Row.DataItem).id;
                    MiscEntryCL miscUpdate = reportBLL.viewMiscByStudentId(studentId, examId);
                    if (miscUpdate.remarks == "NULL")
                    {
                        txtRemarksUpdate.Text = string.Empty;
                    }
                    else
                    {
                        txtRemarksUpdate.Text = miscUpdate.remarks;
                    }
                    if (miscUpdate.attendance == "NULL")
                    {
                        txtAttendanceUpdate.Text = string.Empty;
                    }
                    else
                    {
                        txtAttendanceUpdate.Text = miscUpdate.attendance;
                    }
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            classId = Convert.ToInt32(Request.QueryString["classId"]);
            examId = Convert.ToInt32(Request.QueryString["examId"]);
            reportBLL.deleteMiscFromClassExam(classId, examId);
            Response.Redirect("MiscellaneousEntry.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            sessionId = Convert.ToInt32(Session["sessionId"]);
            int classId = Convert.ToInt32(ddlClass.SelectedValue);
            int examId = Convert.ToInt32(ddlExamination.SelectedValue);
            if (Request.QueryString["classId"] != null)
            {
                Collection<MiscEntryCL> miscCol = new Collection<MiscEntryCL>();
                foreach (GridViewRow item in grdStudent.Rows)
                {
                    string txtRemarksUpdate = ((TextBox)item.FindControl("txtRemarks")).Text;
                    string txtAttendanceUpdate = ((TextBox)item.FindControl("txtAttendance")).Text;
                    if (txtRemarksUpdate == string.Empty && txtAttendanceUpdate == string.Empty)
                    {
                        continue;
                    }
                    else if (txtRemarksUpdate == string.Empty)
                    {
                        int studentId = Convert.ToInt32(grdStudent.DataKeys[item.RowIndex].Value);
                        miscCol.Add(new MiscEntryCL()
                        {
                            studentId = studentId,
                            remarks = "NULL",
                            attendance = txtAttendanceUpdate,
                            sessionId = sessionId,
                        });
                    }
                    else if (txtAttendanceUpdate == string.Empty)
                    {
                        int studentId = Convert.ToInt32(grdStudent.DataKeys[item.RowIndex].Value);
                        miscCol.Add(new MiscEntryCL()
                        {
                            studentId = studentId,
                            remarks = txtRemarksUpdate,
                            attendance = "NULL",
                            sessionId = sessionId,
                        });
                    }
                    else
                    {
                        int studentId = Convert.ToInt32(grdStudent.DataKeys[item.RowIndex].Value);
                        miscCol.Add(new MiscEntryCL()
                        {
                            studentId = studentId,
                            remarks = txtRemarksUpdate,
                            attendance = txtAttendanceUpdate,
                            sessionId = sessionId,
                        });
                    }
                }
                reportBLL.updateMiscFromClassExam(classId, examId, miscCol);
            }
            else
            {
                sessionId = Convert.ToInt32(Session["sessionId"]);
                bool result = reportBLL.CheckMiscEntry(classId, examId);
                if (result == true)
                {
                    Collection<MiscEntryCL> miscCol = new Collection<MiscEntryCL>();
                    foreach (GridViewRow item in grdStudent.Rows)
                    {
                        string txtRemarksUpdate = ((TextBox)item.FindControl("txtRemarks")).Text;
                        string txtAttendanceUpdate = ((TextBox)item.FindControl("txtAttendance")).Text;
                        if (txtRemarksUpdate == string.Empty && txtRemarksUpdate == string.Empty)
                        {
                            continue;
                        }
                        else if (txtRemarksUpdate == string.Empty)
                        {
                            int studentId = Convert.ToInt32(grdStudent.DataKeys[item.RowIndex].Value);
                            miscCol.Add(new MiscEntryCL()
                            {
                                studentId = studentId,
                                remarks = "NULL",
                                attendance = txtAttendanceUpdate,
                                sessionId = sessionId,
                            });
                        }
                        else if (txtAttendanceUpdate == string.Empty)
                        {
                            int studentId = Convert.ToInt32(grdStudent.DataKeys[item.RowIndex].Value);
                            miscCol.Add(new MiscEntryCL()
                            {
                                studentId = studentId,
                                remarks = txtRemarksUpdate,
                                attendance = "NULL",
                                sessionId = sessionId,
                            });
                        }
                        else
                        {
                            int studentId = Convert.ToInt32(grdStudent.DataKeys[item.RowIndex].Value);
                            miscCol.Add(new MiscEntryCL()
                            {
                                studentId = studentId,
                                remarks = txtRemarksUpdate,
                                attendance = txtAttendanceUpdate,
                                sessionId = sessionId,
                                classId = classId,
                            });
                        }
                    }
                    reportBLL.addMiscFromClassExam(classId, examId, miscCol);
                    Response.Redirect("ManageMiscellaneousEntry.aspx?classId=" + classId + "&examId=" + examId);
                }
                else
                {
                    lblUpdate.Text = "Entry is already done for this Class.";
                    lblUpdate1.Text = "Entry is already done for this Class.";
                }
            }
        }
    }
}