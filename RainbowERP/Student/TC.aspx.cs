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

namespace RAINBOW_ERP.Student
{
    public partial class TC : System.Web.UI.Page
    {
        StudentBLL studentBLL = new StudentBLL();
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
                    else if (role.ToLower() == "teacher" || role.ToLower() == "attendanceo")
                    {
                        Response.Redirect("../UnAuthorized.aspx");
                    }
                    else
                    {
                        sessionId = Convert.ToInt32(Session["sessionId"]);
                        grdTC.DataSource = studentBLL.viewTCStudents(sessionId);
                        grdTC.DataBind();
                    }
                }
            }
        }

        protected void grdTC_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int studentId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("ManageTC.aspx?studentId=" + studentId);
            }
        }

        protected void btnAddTC_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageTC.aspx");
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            if (ftAdmissionNo.Text == string.Empty && ftDateFrom.Text == string.Empty && ftDateTo.Text == string.Empty && ftFatherName.Text == string.Empty && ftMobileNumber.Text == string.Empty && ftStudentName.Text == string.Empty)
            {
                grdTC.DataSource = studentBLL.viewTCStudents(sessionId);
                grdTC.DataBind();
            }
            else
            {
                var tcGet = studentBLL.viewTCStudents(sessionId);
                IEnumerable<StudentCL> studentQuery = tcGet;
                Collection<StudentCL> tcUpdate = new Collection<StudentCL>();
                if (ftAdmissionNo.Text != string.Empty)
                {
                    studentQuery = from x in studentQuery where x.admissionNo == Convert.ToInt32(ftAdmissionNo.Text) select x;
                }
                if (ftFatherName.Text != string.Empty)
                {
                    studentQuery = from x in studentQuery where x.fatherName.ToLower().Contains(ftFatherName.Text.ToLower()) select x;
                }
                if (ftStudentName.Text != string.Empty)
                {
                    studentQuery = from x in studentQuery where x.studentName.ToLower().Contains(ftStudentName.Text.ToLower()) select x;
                }
                if (ftMobileNumber.Text != string.Empty)
                {
                    studentQuery = from x in studentQuery where x.fatherMobileNumber.Contains(ftMobileNumber.Text) select x;
                }
                if (ftDateFrom.Text != string.Empty)
                {
                    studentQuery = from x in studentQuery where x.dateDeleted >= Convert.ToDateTime(ftDateFrom.Text) select x;
                }
                if (ftDateTo.Text != string.Empty)
                {
                    studentQuery = from x in studentQuery where x.dateDeleted <= Convert.ToDateTime(ftDateTo.Text) select x;
                }
                foreach (StudentCL item in studentQuery)
                {
                    tcUpdate.Add(new StudentCL()
                    {
                        aadharCardNo = item.aadharCardNo,
                        address = item.address,
                        admissionNo = item.admissionNo,
                        birthCertificate = item.birthCertificate,
                        classId = item.classId,
                        classSection = item.classSection,
                        dateCreated = item.dateCreated,
                        dateDeleted = item.dateDeleted,
                        dateModified = item.dateModified,
                        deletedTransferCertificate = item.deletedTransferCertificate,
                        dob = item.dob,
                        emailAddress = item.emailAddress,
                        fatherMobileNumber = item.fatherMobileNumber,
                        fatherName = item.fatherName,
                        gender = item.gender,
                        id = item.id,
                        isDeleted = item.isDeleted,
                        miscellaneous1Link = item.miscellaneous1Link,
                        miscellaneous1Name = item.miscellaneous1Name,
                        miscellaneous2Link = item.miscellaneous2Link,
                        miscellaneous2Name = item.miscellaneous2Name,
                        miscellaneous3Link = item.miscellaneous3Link,
                        miscellaneous3Name = item.miscellaneous3Name,
                        motherName = item.motherName,
                        session = item.session,
                        siblingAdmissionNo = item.siblingAdmissionNo,
                        studentCategory = item.studentCategory,
                        studentCategoryId = item.studentCategoryId,
                        studentName = item.studentName,
                        transferCertificate = item.transferCertificate,
                    });
                }
                grdTC.DataSource = tcUpdate;
                grdTC.DataBind();
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void grdTC_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdTC.PageIndex = e.NewPageIndex;
                grdTC.DataSource = studentBLL.viewTCStudents(sessionId);
                grdTC.DataBind();
            }
            catch (Exception ex)
            {

                throw (new Exception(ex.Message));
            }
        }
    }
}