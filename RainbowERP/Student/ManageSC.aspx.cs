using BusinessLogicLayer;
using CommunicationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAINBOW_ERP.Student
{
    public partial class ManageSC : System.Web.UI.Page
    {
        StudentCategoryBLL studentCategoryBLL = new StudentCategoryBLL();
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
                        if (Request.QueryString["scId"] != null)
                        {
                            int scId = Convert.ToInt32(Request.QueryString["scId"]);
                            lblHeading.Text = "Update Student Category";
                            StudentCategoryCL scCL = studentCategoryBLL.viewSCById(scId);
                            txtSCName.Text = scCL.name;
                            txtTotalStrength.Text = scCL.totalStrength.ToString();
                            txtDateCreated.Text = scCL.dateCreated.ToString("dd MMMM yyyy");
                            txtDateUpdated.Text = scCL.dateModified.ToString("dd MMMM yyyy");
                        }
                        else
                        {
                            lblHeading.Text = "Add Student Category";
                        }
                    } 
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DateTime dateHosting = DateTime.UtcNow;
            TimeZoneInfo indianZoneId = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime dateNow = TimeZoneInfo.ConvertTimeFromUtc(dateHosting, indianZoneId);
            if (Request.QueryString["scId"] != null)
            {
                StudentCategoryCL scCL = new StudentCategoryCL();
                scCL.id = Convert.ToInt32(Request.QueryString["scId"]);
                scCL.name = txtSCName.Text;
                scCL.dateCreated = Convert.ToDateTime(txtDateCreated.Text);
                scCL.dateModified = dateNow;
                scCL.isDeleted = false;
                StudentCategoryCL scReturn = studentCategoryBLL.updateSC(scCL);
                Response.Redirect("ManageSC.aspx?scId=" + scReturn.id);
            }
            else
            {
                StudentCategoryCL scCL = new StudentCategoryCL();
                scCL.name = txtSCName.Text;
                scCL.dateCreated = dateNow;
                scCL.dateModified = dateNow;
                scCL.isDeleted = false;
                int scId = studentCategoryBLL.addSC(scCL);
                Response.Redirect("ManageSC.aspx?scId=" + scId);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentCategory.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}