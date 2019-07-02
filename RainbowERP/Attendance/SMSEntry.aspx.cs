using BusinessLogicLayer;
using CommunicationLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAINBOW_ERP.Attendance
{
    public partial class SMSEntry : System.Web.UI.Page
    {
        SessionBLL sessionBLL = new SessionBLL();
        StudentLeaveTypesBLL studentLTypeBLL = new StudentLeaveTypesBLL();
        SMSBLL smsBLL = new SMSBLL();
        AttendanceBLL attendanceBLL = new AttendanceBLL();
        StudentBLL studentBLL = new StudentBLL();
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
                        SessionCL sessionCL = sessionBLL.addorCheckSession();
                        Session["sessionId"] = sessionCL.id;
                    }
                    else if (role.ToLower() == "teacher" || role.ToLower() == "attendanceo")
                    {
                        Response.Redirect("../UnAuthorized.aspx");
                    }
                    else
                    {
                        FetchControls();
                    }
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string SMSTemplate = lstSMSTemplate.SelectedItem.ToString();
            int count = 0;
            foreach (GridViewRow item in grdAttendance.Rows)
            {
                DropDownList ddlSelection = item.FindControl("ddlSelection") as DropDownList;
                if (ddlSelection.SelectedValue == "0")
                {
                    int attendanceId = Convert.ToInt32(grdAttendance.DataKeys[item.RowIndex].Value.ToString());
                    AttendanceCL getAttendance = attendanceBLL.viewAttendanceById(attendanceId);
                    Collection<StudentCL> studentCol = studentBLL.viewStudentsByClassId(getAttendance.classId);
                    foreach (StudentCL x in studentCol)
                    {
                        AttendanceCL attendanceCL = attendanceBLL.viewAttendanceByStudentIdandDate(x.id, getAttendance.date);
                        if (attendanceCL.studentLeaveTypeId == getAttendance.studentLeaveTypeId && x.studentCategoryId != 6)
                        {
                            //Your authentication key
                            string authKey = "136481ASa0LIdW5870d589";
                            //Multiple mobiles numbers separated by comma
                            string mobileNumber = x.fatherMobileNumber;
                            //Sender ID,While using route4 sender id should be 6 characters long.
                            string senderId = "RAINBO";
                            //Your message to send, Add URL encoding here.
                            string message = SMSTemplate.Replace("<&admNo>", x.admissionNo.ToString()).Replace("<&studentName>", x.studentName).Replace("<&fatherName>", x.fatherName).Replace("<&motherName>", x.motherName).Replace("<&class>", x.classSection).Replace("<&date>", getAttendance.date.ToString("dd MMM yyyy"));

                            //Prepare you post parameters
                            StringBuilder sbPostData = new StringBuilder();
                            sbPostData.AppendFormat("authkey={0}", authKey);
                            sbPostData.AppendFormat("&mobiles={0}", mobileNumber);
                            sbPostData.AppendFormat("&message={0}", message);
                            sbPostData.AppendFormat("&sender={0}", senderId);
                            sbPostData.AppendFormat("&route={0}", "4");

                            try
                            {
                                //Call Send SMS API
                                string sendSMSUri = "https://control.msg91.com/api/sendhttp.php";
                                //Create HTTPWebrequest
                                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
                                //Prepare and Add URL Encoded data
                                UTF8Encoding encoding = new UTF8Encoding();
                                byte[] data = encoding.GetBytes(sbPostData.ToString());
                                //Specify post method
                                httpWReq.Method = "POST";
                                httpWReq.ContentType = "application/x-www-form-urlencoded";
                                httpWReq.ContentLength = data.Length;
                                using (Stream stream = httpWReq.GetRequestStream())
                                {
                                    stream.Write(data, 0, data.Length);
                                }
                                //Get the response
                                HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                                StreamReader reader = new StreamReader(response.GetResponseStream());
                                string responseString = reader.ReadToEnd();

                                //Close the response
                                reader.Close();
                                response.Close();
                                attendanceBLL.addSMSEntry(new SMSEntryCL
                                {
                                    attendanceId = attendanceCL.id,
                                    dateCreated = DateTime.Now,
                                    isDeleted = false,
                                    smsTemplateId = Convert.ToInt32(lstSMSTemplate.SelectedValue),
                                });
                            }
                            catch (SystemException ex)
                            {
                                throw (new Exception(ex.Message));
                            }
                            count++;
                        }
                    }
                }
            }
            if (count == 0)
            {
                lblUpdate.Text = "Attendance Not Selected.";
            }
            else
            {
                lblUpdate.Text = "SMS sent to " + count + "Entries/Columns. The page will redirect in 10 seconds.";
                Response.AppendHeader("Refresh", "10;url=index.aspx");
            }
        }

        protected void FetchControls()
        {
            sessionId = Convert.ToInt32(Session["sessionId"]);
            ddlStudentLeaveType.DataSource = studentLTypeBLL.viewStudentLeaveTypes();
            ddlStudentLeaveType.DataValueField = "id";
            ddlStudentLeaveType.DataTextField = "name";
            ddlStudentLeaveType.Items.Insert(0, new ListItem("Select", "-1"));
            ddlStudentLeaveType.DataBind();
            lstSMSTemplate.DataSource = smsBLL.viewSMSTemplates();
            lstSMSTemplate.DataValueField = "id";
            lstSMSTemplate.DataTextField = "template";
            lstSMSTemplate.DataBind();
            grdAttendance.DataSource = attendanceBLL.viewAttendanceSortedByDate(sessionId);
            ViewState["attendance"] = attendanceBLL.viewAttendanceSortedByDate(sessionId);
            grdAttendance.DataBind();
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

        protected void grdAttendance_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
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

    }
}