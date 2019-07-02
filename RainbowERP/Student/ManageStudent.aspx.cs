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
    public partial class ManageStudent : System.Web.UI.Page
    {
        SessionBLL sessionBLL = new SessionBLL();
        StudentBLL studentBLL = new StudentBLL();
        ClassBLL classBLL = new ClassBLL();
        StudentCategoryBLL studentCategoryBLL = new StudentCategoryBLL();
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
                        SessionCL sessionCL = sessionBLL.addorCheckSession();
                        Session["sessionId"] = sessionCL.id;
                    }
                    else if (role.ToLower() == "teacher" || role.ToLower() == "attendanceo")
                    {
                        Response.Redirect("../UnAuthorized.aspx");
                    }
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
            Response.Redirect("index.aspx");
        }

        protected void btnAadharEnable_Click(object sender, EventArgs e)
        {
            txtAadharCardNo.Enabled = true;
        }

        protected void btnSiblingEnable_Click(object sender, EventArgs e)
        {
            txtSiblingAdmissionNo.Enabled = true;
        }

        protected void FetchControls()
        {
            sessionId = Convert.ToInt32(Session["sessionId"]);
            Collection<StudentCategoryCL> studentCategoryCol = studentCategoryBLL.viewStudentCategories();
            Collection<ClassCL> classCol = classBLL.viewClasses(sessionId);
            if (Request.QueryString["studentId"] != null)
            {
                int studentId = Convert.ToInt32(Request.QueryString["studentId"]);
                StudentCL studentCL = studentBLL.viewStudentById(studentId,sessionId);
                lblHeading.Text = "Update Student";
                ddlStudentCategory.DataSource = studentCategoryCol;
                ddlStudentCategory.DataValueField = "id";
                ddlStudentCategory.DataTextField = "name";
                ddlStudentCategory.DataBind();
                ddlStudentCategory.SelectedValue = studentCL.studentCategoryId.ToString();
                ddlClass.DataSource = classCol;
                ddlClass.DataValueField = "id";
                ddlClass.DataTextField = "classSection";
                ddlClass.DataBind();
                ddlClass.SelectedValue = studentCL.classId.ToString();
                if (studentCL.aadharCardNo == null)
                { txtAadharCardNo.Enabled = false; }
                else
                { txtAadharCardNo.Text = studentCL.aadharCardNo; }
                txtAddress.Text = studentCL.address;
                txtAdmissionNo.Text = studentCL.admissionNo.ToString();
                txtDateCreated.Text = studentCL.dateCreated.ToString("dd MMMM yyyy");
                txtDateUpdated.Text = studentCL.dateModified.ToString("dd MMMM yyyy");
                txtDOB.Text = studentCL.dob.ToString("yyyy-MM-dd");
                txtEmailAddress.Text = studentCL.emailAddress;
                txtFatherName.Text = studentCL.fatherName;
                txtMobileNumber.Text = studentCL.fatherMobileNumber;
                txtMotherName.Text = studentCL.motherName;
                if (studentCL.siblingAdmissionNo == null)
                { txtSiblingAdmissionNo.Enabled = false; }
                else
                { txtSiblingAdmissionNo.Text = studentCL.siblingAdmissionNo.ToString(); }
                if (studentCL.miscellaneous1Link == null)
                {
                    linkMisc1.Visible = false;
                }
                else
                {
                    linkMisc1.Text = studentCL.miscellaneous1Name;
                    linkMisc1.NavigateUrl = studentCL.miscellaneous1Link;
                }
                if (studentCL.miscellaneous2Link == null)
                {
                    linkMisc2.Visible = false;
                }
                else
                {
                    linkMisc2.Text = studentCL.miscellaneous2Name;
                    linkMisc2.NavigateUrl = studentCL.miscellaneous2Link;
                }
                if (studentCL.miscellaneous3Link == null)
                {
                    linkMisc3.Visible = false;
                }
                else
                {
                    linkMisc3.Text = studentCL.miscellaneous3Name;
                    linkMisc3.NavigateUrl = studentCL.miscellaneous3Link;
                }
                if (studentCL.transferCertificate == null)
                {
                    linkTC.Visible = false;
                }
                else
                {
                    linkTC.Text = studentCL.admissionNo+" - TransferCertificate";
                    linkTC.NavigateUrl = studentCL.transferCertificate;
                }
                if(studentCL.birthCertificate == null || studentCL.birthCertificate==string.Empty)
                {
                    linkBirthC.Visible = false;
                }
                else
	            {

                    linkBirthC.Text = studentCL.admissionNo + " - Birth Cerificate";
                    linkBirthC.NavigateUrl = studentCL.birthCertificate; 
                }
                txtStudentName.Text = studentCL.studentName;
                txtFileUpload1.Enabled = false;
                txtFileUpload2.Enabled = false;
                txtFileUpload3.Enabled = false;
                fuBirthCertificate.Enabled = false;
                fuMisc1.Enabled = false;
                fuMisc2.Enabled = false;
                fuMisc3.Enabled = false;
                fuTransferCertificate.Enabled = false;
            }
            else
            {
                lblHeading.Text = "Add Student";
                linkBirthC.Visible = false;
                linkMisc1.Visible = false;
                linkMisc2.Visible = false;
                linkMisc3.Visible = false;
                linkTC.Visible = false;
                btnAadharEnable.Enabled = false;
                btnSiblingEnable.Enabled = false;
                ddlStudentCategory.DataSource = studentCategoryCol;
                ddlStudentCategory.DataValueField = "id";
                ddlStudentCategory.DataTextField = "name";
                ddlStudentCategory.DataBind();
                ddlClass.DataSource = classCol;
                ddlClass.DataValueField = "id";
                ddlClass.DataTextField = "classSection";
                ddlClass.DataBind();
            }
        }

        protected void AddData()
        {
            DateTime dateHosting = DateTime.UtcNow;
            TimeZoneInfo indianZoneId = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime dateNow = TimeZoneInfo.ConvertTimeFromUtc(dateHosting, indianZoneId);
            StudentCL studentCL = new StudentCL();
            if (txtAadharCardNo.Text != string.Empty)
            {
                studentCL.aadharCardNo = txtAadharCardNo.Text;
            }
            else
            {
                studentCL.aadharCardNo = null;
            }
            studentCL.address = txtAddress.Text;
            studentCL.admissionNo = Convert.ToInt32(txtAdmissionNo.Text);
            studentCL.classId = Convert.ToInt32(ddlClass.SelectedValue);
            studentCL.dateCreated = dateNow;
            studentCL.dateModified = dateNow;
            studentCL.dob = Convert.ToDateTime(txtDOB.Text);
            if (txtEmailAddress.Text != string.Empty)
            {
                studentCL.emailAddress = txtEmailAddress.Text;
            }
            else
            {
                studentCL.emailAddress = null;
            }
            studentCL.fatherMobileNumber = txtMobileNumber.Text;
            studentCL.fatherName = txtFatherName.Text;
            studentCL.gender = Convert.ToBoolean(ddlGender.SelectedValue);
            studentCL.isDeleted = false;
            studentCL.motherName = txtMotherName.Text;
            bool exists = System.IO.Directory.Exists(Server.MapPath("Data/"));
            if (!exists)
                System.IO.Directory.CreateDirectory(Server.MapPath("Data/"));
            if (txtSiblingAdmissionNo.Text != string.Empty)
            {
                studentCL.siblingAdmissionNo = Convert.ToInt32(txtSiblingAdmissionNo.Text);
            }
            else
            {
                studentCL.siblingAdmissionNo = null;
            }
            studentCL.studentCategoryId = Convert.ToInt32(ddlStudentCategory.SelectedIndex);
            studentCL.studentName = txtStudentName.Text;
            if (fuMisc1.HasFile)
            {
                string Misc1FilePath = txtAdmissionNo.Text + "-" + dateNow.ToString("yyyy-mm-dd") + txtFileUpload1.Text + Path.GetExtension(fuMisc1.FileName);
                fuMisc1.PostedFile.SaveAs(Server.MapPath("Data/") + Misc1FilePath);
                studentCL.miscellaneous1Link = "http://www.rainbowjanakpuri.com/Student/Data/" + Misc1FilePath;
                studentCL.miscellaneous1Name = txtFileUpload1.Text;
            }
            if (fuMisc2.HasFile)
            {
                string Misc2FilePath = txtAdmissionNo.Text + "-" + dateNow.ToString("yyyy-mm-dd") + txtFileUpload2.Text + Path.GetExtension(fuMisc2.FileName);
                fuMisc2.PostedFile.SaveAs(Server.MapPath("Data/") + Misc2FilePath);
                studentCL.miscellaneous2Link = "http://www.rainbowjanakpuri.com/Student/Data/" + Misc2FilePath;
                studentCL.miscellaneous2Name = txtFileUpload2.Text;
            }
            if (fuMisc3.HasFile)
            {
                string Misc3FilePath = txtAdmissionNo.Text + "-" + dateNow.ToString("yyyy-mm-dd") + txtFileUpload3.Text + Path.GetExtension(fuMisc3.FileName);
                fuMisc3.PostedFile.SaveAs(Server.MapPath("Data/") + Misc3FilePath);
                studentCL.miscellaneous3Link = "http://www.rainbowjanakpuri.com/Student/Data/" + Misc3FilePath;
                studentCL.miscellaneous3Name = txtFileUpload3.Text;
            }
            if (fuTransferCertificate.HasFile)
            {
                string TCFilePath =  txtAdmissionNo.Text + "-" + dateNow.ToString("yyyy-mm-dd") + "TC" + Path.GetExtension(fuTransferCertificate.FileName);
                fuTransferCertificate.PostedFile.SaveAs(Server.MapPath("Data/") + TCFilePath);
                studentCL.transferCertificate = "http://www.rainbowjanakpuri.com/Student/Data/" + TCFilePath;
            }
            if (fuBirthCertificate.HasFile)
            {
                string BirthCertificateFilePath = txtAdmissionNo.Text + "-" + dateNow.ToString("yyyy-mm-dd") + "BirthCertificate" + Path.GetExtension(fuBirthCertificate.FileName);
                fuBirthCertificate.PostedFile.SaveAs(Server.MapPath("Data/") + BirthCertificateFilePath);
                studentCL.birthCertificate = "http://www.rainbowjanakpuri.com/Student/Data/" + BirthCertificateFilePath;
            }
            else
            {
                studentCL.birthCertificate = string.Empty;
            }
            studentCL.deletedTransferCertificate = null;
            int studentId = studentBLL.addStudent(studentCL);
            Response.Redirect("ManageStudent.aspx?studentId=" + studentId);
        }

        protected void UpdateData()
        {
            DateTime dateHosting = DateTime.UtcNow;
            TimeZoneInfo indianZoneId = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime dateNow = TimeZoneInfo.ConvertTimeFromUtc(dateHosting, indianZoneId);
            StudentCL studentCL = new StudentCL();
            studentCL.id = Convert.ToInt32(Request.QueryString["studentId"]);
            if (txtAadharCardNo.Text != string.Empty && txtAadharCardNo.Enabled != false)
            {
                studentCL.aadharCardNo = txtAadharCardNo.Text;
            }
            else
            {
                studentCL.aadharCardNo = null;
            }
            studentCL.address = txtAddress.Text;
            studentCL.admissionNo = Convert.ToInt32(txtAdmissionNo.Text);
            studentCL.classId = Convert.ToInt32(ddlClass.SelectedValue);
            studentCL.dateCreated = Convert.ToDateTime(txtDateCreated.Text);
            studentCL.dateModified = dateNow;
            studentCL.dob = Convert.ToDateTime(txtDOB.Text);
            if (txtEmailAddress.Text != string.Empty && txtEmailAddress.Enabled != false)
            {
                studentCL.emailAddress = txtEmailAddress.Text;
            }
            else
            {
                studentCL.emailAddress = null;
            }
            studentCL.fatherMobileNumber = txtMobileNumber.Text;
            studentCL.fatherName = txtFatherName.Text;
            studentCL.gender = Convert.ToBoolean(ddlGender.SelectedValue);
            studentCL.isDeleted = false;
            studentCL.motherName = txtMotherName.Text;
            if (txtSiblingAdmissionNo.Text != "" && txtSiblingAdmissionNo.Enabled != false)
            {
                studentCL.siblingAdmissionNo = Convert.ToInt32(txtSiblingAdmissionNo.Text);
            }
            else
            {
                studentCL.siblingAdmissionNo = null;
            }
            studentCL.studentCategoryId = Convert.ToInt32(ddlStudentCategory.SelectedValue);
            studentCL.studentName = txtStudentName.Text;
            StudentCL studentReturn = studentBLL.updateStudent(studentCL);
            Response.Redirect("ManageStudent.aspx?studentId=" + studentReturn.id);
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}