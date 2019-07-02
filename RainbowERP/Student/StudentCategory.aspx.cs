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

namespace RAINBOW_ERP.Student
{
    public partial class StudentCategory : System.Web.UI.Page
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
                        grdSC.DataSource = studentCategoryBLL.viewStudentCategories();
                        grdSC.DataBind();
                    } 
                }
            }
        }

        protected void btnAddSC_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageSC.aspx");
        }

        protected void grdSC_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int scId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("ManageSC.aspx?scId=" + scId);
            }
            else if (e.CommandName == "Delete")
            {
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {
                    int scId = Convert.ToInt32(e.CommandArgument);
                    studentCategoryBLL.deleteSC(scId);
                    Response.Redirect("StudentCategory.aspx");
                }
                else
                {
                    Response.Redirect("StudentCategory.aspx");
                }
            }
        }
        
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            if(ftSC.Text == string.Empty)
            {
                grdSC.DataSource = studentCategoryBLL.viewStudentCategories();
                grdSC.DataBind();
            }
            else
            {
                if (ftSC.Text != string.Empty)
                {
                    var scQuery = studentCategoryBLL.viewStudentCategories();
                    IEnumerable<StudentCategoryCL> studentFilter = scQuery;
                    Collection<StudentCategoryCL> newStudent = new Collection<StudentCategoryCL>();
                    studentFilter = from x in studentFilter where x.name.Contains(ftSC.Text) select x;
                    foreach (StudentCategoryCL item in studentFilter)
                    {
                        newStudent.Add(new StudentCategoryCL()
                        {
                            dateCreated = item.dateCreated,
                            dateModified = item.dateModified,
                            id = item.id,
                            isDeleted = item.isDeleted,
                            name = item.name,
                            totalStrength = item.totalStrength,
                        });
                    }
                    grdSC.DataSource = newStudent;
                    grdSC.DataBind();
                } 
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void grdSC_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdSC.PageIndex = e.NewPageIndex;
                grdSC.DataSource = studentCategoryBLL.viewStudentCategories();
                grdSC.DataBind();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }

        protected void grdSC_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                //re-run the query, use linq to sort the objects based on the arg.
                //perform a search using the constraints given 
                //you could have this saved in Session, rather than requerying your datastore
                Collection<StudentCategoryCL> myGridResults = studentCategoryBLL.viewStudentCategories();


                if (myGridResults != null)
                {
                    var param = Expression.Parameter(typeof(StudentCategoryCL), e.SortExpression);
                    var sortExpression = Expression.Lambda<Func<StudentCategoryCL, object>>(Expression.Convert(Expression.Property(param, e.SortExpression), typeof(object)), param);


                    if (GridViewSortDirection == SortDirection.Ascending)
                    {
                        grdSC.DataSource = myGridResults.AsQueryable<StudentCategoryCL>().OrderBy(sortExpression).ToList();
                        GridViewSortDirection = SortDirection.Descending;
                    }
                    else
                    {
                        grdSC.DataSource = myGridResults.AsQueryable<StudentCategoryCL>().OrderByDescending(sortExpression).ToList();
                        GridViewSortDirection = SortDirection.Ascending;
                    };


                    grdSC.DataBind();
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