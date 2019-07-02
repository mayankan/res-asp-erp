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

namespace RAINBOW_ERP.Attendance
{
    public partial class SMSTemplate : System.Web.UI.Page
    {
        StudentLeaveTypesBLL studentLeaveTypeBLL = new StudentLeaveTypesBLL();

        SMSBLL smsBLL = new SMSBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                    ddlStudentLeaveType.DataSource = studentLeaveTypeBLL.viewStudentLeaveTypes();
                    ddlStudentLeaveType.DataValueField = "id";
                    ddlStudentLeaveType.DataTextField = "name";
                    ddlStudentLeaveType.Items.Insert(0, new ListItem("Select", "-1"));
                    ddlStudentLeaveType.DataBind();
                    grdSMS.DataSource = smsBLL.viewSMSTemplates();
                    grdSMS.DataBind();
                }
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            Collection<SMSCL> filteredSMSTemplate = smsBLL.viewSMSTemplates();
            if (ftSMS.Text == string.Empty && ddlStudentLeaveType.SelectedIndex == -1)
            {
                grdSMS.DataSource = filteredSMSTemplate;
                grdSMS.DataBind();
            }
            else
            {
                IEnumerable<SMSCL> filterNewSMS = filteredSMSTemplate;
                Collection<SMSCL> updatedSMS = new Collection<SMSCL>();
                if (ftSMS.Text != string.Empty)
                {
                    filterNewSMS = from x in filterNewSMS where x.template.Contains(ftSMS.Text) select x;
                }
                if (ddlStudentLeaveType.SelectedIndex != -1)
                {
                    filterNewSMS = from x in filterNewSMS where x.studentLeaveTypeId == ddlStudentLeaveType.SelectedIndex select x;
                }
                foreach (SMSCL item in filterNewSMS)
                {
                    updatedSMS.Add(new SMSCL()
                    {
                        dateCreated = item.dateCreated,
                        dateModified = item.dateModified,
                        id = item.id,
                        isDeleted = item.isDeleted,
                        studentLeaveType = item.studentLeaveType,
                        studentLeaveTypeId = item.studentLeaveTypeId,
                        template = item.template,
                    });
                }
                grdSMS.DataSource = updatedSMS;
            }
        }

        protected void grdSMS_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                grdSMS.PageIndex = e.NewSelectedIndex;
                grdSMS.DataSource = smsBLL.viewSMSTemplates();
                grdSMS.DataBind();
            }
            catch (Exception ex)
            {

                throw (new Exception(ex.Message));
            }
        }

        protected void grdSMS_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int smsId = Convert.ToInt32(e.CommandArgument.ToString());
                Response.Redirect("ManageSMSTemplate.aspx?smsId=" + smsId);
            }
            if (e.CommandName == "Delete")
            {
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {
                    int smsId = Convert.ToInt32(e.CommandArgument.ToString());
                    smsBLL.deleteSMS(smsId);
                    Response.Redirect("SMSTemplate.aspx");
                }
                else
                {
                    Response.Redirect("SMSTemplate.aspx");
                }
            }
        }

        protected void btnAddSMSTemplate_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageSMSTemplate.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void grdSMS_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                //re-run the query, use linq to sort the objects based on the arg.
                //perform a search using the constraints given 
                //you could have this saved in Session, rather than requerying your datastore
                Collection<SMSCL> myGridResults = smsBLL.viewSMSTemplates();


                if (myGridResults != null)
                {
                    var param = Expression.Parameter(typeof(SMSCL), e.SortExpression);
                    var sortExpression = Expression.Lambda<Func<SMSCL, object>>(Expression.Convert(Expression.Property(param, e.SortExpression), typeof(object)), param);


                    if (GridViewSortDirection == SortDirection.Ascending)
                    {
                        grdSMS.DataSource = myGridResults.AsQueryable<SMSCL>().OrderBy(sortExpression).ToList();
                        GridViewSortDirection = SortDirection.Descending;
                    }
                    else
                    {
                        grdSMS.DataSource = myGridResults.AsQueryable<SMSCL>().OrderByDescending(sortExpression).ToList();
                        GridViewSortDirection = SortDirection.Ascending;
                    };

                    grdSMS.DataBind();
                }
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
    }
}