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
    public partial class ManageGClassSubject : System.Web.UI.Page
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
                    else if (role.ToLower() != "su")
                    {
                        Response.Redirect("../UnAuthorized.aspx");
                    }
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

        public void FetchControls()
        {
            ddlClass.DataSource = classBLL.viewClasses(0);
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
            txtSubject21.DataSource = subjectBLL.viewSubjects();
            txtSubject21.DataValueField = "id";
            txtSubject21.DataTextField = "name";
            txtSubject21.DataBind();
            txtSubject21.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject22.DataSource = subjectBLL.viewSubjects();
            txtSubject22.DataValueField = "id";
            txtSubject22.DataTextField = "name";
            txtSubject22.DataBind();
            txtSubject22.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject23.DataSource = subjectBLL.viewSubjects();
            txtSubject23.DataValueField = "id";
            txtSubject23.DataTextField = "name";
            txtSubject23.DataBind();
            txtSubject23.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject24.DataSource = subjectBLL.viewSubjects();
            txtSubject24.DataValueField = "id";
            txtSubject24.DataTextField = "name";
            txtSubject24.DataBind();
            txtSubject24.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject25.DataSource = subjectBLL.viewSubjects();
            txtSubject25.DataValueField = "id";
            txtSubject25.DataTextField = "name";
            txtSubject25.DataBind();
            txtSubject25.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject26.DataSource = subjectBLL.viewSubjects();
            txtSubject26.DataValueField = "id";
            txtSubject26.DataTextField = "name";
            txtSubject26.DataBind();
            txtSubject26.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject27.DataSource = subjectBLL.viewSubjects();
            txtSubject27.DataValueField = "id";
            txtSubject27.DataTextField = "name";
            txtSubject27.DataBind();
            txtSubject27.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject28.DataSource = subjectBLL.viewSubjects();
            txtSubject28.DataValueField = "id";
            txtSubject28.DataTextField = "name";
            txtSubject28.DataBind();
            txtSubject28.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject29.DataSource = subjectBLL.viewSubjects();
            txtSubject29.DataValueField = "id";
            txtSubject29.DataTextField = "name";
            txtSubject29.DataBind();
            txtSubject29.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject30.DataSource = subjectBLL.viewSubjects();
            txtSubject30.DataValueField = "id";
            txtSubject30.DataTextField = "name";
            txtSubject30.DataBind();
            txtSubject31.DataSource = subjectBLL.viewSubjects();
            txtSubject31.DataValueField = "id";
            txtSubject31.DataTextField = "name";
            txtSubject31.DataBind();
            txtSubject31.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject32.DataSource = subjectBLL.viewSubjects();
            txtSubject32.DataValueField = "id";
            txtSubject32.DataTextField = "name";
            txtSubject32.DataBind();
            txtSubject32.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject33.DataSource = subjectBLL.viewSubjects();
            txtSubject33.DataValueField = "id";
            txtSubject33.DataTextField = "name";
            txtSubject33.DataBind();
            txtSubject33.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject34.DataSource = subjectBLL.viewSubjects();
            txtSubject34.DataValueField = "id";
            txtSubject34.DataTextField = "name";
            txtSubject34.DataBind();
            txtSubject34.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject35.DataSource = subjectBLL.viewSubjects();
            txtSubject35.DataValueField = "id";
            txtSubject35.DataTextField = "name";
            txtSubject35.DataBind();
            txtSubject35.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject36.DataSource = subjectBLL.viewSubjects();
            txtSubject36.DataValueField = "id";
            txtSubject36.DataTextField = "name";
            txtSubject36.DataBind();
            txtSubject36.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject37.DataSource = subjectBLL.viewSubjects();
            txtSubject37.DataValueField = "id";
            txtSubject37.DataTextField = "name";
            txtSubject37.DataBind();
            txtSubject37.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject38.DataSource = subjectBLL.viewSubjects();
            txtSubject38.DataValueField = "id";
            txtSubject38.DataTextField = "name";
            txtSubject38.DataBind();
            txtSubject38.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject39.DataSource = subjectBLL.viewSubjects();
            txtSubject39.DataValueField = "id";
            txtSubject39.DataTextField = "name";
            txtSubject39.DataBind();
            txtSubject39.Items.Insert(0, new ListItem("Select", "Select"));
            txtSubject40.DataSource = subjectBLL.viewSubjects();
            txtSubject40.DataValueField = "id";
            txtSubject40.DataTextField = "name";
            txtSubject40.DataBind();
            txtSubject40.Items.Insert(0, new ListItem("Select", "Select"));
        }

        public void SwitchCase(int classId)
        {
            Collection<SubjectCL> subjectCol = subjectBLL.viewSubjectByClassId(classId);
            List<SubjectCL> newSubjectColCL = subjectCol.ToList();
            newSubjectColCL.Sort((x, y) => x.name.ToLower().CompareTo(y.name.ToLower()));
            Collection<SubjectCL> subjectColCL = new Collection<SubjectCL>();
            foreach (SubjectCL item in newSubjectColCL)
            {
                subjectColCL.Add(new SubjectCL()
                {
                    dateCreated = item.dateCreated,
                    dateModified = item.dateModified,
                    id = item.id,
                    isDeleted = item.isDeleted,
                    name = item.name,
                    totalClasses = item.totalClasses,
                });
            }
            switch (subjectColCL.Count())
            {
                case 1:
                    //for(int i=1;i<2;i++)
                    //{
                    //    DropDownList dpDown = new DropDownList();
                    //    dpDown.ID = subjectColCL[i].id.ToString();
                    //}
                    txtSubject1.SelectedValue = subjectColCL[0].id.ToString();
                    break;
                case 2:
                    txtSubject1.SelectedValue = subjectColCL[0].id.ToString();
                    txtSubject2.SelectedValue = subjectColCL[1].id.ToString();
                    break;
                case 3:
                    txtSubject1.SelectedValue = subjectColCL[0].id.ToString();
                    txtSubject2.SelectedValue = subjectColCL[1].id.ToString();
                    txtSubject3.SelectedValue = subjectColCL[2].id.ToString();
                    break;
                case 4:
                    txtSubject1.SelectedValue = subjectColCL[0].id.ToString();
                    txtSubject2.SelectedValue = subjectColCL[1].id.ToString();
                    txtSubject3.SelectedValue = subjectColCL[2].id.ToString();
                    txtSubject4.SelectedValue = subjectColCL[3].id.ToString();
                    break;
                case 5:
                    txtSubject1.SelectedValue = subjectColCL[0].id.ToString();
                    txtSubject2.SelectedValue = subjectColCL[1].id.ToString();
                    txtSubject3.SelectedValue = subjectColCL[2].id.ToString();
                    txtSubject4.SelectedValue = subjectColCL[3].id.ToString();
                    txtSubject5.SelectedValue = subjectColCL[4].id.ToString();
                    break;
                case 6:
                    txtSubject1.SelectedValue = subjectColCL[0].id.ToString();
                    txtSubject2.SelectedValue = subjectColCL[1].id.ToString();
                    txtSubject3.SelectedValue = subjectColCL[2].id.ToString();
                    txtSubject4.SelectedValue = subjectColCL[3].id.ToString();
                    txtSubject5.SelectedValue = subjectColCL[4].id.ToString();
                    txtSubject6.SelectedValue = subjectColCL[5].id.ToString();
                    break;
                case 7:
                    //for (int i = 1; i < 8; i++)
                    //{
                    //    DropDownList dpDown = new DropDownList();
                    //    dpDown.ID = subjectColCL[i].id.ToString();
                    //}
                    txtSubject1.SelectedValue = subjectColCL[0].id.ToString();
                    txtSubject2.SelectedValue = subjectColCL[1].id.ToString();
                    txtSubject3.SelectedValue = subjectColCL[2].id.ToString();
                    txtSubject4.SelectedValue = subjectColCL[3].id.ToString();
                    txtSubject5.SelectedValue = subjectColCL[4].id.ToString();
                    txtSubject6.SelectedValue = subjectColCL[5].id.ToString();
                    txtSubject7.SelectedValue = subjectColCL[6].id.ToString();
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
                case 21:
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
                    txtSubject21.SelectedValue = subjectColCL[20].id.ToString();
                    break;
                case 22:
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
                    txtSubject21.SelectedValue = subjectColCL[20].id.ToString();
                    txtSubject22.SelectedValue = subjectColCL[21].id.ToString();
                    break;
                case 23:
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
                    txtSubject21.SelectedValue = subjectColCL[20].id.ToString();
                    txtSubject22.SelectedValue = subjectColCL[21].id.ToString();
                    txtSubject23.SelectedValue = subjectColCL[22].id.ToString();
                    break;
                case 24:
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
                    txtSubject21.SelectedValue = subjectColCL[20].id.ToString();
                    txtSubject22.SelectedValue = subjectColCL[21].id.ToString();
                    txtSubject23.SelectedValue = subjectColCL[22].id.ToString();
                    txtSubject24.SelectedValue = subjectColCL[23].id.ToString();
                    break;
                case 25:
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
                    txtSubject21.SelectedValue = subjectColCL[20].id.ToString();
                    txtSubject22.SelectedValue = subjectColCL[21].id.ToString();
                    txtSubject23.SelectedValue = subjectColCL[22].id.ToString();
                    txtSubject24.SelectedValue = subjectColCL[23].id.ToString();
                    txtSubject25.SelectedValue = subjectColCL[24].id.ToString();
                    break;
                case 26:
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
                    txtSubject21.SelectedValue = subjectColCL[20].id.ToString();
                    txtSubject22.SelectedValue = subjectColCL[21].id.ToString();
                    txtSubject23.SelectedValue = subjectColCL[22].id.ToString();
                    txtSubject24.SelectedValue = subjectColCL[23].id.ToString();
                    txtSubject25.SelectedValue = subjectColCL[24].id.ToString();
                    txtSubject26.SelectedValue = subjectColCL[25].id.ToString();
                    break;
                case 27:
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
                    txtSubject21.SelectedValue = subjectColCL[20].id.ToString();
                    txtSubject22.SelectedValue = subjectColCL[21].id.ToString();
                    txtSubject23.SelectedValue = subjectColCL[22].id.ToString();
                    txtSubject24.SelectedValue = subjectColCL[23].id.ToString();
                    txtSubject25.SelectedValue = subjectColCL[24].id.ToString();
                    txtSubject26.SelectedValue = subjectColCL[25].id.ToString();
                    txtSubject27.SelectedValue = subjectColCL[26].id.ToString();
                    break;
                case 28:
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
                    txtSubject21.SelectedValue = subjectColCL[20].id.ToString();
                    txtSubject22.SelectedValue = subjectColCL[21].id.ToString();
                    txtSubject23.SelectedValue = subjectColCL[22].id.ToString();
                    txtSubject24.SelectedValue = subjectColCL[23].id.ToString();
                    txtSubject25.SelectedValue = subjectColCL[24].id.ToString();
                    txtSubject26.SelectedValue = subjectColCL[25].id.ToString();
                    txtSubject27.SelectedValue = subjectColCL[26].id.ToString();
                    txtSubject28.SelectedValue = subjectColCL[27].id.ToString();
                    break;
                case 29:
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
                    txtSubject21.SelectedValue = subjectColCL[20].id.ToString();
                    txtSubject22.SelectedValue = subjectColCL[21].id.ToString();
                    txtSubject23.SelectedValue = subjectColCL[22].id.ToString();
                    txtSubject24.SelectedValue = subjectColCL[23].id.ToString();
                    txtSubject25.SelectedValue = subjectColCL[24].id.ToString();
                    txtSubject26.SelectedValue = subjectColCL[25].id.ToString();
                    txtSubject27.SelectedValue = subjectColCL[26].id.ToString();
                    txtSubject28.SelectedValue = subjectColCL[27].id.ToString();
                    txtSubject29.SelectedValue = subjectColCL[28].id.ToString();
                    break;
                case 30:
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
                    txtSubject21.SelectedValue = subjectColCL[20].id.ToString();
                    txtSubject22.SelectedValue = subjectColCL[21].id.ToString();
                    txtSubject23.SelectedValue = subjectColCL[22].id.ToString();
                    txtSubject24.SelectedValue = subjectColCL[23].id.ToString();
                    txtSubject25.SelectedValue = subjectColCL[24].id.ToString();
                    txtSubject26.SelectedValue = subjectColCL[25].id.ToString();
                    txtSubject27.SelectedValue = subjectColCL[26].id.ToString();
                    txtSubject28.SelectedValue = subjectColCL[27].id.ToString();
                    txtSubject29.SelectedValue = subjectColCL[28].id.ToString();
                    txtSubject30.SelectedValue = subjectColCL[29].id.ToString();
                    break;
                case 31:
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
                    txtSubject21.SelectedValue = subjectColCL[20].id.ToString();
                    txtSubject22.SelectedValue = subjectColCL[21].id.ToString();
                    txtSubject23.SelectedValue = subjectColCL[22].id.ToString();
                    txtSubject24.SelectedValue = subjectColCL[23].id.ToString();
                    txtSubject25.SelectedValue = subjectColCL[24].id.ToString();
                    txtSubject26.SelectedValue = subjectColCL[25].id.ToString();
                    txtSubject27.SelectedValue = subjectColCL[26].id.ToString();
                    txtSubject28.SelectedValue = subjectColCL[27].id.ToString();
                    txtSubject29.SelectedValue = subjectColCL[28].id.ToString();
                    txtSubject30.SelectedValue = subjectColCL[29].id.ToString();
                    txtSubject31.SelectedValue = subjectColCL[30].id.ToString();
                    break;
                case 32:
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
                    txtSubject21.SelectedValue = subjectColCL[20].id.ToString();
                    txtSubject22.SelectedValue = subjectColCL[21].id.ToString();
                    txtSubject23.SelectedValue = subjectColCL[22].id.ToString();
                    txtSubject24.SelectedValue = subjectColCL[23].id.ToString();
                    txtSubject25.SelectedValue = subjectColCL[24].id.ToString();
                    txtSubject26.SelectedValue = subjectColCL[25].id.ToString();
                    txtSubject27.SelectedValue = subjectColCL[26].id.ToString();
                    txtSubject28.SelectedValue = subjectColCL[27].id.ToString();
                    txtSubject29.SelectedValue = subjectColCL[28].id.ToString();
                    txtSubject30.SelectedValue = subjectColCL[29].id.ToString();
                    txtSubject31.SelectedValue = subjectColCL[30].id.ToString();
                    txtSubject32.SelectedValue = subjectColCL[31].id.ToString();
                    break;
                case 33:
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
                    txtSubject21.SelectedValue = subjectColCL[20].id.ToString();
                    txtSubject22.SelectedValue = subjectColCL[21].id.ToString();
                    txtSubject23.SelectedValue = subjectColCL[22].id.ToString();
                    txtSubject24.SelectedValue = subjectColCL[23].id.ToString();
                    txtSubject25.SelectedValue = subjectColCL[24].id.ToString();
                    txtSubject26.SelectedValue = subjectColCL[25].id.ToString();
                    txtSubject27.SelectedValue = subjectColCL[26].id.ToString();
                    txtSubject28.SelectedValue = subjectColCL[27].id.ToString();
                    txtSubject29.SelectedValue = subjectColCL[28].id.ToString();
                    txtSubject30.SelectedValue = subjectColCL[29].id.ToString();
                    txtSubject31.SelectedValue = subjectColCL[30].id.ToString();
                    txtSubject32.SelectedValue = subjectColCL[31].id.ToString();
                    txtSubject33.SelectedValue = subjectColCL[32].id.ToString();
                    break;
                case 34:
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
                    txtSubject21.SelectedValue = subjectColCL[20].id.ToString();
                    txtSubject22.SelectedValue = subjectColCL[21].id.ToString();
                    txtSubject23.SelectedValue = subjectColCL[22].id.ToString();
                    txtSubject24.SelectedValue = subjectColCL[23].id.ToString();
                    txtSubject25.SelectedValue = subjectColCL[24].id.ToString();
                    txtSubject26.SelectedValue = subjectColCL[25].id.ToString();
                    txtSubject27.SelectedValue = subjectColCL[26].id.ToString();
                    txtSubject28.SelectedValue = subjectColCL[27].id.ToString();
                    txtSubject29.SelectedValue = subjectColCL[28].id.ToString();
                    txtSubject30.SelectedValue = subjectColCL[29].id.ToString();
                    txtSubject31.SelectedValue = subjectColCL[30].id.ToString();
                    txtSubject32.SelectedValue = subjectColCL[31].id.ToString();
                    txtSubject33.SelectedValue = subjectColCL[32].id.ToString();
                    txtSubject34.SelectedValue = subjectColCL[33].id.ToString();
                    break;
                case 35:
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
                    txtSubject21.SelectedValue = subjectColCL[20].id.ToString();
                    txtSubject22.SelectedValue = subjectColCL[21].id.ToString();
                    txtSubject23.SelectedValue = subjectColCL[22].id.ToString();
                    txtSubject24.SelectedValue = subjectColCL[23].id.ToString();
                    txtSubject25.SelectedValue = subjectColCL[24].id.ToString();
                    txtSubject26.SelectedValue = subjectColCL[25].id.ToString();
                    txtSubject27.SelectedValue = subjectColCL[26].id.ToString();
                    txtSubject28.SelectedValue = subjectColCL[27].id.ToString();
                    txtSubject29.SelectedValue = subjectColCL[28].id.ToString();
                    txtSubject30.SelectedValue = subjectColCL[29].id.ToString();
                    txtSubject31.SelectedValue = subjectColCL[30].id.ToString();
                    txtSubject32.SelectedValue = subjectColCL[31].id.ToString();
                    txtSubject33.SelectedValue = subjectColCL[32].id.ToString();
                    txtSubject34.SelectedValue = subjectColCL[33].id.ToString();
                    txtSubject35.SelectedValue = subjectColCL[34].id.ToString();
                    break;
                case 36:
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
                    txtSubject21.SelectedValue = subjectColCL[20].id.ToString();
                    txtSubject22.SelectedValue = subjectColCL[21].id.ToString();
                    txtSubject23.SelectedValue = subjectColCL[22].id.ToString();
                    txtSubject24.SelectedValue = subjectColCL[23].id.ToString();
                    txtSubject25.SelectedValue = subjectColCL[24].id.ToString();
                    txtSubject26.SelectedValue = subjectColCL[25].id.ToString();
                    txtSubject27.SelectedValue = subjectColCL[26].id.ToString();
                    txtSubject28.SelectedValue = subjectColCL[27].id.ToString();
                    txtSubject29.SelectedValue = subjectColCL[28].id.ToString();
                    txtSubject30.SelectedValue = subjectColCL[29].id.ToString();
                    txtSubject31.SelectedValue = subjectColCL[30].id.ToString();
                    txtSubject32.SelectedValue = subjectColCL[31].id.ToString();
                    txtSubject33.SelectedValue = subjectColCL[32].id.ToString();
                    txtSubject34.SelectedValue = subjectColCL[33].id.ToString();
                    txtSubject35.SelectedValue = subjectColCL[34].id.ToString();
                    txtSubject36.SelectedValue = subjectColCL[35].id.ToString();
                    break;
                case 37:
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
                    txtSubject21.SelectedValue = subjectColCL[20].id.ToString();
                    txtSubject22.SelectedValue = subjectColCL[21].id.ToString();
                    txtSubject23.SelectedValue = subjectColCL[22].id.ToString();
                    txtSubject24.SelectedValue = subjectColCL[23].id.ToString();
                    txtSubject25.SelectedValue = subjectColCL[24].id.ToString();
                    txtSubject26.SelectedValue = subjectColCL[25].id.ToString();
                    txtSubject27.SelectedValue = subjectColCL[26].id.ToString();
                    txtSubject28.SelectedValue = subjectColCL[27].id.ToString();
                    txtSubject29.SelectedValue = subjectColCL[28].id.ToString();
                    txtSubject30.SelectedValue = subjectColCL[29].id.ToString();
                    txtSubject31.SelectedValue = subjectColCL[30].id.ToString();
                    txtSubject32.SelectedValue = subjectColCL[31].id.ToString();
                    txtSubject33.SelectedValue = subjectColCL[32].id.ToString();
                    txtSubject34.SelectedValue = subjectColCL[33].id.ToString();
                    txtSubject35.SelectedValue = subjectColCL[34].id.ToString();
                    txtSubject36.SelectedValue = subjectColCL[35].id.ToString();
                    txtSubject37.SelectedValue = subjectColCL[36].id.ToString();
                    break;
                case 38:
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
                    txtSubject21.SelectedValue = subjectColCL[20].id.ToString();
                    txtSubject22.SelectedValue = subjectColCL[21].id.ToString();
                    txtSubject23.SelectedValue = subjectColCL[22].id.ToString();
                    txtSubject24.SelectedValue = subjectColCL[23].id.ToString();
                    txtSubject25.SelectedValue = subjectColCL[24].id.ToString();
                    txtSubject26.SelectedValue = subjectColCL[25].id.ToString();
                    txtSubject27.SelectedValue = subjectColCL[26].id.ToString();
                    txtSubject28.SelectedValue = subjectColCL[27].id.ToString();
                    txtSubject29.SelectedValue = subjectColCL[28].id.ToString();
                    txtSubject30.SelectedValue = subjectColCL[29].id.ToString();
                    txtSubject31.SelectedValue = subjectColCL[30].id.ToString();
                    txtSubject32.SelectedValue = subjectColCL[31].id.ToString();
                    txtSubject33.SelectedValue = subjectColCL[32].id.ToString();
                    txtSubject34.SelectedValue = subjectColCL[33].id.ToString();
                    txtSubject35.SelectedValue = subjectColCL[34].id.ToString();
                    txtSubject36.SelectedValue = subjectColCL[35].id.ToString();
                    txtSubject37.SelectedValue = subjectColCL[36].id.ToString();
                    txtSubject38.SelectedValue = subjectColCL[37].id.ToString();
                    break;
                case 39:
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
                    txtSubject21.SelectedValue = subjectColCL[20].id.ToString();
                    txtSubject22.SelectedValue = subjectColCL[21].id.ToString();
                    txtSubject23.SelectedValue = subjectColCL[22].id.ToString();
                    txtSubject24.SelectedValue = subjectColCL[23].id.ToString();
                    txtSubject25.SelectedValue = subjectColCL[24].id.ToString();
                    txtSubject26.SelectedValue = subjectColCL[25].id.ToString();
                    txtSubject27.SelectedValue = subjectColCL[26].id.ToString();
                    txtSubject28.SelectedValue = subjectColCL[27].id.ToString();
                    txtSubject29.SelectedValue = subjectColCL[28].id.ToString();
                    txtSubject30.SelectedValue = subjectColCL[29].id.ToString();
                    txtSubject31.SelectedValue = subjectColCL[30].id.ToString();
                    txtSubject32.SelectedValue = subjectColCL[31].id.ToString();
                    txtSubject33.SelectedValue = subjectColCL[32].id.ToString();
                    txtSubject34.SelectedValue = subjectColCL[33].id.ToString();
                    txtSubject35.SelectedValue = subjectColCL[34].id.ToString();
                    txtSubject36.SelectedValue = subjectColCL[35].id.ToString();
                    txtSubject37.SelectedValue = subjectColCL[36].id.ToString();
                    txtSubject38.SelectedValue = subjectColCL[37].id.ToString();
                    txtSubject39.SelectedValue = subjectColCL[38].id.ToString();
                    break;
                case 40:
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
                    txtSubject21.SelectedValue = subjectColCL[20].id.ToString();
                    txtSubject22.SelectedValue = subjectColCL[21].id.ToString();
                    txtSubject23.SelectedValue = subjectColCL[22].id.ToString();
                    txtSubject24.SelectedValue = subjectColCL[23].id.ToString();
                    txtSubject25.SelectedValue = subjectColCL[24].id.ToString();
                    txtSubject26.SelectedValue = subjectColCL[25].id.ToString();
                    txtSubject27.SelectedValue = subjectColCL[26].id.ToString();
                    txtSubject28.SelectedValue = subjectColCL[27].id.ToString();
                    txtSubject29.SelectedValue = subjectColCL[28].id.ToString();
                    txtSubject30.SelectedValue = subjectColCL[29].id.ToString();
                    txtSubject31.SelectedValue = subjectColCL[30].id.ToString();
                    txtSubject32.SelectedValue = subjectColCL[31].id.ToString();
                    txtSubject33.SelectedValue = subjectColCL[32].id.ToString();
                    txtSubject34.SelectedValue = subjectColCL[33].id.ToString();
                    txtSubject35.SelectedValue = subjectColCL[34].id.ToString();
                    txtSubject36.SelectedValue = subjectColCL[35].id.ToString();
                    txtSubject37.SelectedValue = subjectColCL[36].id.ToString();
                    txtSubject38.SelectedValue = subjectColCL[37].id.ToString();
                    txtSubject39.SelectedValue = subjectColCL[38].id.ToString();
                    txtSubject40.SelectedValue = subjectColCL[39].id.ToString();
                    break;
            }
        }

        public Collection<ClassSubjectMapGridCL> SendControls()
        {
            Collection<ClassSubjectMapGridCL> subjectData = new Collection<ClassSubjectMapGridCL>();
            if (txtSubject1.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject1.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject2.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject2.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject3.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject3.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject4.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject4.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject5.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject5.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject6.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject6.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject7.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject7.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject8.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject8.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject9.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject9.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject10.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject10.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject11.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject11.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject12.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject12.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject13.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject13.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject14.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject14.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject15.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject15.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject16.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject16.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject17.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject17.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject18.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject18.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject19.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject19.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject20.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject20.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject21.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject21.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject22.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject22.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject23.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject23.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject24.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject24.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject25.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject25.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject26.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject26.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject27.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject27.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject28.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject28.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject29.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject29.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject30.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject30.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject31.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject31.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject32.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject32.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject33.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject33.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject34.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject34.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject35.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject35.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject36.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject36.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject37.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject37.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject38.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject38.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject39.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject39.SelectedValue),
                    sessionId = 0,
                });
            }
            if (txtSubject40.SelectedValue != "Select")
            {
                subjectData.Add(new ClassSubjectMapGridCL()
                {
                    classId = Convert.ToInt32(ddlClass.SelectedValue),
                    classSection = ddlClass.SelectedItem.ToString(),
                    subjectId = Convert.ToInt32(txtSubject40.SelectedValue),
                    sessionId = 0,
                });
            }
            return subjectData;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["classId"] != null)
            {
                Collection<ClassSubjectMapGridCL> subjectData = SendControls();
                classSubjectBLL.updateClassSubjectMap(Convert.ToInt32(Request.QueryString["classId"]), subjectData);
            }
            else
            {
                Collection<ClassSubjectMapGridCL> subjectData = SendControls();
                classSubjectBLL.addClassSubjectMap(Convert.ToInt32(Request.QueryString["classId"]), subjectData);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Collection<ClassSubjectMapGridCL> subjectData = SendControls();
            int count = classSubjectBLL.deleteClassSubjectMap(Convert.ToInt32(Request.QueryString["classId"]), subjectData);
            lblUpdate.Text = count + "Entries deleted. The page will redirect in 10 seconds.";
            Response.AppendHeader("Refresh", "10;url=ClassSubjectMap.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClassSubjectMap.aspx");
        }
    }
}