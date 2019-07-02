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

namespace RAINBOW_ERP.Student
{
    public partial class Class : System.Web.UI.Page
    {
        ClassBLL classBLL = new ClassBLL();

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
                        grdClass.DataSource = classBLL.viewClasses(sessionId);
                        ViewState["class"] = classBLL.viewClasses(sessionId);
                        grdClass.DataBind();
                    }
                }
            }
        }

        protected void grdClass_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int classId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("ManageClass.aspx?classId=" + classId);
            }
            else if (e.CommandName == "Delete")
            {
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {
                    int classId = Convert.ToInt32(e.CommandArgument);
                    classBLL.deleteClass(classId);
                    Response.Redirect("Class.aspx");
                }
                else
                {
                    Response.Redirect("Class.aspx");
                }
            }
        }

        protected void btnTC_Click(object sender, EventArgs e)
        {
            Response.Redirect("TC.aspx");
        }

        protected void btnAddClass_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageClass.aspx");
        }

        protected void grdClass_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                var classQuery = (Collection<ClassCL>)ViewState["class"];
                Collection<ClassCL> newClass = new Collection<ClassCL>();
                IEnumerable<ClassCL> studentFilter = classQuery;
                var param = Expression.Parameter(typeof(ClassCL), e.SortExpression);
                var sortExpression = Expression.Lambda<Func<ClassCL, object>>(Expression.Convert(Expression.Property(param, e.SortExpression), typeof(object)), param);
                if (GridViewSortDirection == SortDirection.Ascending)
                {
                    studentFilter = studentFilter.AsQueryable<ClassCL>().OrderBy(sortExpression);
                    GridViewSortDirection = SortDirection.Descending;
                }
                else
                {
                    studentFilter = studentFilter.AsQueryable<ClassCL>().OrderByDescending(sortExpression);
                    GridViewSortDirection = SortDirection.Ascending;
                }
                foreach (ClassCL item in studentFilter)
                {
                    newClass.Add(new ClassCL()
                    {
                        class1 = item.class1,
                        classSection = item.classSection,
                        dateCreated = item.dateCreated,
                        dateModified = item.dateModified,
                        id = item.id,
                        isDeleted = item.isDeleted,
                        section = item.section,
                        sessionId = item.sessionId,
                        totalStrength = item.totalStrength,
                    });
                }
                grdClass.DataSource = newClass;
                ViewState["class"] = newClass;
                grdClass.DataBind();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }

        protected SortDirection GridViewSortDirection
        {
            get
            {
                if (ViewState["sortDirection"] == null)
                    ViewState["sortDirection"] = SortDirection.Ascending;

                return (SortDirection)ViewState["sortDirection"];
            }
            set { ViewState["sortDirection"] = value; }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            if (ftClass.Text == string.Empty && ftSection.Text == string.Empty)
            {
                grdClass.DataSource = classBLL.viewClasses(sessionId);
                ViewState["class"] = classBLL.viewClasses(sessionId);
                grdClass.DataBind();
            }
            else
            {
                var classQuery = (Collection<ClassCL>)ViewState["class"];
                Collection<ClassCL> newClass = new Collection<ClassCL>();
                IEnumerable<ClassCL> studentFilter = classQuery;
                if (ftClass.Text != string.Empty)
                {
                    studentFilter = from x in studentFilter where x.class1.ToLower().Contains(ftClass.Text.ToLower()) select x;
                }
                if (ftSection.Text != string.Empty)
                {
                    studentFilter = from x in studentFilter where x.section.ToLower().Contains(ftSection.Text.ToLower()) select x;
                }
                foreach (ClassCL item in studentFilter)
                {
                    newClass.Add(new ClassCL()
                    {
                        class1 = item.class1,
                        classSection = item.classSection,
                        dateCreated = item.dateCreated,
                        dateModified = item.dateModified,
                        id = item.id,
                        isDeleted = item.isDeleted,
                        section = item.section,
                        sessionId = item.sessionId,
                        totalStrength = item.totalStrength,
                    });
                }
                grdClass.DataSource = newClass;
                ViewState["class"] = newClass;
                grdClass.DataBind();
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void grdClass_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdClass.PageIndex = e.NewPageIndex;
                grdClass.DataSource = (Collection<ClassCL>)ViewState["class"];
                grdClass.DataBind();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }
    }
}