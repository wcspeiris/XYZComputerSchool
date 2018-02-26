using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using XYZComputerSchool.Database;
using XYZComputerSchool.WebForms;

namespace XYZComputerSchool.Classes
{
    public class ClassModules
    {
        private string vModuleId, vModuleName, vReadModuleId, vAddedBy, vModuleStatus, vCourseId, vStudentId;
        private int vNewModuleId;

        public string GenerateModuleId()
        {
            DatabaseConnection DB = new DatabaseConnection();
            DB.openConnection();

            string sqlSelectCmd = "SELECT MAX(moduleId) FROM Modules WHERE moduleId LIKE 'M%'";
            SqlCommand com = new SqlCommand(sqlSelectCmd, DatabaseConnection.dbConnection);
            SqlDataReader read = com.ExecuteReader();
            read.Read();
            vReadModuleId = read[0].ToString();

            if (string.IsNullOrEmpty(vReadModuleId))
            {
                vModuleId = "M001";
            }
            else
            {
                vNewModuleId = Convert.ToInt32(vReadModuleId.Substring(1)) + 1;
                vModuleId = "M" + vNewModuleId.ToString("000");
            }
            DB.closeConnection();
            return vModuleId;
        }

        public void AddNewModule(Modules modules, System.Web.UI.WebControls.Label lblAddedBy)
        {
            try
            {
                DatabaseConnection DB = new DatabaseConnection();
                DB.openConnection();
                vModuleId = modules.txAddModuleId.Text;
                vModuleName = modules.txAddModuleName.Text;
                vModuleStatus = "Active";
                vAddedBy = lblAddedBy.Text;

                string sqlInsertCmd = "INSERT INTO Modules VALUES('" + vModuleId + "', '" + vModuleName + "', '" + vModuleStatus + "', '" + vAddedBy + "')";
                SqlCommand cmd = new SqlCommand(sqlInsertCmd, DatabaseConnection.dbConnection);
                cmd.ExecuteNonQuery();
                DB.closeConnection();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        public void UpdateModule(Modules module)
        {
            try
            {
                DatabaseConnection DB = new DatabaseConnection();
                DB.openConnection();
                vModuleId = module.txUpdateModuleId.Text;
                vModuleName = module.txUpdateModuleName.Text;

                string sqlUpdateCmd = "UPDATE Modules SET moduleName = '" + vModuleName + "' WHERE moduleId = '" + vModuleId + "'";
                SqlCommand cmd = new SqlCommand(sqlUpdateCmd, DatabaseConnection.dbConnection);
                cmd.ExecuteNonQuery();
                DB.closeConnection();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        public void DeleteModule(Modules module)
        {
            DatabaseConnection DB = new DatabaseConnection();
            DB.openConnection();
            vModuleId = module.lblDeleteModuleId.Text;
            string sqlDeleteUpdateCmd = "UPDATE Modules SET moduleStatus = 'Inactive' WHERE moduleId = '" + vModuleId + "'";
            SqlCommand cmd = new SqlCommand(sqlDeleteUpdateCmd, DatabaseConnection.dbConnection);
            cmd.ExecuteNonQuery();
            DB.closeConnection();
        }

        public void LoadCourseModules(AddRemoveModules module)
        {
            try
            {
                DatabaseConnection DB = new DatabaseConnection();
                DB.openConnection();

                string vSelectedCourseId = module.GridViewCourses.SelectedRow.Cells[1].Text;
                string sqlViewcmd = "SELECT t1.moduleId, t1.moduleName FROM Modules as t1 RIGHT JOIN CourseContainModules AS t2 ON t1.moduleId = t2.containModuleId WHERE t2.containCourseId='" + vSelectedCourseId + "'";

                var dataAdapter = new SqlDataAdapter(sqlViewcmd, DatabaseConnection.dbConnection);
                var DS = new DataSet();
                dataAdapter.Fill(DS);
                module.GridViewModules.DataSource = DS.Tables[0];
                module.GridViewModules.DataBind();
                DB.closeConnection();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error" + e);
            }
        }

        public bool ValidateModules(GridView gridViewModules, DropDownList ddAddModuleName)
        {
            foreach (GridViewRow row in gridViewModules.Rows)
            {
                if (row.Cells[1].Text == ddAddModuleName.SelectedValue)
                {
                    return true;
                }                
            }
            return false;
        }        
        public void AddModuleToCourse(AddRemoveModules addModule)
        {            
            try
            {
                DatabaseConnection DB = new DatabaseConnection();
                DB.openConnection();
                vCourseId = addModule.txAddCourseId.Text;
                vModuleId = addModule.ddAddModuleName.SelectedItem.Value;

                string sqlInsertCmd = "INSERT INTO CourseContainModules VALUES('" + vCourseId + "', '" + vModuleId + "')";
                SqlCommand cmd = new SqlCommand(sqlInsertCmd, DatabaseConnection.dbConnection);
                cmd.ExecuteNonQuery();
                DB.closeConnection();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        public void RemoveModuleFromCourse(AddRemoveModules removeModule)
        {
            try
            {
                DatabaseConnection DB = new DatabaseConnection();
                DB.openConnection();
                vCourseId = removeModule.GridViewCourses.SelectedRow.Cells[1].Text;
                vModuleId = removeModule.GridViewModules.SelectedRow.Cells[1].Text;

                string sqlDeleteCmd = "DELETE FROM CourseContainModules WHERE containCourseId = '" + vCourseId + "' AND containModuleId = '" + vModuleId + "'";
                SqlCommand cmd = new SqlCommand(sqlDeleteCmd, DatabaseConnection.dbConnection);
                cmd.ExecuteNonQuery();
                DB.closeConnection();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        public void LoadStudentAvailableModules(GridView gridViewStudentObtainedGrades, System.Web.UI.WebControls.Label lblLoggedInStudent)
        {
            try
            {
                DatabaseConnection DB = new DatabaseConnection();
                DB.openConnection();
                vStudentId = lblLoggedInStudent.Text;
                string sqlViewCmd = "SELECT t2.containModuleId, t3.moduleName FROM Students AS t1 LEFT JOIN CourseContainModules AS t2 ON t1.enrolledCourseId = t2.containCourseId LEFT JOIN Modules AS t3 ON t2.containModuleId = t3.moduleId WHERE studentId = '" + vStudentId + "' ";

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

        public void CountModuleAttempts(System.Web.UI.WebControls.Label lblAttemptsTaken, System.Web.UI.WebControls.Label lblLoggedInStudent, GridView gridViewAvailableModules)
        {
            try
            {
                DatabaseConnection DB = new DatabaseConnection();
                DB.openConnection();
                vStudentId = lblLoggedInStudent.Text;
                vModuleId = gridViewAvailableModules.SelectedRow.Cells[1].Text;

                string sqlViewCmd = "SELECT COUNT(*) FROM StudentStudy WHERE studyStudentId = '" + vStudentId + "' AND studyModuleId = '" + vModuleId + "' ";
                SqlCommand cmd = new SqlCommand(sqlViewCmd, DatabaseConnection.dbConnection);
                lblAttemptsTaken.Text = cmd.ExecuteScalar().ToString();

                DB.closeConnection();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error" + e);
            }
        }

        public void SearchModule(DropDownList ddModuleSearch, System.Web.UI.WebControls.TextBox txModuleSearch, GridView GridViewModules)
        {
            try
            {
                DatabaseConnection DB = new DatabaseConnection();
                DB.openConnection();
                string selectQuery = null;
                string vSearchValue = txModuleSearch.Text + '%';

                switch (ddModuleSearch.SelectedIndex)
                {
                    case 0:
                        selectQuery = "SELECT moduleId, moduleName, addedBy FROM Modules WHERE moduleId LIKE '" + vSearchValue + "' AND moduleStatus = 'Active'";
                        break;

                    case 1:
                        selectQuery = "SELECT moduleId, moduleName, addedBy FROM Modules WHERE moduleName LIKE '" + vSearchValue + "' AND moduleStatus = 'Active'";
                        break;
                }
                var dataAdapter = new SqlDataAdapter(selectQuery, DatabaseConnection.dbConnection);
                var DS = new DataSet();
                dataAdapter.Fill(DS);
                GridViewModules.DataSourceID = null;
                GridViewModules.DataSource = DS.Tables[0];
                GridViewModules.DataBind();
                DB.closeConnection();
                txModuleSearch.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }
    }
}