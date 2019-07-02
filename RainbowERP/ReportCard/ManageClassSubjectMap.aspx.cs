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
    public partial class ManageClassSubjectMap : System.Web.UI.Page
    {
        ClassBLL classBLL = new ClassBLL();
        SubjectBLL subjectBLL = new SubjectBLL();
        ClassSubjectBLL classSubjectBLL = new ClassSubjectBLL();
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
                        FetchControls();
                        if (Request.QueryString["classId"] != null)
                        {
                            ddlClass.Enabled = false;
                            int classId = Convert.ToInt32(Request.QueryString["classId"]);
                            lblHeading.Text = "Update Class Subject";
                            ddlClass.SelectedValue = classId.ToString();
                            SwitchCase(classId);
                            btnSubmit.Text = "Update";
                            btnDelete.Visible = true;
                        }
                        else
                        {
                            lblHeading.Text = "Add Class Subject";
                            btnSubmit.Text = "Submit";
                            btnDelete.Visible = false;
                        }
                    }
                }
            }
        }

        public void FetchControls()
        {
            int sessionId = Convert.ToInt32(Session["sessionId"]);
            ddlClass.DataSource = classBLL.viewClasses(sessionId);
            ddlClass.DataValueField = "id";
            ddlClass.DataTextField = "classSection";
            ddlClass.DataBind();
            txtSubject1.DataSource = subjectBLL.viewSubjects();
            txtSubject1.DataValueField = "id";
            txtSubject1.DataTextField = "name";
            txtSubject1.DataBind();
            txtSubject1.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject2.DataSource = subjectBLL.viewSubjects();
            txtSubject2.DataValueField = "id";
            txtSubject2.DataTextField = "name";
            txtSubject2.DataBind();
            txtSubject2.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject3.DataSource = subjectBLL.viewSubjects();
            txtSubject3.DataValueField = "id";
            txtSubject3.DataTextField = "name";
            txtSubject3.DataBind();
            txtSubject3.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject4.DataSource = subjectBLL.viewSubjects();
            txtSubject4.DataValueField = "id";
            txtSubject4.DataTextField = "name";
            txtSubject4.DataBind();
            txtSubject4.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject5.DataSource = subjectBLL.viewSubjects();
            txtSubject5.DataValueField = "id";
            txtSubject5.DataTextField = "name";
            txtSubject5.DataBind();
            txtSubject5.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject6.DataSource = subjectBLL.viewSubjects();
            txtSubject6.DataValueField = "id";
            txtSubject6.DataTextField = "name";
            txtSubject6.DataBind();
            txtSubject6.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject7.DataSource = subjectBLL.viewSubjects();
            txtSubject7.DataValueField = "id";
            txtSubject7.DataTextField = "name";
            txtSubject7.DataBind();
            txtSubject7.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject8.DataSource = subjectBLL.viewSubjects();
            txtSubject8.DataValueField = "id";
            txtSubject8.DataTextField = "name";
            txtSubject8.DataBind();
            txtSubject8.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject9.DataSource = subjectBLL.viewSubjects();
            txtSubject9.DataValueField = "id";
            txtSubject9.DataTextField = "name";
            txtSubject9.DataBind();
            txtSubject9.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject10.DataSource = subjectBLL.viewSubjects();
            txtSubject10.DataValueField = "id";
            txtSubject10.DataTextField = "name";
            txtSubject10.DataBind();
            txtSubject10.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject11.DataSource = subjectBLL.viewSubjects();
            txtSubject11.DataValueField = "id";
            txtSubject11.DataTextField = "name";
            txtSubject11.DataBind();
            txtSubject11.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject12.DataSource = subjectBLL.viewSubjects();
            txtSubject12.DataValueField = "id";
            txtSubject12.DataTextField = "name";
            txtSubject12.DataBind();
            txtSubject12.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject13.DataSource = subjectBLL.viewSubjects();
            txtSubject13.DataValueField = "id";
            txtSubject13.DataTextField = "name";
            txtSubject13.DataBind();
            txtSubject13.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject14.DataSource = subjectBLL.viewSubjects();
            txtSubject14.DataValueField = "id";
            txtSubject14.DataTextField = "name";
            txtSubject14.DataBind();
            txtSubject14.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject15.DataSource = subjectBLL.viewSubjects();
            txtSubject15.DataValueField = "id";
            txtSubject15.DataTextField = "name";
            txtSubject15.DataBind();
            txtSubject15.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject16.DataSource = subjectBLL.viewSubjects();
            txtSubject16.DataValueField = "id";
            txtSubject16.DataTextField = "name";
            txtSubject16.DataBind();
            txtSubject16.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject17.DataSource = subjectBLL.viewSubjects();
            txtSubject17.DataValueField = "id";
            txtSubject17.DataTextField = "name";
            txtSubject17.DataBind();
            txtSubject17.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject18.DataSource = subjectBLL.viewSubjects();
            txtSubject18.DataValueField = "id";
            txtSubject18.DataTextField = "name";
            txtSubject18.DataBind();
            txtSubject18.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject19.DataSource = subjectBLL.viewSubjects();
            txtSubject19.DataValueField = "id";
            txtSubject19.DataTextField = "name";
            txtSubject19.DataBind();
            txtSubject19.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject20.DataSource = subjectBLL.viewSubjects();
            txtSubject20.DataValueField = "id";
            txtSubject20.DataTextField = "name";
            txtSubject20.DataBind();
            txtSubject20.Items.Insert(0, new ListItem("Select", "Select"));
        }

        public void SwitchCase(int classId)
        {
            Collection<SubjectCL> subjectColCL = subjectBLL.viewSubjectByClassId(classId);
            switch (subjectColCL.Count())
            {
                case 1:
                    txtSubject1.SelectedValue = subjectColCL[0].id.ToString();
                    txtSubject2.Enabled = false;
                    txtSubject3.Enabled = false;
                    txtSubject4.Enabled = false;
                    txtSubject5.Enabled = false;
                    txtSubject6.Enabled = false;
                    txtSubject7.Enabled = false;
                    txtSubject8.Enabled = false;
                    txtSubject9.Enabled = false;
                    txtSubject10.Enabled = false;
                    txtSubject11.Enabled = false;
                    txtSubject12.Enabled = false;
                    txtSubject13.Enabled = false;
                    txtSubject14.Enabled = false;
                    txtSubject15.Enabled = false;
                    txtSubject16.Enabled = false;
                    txtSubject17.Enabled = false;
                    txtSubject18.Enabled = false;
                    txtSubject19.Enabled = false;
                    txtSubject20.Enabled = false;
                    break;
                case 2:
                    txtSubject1.SelectedValue = subjectColCL[0].id.ToString();
                    txtSubject2.SelectedValue = subjectColCL[1].id.ToString();
                    txtSubject3.Enabled = false;
                    txtSubject4.Enabled = false;
                    txtSubject5.Enabled = false;
                    txtSubject6.Enabled = false;
                    txtSubject7.Enabled = false;
                    txtSubject8.Enabled = false;
                    txtSubject9.Enabled = false;
                    txtSubject10.Enabled = false;
                    txtSubject11.Enabled = false;
                    txtSubject12.Enabled = false;
                    txtSubject13.Enabled = false;
                    txtSubject14.Enabled = false;
                    txtSubject15.Enabled = false;
                    txtSubject16.Enabled = false;
                    txtSubject17.Enabled = false;
                    txtSubject18.Enabled = false;
                    txtSubject19.Enabled = false;
                    txtSubject20.Enabled = false;
                    break;
                case 3:
                    txtSubject1.SelectedValue = subjectColCL[0].id.ToString();
                    txtSubject2.SelectedValue = subjectColCL[1].id.ToString();
                    txtSubject3.SelectedValue = subjectColCL[2].id.ToString();
                    txtSubject4.Enabled = false;
                    txtSubject5.Enabled = false;
                    txtSubject6.Enabled = false;
                    txtSubject7.Enabled = false;
                    txtSubject8.Enabled = false;
                    txtSubject9.Enabled = false;
                    txtSubject10.Enabled = false;
                    txtSubject11.Enabled = false;
                    txtSubject12.Enabled = false;
                    txtSubject13.Enabled = false;
                    txtSubject14.Enabled = false;
                    txtSubject15.Enabled = false;
                    txtSubject16.Enabled = false;
                    txtSubject17.Enabled = false;
                    txtSubject18.Enabled = false;
                    txtSubject19.Enabled = false;
                    txtSubject20.Enabled = false;
                    break;
                case 4:
                    txtSubject1.SelectedValue = subjectColCL[0].id.ToString();
                    txtSubject2.SelectedValue = subjectColCL[1].id.ToString();
                    txtSubject3.SelectedValue = subjectColCL[2].id.ToString();
                    txtSubject4.SelectedValue = subjectColCL[3].id.ToString();
                    txtSubject5.Enabled = false;
                    txtSubject6.Enabled = false;
                    txtSubject7.Enabled = false;
                    txtSubject8.Enabled = false;
                    txtSubject9.Enabled = false;
                    txtSubject10.Enabled = false;
                    txtSubject11.Enabled = false;
                    txtSubject12.Enabled = false;
                    txtSubject13.Enabled = false;
                    txtSubject14.Enabled = false;
                    txtSubject15.Enabled = false;
                    txtSubject16.Enabled = false;
                    txtSubject17.Enabled = false;
                    txtSubject18.Enabled = false;
                    txtSubject19.Enabled = false;
                    txtSubject20.Enabled = false;
                    break;
                case 5:
                    txtSubject1.SelectedValue = subjectColCL[0].id.ToString();
                    txtSubject2.SelectedValue = subjectColCL[1].id.ToString();
                    txtSubject3.SelectedValue = subjectColCL[2].id.ToString();
                    txtSubject4.SelectedValue = subjectColCL[3].id.ToString();
                    txtSubject5.SelectedValue = subjectColCL[4].id.ToString();
                    txtSubject6.Enabled = false;
                    txtSubject7.Enabled = false;
                    txtSubject8.Enabled = false;
                    txtSubject9.Enabled = false;
                    txtSubject10.Enabled = false;
                    txtSubject11.Enabled = false;
                    txtSubject12.Enabled = false;
                    txtSubject13.Enabled = false;
                    txtSubject14.Enabled = false;
                    txtSubject15.Enabled = false;
                    txtSubject16.Enabled = false;
                    txtSubject17.Enabled = false;
                    txtSubject18.Enabled = false;
                    txtSubject19.Enabled = false;
                    txtSubject20.Enabled = false;
                    break;
                case 6:
                    txtSubject1.SelectedValue = subjectColCL[0].id.ToString();
                    txtSubject2.SelectedValue = subjectColCL[1].id.ToString();
                    txtSubject3.SelectedValue = subjectColCL[2].id.ToString();
                    txtSubject4.SelectedValue = subjectColCL[3].id.ToString();
                    txtSubject5.SelectedValue = subjectColCL[4].id.ToString();
                    txtSubject6.SelectedValue = subjectColCL[5].id.ToString();
                    txtSubject7.Enabled = false;
                    txtSubject8.Enabled = false;
                    txtSubject9.Enabled = false;
                    txtSubject10.Enabled = false;
                    txtSubject11.Enabled = false;
                    txtSubject12.Enabled = false;
                    txtSubject13.Enabled = false;
                    txtSubject14.Enabled = false;
                    txtSubject15.Enabled = false;
                    txtSubject16.Enabled = false;
                    txtSubject17.Enabled = false;
                    txtSubject18.Enabled = false;
                    txtSubject19.Enabled = false;
                    txtSubject20.Enabled = false;
                    break;
                case 7:
                    txtSubject1.SelectedValue = subjectColCL[0].id.ToString();
                    txtSubject2.SelectedValue = subjectColCL[1].id.ToString();
                    txtSubject3.SelectedValue = subjectColCL[2].id.ToString();
                    txtSubject4.SelectedValue = subjectColCL[3].id.ToString();
                    txtSubject5.SelectedValue = subjectColCL[4].id.ToString();
                    txtSubject6.SelectedValue = subjectColCL[5].id.ToString();
                    txtSubject7.SelectedValue = subjectColCL[6].id.ToString();
                    txtSubject8.Enabled = false;
                    txtSubject9.Enabled = false;
                    txtSubject10.Enabled = false;
                    txtSubject11.Enabled = false;
                    txtSubject12.Enabled = false;
                    txtSubject13.Enabled = false;
                    txtSubject14.Enabled = false;
                    txtSubject15.Enabled = false;
                    txtSubject16.Enabled = false;
                    txtSubject17.Enabled = false;
                    txtSubject18.Enabled = false;
                    txtSubject19.Enabled = false;
                    txtSubject20.Enabled = false;
                    break;
                case 8:
                    txtSubject1.SelectedValue = subjectColCL[0].id.ToString();
                    txtSubject2.SelectedValue = subjectColCL[1].id.ToString();
                    txtSubject3.SelectedValue = subjectColCL[2].id.ToString();
                    txtSubject4.SelectedValue = subjectColCL[3].id.ToString();
                    txtSubject5.SelectedValue = subjectColCL[4].id.ToString();
                    txtSubject6.SelectedValue = subjectColCL[5].id.ToString();
                    txtSubject7.SelectedValue = subjectColCL[6].id.ToString();
                    txtSubject8.SelectedValue = subjectColCL[7].id.ToString();
                    txtSubject9.Enabled = false;
                    txtSubject10.Enabled = false;
                    txtSubject11.Enabled = false;
                    txtSubject12.Enabled = false;
                    txtSubject13.Enabled = false;
                    txtSubject14.Enabled = false;
                    txtSubject15.Enabled = false;
                    txtSubject16.Enabled = false;
                    txtSubject17.Enabled = false;
                    txtSubject18.Enabled = false;
                    txtSubject19.Enabled = false;
                    txtSubject20.Enabled = false;
                    break;
                case 9:
                    txtSubject1.SelectedValue = subjectColCL[0].id.ToString();
                    txtSubject2.SelectedValue = subjectColCL[1].id.ToString();
                    txtSubject3.SelectedValue = subjectColCL[2].id.ToString();
                    txtSubject4.SelectedValue = subjectColCL[3].id.ToString();
                    txtSubject5.SelectedValue = subjectColCL[4].id.ToString();
                    txtSubject6.SelectedValue = subjectColCL[5].id.ToString();
                    txtSubject7.SelectedValue = subjectColCL[6].id.ToString();
                    txtSubject8.SelectedValue = subjectColCL[7].id.ToString();
                    txtSubject9.SelectedValue = subjectColCL[8].id.ToString();
                    txtSubject10.Enabled = false;
                    txtSubject11.Enabled = false;
                    txtSubject12.Enabled = false;
                    txtSubject13.Enabled = false;
                    txtSubject14.Enabled = false;
                    txtSubject15.Enabled = false;
                    txtSubject16.Enabled = false;
                    txtSubject17.Enabled = false;
                    txtSubject18.Enabled = false;
                    txtSubject19.Enabled = false;
                    txtSubject20.Enabled = false;
                    break;
                case 10:
                    txtSubject1.SelectedValue = subjectColCL[0].id.ToString();
                    txtSubject2.SelectedValue = subjectColCL[1].id.ToString();
                    txtSubject3.SelectedValue = subjectColCL[2].id.ToString();
                    txtSubject4.SelectedValue = subjectColCL[3].id.ToString();
                    txtSubject5.SelectedValue = subjectColCL[4].id.ToString();
                    txtSubject6.SelectedValue = subjectColCL[5].id.ToString();
                    txtSubject7.SelectedValue = subjectColCL[6].id.ToString();
                    txtSubject8.SelectedValue = subjectColCL[7].id.ToString();
                    txtSubject9.SelectedValue = subjectColCL[8].id.ToString();
                    txtSubject10.SelectedValue = subjectColCL[9].id.ToString();
                    txtSubject11.Enabled = false;
                    txtSubject12.Enabled = false;
                    txtSubject13.Enabled = false;
                    txtSubject14.Enabled = false;
                    txtSubject15.Enabled = false;
                    txtSubject16.Enabled = false;
                    txtSubject17.Enabled = false;
                    txtSubject18.Enabled = false;
                    txtSubject19.Enabled = false;
                    txtSubject20.Enabled = false;
                    break;
                case 11:
                    txtSubject1.SelectedValue = subjectColCL[0].id.ToString();
                    txtSubject2.SelectedValue = subjectColCL[1].id.ToString();
                    txtSubject3.SelectedValue = subjectColCL[2].id.ToString();
                    txtSubject4.SelectedValue = subjectColCL[3].id.ToString();
                    txtSubject5.SelectedValue = subjectColCL[4].id.ToString();
                    txtSubject6.SelectedValue = subjectColCL[5].id.ToString();
                    txtSubject7.SelectedValue = subjectColCL[6].id.ToString();
                    txtSubject8.SelectedValue = subjectColCL[7].id.ToString();
                    txtSubject9.SelectedValue = subjectColCL[8].id.ToString();
                    txtSubject10.SelectedValue = subjectColCL[9].id.ToString();
                    txtSubject11.SelectedValue = subjectColCL[10].id.ToString();
                    txtSubject12.Enabled = false;
                    txtSubject13.Enabled = false;
                    txtSubject14.Enabled = false;
                    txtSubject15.Enabled = false;
                    txtSubject16.Enabled = false;
                    txtSubject17.Enabled = false;
                    txtSubject18.Enabled = false;
                    txtSubject19.Enabled = false;
                    txtSubject20.Enabled = false;
                    break;
                case 12:
                    txtSubject1.SelectedValue = subjectColCL[0].id.ToString();
                    txtSubject2.SelectedValue = subjectColCL[1].id.ToString();
                    txtSubject3.SelectedValue = subjectColCL[2].id.ToString();
                    txtSubject4.SelectedValue = subjectColCL[3].id.ToString();
                    txtSubject5.SelectedValue = subjectColCL[4].id.ToString();
                    txtSubject6.SelectedValue = subjectColCL[5].id.ToString();
                    txtSubject7.SelectedValue = subjectColCL[6].id.ToString();
                    txtSubject8.SelectedValue = subjectColCL[7].id.ToString();
                    txtSubject9.SelectedValue = subjectColCL[8].id.ToString();
                    txtSubject10.SelectedValue = subjectColCL[9].id.ToString();
                    txtSubject11.SelectedValue = subjectColCL[10].id.ToString();
                    txtSubject12.SelectedValue = subjectColCL[11].id.ToString();
                    txtSubject13.Enabled = false;
                    txtSubject14.Enabled = false;
                    txtSubject15.Enabled = false;
                    txtSubject16.Enabled = false;
                    txtSubject17.Enabled = false;
                    txtSubject18.Enabled = false;
                    txtSubject19.Enabled = false;
                    txtSubject20.Enabled = false;
                    break;
                case 13:
                    txtSubject1.SelectedValue = subjectColCL[0].id.ToString();
                    txtSubject2.SelectedValue = subjectColCL[1].id.ToString();
                    txtSubject3.SelectedValue = subjectColCL[2].id.ToString();
                    txtSubject4.SelectedValue = subjectColCL[3].id.ToString();
                    txtSubject5.SelectedValue = subjectColCL[4].id.ToString();
                    txtSubject6.SelectedValue = subjectColCL[5].id.ToString();
                    txtSubject7.SelectedValue = subjectColCL[6].id.ToString();
                    txtSubject8.SelectedValue = subjectColCL[7].id.ToString();
                    txtSubject9.SelectedValue = subjectColCL[8].id.ToString();
                    txtSubject10.SelectedValue = subjectColCL[9].id.ToString();
                    txtSubject11.SelectedValue = subjectColCL[10].id.ToString();
                    txtSubject12.SelectedValue = subjectColCL[11].id.ToString();
                    txtSubject13.SelectedValue = subjectColCL[12].id.ToString();
                    txtSubject14.Enabled = false;
                    txtSubject15.Enabled = false;
                    txtSubject16.Enabled = false;
                    txtSubject17.Enabled = false;
                    txtSubject18.Enabled = false;
                    txtSubject19.Enabled = false;
                    txtSubject20.Enabled = false;
                    break;
                case 14:
                    txtSubject1.SelectedValue = subjectColCL[0].id.ToString();
                    txtSubject2.SelectedValue = subjectColCL[1].id.ToString();
                    txtSubject3.SelectedValue = subjectColCL[2].id.ToString();
                    txtSubject4.SelectedValue = subjectColCL[3].id.ToString();
                    txtSubject5.SelectedValue = subjectColCL[4].id.ToString();
                    txtSubject6.SelectedValue = subjectColCL[5].id.ToString();
                    txtSubject7.SelectedValue = subjectColCL[6].id.ToString();
                    txtSubject8.SelectedValue = subjectColCL[7].id.ToString();
                    txtSubject9.SelectedValue = subjectColCL[8].id.ToString();
                    txtSubject10.SelectedValue = subjectColCL[9].id.ToString();
                    txtSubject11.SelectedValue = subjectColCL[10].id.ToString();
                    txtSubject12.SelectedValue = subjectColCL[11].id.ToString();
                    txtSubject13.SelectedValue = subjectColCL[12].id.ToString();
                    txtSubject14.SelectedValue = subjectColCL[13].id.ToString();
                    txtSubject15.Enabled = false;
                    txtSubject16.Enabled = false;
                    txtSubject17.Enabled = false;
                    txtSubject18.Enabled = false;
                    txtSubject19.Enabled = false;
                    txtSubject20.Enabled = false;
                    break;
                case 15:
                    txtSubject1.SelectedValue = subjectColCL[0].id.ToString();
                    txtSubject2.SelectedValue = subjectColCL[1].id.ToString();
                    txtSubject3.SelectedValue = subjectColCL[2].id.ToString();
                    txtSubject4.SelectedValue = subjectColCL[3].id.ToString();
                    txtSubject5.SelectedValue = subjectColCL[4].id.ToString();
                    txtSubject6.SelectedValue = subjectColCL[5].id.ToString();
                    txtSubject7.SelectedValue = subjectColCL[6].id.ToString();
                    txtSubject8.SelectedValue = subjectColCL[7].id.ToString();
                    txtSubject9.SelectedValue = subjectColCL[8].id.ToString();
                    txtSubject10.SelectedValue = subjectColCL[9].id.ToString();
                    txtSubject11.SelectedValue = subjectColCL[10].id.ToString();
                    txtSubject12.SelectedValue = subjectColCL[11].id.ToString();
                    txtSubject13.SelectedValue = subjectColCL[12].id.ToString();
                    txtSubject14.SelectedValue = subjectColCL[13].id.ToString();
                    txtSubject15.SelectedValue = subjectColCL[14].id.ToString();
                    txtSubject16.Enabled = false;
                    txtSubject17.Enabled = false;
                    txtSubject18.Enabled = false;
                    txtSubject19.Enabled = false;
                    txtSubject20.Enabled = false;
                    break;
                case 16:
                    txtSubject1.SelectedValue = subjectColCL[0].id.ToString();
                    txtSubject2.SelectedValue = subjectColCL[1].id.ToString();
                    txtSubject3.SelectedValue = subjectColCL[2].id.ToString();
                    txtSubject4.SelectedValue = subjectColCL[3].id.ToString();
                    txtSubject5.SelectedValue = subjectColCL[4].id.ToString();
                    txtSubject6.SelectedValue = subjectColCL[5].id.ToString();
                    txtSubject7.SelectedValue = subjectColCL[6].id.ToString();
                    txtSubject8.SelectedValue = subjectColCL[7].id.ToString();
                    txtSubject9.SelectedValue = subjectColCL[8].id.ToString();
                    txtSubject10.SelectedValue = subjectColCL[9].id.ToString();
                    txtSubject11.SelectedValue = subjectColCL[10].id.ToString();
                    txtSubject12.SelectedValue = subjectColCL[11].id.ToString();
                    txtSubject13.SelectedValue = subjectColCL[12].id.ToString();
                    txtSubject14.SelectedValue = subjectColCL[13].id.ToString();
                    txtSubject15.SelectedValue = subjectColCL[14].id.ToString();
                    txtSubject16.SelectedValue = subjectColCL[15].id.ToString();
                    txtSubject17.Enabled = false;
                    txtSubject18.Enabled = false;
                    txtSubject19.Enabled = false;
                    txtSubject20.Enabled = false;
                    break;
                case 17:
                    txtSubject1.SelectedValue = subjectColCL[0].id.ToString();
                    txtSubject2.SelectedValue = subjectColCL[1].id.ToString();
                    txtSubject3.SelectedValue = subjectColCL[2].id.ToString();
                    txtSubject4.SelectedValue = subjectColCL[3].id.ToString();
                    txtSubject5.SelectedValue = subjectColCL[4].id.ToString();
                    txtSubject6.SelectedValue = subjectColCL[5].id.ToString();
                    txtSubject7.SelectedValue = subjectColCL[6].id.ToString();
                    txtSubject8.SelectedValue = subjectColCL[7].id.ToString();
                    txtSubject9.SelectedValue = subjectColCL[8].id.ToString();
                    txtSubject10.SelectedValue = subjectColCL[9].id.ToString();
                    txtSubject11.SelectedValue = subjectColCL[10].id.ToString();
                    txtSubject12.SelectedValue = subjectColCL[11].id.ToString();
                    txtSubject13.SelectedValue = subjectColCL[12].id.ToString();
                    txtSubject14.SelectedValue = subjectColCL[13].id.ToString();
                    txtSubject15.SelectedValue = subjectColCL[14].id.ToString();
                    txtSubject16.SelectedValue = subjectColCL[15].id.ToString();
                    txtSubject17.SelectedValue = subjectColCL[16].id.ToString();
                    txtSubject18.Enabled = false;
                    txtSubject19.Enabled = false;
                    txtSubject20.Enabled = false;
                    break;
                case 18:
                    txtSubject1.SelectedValue = subjectColCL[0].id.ToString();
                    txtSubject2.SelectedValue = subjectColCL[1].id.ToString();
                    txtSubject3.SelectedValue = subjectColCL[2].id.ToString();
                    txtSubject4.SelectedValue = subjectColCL[3].id.ToString();
                    txtSubject5.SelectedValue = subjectColCL[4].id.ToString();
                    txtSubject6.SelectedValue = subjectColCL[5].id.ToString();
                    txtSubject7.SelectedValue = subjectColCL[6].id.ToString();
                    txtSubject8.SelectedValue = subjectColCL[7].id.ToString();
                    txtSubject9.SelectedValue = subjectColCL[8].id.ToString();
                    txtSubject10.SelectedValue = subjectColCL[9].id.ToString();
                    txtSubject11.SelectedValue = subjectColCL[10].id.ToString();
                    txtSubject12.SelectedValue = subjectColCL[11].id.ToString();
                    txtSubject13.SelectedValue = subjectColCL[12].id.ToString();
                    txtSubject14.SelectedValue = subjectColCL[13].id.ToString();
                    txtSubject15.SelectedValue = subjectColCL[14].id.ToString();
                    txtSubject16.SelectedValue = subjectColCL[15].id.ToString();
                    txtSubject17.SelectedValue = subjectColCL[16].id.ToString();
                    txtSubject18.SelectedValue = subjectColCL[17].id.ToString();
                    txtSubject19.Enabled = false;
                    txtSubject20.Enabled = false;
                    break;
                case 19:
                    txtSubject1.SelectedValue = subjectColCL[0].id.ToString();
                    txtSubject2.SelectedValue = subjectColCL[1].id.ToString();
                    txtSubject3.SelectedValue = subjectColCL[2].id.ToString();
                    txtSubject4.SelectedValue = subjectColCL[3].id.ToString();
                    txtSubject5.SelectedValue = subjectColCL[4].id.ToString();
                    txtSubject6.SelectedValue = subjectColCL[5].id.ToString();
                    txtSubject7.SelectedValue = subjectColCL[6].id.ToString();
                    txtSubject8.SelectedValue = subjectColCL[7].id.ToString();
                    txtSubject9.SelectedValue = subjectColCL[8].id.ToString();
                    txtSubject10.SelectedValue = subjectColCL[9].id.ToString();
                    txtSubject11.SelectedValue = subjectColCL[10].id.ToString();
                    txtSubject12.SelectedValue = subjectColCL[11].id.ToString();
                    txtSubject13.SelectedValue = subjectColCL[12].id.ToString();
                    txtSubject14.SelectedValue = subjectColCL[13].id.ToString();
                    txtSubject15.SelectedValue = subjectColCL[14].id.ToString();
                    txtSubject16.SelectedValue = subjectColCL[15].id.ToString();
                    txtSubject17.SelectedValue = subjectColCL[16].id.ToString();
                    txtSubject18.SelectedValue = subjectColCL[17].id.ToString();
                    txtSubject19.SelectedValue = subjectColCL[18].id.ToString();
                    txtSubject20.Enabled = false;
                    break;
                case 20:
                    txtSubject1.SelectedValue = subjectColCL[0].id.ToString();
                    txtSubject2.SelectedValue = subjectColCL[1].id.ToString();
                    txtSubject3.SelectedValue = subjectColCL[2].id.ToString();
                    txtSubject4.SelectedValue = subjectColCL[3].id.ToString();
                    txtSubject5.SelectedValue = subjectColCL[4].id.ToString();
                    txtSubject6.SelectedValue = subjectColCL[5].id.ToString();
                    txtSubject7.SelectedValue = subjectColCL[6].id.ToString();
                    txtSubject8.SelectedValue = subjectColCL[7].id.ToString();
                    txtSubject9.SelectedValue = subjectColCL[8].id.ToString();
                    txtSubject10.SelectedValue = subjectColCL[9].id.ToString();
                    txtSubject11.SelectedValue = subjectColCL[10].id.ToString();
                    txtSubject12.SelectedValue = subjectColCL[11].id.ToString();
                    txtSubject13.SelectedValue = subjectColCL[12].id.ToString();
                    txtSubject14.SelectedValue = subjectColCL[13].id.ToString();
                    txtSubject15.SelectedValue = subjectColCL[14].id.ToString();
                    txtSubject16.SelectedValue = subjectColCL[15].id.ToString();
                    txtSubject17.SelectedValue = subjectColCL[16].id.ToString();
                    txtSubject18.SelectedValue = subjectColCL[17].id.ToString();
                    txtSubject19.SelectedValue = subjectColCL[18].id.ToString();
                    txtSubject20.SelectedValue = subjectColCL[19].id.ToString();
                    break;
            }
        }

        public Collection<ClassSubjectMapGridCL> SendControls()
        {
            int sessionId = Convert.ToInt32(Session["sessionId"]);
            Collection<ClassSubjectMapGridCL> subjectData = new Collection<ClassSubjectMapGridCL>();
            if (txtSubject1.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject1.SelectedValue),
                    sessionId = sessionId,
                });
            }
            if (txtSubject2.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject2.SelectedValue),
                    sessionId = sessionId,
                });
            }
            if (txtSubject3.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject3.SelectedValue),
                    sessionId = sessionId,
                });
            }
            if (txtSubject4.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject4.SelectedValue),
                    sessionId = sessionId,
                });
            }
            if (txtSubject5.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject5.SelectedValue),
                    sessionId = sessionId,
                });
            }
            if (txtSubject6.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject6.SelectedValue),
                    sessionId = sessionId,
                });
            }
            if (txtSubject7.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject7.SelectedValue),
                    sessionId = sessionId,
                });
            }
            if (txtSubject8.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject8.SelectedValue),
                    sessionId = sessionId,
                });
            }
            if (txtSubject9.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject9.SelectedValue),
                    sessionId = sessionId,
                });
            }
            if (txtSubject10.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject10.SelectedValue),
                    sessionId = sessionId,
                });
            }
            if (txtSubject11.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject11.SelectedValue),
                    sessionId = sessionId,
                });
            }
            if (txtSubject12.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject12.SelectedValue),
                    sessionId = sessionId,
                });
            }
            if (txtSubject13.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject13.SelectedValue),
                    sessionId = sessionId,
                });
            }
            if (txtSubject14.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject14.SelectedValue),
                    sessionId = sessionId,
                });
            }
            if (txtSubject15.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject15.SelectedValue),
                    sessionId = sessionId,
                });
            }
            if (txtSubject16.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject16.SelectedValue),
                    sessionId = sessionId,
                });
            }
            if (txtSubject17.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject17.SelectedValue),
                    sessionId = sessionId,
                });
            }
            if (txtSubject18.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject18.SelectedValue),
                    sessionId = sessionId,
                });
            }
            if (txtSubject19.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject19.SelectedValue),
                    sessionId = sessionId,
                });
            }
            if (txtSubject20.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject20.SelectedValue),
                    sessionId = sessionId,
                });
            }
            return subjectData;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClassSubjectMap.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bool result = false;
            if (Request.QueryString["classId"] != null)
            {
                Collection<ClassSubjectMapGridCL> subjectData = SendControls();
                result = classSubjectBLL.updateClassSubjectMap(Convert.ToInt32(Request.QueryString["classId"]), subjectData);
            }
            else
            {
                Collection<ClassSubjectMapGridCL> subjectData = SendControls();
                result = classSubjectBLL.addClassSubjectMap(Convert.ToInt32(ddlClass.SelectedValue), subjectData);
            }
            if (result)
                lblUpdate.Text = "Subject is already there in class. Please add/update class subject again.";
            else
            {
                lblUpdate.Text = "Class Subject Mapping has been added successfully.The page will redirect in 10 seconds.";
                Response.AppendHeader("Refresh", "10;url=ClassSubjectMap.aspx");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Collection<ClassSubjectMapGridCL> subjectData = SendControls();
            int count = classSubjectBLL.deleteClassSubjectMap(Convert.ToInt32(Request.QueryString["classId"]), subjectData);
            lblUpdate.Text = count + "Entries deleted. The page will redirect in 10 seconds.";
            Response.AppendHeader("Refresh", "10;url=ClassSubjectMap.aspx");
        }
    }
}