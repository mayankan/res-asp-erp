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
    public partial class index : System.Web.UI.Page
    {
        AttendanceBLL attendanceBLL = new AttendanceBLL();

        SessionBLL sessionBLL = new SessionBLL();

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
                    else if (role.ToLower() == "teacher")
                    {
                        Response.Redirect("../UnAuthorized.aspx");
                    }
                    else
                    {
                        sessionId = Convert.ToInt32(Session["sessionId"]);
                        grdAttendance.DataSource = attendanceBLL.viewAttendanceSortedByDate(sessionId);
                        ViewState["attendance"] = attendanceBLL.viewAttendanceSortedByDate(sessionId);
                        grdAttendance.DataBind();
                    }
                }
            }
        }

        protected void btnAddAttendance_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageAttendance.aspx");
        }

        protected void grdAttendance_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                int classId = Convert.ToInt32(commandArgs[0]);
                DateTime date = Convert.ToDateTime(commandArgs[1]);
                Response.Redirect("ManageAttendance.aspx?classId=" + classId + "&date=" + date.ToShortDateString());
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            if (ftClass.Text == string.Empty && ftSection.Text == string.Empty && ftDateFrom.Text == string.Empty && ftDateTo.Text == string.Empty)
            {
                grdAttendance.DataSource = attendanceBLL.viewAttendanceSortedByDate(sessionId);
                ViewState["attendance"] = attendanceBLL.viewAttendanceSortedByDate(sessionId);
                grdAttendance.DataBind();
            }
            else
            {
                var classAttendanceCol = attendanceBLL.viewAttendance(sessionId);
                IEnumerable<AttendanceGridCL> attendanceColGet = classAttendanceCol;
                Collection<AttendanceGridCL> newAttendanceCol = new Collection<AttendanceGridCL>();
                if (ftClass.Text != string.Empty)
                {
                    attendanceColGet = from x in attendanceColGet where x.class1.Contains(ftClass.Text) select x;
                }
                if (ftSection.Text != string.Empty)
                {
                    attendanceColGet = from x in attendanceColGet where x.section.Contains(ftSection.Text) select x;
                }
                if (ftDateFrom.Text != string.Empty)
                {
                    attendanceColGet = from x in attendanceColGet where x.date > Convert.ToDateTime(ftDateFrom.Text) select x;
                }
                if (ftDateTo.Text != string.Empty)
                {
                    attendanceColGet = from x in attendanceColGet where x.date < Convert.ToDateTime(ftDateTo.Text) select x;
                }
                foreach (AttendanceGridCL item in attendanceColGet)
                {
                    newAttendanceCol.Add(new AttendanceGridCL()
                    {
                        dateCreated = item.dateCreated,
                        studentLeaveType = item.studentLeaveType,
                        dateModified = item.dateModified,
                        date = item.date,
                        id = item.id,
                        isDeleted = item.isDeleted,
                        studentId = item.studentId,
                        studentLeaveTypeId = item.studentLeaveTypeId,
                        classId = item.classId,
                        class1 = item.class1,
                        section = item.section,
                        noOfAbsentees = item.noOfAbsentees,
                    });
                }
                grdAttendance.DataSource = newAttendanceCol;
                ViewState["attendance"] = newAttendanceCol;
                grdAttendance.DataBind();
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void grdAttendance_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                //re-run the query, use linq to sort the objects based on the arg.
                //perform a search using the constraints given 
                //you could have this saved in Session, rather than requerying your datastore

                var attendanceCol = (Collection<AttendanceGridCL>)ViewState["attendance"];
                IEnumerable<AttendanceGridCL> attendanceColGet = attendanceCol;
                Collection<AttendanceGridCL> newAttendanceCol = new Collection<AttendanceGridCL>();

                if (attendanceColGet != null)
                {
                    var param = Expression.Parameter(typeof(AttendanceGridCL), e.SortExpression);
                    var sortExpression = Expression.Lambda<Func<AttendanceGridCL, object>>(Expression.Convert(Expression.Property(param, e.SortExpression), typeof(object)), param);


                    if (GridViewSortDirection == SortDirection.Ascending)
                    {
                        attendanceColGet = attendanceColGet.AsQueryable<AttendanceGridCL>().OrderBy(sortExpression).ToList();
                        GridViewSortDirection = SortDirection.Descending;
                    }
                    else
                    {
                        attendanceColGet = attendanceColGet.AsQueryable<AttendanceGridCL>().OrderByDescending(sortExpression).ToList();
                        GridViewSortDirection = SortDirection.Ascending;
                    };
                    foreach (AttendanceGridCL item in attendanceColGet)
                    {
                        newAttendanceCol.Add(new AttendanceGridCL()
                        {
                            dateCreated = item.dateCreated,
                            studentLeaveType = item.studentLeaveType,
                            dateModified = item.dateModified,
                            date = item.date,
                            id = item.id,
                            isDeleted = item.isDeleted,
                            studentId = item.studentId,
                            studentLeaveTypeId = item.studentLeaveTypeId,
                            classId = item.classId,
                            class1 = item.class1,
                            section = item.section,
                            noOfAbsentees = item.noOfAbsentees,
                        });
                    }
                    grdAttendance.DataSource = newAttendanceCol;
                    ViewState["attendance"] = newAttendanceCol;
                    grdAttendance.DataBind();
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

        protected void grdAttendance_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdAttendance.PageIndex = e.NewPageIndex;
                grdAttendance.DataSource = (Collection<AttendanceGridCL>)ViewState["attendance"];
                grdAttendance.DataBind();
            }
            catch (Exception ex)
            {

                throw (new Exception(ex.Message));
            }
        }
    }
}