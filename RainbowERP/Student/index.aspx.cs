using BusinessLogicLayer;
using CommunicationLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAINBOW_ERP.Student
{
    public partial class index : System.Web.UI.Page
    {
        StudentBLL studentBLL = new StudentBLL();
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
                    else
                    {
                        sessionId = Convert.ToInt32(Session["sessionId"]);
                        grdStudent.DataSource = studentBLL.viewStudents(sessionId);
                        ViewState["students"] = studentBLL.viewStudents(sessionId);
                        grdStudent.DataBind();
                    }
                }
            }
        }

        protected void btnAddStudent_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageStudent.aspx");
        }

        protected void btnTC_Click(object sender, EventArgs e)
        {
            Response.Redirect("TC.aspx");
        }

        protected void grdStudent_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int studentId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("ManageStudent.aspx?studentId=" + studentId);
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            getFilterData();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
        private void getFilterData()
        {
            if (ftAdmissionNo.Text == string.Empty && ftClass.Text == string.Empty && ftFatherName.Text == string.Empty && ftMobileNumber.Text == string.Empty && ftSection.Text == string.Empty && ftStudentName.Text == string.Empty && ftStudentCategory.Text == string.Empty)
            {
                sessionId = Convert.ToInt32(Session["sessionId"]);
                grdStudent.DataSource = studentBLL.viewStudents(sessionId);
                ViewState["students"] = studentBLL.viewStudents(sessionId);
                grdStudent.DataBind();
            }
            else
            {
                sessionId = Convert.ToInt32(Session["sessionId"]);
                var studentCol = studentBLL.viewStudents(sessionId);
                IEnumerable<StudentCL> studentColGet = studentCol;
                Collection<StudentCL> newStudentCol = new Collection<StudentCL>();
                if (ftAdmissionNo.Text != string.Empty)
                {
                    studentColGet = from x in studentColGet where x.admissionNo == Convert.ToInt32(ftAdmissionNo.Text) select x;
                }
                if (ftClass.Text != string.Empty)
                {
                    studentColGet = from x in studentColGet where x.classSection.ToLower().Remove(x.classSection.IndexOf('-')).Contains(ftClass.Text.ToLower()) select x;
                }
                if (ftSection.Text != string.Empty)
                {
                    studentColGet = from x in studentColGet where x.classSection.ToLower().Substring(x.classSection.IndexOf('-')).Contains(ftSection.Text.ToLower()) select x;
                }
                if (ftStudentCategory.Text != string.Empty)
                {
                    studentColGet = from x in studentColGet where x.studentCategory.ToLower().Contains(ftStudentCategory.Text.ToLower()) select x;
                }
                if (ftStudentName.Text != string.Empty)
                {
                    studentColGet = from x in studentColGet where x.studentName.ToLower().Contains(ftStudentName.Text.ToLower()) select x;
                }
                if (ftFatherName.Text != string.Empty)
                {
                    studentColGet = from x in studentColGet where x.fatherName.ToLower().Contains(ftFatherName.Text.ToLower()) select x;
                }
                if (ftMobileNumber.Text != string.Empty)
                {
                    studentColGet = from x in studentColGet where x.fatherMobileNumber.Contains(ftMobileNumber.Text) select x;
                }
                foreach (StudentCL item in studentColGet)
                {
                    newStudentCol.Add(new StudentCL()
                    {
                        aadharCardNo = item.aadharCardNo,
                        address = item.address,
                        admissionNo = item.admissionNo,
                        birthCertificate = item.birthCertificate,
                        classId = item.classId,
                        classSection = item.classSection,
                        dateCreated = item.dateCreated,
                        dateDeleted = item.dateDeleted,
                        dateModified = item.dateModified,
                        deletedTransferCertificate = item.deletedTransferCertificate,
                        dob = item.dob,
                        emailAddress = item.emailAddress,
                        fatherMobileNumber = item.fatherMobileNumber,
                        fatherName = item.fatherName,
                        gender = item.gender,
                        id = item.id,
                        isDeleted = item.isDeleted,
                        miscellaneous1Link = item.miscellaneous1Link,
                        miscellaneous1Name = item.miscellaneous1Name,
                        miscellaneous2Link = item.miscellaneous2Link,
                        miscellaneous2Name = item.miscellaneous2Name,
                        miscellaneous3Link = item.miscellaneous3Link,
                        miscellaneous3Name = item.miscellaneous3Name,
                        motherName = item.motherName,
                        session = item.session,
                        siblingAdmissionNo = item.siblingAdmissionNo,
                        studentCategory = item.studentCategory,
                        studentCategoryId = item.studentCategoryId,
                        studentName = item.studentName,
                        transferCertificate = item.transferCertificate,
                    });
                }
                grdStudent.DataSource = newStudentCol;
                ViewState["students"] = newStudentCol;
                grdStudent.DataBind();
            }
        }
        protected void grdStudent_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                //re-run the query, use linq to sort the objects based on the arg.
                //perform a search using the constraints given 
                //you could have this saved in Session, rather than requerying your datastore

                var studentCol = (Collection<StudentCL>)ViewState["students"];
                IEnumerable<StudentCL> studentColGet = studentCol;
                Collection<StudentCL> newStudentCol = new Collection<StudentCL>();

                if (studentColGet != null)
                {
                    var param = Expression.Parameter(typeof(StudentCL), e.SortExpression);
                    var sortExpression = Expression.Lambda<Func<StudentCL, object>>(Expression.Convert(Expression.Property(param, e.SortExpression), typeof(object)), param);


                    if (GridViewSortDirection == SortDirection.Ascending)
                    {
                        studentColGet = studentColGet.AsQueryable<StudentCL>().OrderBy(sortExpression);
                        GridViewSortDirection = SortDirection.Descending;
                    }
                    else
                    {
                        studentColGet = studentColGet.AsQueryable<StudentCL>().OrderByDescending(sortExpression);
                        GridViewSortDirection = SortDirection.Ascending;
                    };
                    foreach (StudentCL item in studentColGet)
                    {
                        newStudentCol.Add(new StudentCL()
                        {
                            aadharCardNo = item.aadharCardNo,
                            address = item.address,
                            admissionNo = item.admissionNo,
                            birthCertificate = item.birthCertificate,
                            classId = item.classId,
                            classSection = item.classSection,
                            dateCreated = item.dateCreated,
                            dateDeleted = item.dateDeleted,
                            dateModified = item.dateModified,
                            deletedTransferCertificate = item.deletedTransferCertificate,
                            dob = item.dob,
                            emailAddress = item.emailAddress,
                            fatherMobileNumber = item.fatherMobileNumber,
                            fatherName = item.fatherName,
                            gender = item.gender,
                            id = item.id,
                            isDeleted = item.isDeleted,
                            miscellaneous1Link = item.miscellaneous1Link,
                            miscellaneous1Name = item.miscellaneous1Name,
                            miscellaneous2Link = item.miscellaneous2Link,
                            miscellaneous2Name = item.miscellaneous2Name,
                            miscellaneous3Link = item.miscellaneous3Link,
                            miscellaneous3Name = item.miscellaneous3Name,
                            motherName = item.motherName,
                            session = item.session,
                            siblingAdmissionNo = item.siblingAdmissionNo,
                            studentCategory = item.studentCategory,
                            studentCategoryId = item.studentCategoryId,
                            studentName = item.studentName,
                            transferCertificate = item.transferCertificate,
                        });
                    }
                    grdStudent.DataSource = newStudentCol;
                    ViewState["students"] = newStudentCol;
                    grdStudent.DataBind();
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

        protected void grdStudent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdStudent.PageIndex = e.NewPageIndex;
                grdStudent.DataSource = (Collection<StudentCL>)ViewState["students"];
                grdStudent.DataBind();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition",
                 "attachment;filename=ExportExcel.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                grdStudent.AllowPaging = false;
                getFilterData();
                for (int i = 0; i < grdStudent.Rows.Count; i++)
                {
                    GridViewRow row = grdStudent.Rows[i];
                    //Apply text style to each Row
                    row.Attributes.Add("class", "textmode");
                }
                grdStudent.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            Response.Redirect("ImportStudent.aspx");
        }
    }
}