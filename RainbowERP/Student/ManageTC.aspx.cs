using BusinessLogicLayer;
using CommunicationLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAINBOW_ERP.Student
{
    public partial class ManageTC : System.Web.UI.Page
    {
        SessionBLL sessionBLL = new SessionBLL();
        StudentBLL studentBLL = new StudentBLL();
        ClassBLL classBLL = new ClassBLL();
        int sessionId;
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
                        SessionCL sessionCL = sessionBLL.addorCheckSession();
                        Session["sessionId"] = sessionCL.id;
                    }
                    else if (role.ToLower() == "teacher" || role.ToLower() == "attendanceo")
                    {
                        Response.Redirect("../UnAuthorized.aspx");
                    }
                    else
                    {
                        FetchControls();
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["studentId"] != null)
            {
                UpdateData();
            }
            else
            {
                AddData();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("TC.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DateTime dateHosting = DateTime.UtcNow;
            TimeZoneInfo indianZoneId = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime dateNow = TimeZoneInfo.ConvertTimeFromUtc(dateHosting, indianZoneId);
            StudentCL studentCL = new StudentCL();
            studentCL.id = Convert.ToInt32(Request.QueryString["studentId"]);
            studentCL.isDeleted = false;
            studentCL.dateDeleted = null;
            studentCL.miscellaneous1Link = null;
            StudentCL deletedStudent = studentBLL.updateTCStudent(studentCL);
            Response.Redirect("TC.aspx");
        }

        protected void FetchControls()
        {
            sessionId = Convert.ToInt32(Session["sessionId"]);
            Collection<ClassCL> classCol = classBLL.viewClasses(sessionId);
            if (Request.QueryString["studentId"] != null)
            {
                int studentId = Convert.ToInt32(Request.QueryString["studentId"]);
                StudentCL studentCL = studentBLL.viewStudentById(studentId, sessionId);
                lblHeading.Text = "Update/Remove Transfer Certificate";
                ddlClass.DataSource = classCol;
                ddlClass.DataValueField = "id";
                ddlClass.DataTextField = "classSection";
                ddlClass.DataBind();
                ddlClass.SelectedIndex = studentCL.classId;
                txtAddress.Text = studentCL.address;
                txtAdmissionNo.Text = studentCL.admissionNo.ToString();
                txtDateUpdated.Text = studentCL.dateModified.ToString("dd MMMM yyyy");
                txtDOB.Text = studentCL.dob.ToString("yyyy-MM-dd");
                txtEmailAddress.Text = studentCL.emailAddress;
                txtFatherName.Text = studentCL.fatherName;
                txtMobileNumber.Text = studentCL.fatherMobileNumber;
                DateTime DateOfIssue = Convert.ToDateTime(studentCL.dateDeleted);
                txtDateofIssue.Text = DateOfIssue.ToString("yyyy-MM-dd");
                txtStudentName.Text = studentCL.studentName;
                linkTC.Visible = true;
                linkTC.Text = studentCL.admissionNo + " - Issued TC on " + DateOfIssue.ToString("dd MMMM yy");
                linkTC.NavigateUrl = studentCL.deletedTransferCertificate;
            }
            else
            {
                lblHeading.Text = "Add Transfer Certificate";
                ddlClass.DataSource = classCol;
                ddlClass.DataValueField = "id";
                ddlClass.DataTextField = "classSection";
                ddlClass.DataBind();
                txtAdmissionNo.ReadOnly = false;
                linkTC.Visible = false;
                btnDelete.Visible = false;
                btnUpdate.Text = "Submit";
            }
        }

        protected void AddData()
        {
            DateTime dateHosting = DateTime.UtcNow;
            TimeZoneInfo indianZoneId = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime dateNow = TimeZoneInfo.ConvertTimeFromUtc(dateHosting, indianZoneId);
            StudentCL studentCL = new StudentCL();
            StudentCL getStudent = studentBLL.viewStudentByAdmissionNo(Convert.ToInt32(txtAdmissionNo.Text), Convert.ToInt32(Session["sessionId"]));
            studentCL.id = getStudent.id;
            studentCL.isDeleted = true;
            studentCL.dateDeleted = Convert.ToDateTime(txtDateofIssue.Text);
            bool exists = System.IO.Directory.Exists(Server.MapPath("Data/"));
            if (!exists)
                System.IO.Directory.CreateDirectory(Server.MapPath("Data/"));
            if (fuTransferCertificate.HasFile)
            {
                string TCFilePath = txtAdmissionNo.Text + "-" + dateNow.ToString("yyyy-mm-dd") + "InactiveTC" + Path.GetExtension(fuTransferCertificate.FileName);
                fuTransferCertificate.PostedFile.SaveAs(Server.MapPath("Data/") + TCFilePath);
                studentCL.deletedTransferCertificate = "http://www.rainbowjanakpuri.com/Student/Data/" + TCFilePath;
            }
            StudentCL deletedStudent = studentBLL.updateTCStudent(studentCL);
            Response.Redirect("ManageTC.aspx?studentId=" + deletedStudent.id);
        }

        protected void UpdateData()
        {
            DateTime dateHosting = DateTime.UtcNow;
            TimeZoneInfo indianZoneId = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime dateNow = TimeZoneInfo.ConvertTimeFromUtc(dateHosting, indianZoneId);
            StudentCL studentCL = new StudentCL();
            studentCL.id = Convert.ToInt32(Request.QueryString["studentId"]);
            studentCL.isDeleted = true;
            studentCL.dateDeleted = Convert.ToDateTime(txtDateofIssue.Text);
            bool exists = System.IO.Directory.Exists(Server.MapPath("Data/"));
            if (!exists)
                System.IO.Directory.CreateDirectory(Server.MapPath("Data/"));
            if (fuTransferCertificate.HasFile)
            {
                string TCFilePath = txtAdmissionNo.Text + "-" + dateNow.ToString("yyyy-mm-dd") + "InactiveTC-" + Path.GetExtension(fuTransferCertificate.FileName);
                fuTransferCertificate.PostedFile.SaveAs(Server.MapPath("Data/") + TCFilePath);
                studentCL.deletedTransferCertificate = "http://www.rainbowjanakpuri.com/Student/Data/" + TCFilePath;
            }
            StudentCL deletedStudent = studentBLL.updateTCStudent(studentCL);
            Response.Redirect("ManageTC.aspx?studentId=" + deletedStudent.id);
        }

        protected void txtAdmissionNo_TextChanged(object sender, EventArgs e)
        {
            if (txtAdmissionNo.Text != "")
            {
                StudentCL getStudent = studentBLL.viewStudentByAdmissionNo(Convert.ToInt32(txtAdmissionNo.Text), Convert.ToInt32(Session["sessionId"]));
                if (getStudent.id == 0)
                {
                    string script = "alert(\"Incorrect Admission Number.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);
                }
                else
                {
                    Collection<ClassCL> classCol = classBLL.viewClasses(Convert.ToInt32(Session["sessionId"]));
                    ddlClass.DataSource = classCol;
                    ddlClass.DataValueField = "id";
                    ddlClass.DataTextField = "classSection";
                    ddlClass.DataBind();
                    ddlClass.SelectedValue = getStudent.classId.ToString();
                    txtAddress.Text = getStudent.address;
                    txtDateUpdated.Text = getStudent.dateModified.ToString("dd MMMM yyyy");
                    txtDOB.Text = getStudent.dob.ToString("yyyy-MM-dd");
                    txtEmailAddress.Text = getStudent.emailAddress;
                    txtFatherName.Text = getStudent.fatherName;
                    txtMobileNumber.Text = getStudent.fatherMobileNumber;
                    txtStudentName.Text = getStudent.studentName;
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