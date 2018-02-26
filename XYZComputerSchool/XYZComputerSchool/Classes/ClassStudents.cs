using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XYZComputerSchool.Database;
using System.Data.SqlClient;
using XYZComputerSchool.WebForms;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI;

namespace XYZComputerSchool.Classes
{
    public class ClassStudents : ClassUser
    {
        private string vReadStudentId, vStudentId, vEnrolledCourseId;
        private int vNewStudentId;
        private double vAverageMarks;

        public string GenerateStudentId()
        {
            try
            {
                DatabaseConnection DB = new DatabaseConnection();
                DB.openConnection();

                string sqlSelectCmd = "SELECT MAX(studentId) FROM Students";
                SqlCommand com = new SqlCommand(sqlSelectCmd, DatabaseConnection.dbConnection);
                SqlDataReader read = com.ExecuteReader();
                read.Read();
                vReadStudentId = read[0].ToString();
                if (string.IsNullOrEmpty(vReadStudentId))
                {
                    vStudentId = "Stu001";
                }
                else
                {
                    vNewStudentId = Convert.ToInt32(vReadStudentId.Substring(3)) + 1;
                    vStudentId = "Stu" + vNewStudentId.ToString("000");
                }
                DB.closeConnection();                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            return vStudentId;
        }

        public void AddNewStudent(Students stu, System.Web.UI.WebControls.Label lblAddedBy, System.Web.UI.WebControls.Label lblAddAlert)
        {
            try
            {
                DatabaseConnection DB = new DatabaseConnection();
                DB.openConnection();
                vStudentId = stu.txAddStudentId.Text;
                vPassword = stu.txAddStudentId.Text;
                vAuthorityLevel = 1;
                vFirstName = stu.txAddFirstName.Text;
                vLastName = stu.txAddLastName.Text;
                vAddress = stu.txAddAddress.Text;
                vContactNo = stu.txAddContactNo.Text;
                vDOB = stu.txAddDOB.Text;
                vEnrolledCourseId = stu.ddAddEnrollingCourse.Text;
                vEmailAddress = stu.txAddEmail.Text;
                vAddedBy = lblAddedBy.Text;
                vAddedDateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                vAverageMarks = 0;


                string sqlInsertCmd = "INSERT INTO Students VALUES('" + vStudentId + "', '" + vPassword + "', '" + vAuthorityLevel + "', '" + vFirstName + "', '" + vLastName + "', '" + vAddress + "', '" + vContactNo + "', '" + vDOB + "', '" + vEnrolledCourseId + "', '" + vEmailAddress + "' , '" + vAverageMarks + "', '" + vAddedBy + "', '" + vAddedDateTime + "')";
                SqlCommand cmd = new SqlCommand(sqlInsertCmd, DatabaseConnection.dbConnection);
                cmd.ExecuteNonQuery();

                DB.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        public void UpdateStudent(Students stu)
        {
            try
            {
                DatabaseConnection DB = new DatabaseConnection();
                DB.openConnection();
                vStudentId = stu.txUpdateStudentId.Text;
                vFirstName = stu.txUpdateFirstName.Text;
                vLastName = stu.txUpdateLastName.Text;
                vAddress = stu.txUpdateAddress.Text;
                vContactNo = stu.txUpdateContactNo.Text;
                vDOB = stu.txUpdateDOB.Text;
                vEnrolledCourseId = stu.ddUpdateEnrollingCourse.Text;
                vEmailAddress = stu.txUpdateEmail.Text;

                string sqlUpdateCmd = "Update Students SET firstName = '" + vFirstName + "', lastName = '" + vLastName + "', address = '" + vAddress + "', contactNo = '" + vContactNo + "', DOB = '" + vDOB + "', enrolledCourseId='" + vEnrolledCourseId + "', emailAddress = '" + vEmailAddress + "' WHERE studentId = '" + vStudentId + "'";
                SqlCommand cmd = new SqlCommand(sqlUpdateCmd, DatabaseConnection.dbConnection);
                cmd.ExecuteNonQuery();
                DB.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        public void SearchStudent(DropDownList ddStudentSearch, System.Web.UI.WebControls.TextBox txStudentSearch, GridView GridViewStudents)
        {
            try
            {
                DatabaseConnection DB = new DatabaseConnection();
                DB.openConnection();
                string selectQuery = null;
                string vSearchValue = txStudentSearch.Text + '%';

                switch (ddStudentSearch.SelectedIndex)
                {
                    case 0:
                        selectQuery = "SELECT studentId, firstName, lastName, address, contactNo, DOB, enrolledCourseId, emailAddress, averageMarks, addedBy, addedDateTime FROM Students WHERE studentId LIKE '" + vSearchValue + "'";
                        break;

                    case 1:
                        selectQuery = "SELECT studentId, firstName, lastName, address, contactNo, DOB, enrolledCourseId, emailAddress, averageMarks, addedBy, addedDateTime FROM Students WHERE firstName LIKE '" + vSearchValue + "'";
                        break;

                    case 2:
                        selectQuery = "SELECT studentId, firstName, lastName, address, contactNo, DOB, enrolledCourseId, emailAddress, averageMarks, addedBy, addedDateTime FROM Students WHERE lastName LIKE '" + vSearchValue + "'";
                        break;
                }
                var dataAdapter = new SqlDataAdapter(selectQuery, DatabaseConnection.dbConnection);
                var DS = new DataSet();
                dataAdapter.Fill(DS);
                GridViewStudents.DataSourceID = null;
                GridViewStudents.DataSource = DS.Tables[0];
                GridViewStudents.DataBind();
                DB.closeConnection();
                txStudentSearch.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        } 
        
        public void LoadStudentDetailsToStudentGrade(GridView gridViewStudents)
        {
            try
            {
                DatabaseConnection DB = new DatabaseConnection();
                DB.openConnection();
                
                string sqlViewCmd = "SELECT t1.studentId, t1.firstName, t1.lastName, t2.courseName FROM Students AS t1 LEFT JOIN Courses AS t2 ON t1.enrolledCourseId = t2.courseId";

                var dataAdapter = new SqlDataAdapter(sqlViewCmd, DatabaseConnection.dbConnection);
                var DS = new DataSet();
                dataAdapter.Fill(DS);
                gridViewStudents.DataSource = DS.Tables[0];
                gridViewStudents.DataBind();
                DB.closeConnection();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error" + e);
            }
        }

        public void LoadStudentGradesToStudentGrade(GridView gridViewStudents, GridView gridViewStudentModules)
        {
            try
            {
                DatabaseConnection DB = new DatabaseConnection();
                DB.openConnection();

                vStudentId = gridViewStudents.SelectedRow.Cells[1].Text;
                string sqlViewCmd = "SELECT t1.examAttempt, t1.examAttemptedDateTime, t1.examMarks, t2.moduleId, t2.moduleName, t1.examMarks/15*100 AS percentage FROM StudentStudy AS t1 LEFT JOIN Modules AS t2 ON t1.studyModuleId = t2.moduleId WHERE studyStudentId = '" + vStudentId + "'";

                var dataAdapter = new SqlDataAdapter(sqlViewCmd, DatabaseConnection.dbConnection);
                var DS = new DataSet();
                dataAdapter.Fill(DS);
                gridViewStudentModules.DataSource = DS.Tables[0];
                gridViewStudentModules.DataBind();
                DB.closeConnection();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error" + e);
            }
        }

        public void LoadStudentGradesToStudentGrade(GridView gridViewStudentObtainedGrades, System.Web.UI.WebControls.Label lblLoggedInStudent)
        {
            try
            {
                DatabaseConnection DB = new DatabaseConnection();
                DB.openConnection();
                vStudentId = lblLoggedInStudent.Text;
                string sqlViewCmd = "SELECT t1.examAttempt, t1.examAttemptedDateTime, t1.examMarks, t2.moduleId, t2.moduleName, t1.examMarks/15*100 AS percentage FROM StudentStudy AS t1 LEFT JOIN Modules AS t2 ON t1.studyModuleId = t2.moduleId WHERE studyStudentId = '" + vStudentId + "'";

                var dataAdapter = new SqlDataAdapter(sqlViewCmd, DatabaseConnection.dbConnection);
                var DS = new DataSet();
                dataAdapter.Fill(DS);
                gridViewStudentObtainedGrades.DataSource = DS.Tables[0];
                gridViewStudentObtainedGrades.DataBind();
                DB.closeConnection();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error" + e);
            }
        }
        
        public void CalculateStudentAverageScore(GridView gridViewStudentObtainedGrades, System.Web.UI.WebControls.Label lblAverageScore)
        {
            double value = 0;
            double count = 0;

            foreach (GridViewRow row in gridViewStudentObtainedGrades.Rows)
            {
                value = value + Convert.ToDouble(row.Cells[6].Text);
                count++;
            }
            lblAverageScore.Text = (value / count).ToString("00.00");
        }        
    }
}