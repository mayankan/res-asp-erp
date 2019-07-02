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

namespace RAINBOW_ERP.Attendance
{
    public partial class ManageAttendance : System.Web.UI.Page
    {
        SessionBLL sessionBLL = new SessionBLL();
        StudentLeaveTypesBLL stlBLL = new StudentLeaveTypesBLL();
        ClassBLL classBLL = new ClassBLL();
        StudentBLL studentBLL = new StudentBLL();
        AttendanceBLL attendanceBLL = new AttendanceBLL();
        public int sessionId;
        public int classId = 0;
        public DateTime date;

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
                        grdStudent.DataSource = FetchControls();
                        grdStudent.DataBind();
                    }
                }
            }
        }

        protected class AttendanceUpdateEntry
        {
            public int id { get; set; }
            public int admissionNo { get; set; }
            public int studentId { get; set; }
            public string studentName { get; set; }
            public string studentLeaveType { get; set; }
            public DateTime date { get; set; }
            public bool gender { get; set; }
            public int studentLeaveTypeId { get; set; }
            public int sessionId { get; set; }
            public int classId { get; set; }
            public int attendanceId { get; set; }
            public string studentCategory { get; set; }
        }

        protected void grdStudent_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                grdStudent.PageIndex = e.NewSelectedIndex;
                grdStudent.DataSource = FetchControls();
                grdStudent.DataBind();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["classId"] != null)
            {
                UpdateData();
            }
            else
            {
                AddData();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            sessionId = Convert.ToInt32(Session["sessionId"]);
            Collection<AttendanceCL> attendanceCL = new Collection<AttendanceCL>();
            foreach (GridViewRow item in grdStudent.Rows)
            {
                int studentId = Convert.ToInt32(grdStudent.DataKeys[item.RowIndex].Value.ToString());
                int attendanceId = attendanceBLL.viewAttendanceByStudentIdandDate(studentId, Convert.ToDateTime(txtDate.Text)).id;
                StudentCL studentCL = studentBLL.viewStudentById(studentId,sessionId);
                DropDownList ddlStudentLeaveType = item.FindControl("ddlGrdStudentLeaveType") as DropDownList;
                if (Convert.ToInt32(ddlStudentLeaveType.SelectedValue) != -1)
                {
                    attendanceCL.Add(new AttendanceCL()
                    {
                        classId = studentCL.classId,
                        date = Convert.ToDateTime(txtDate.Text),
                        dateCreated = DateTime.Now,
                        dateModified = DateTime.Now,
                        isDeleted = false,
                        studentId = studentId,
                        studentLeaveType = ddlStudentLeaveType.SelectedItem.ToString(),
                        studentLeaveTypeId = Convert.ToInt32(ddlStudentLeaveType.SelectedValue),
                        id = attendanceId,
                    });
                }
            }
            int attendanceUpdated = attendanceBLL.deleteAttendance(attendanceCL);
            lblUpdate.Text = attendanceUpdated + " Entries have been deleted. The page will refresh in 5 seconds";
            Response.AppendHeader("Refresh", "5;url=ManageAttendance.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected string GetGender(object dataItem)
        {
            string text = "";
            bool? val = dataItem as bool?;
            if (val == true)
            {
                text = "Male";
            }
            else
            {
                text = "Female";
            }
            return text;
        }

        protected Collection<AttendanceUpdateEntry> FetchControls()
        {
            sessionId = Convert.ToInt32(Session["sessionId"]);
            classId = Convert.ToInt32(Request.QueryString["classId"]);
            date = Convert.ToDateTime(Request.QueryString["date"]);
            Collection<StudentLeaveTypeCL> stlCol = stlBLL.viewStudentLeaveTypes();
            Collection<ClassCL> classCol = classBLL.viewClasses(Convert.ToInt32(Session["sessionId"]));
            if (Request.QueryString["classId"] != null)
            {
                ddlClass.Enabled = false;
                txtDate.Enabled = false;
                int studentId = Convert.ToInt32(Request.QueryString["studentId"]);
                Collection<AttendanceUpdateEntry> studentGrid = new Collection<AttendanceUpdateEntry>();
                lblHeading.Text = "Update Attendance Entry";
                btnSubmit.Text = "Update";
                ddlStudentLeaveType.DataSource = stlCol;
                ddlStudentLeaveType.DataValueField = "id";
                ddlStudentLeaveType.DataTextField = "name";
                ddlStudentLeaveType.DataBind();
                ddlStudentLeaveType.Items.Insert(0, new ListItem("Present", "-1"));
                ddlClass.DataSource = classCol;
                ddlClass.DataValueField = "id";
                ddlClass.DataTextField = "classSection";
                ddlClass.DataBind();
                ddlClass.SelectedValue = classId.ToString();
                ddlClass.Enabled = false;
                Collection<StudentCL> studentCL = studentBLL.viewStudentsByClassId(Convert.ToInt32(ddlClass.SelectedValue));
                txtDate.Text = date.ToString("yyyy-MM-dd");
                int count = 1;
                foreach (StudentCL item in studentCL)
                {
                    AttendanceCL attendanceCL = attendanceBLL.viewAttendanceByStudentIdandDate(item.id, date);
                    if (attendanceCL.studentLeaveTypeId == -1)
                    {
                        studentGrid.Add(new AttendanceUpdateEntry()
                        {
                            admissionNo = item.admissionNo,
                            classId = item.classId,
                            date = date,
                            gender = item.gender,
                            id = count,
                            studentLeaveTypeId = attendanceCL.studentLeaveTypeId,
                            studentName = item.studentName,
                            studentLeaveType = "Present",
                            studentId = item.id,
                            attendanceId = attendanceCL.id,
                            studentCategory = item.studentCategory,
                        });
                        count++;
                    }
                    else
                    {
                        studentGrid.Add(new AttendanceUpdateEntry()
                        {
                            admissionNo = item.admissionNo,
                            classId = item.classId,
                            date = date,
                            gender = item.gender,
                            id = count,
                            studentLeaveTypeId = attendanceCL.studentLeaveTypeId,
                            studentName = item.studentName,
                            studentLeaveType = attendanceCL.studentLeaveType,
                            studentId = item.id,
                            attendanceId = attendanceCL.id,
                            studentCategory = item.studentCategory,
                        });
                        count++;
                    }
                }
                return studentGrid;
            }
            else
            {
                lblHeading.Text = "Add Attendance Entry";
                btnSubmit.Text = "Submit";
                btnDelete.Visible = false;
                ddlClass.DataSource = classCol;
                ddlClass.DataValueField = "id";
                ddlClass.DataTextField = "classSection";
                ddlClass.DataBind();
                ddlStudentLeaveType.DataSource = stlCol;
                ddlStudentLeaveType.DataValueField = "id";
                ddlStudentLeaveType.DataTextField = "name";
                ddlStudentLeaveType.DataBind();
                ddlStudentLeaveType.Items.Insert(0, new ListItem("Present", "-1"));
                Collection<StudentCL> studentCL = studentBLL.viewStudentsByClassId(Convert.ToInt32(ddlClass.SelectedValue));
                Collection<AttendanceUpdateEntry> studentGrid = new Collection<AttendanceUpdateEntry>();
                int count = 1;
                foreach (StudentCL item in studentCL)
                {
                    AttendanceCL attendanceCL = attendanceBLL.viewAttendanceByStudentIdandDate(item.id, date);
                    if (attendanceCL.studentLeaveTypeId == -1)
                    {
                        studentGrid.Add(new AttendanceUpdateEntry()
                        {
                            admissionNo = item.admissionNo,
                            classId = item.classId,
                            date = date,
                            gender = item.gender,
                            id = count,
                            studentLeaveTypeId = attendanceCL.studentLeaveTypeId,
                            studentName = item.studentName,
                            studentLeaveType = "Present",
                            studentId = item.id,
                            attendanceId = attendanceCL.id,
                            studentCategory = item.studentCategory,
                        });
                        count++;
                    }
                    else
                    {
                        studentGrid.Add(new AttendanceUpdateEntry()
                        {
                            admissionNo = item.admissionNo,
                            classId = item.classId,
                            date = date,
                            gender = item.gender,
                            id = count,
                            studentLeaveTypeId = attendanceCL.studentLeaveTypeId,
                            studentName = item.studentName,
                            studentLeaveType = attendanceCL.studentLeaveType,
                            studentId = item.id,
                            attendanceId = attendanceCL.id,
                            studentCategory = item.studentCategory,
                        });
                        count++;
                    }
                }
                return studentGrid;
            }
        }

        protected Collection<AttendanceUpdateEntry> FetchControls1()
        {
            classId = Convert.ToInt32(Request.QueryString["classId"]);
            date = Convert.ToDateTime(Request.QueryString["date"]);
            Collection<StudentLeaveTypeCL> stlCol = stlBLL.viewStudentLeaveTypes();
            Collection<ClassCL> classCol = classBLL.viewClasses(Convert.ToInt16(Session["sessionId"]));
            if (Request.QueryString["classId"] != null)
            {
                int studentId = Convert.ToInt32(Request.QueryString["studentId"]);
                Collection<AttendanceUpdateEntry> studentGrid = new Collection<AttendanceUpdateEntry>();
                Collection<StudentCL> studentCL = studentBLL.viewStudentsByClassId(Convert.ToInt32(ddlClass.SelectedValue));
                txtDate.Text = date.ToString("yyyy-MM-dd");
                int count = 1;
                foreach (StudentCL item in studentCL)
                {
                    AttendanceCL attendanceCL = attendanceBLL.viewAttendanceByStudentIdandDate(item.id, date);
                    if (attendanceCL.studentLeaveTypeId == -1)
                    {
                        studentGrid.Add(new AttendanceUpdateEntry()
                        {
                            admissionNo = item.admissionNo,
                            classId = item.classId,
                            date = date,
                            gender = item.gender,
                            id = count,
                            studentLeaveTypeId = attendanceCL.studentLeaveTypeId,
                            studentName = item.studentName,
                            studentLeaveType = "Present",
                            studentId = item.id,
                            attendanceId = attendanceCL.id,
                            studentCategory = item.studentCategory,
                        });
                        count++;
                    }
                    else
                    {
                        studentGrid.Add(new AttendanceUpdateEntry()
                        {
                            admissionNo = item.admissionNo,
                            classId = item.classId,
                            date = date,
                            gender = item.gender,
                            id = count,
                            studentLeaveTypeId = attendanceCL.studentLeaveTypeId,
                            studentName = item.studentName,
                            studentLeaveType = attendanceCL.studentLeaveType,
                            studentId = item.id,
                            attendanceId = attendanceCL.id,
                            studentCategory = item.studentCategory,
                        });
                        count++;
                    }
                }
                return studentGrid;
            }
            else
            {
                Collection<StudentCL> studentCL = studentBLL.viewStudentsByClassId(Convert.ToInt32(ddlClass.SelectedValue));
                Collection<AttendanceUpdateEntry> studentGrid = new Collection<AttendanceUpdateEntry>();
                int count = 1;
                foreach (StudentCL item in studentCL)
                {
                    AttendanceCL attendanceCL = attendanceBLL.viewAttendanceByStudentIdandDate(item.id, date);
                    if (attendanceCL.studentLeaveTypeId == -1)
                    {
                        studentGrid.Add(new AttendanceUpdateEntry()
                        {
                            admissionNo = item.admissionNo,
                            classId = item.classId,
                            date = date,
                            gender = item.gender,
                            id = count,
                            studentLeaveTypeId = attendanceCL.studentLeaveTypeId,
                            studentName = item.studentName,
                            studentLeaveType = "Present",
                            studentId = item.id,
                            attendanceId = attendanceCL.id,
                            studentCategory = item.studentCategory,
                        });
                        count++;
                    }
                    else
                    {
                        studentGrid.Add(new AttendanceUpdateEntry()
                        {
                            admissionNo = item.admissionNo,
                            classId = item.classId,
                            date = date,
                            gender = item.gender,
                            id = count,
                            studentLeaveTypeId = attendanceCL.studentLeaveTypeId,
                            studentName = item.studentName,
                            studentLeaveType = attendanceCL.studentLeaveType,
                            studentId = item.id,
                            attendanceId = attendanceCL.id,
                            studentCategory = item.studentCategory,
                        });
                        count++;
                    }
                }
                return studentGrid;
            }
        }

        protected void grdStudent_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Collection<StudentLeaveTypeCL> stlCol = stlBLL.viewStudentLeaveTypes();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Request.QueryString["classId"] != null)
                {
                    //Update Attendance Query
                    DropDownList ddlStudentLeaveType = (e.Row.FindControl("ddlGrdStudentLeaveType") as DropDownList);
                    ddlStudentLeaveType.DataSource = stlCol;
                    ddlStudentLeaveType.DataValueField = "id";
                    ddlStudentLeaveType.DataTextField = "name";
                    ddlStudentLeaveType.DataBind();
                    ddlStudentLeaveType.Items.Insert(0, new ListItem("Present", "-1"));
                    int studentLeaveTypeId = ((AttendanceUpdateEntry)e.Row.DataItem).studentLeaveTypeId;
                    ddlStudentLeaveType.Items.FindByValue(studentLeaveTypeId.ToString()).Selected = true;
                }
                else
                {
                    //Add Attendance Query
                    DropDownList ddlStudentLeaveType = (e.Row.FindControl("ddlGrdStudentLeaveType") as DropDownList);
                    ddlStudentLeaveType.DataSource = stlCol;
                    ddlStudentLeaveType.DataValueField = "id";
                    ddlStudentLeaveType.DataTextField = "name";
                    ddlStudentLeaveType.DataBind();
                    ddlStudentLeaveType.Items.Insert(0, new ListItem("Present", "-1"));
                }
            }
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            Collection<StudentCL> studentCL = studentBLL.viewStudentsByClassId(Convert.ToInt32(ddlClass.SelectedValue));
            Collection<AttendanceUpdateEntry> studentGrid = new Collection<AttendanceUpdateEntry>();
            foreach (StudentCL item in studentCL)
            {
                AttendanceCL attendanceCL = attendanceBLL.viewAttendanceByStudentIdandDate(item.id, date);
                studentGrid.Add(new AttendanceUpdateEntry()
                {
                    admissionNo = item.admissionNo,
                    classId = item.classId,
                    date = date,
                    gender = item.gender,
                    id = item.id,
                    studentLeaveTypeId = attendanceCL.studentLeaveTypeId,
                    studentName = item.studentName,
                    attendanceId = attendanceCL.id,
                    studentId = item.id,
                });
            }
            grdStudent.DataSource = studentGrid;
            grdStudent.DataBind();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void AddData()
        {
            sessionId = Convert.ToInt32(Session["sessionId"]);
            Collection<AttendanceCL> attendanceCL = new Collection<AttendanceCL>();
            foreach (GridViewRow item in grdStudent.Rows)
            {
                int studentId = Convert.ToInt32(grdStudent.DataKeys[item.RowIndex].Value.ToString());
                StudentCL studentCL = studentBLL.viewStudentById(studentId,sessionId);
                DropDownList ddlStudentLeaveType1 = item.FindControl("ddlGrdStudentLeaveType") as DropDownList;
                if (Convert.ToInt32(ddlStudentLeaveType1.SelectedValue) != -1)
                {
                    attendanceCL.Add(new AttendanceCL()
                    {
                        classId = studentCL.classId,
                        date = Convert.ToDateTime(txtDate.Text),
                        dateCreated = DateTime.Now,
                        dateModified = DateTime.Now,
                        isDeleted = false,
                        studentId = studentId,
                        studentLeaveType = ddlStudentLeaveType1.SelectedItem.ToString(),
                        studentLeaveTypeId = Convert.ToInt32(ddlStudentLeaveType1.SelectedValue),
                    });
                }
            }
            Collection<AttendanceCL> attendanceUpdated = attendanceBLL.addAttendance(attendanceCL);
            //lblUpdate.Text = attendanceUpdated.Count() + " Entries have been added. The page will refresh in 5 seconds";
            //Response.AppendHeader("Refresh", "5;url=ManageAttendance.aspx?classId=" + attendanceUpdated[0].classId + "&date=" + attendanceUpdated[0].date);
        }

        protected void UpdateData()
        {
            sessionId = Convert.ToInt32(Session["sessionId"]);
            int classId = Convert.ToInt32(Request.QueryString["classId"]);
            Collection<AttendanceCL> attendanceCL = new Collection<AttendanceCL>();
            foreach (GridViewRow item in grdStudent.Rows)
            {
                int studentId = Convert.ToInt32(grdStudent.DataKeys[item.RowIndex].Value.ToString());
                AttendanceCL getAttendance = attendanceBLL.viewAttendanceByStudentIdandDate(studentId, Convert.ToDateTime(txtDate.Text));
                StudentCL studentCL = studentBLL.viewStudentById(studentId,sessionId);
                DropDownList ddlStudentLeaveType = item.FindControl("ddlGrdStudentLeaveType") as DropDownList;
                if (Convert.ToInt32(ddlStudentLeaveType.SelectedValue) != -1)
                {
                    attendanceCL.Add(new AttendanceCL()
                    {
                        classId = classId,
                        date = Convert.ToDateTime(txtDate.Text),
                        dateCreated = DateTime.Now,
                        dateModified = DateTime.Now,
                        isDeleted = false,
                        studentId = studentId,
                        studentLeaveType = ddlStudentLeaveType.SelectedItem.ToString(),
                        studentLeaveTypeId = Convert.ToInt32(ddlStudentLeaveType.SelectedValue),
                        id = getAttendance.id,
                    });
                }
                else
                {
                    if (getAttendance.studentLeaveTypeId != -1)
                    {
                        AttendanceCL deletedAttendance = new AttendanceCL()
                        {
                            id = getAttendance.id,
                        };
                        attendanceBLL.deleteAttendanceCL(deletedAttendance);
                    }
                }
            }
            AttendanceCL attendanceUpdated = attendanceBLL.updateAttendance(attendanceCL);
            lblUpdate.Text = " Entries have been updated. The page will refresh in 5 seconds";
            Response.AppendHeader("Refresh", "5;url=index.aspx");
        }

        protected void grdStudent_Sorting(object sender, GridViewSortEventArgs e)
        {
            //re-run the query, use linq to sort the objects based on the arg.
            //perform a search using the constraints given 
            //you could have this saved in Session, rather than requerying your datastore
            Collection<AttendanceUpdateEntry> myGridResults = FetchControls1();
            if (myGridResults != null)
            {
                var param = Expression.Parameter(typeof(AttendanceUpdateEntry), e.SortExpression);
                var sortExpression = Expression.Lambda<Func<AttendanceUpdateEntry, object>>(Expression.Convert(Expression.Property(param, e.SortExpression), typeof(object)), param);


                if (GridViewSortDirection == SortDirection.Ascending)
                {
                    grdStudent.DataSource = myGridResults.AsQueryable<AttendanceUpdateEntry>().OrderBy(sortExpression).ToList();
                    GridViewSortDirection = SortDirection.Descending;
                }
                else
                {
                    grdStudent.DataSource = myGridResults.AsQueryable<AttendanceUpdateEntry>().OrderByDescending(sortExpression).ToList();
                    GridViewSortDirection = SortDirection.Ascending;
                };
                grdStudent.DataBind();
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

        protected void btnApplyAll_Click(object sender, EventArgs e)
        {
            int leaveTypeId = Convert.ToInt32(ddlStudentLeaveType.SelectedValue);
            foreach (GridViewRow item in grdStudent.Rows)
            {
                DropDownList ddlStudentLeaveType1 = item.FindControl("ddlGrdStudentLeaveType") as DropDownList;
                ddlStudentLeaveType1.SelectedValue = leaveTypeId.ToString();
                ddlStudentLeaveType1.DataBind();
            }
        }
    }
}