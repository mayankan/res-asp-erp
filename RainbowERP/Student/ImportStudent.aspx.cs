using BusinessLogicLayer;
using CommunicationLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAINBOW_ERP.Student
{
    public partial class ImportStudent : System.Web.UI.Page
    {
        StudentBLL studentBLL = new StudentBLL();
        ClassBLL classBLL = new ClassBLL();
        StudentCategoryBLL studentCategoryBLL = new StudentCategoryBLL();
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
                        if (role.ToLower() == "teacher" || role.ToLower() == "attendanceo")
                        {
                            Response.Redirect("../UnAuthorized.aspx");
                        }
                        sessionId = Convert.ToInt32(Session["sessionId"]);
                        ddlClass.DataSource = classBLL.viewClasses(sessionId);
                        ddlClass.DataValueField = "id";
                        ddlClass.DataTextField = "classSection";
                        ddlClass.DataBind();
                        ddlStudentcategory.DataSource = studentCategoryBLL.viewStudentCategories();
                        ddlStudentcategory.DataValueField = "id";
                        ddlStudentcategory.DataTextField = "name";
                        ddlStudentcategory.DataBind();
                        btnImport.Visible = false;
                    }
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        public void BindDataGrid()
        {
            //Creating object of datatable  
            DataTable tblcsv = new DataTable();
            //Adding the first row which is pre-defined.
            tblcsv.Columns.AddRange(new DataColumn[8] { new DataColumn("Admission Number", typeof(int)),
                    new DataColumn("Student's Name", typeof(string)),
                    new DataColumn("Father's Name", typeof(string)),
                    new DataColumn("Mother's Name",typeof(string)),
                    new DataColumn("Mobile Number",typeof(string)),
                    new DataColumn("Gender",typeof(string)),
                    new DataColumn("Date Of Birth",typeof(DateTime)),
                    new DataColumn("Address",typeof(string)) });
            //Creating the CSV Location which is saved in temporary storage.
            string CSVFilePath = Path.GetTempFileName() + flExcelUpload.FileName;
            flExcelUpload.SaveAs(CSVFilePath);
            //Storing the CSV Location in Session for further usage.
            Session["CSVLocation"] = CSVFilePath;
            //Reading All text  
            string ReadCSV = File.ReadAllText(CSVFilePath);
            //spliting row after new line  
            foreach (string csvRow in ReadCSV.Split('\n'))
            {
                if (ReadCSV.IndexOf(csvRow) != 0)
                {
                    //Checking whether the data is empty.
                    if (!string.IsNullOrEmpty(csvRow))
                    {
                        //Adding each row into datatable  
                        tblcsv.Rows.Add();
                        //Creating count variable for splitting data in columns.
                        int count = 0;
                        //Creating Address Count Varaible for splitting Address Column from other data.
                        int AddressCount = 0;
                        //Creating an array to split Address Column from Other Columns.
                        string[] def = csvRow.Split('"');
                        //Checking whether Address field has commas with "" or not.
                        if (def.Count() == 1)
                        {
                            foreach (string x in csvRow.Split(','))
                            {
                                tblcsv.Rows[tblcsv.Rows.Count - 1][count] = x;
                                count++;
                            }
                        }
                        //Address field doesn't have commas and "".
                        else
                        {
                            foreach (string FileRec in def.Take(def.Length - 1))
                            {
                                string[] abc = FileRec.Split(',');
                                foreach (string x in abc.Take(abc.Length - 1))
                                {
                                    if (AddressCount != 0) break;
                                    tblcsv.Rows[tblcsv.Rows.Count - 1][count] = x;
                                    count++;
                                }
                                if (AddressCount == 0)
                                {
                                    AddressCount++;
                                    continue;
                                }
                                tblcsv.Rows[tblcsv.Rows.Count - 1][count] = FileRec;
                                count++;
                            }
                        }
                    }
                }
            }
            //Calling Bind Grid Functions
            grdStudent.DataSource = tblcsv;
            ViewState["students"] = tblcsv;
            grdStudent.DataBind();
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            int admissionNoError = 0;
            try
            {
                //Creating Collection of FeeExcelCL for storing multiple data entries provided by excel file.
                Collection<StudentCL> studentCol = new Collection<StudentCL>();
                //Getting the CSV Location from session which is saved in temporary storage.
                string CSVLocation = Session["CSVLocation"].ToString();
                //Reading All text 
                string ReadCSV = File.ReadAllText(CSVLocation);
                //spliting row after new line  
                foreach (string csvRow in ReadCSV.Split('\n'))
                {
                    if (ReadCSV.IndexOf(csvRow) != 0)
                    {
                        //Checking whether the data is empty.
                        if (!string.IsNullOrEmpty(csvRow))
                        {
                            //Creating StudentCL instance for storing single data entry in loop.
                            StudentCL studentCL = new StudentCL();
                            //Creating studentCount variable for counting student data entries.
                            int feeCount = 0;
                            //Creating count variable for splitting data in columns.
                            int count = 0;
                            //Storing Admission No for handling Exception and returning AdmissionNo.
                            admissionNoError = Convert.ToInt32(csvRow.Split(',')[0]);
                            //Loop for splitting the data and inputting the data in StudentCL intance.
                            foreach (string FileRec in csvRow.Split(','))
                            {
                                if (count == 0)
                                {
                                    studentCL.admissionNo = Convert.ToInt32(FileRec);
                                }
                                if (count == 1)
                                {
                                    studentCL.studentName = FileRec;
                                }
                                if (count == 2)
                                {
                                    studentCL.fatherName = FileRec;
                                }
                                if (count == 3)
                                {
                                    studentCL.motherName = FileRec;
                                }
                                if (count == 4)
                                {
                                    studentCL.fatherMobileNumber = FileRec;
                                }
                                if (count == 5)
                                {
                                    studentCL.gender = Convert.ToBoolean((FileRec == "1") ? "True" : "False");
                                }
                                if (count == 6)
                                {
                                    studentCL.dob = Convert.ToDateTime(FileRec+" 00:00");
                                }
                                if (count == 7)
                                {
                                    studentCL.address = FileRec;
                                    continue;
                                }
                                count++;
                            }
                            //Increasing the studentCount to input in Id Field to store multiple entries in Entity Framework.
                            feeCount++;
                            studentCL.dateCreated = DateTime.Now;
                            studentCL.dateModified = DateTime.Now;
                            studentCL.isDeleted = false;
                            studentCL.id = feeCount;
                            studentCL.aadharCardNo = string.Empty;
                            studentCL.birthCertificate = string.Empty;
                            studentCL.emailAddress = string.Empty;
                            studentCL.studentCategoryId = Convert.ToInt32(ddlStudentcategory.SelectedValue);
                            studentCL.classId = Convert.ToInt32(ddlClass.SelectedValue);
                            studentCL.transferCertificate = string.Empty;

                            //Adding StudentCL instance in Collection instance.
                            studentCol.Add(studentCL);
                        }
                    }
                }
                int returnStudents = studentBLL.createStudentCollection(studentCol);
                if (returnStudents > 999)
                {
                    lblConfirm.Text = "Admission Number " + returnStudents + " has been already added in the Application. Please remove it and Import Again.";
                }
                else
                {
                    lblConfirm.Text = "Student Data imported successfully. The page will refresh in 10 seconds";
                    Response.AppendHeader("Refresh", "10;url=ImportStudent.aspx");
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error in Line with Admission No. " + admissionNoError;
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (flExcelUpload.HasFile)
                {
                    BindDataGrid();
                    btnImport.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }

        protected void grdStudent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdStudent.PageIndex = e.NewPageIndex;
                grdStudent.DataSource = ViewState["students"];
                grdStudent.DataBind();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }
    }
}