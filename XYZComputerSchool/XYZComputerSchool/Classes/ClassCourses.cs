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

namespace XYZComputerSchool.Classes
{
    public class ClassCourses
    {
        protected string vCourseId, vCourseName, vCourseDuration, vCourseStatus, vReadCourseId, vAddedBy, vAddedDateTime;
        protected int vNewCourseId;
        protected double vCourseFee;

        public string GenerateCourseId()
        {
            DatabaseConnection DB = new DatabaseConnection();
            DB.openConnection();

            string sqlSelectCmd = "SELECT MAX(courseId) FROM Courses WHERE courseId LIKE 'C%'";
            SqlCommand com = new SqlCommand(sqlSelectCmd, DatabaseConnection.dbConnection);
            SqlDataReader read = com.ExecuteReader();
            read.Read();
            vReadCourseId = read[0].ToString();

            if (string.IsNullOrEmpty(vReadCourseId))
            {
                vCourseId = "C001";
            }
            else
            {
                vNewCourseId = Convert.ToInt32(vReadCourseId.Substring(1)) + 1;
                vCourseId = "C" + vNewCourseId.ToString("000");
            }
            DB.closeConnection();
            return vCourseId;
        }

        public void AddNewCourse(Courses course, System.Web.UI.WebControls.Label lblAddedBy)
        {
            try
            {
                DatabaseConnection DB = new DatabaseConnection();
                DB.openConnection();
                vCourseId = course.txAddCourseId.Text;
                vCourseName = course.txAddCourseName.Text;
                vCourseDuration = course.ddAddCourseDuration.Text;
                vCourseFee = Convert.ToDouble(course.txAddCourseFee.Text);
                vCourseStatus = "Active";
                vAddedBy = lblAddedBy.Text;
                vAddedDateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                string sqlInsertCmd = "INSERT INTO Courses VALUES('" + vCourseId + "', '" + vCourseName + "', '" + vCourseDuration + "', '" + vCourseFee + "', '" + vCourseStatus + "', '" + vAddedBy + "', '" + vAddedDateTime + "')";
                SqlCommand cmd = new SqlCommand(sqlInsertCmd, DatabaseConnection.dbConnection);
                cmd.ExecuteNonQuery();
                DB.closeConnection();                
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        public void UpdateCourse(Courses course)
        {
            try
            {
                DatabaseConnection DB = new DatabaseConnection();
                DB.openConnection();
                vCourseId = course.txUpdateCourseId.Text;
                vCourseName = course.txUpdateCourseName.Text;
                vCourseDuration = course.ddUpdateCourseDuration.Text;
                vCourseFee = Convert.ToDouble(course.txUpdateCourseFee.Text);

                string sqlUpdateCmd = "UPDATE Courses SET courseName = '" + vCourseName + "', courseDuration = '" + vCourseDuration + "', courseFee = '" + vCourseFee + "' WHERE courseId = '" + vCourseId + "'";
                SqlCommand cmd = new SqlCommand(sqlUpdateCmd, DatabaseConnection.dbConnection);
                cmd.ExecuteNonQuery();
                DB.closeConnection();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        public void DeleteCourse(Courses course)
        {
            try
            {
                DatabaseConnection DB = new DatabaseConnection();
                DB.openConnection();
                vCourseId = course.lblDeleteCourseId.Text;
                string sqlDeleteUpdateCmd = "UPDATE Courses SET courseStatus = 'Inactive' WHERE courseId = '" + vCourseId + "'";
                SqlCommand cmd = new SqlCommand(sqlDeleteUpdateCmd, DatabaseConnection.dbConnection);
                cmd.ExecuteNonQuery();
                DB.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        public void SearchCourse(DropDownList ddCourseSearch, System.Web.UI.WebControls.TextBox txCourseSearch, GridView GridViewCourses)
        {
            try
            {
                DatabaseConnection DB = new DatabaseConnection();
                DB.openConnection();
                string selectQuery = null;
                string vSearchValue = txCourseSearch.Text + '%';

                switch (ddCourseSearch.SelectedIndex)
                {
                    case 0:
                        selectQuery = "SELECT * FROM Courses WHERE courseId LIKE '" + vSearchValue + "' AND courseStatus = 'Active'";
                        break;

                    case 1:
                        selectQuery = "SELECT * FROM Courses WHERE courseName LIKE '" + vSearchValue + "' AND courseStatus = 'Active'";
                        break;                    
                }
                var dataAdapter = new SqlDataAdapter(selectQuery, DatabaseConnection.dbConnection);
                var DS = new DataSet();
                dataAdapter.Fill(DS);
                GridViewCourses.DataSourceID = null;
                GridViewCourses.DataSource = DS.Tables[0];
                GridViewCourses.DataBind();
                DB.closeConnection();
                txCourseSearch.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }
    }
}