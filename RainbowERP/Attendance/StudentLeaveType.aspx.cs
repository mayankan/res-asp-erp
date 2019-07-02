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
    public partial class StudentLeaveType : System.Web.UI.Page
    {
        StudentLeaveTypesBLL studentLTypeBLL = new StudentLeaveTypesBLL();

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
                        grdSLT.DataSource = studentLTypeBLL.viewStudentLeaveTypes();
                        grdSLT.DataBind();
                    } 
                }
            }
        }

        protected void btnAddLeaveType_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageSLT.aspx");
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            if (ftSLT.Text == string.Empty)
            {
                grdSLT.DataSource = studentLTypeBLL.viewStudentLeaveTypes();
                grdSLT.DataBind();
            }
            else
            {
                if (ftSLT.Text != string.Empty)
                {
                    var sltQuery = studentLTypeBLL.viewStudentLeaveTypes();
                    IEnumerable<StudentLeaveTypeCL> studentFilter = sltQuery;
                    Collection<StudentLeaveTypeCL> newStudent = new Collection<StudentLeaveTypeCL>();
                    studentFilter = from x in studentFilter where x.name.Contains(ftSLT.Text) select x;
                    foreach (StudentLeaveTypeCL item in studentFilter)
                    {
                        newStudent.Add(new StudentLeaveTypeCL()
                        {
                            dateCreated = item.dateCreated,
                            dateModified = item.dateModified,
                            id = item.id,
                            isDeleted = item.isDeleted,
                            name = item.name,
                        });
                    }
                    grdSLT.DataSource = newStudent;
                    grdSLT.DataBind();
                }
            }
        }

        protected void grdSLT_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int sltId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("ManageSLT.aspx?sltId=" + sltId);
            }
            else if (e.CommandName == "Delete")
            {
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {
                    int sltId = Convert.ToInt32(e.CommandArgument);
                    studentLTypeBLL.deleteSLT(sltId);
                    Response.Redirect("StudentCategory.aspx");
                }
                else
                {
                    Response.Redirect("StudentCategory.aspx");
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void grdSLT_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                //re-run the query, use linq to sort the objects based on the arg.
                //perform a search using the constraints given 
                //you could have this saved in Session, rather than requerying your datastore
                Collection<StudentLeaveTypeCL> myGridResults = studentLTypeBLL.viewStudentLeaveTypes();


                if (myGridResults != null)
                {
                    var param = Expression.Parameter(typeof(StudentLeaveTypeCL), e.SortExpression);
                    var sortExpression = Expression.Lambda<Func<StudentLeaveTypeCL, object>>(Expression.Convert(Expression.Property(param, e.SortExpression), typeof(object)), param);


                    if (GridViewSortDirection == SortDirection.Ascending)
                    {
                        grdSLT.DataSource = myGridResults.AsQueryable<StudentLeaveTypeCL>().OrderBy(sortExpression).ToList();
                        GridViewSortDirection = SortDirection.Descending;
                    }
                    else
                    {
                        grdSLT.DataSource = myGridResults.AsQueryable<StudentLeaveTypeCL>().OrderByDescending(sortExpression).ToList();
                        GridViewSortDirection = SortDirection.Ascending;
                    };
                    grdSLT.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }

        protected void grdSLT_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdSLT.PageIndex = e.NewPageIndex;
                grdSLT.DataSource = studentLTypeBLL.viewStudentLeaveTypes();
                grdSLT.DataBind();
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