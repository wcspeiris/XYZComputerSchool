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
    public class ClassLecturer:ClassUser
    {
        private string vReadLecturerId, vLecturerId;
        private int vNewLecturerId;
        private double vSalary;

        public string GenerateLecturerId()
        {
            try
            {
                DatabaseConnection DB = new DatabaseConnection();
                DB.openConnection();

                string sqlSelectCmd = "SELECT MAX(employeeId) FROM Employees WHERE EmployeeId LIKE 'Lec%'";
                SqlCommand com = new SqlCommand(sqlSelectCmd, DatabaseConnection.dbConnection);
                SqlDataReader read = com.ExecuteReader();
                read.Read();
                vReadLecturerId = read[0].ToString();
                if (string.IsNullOrEmpty(vReadLecturerId))
                {
                    vLecturerId = "Lec001";
                }
                else
                {
                    vNewLecturerId = Convert.ToInt32(vReadLecturerId.Substring(3)) + 1;
                    vLecturerId = "Lec" + vNewLecturerId.ToString("000");
                }
                DB.closeConnection();                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            return vLecturerId;
        }

        public void AddNewLecturer(Lecturers lec, System.Web.UI.WebControls.Label lblAddedBy)
        {
            try
            {
                DatabaseConnection DB = new DatabaseConnection();
                DB.openConnection();
                vLecturerId= lec.txAddLecturerId.Text;
                vPassword = lec.txAddLecturerId.Text;
                vAuthorityLevel = 2;
                vFirstName = lec.txAddFirstName.Text;
                vLastName = lec.txAddLastName.Text;
                vAddress = lec.txAddAddress.Text;
                vContactNo = lec.txAddContactNo.Text;                
                vDOB = lec.txAddDOB.Text;
                vSalary = Convert.ToDouble(lec.txAddSalary.Text);
                vEmailAddress = lec.txAddEmail.Text;
                vAddedBy = lblAddedBy.Text;
                vAddedDateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                string sqlInsertCmd = "INSERT INTO Employees VALUES('" + vLecturerId + "', '" + vPassword + "', '" + vAuthorityLevel + "', '" + vFirstName + "', '" + vLastName + "', '" + vAddress + "', '" + vContactNo + "', '" + vDOB + "', '" + vSalary + "', '" + vEmailAddress + "', '" + vAddedBy + "', '" + vAddedDateTime + "')";
                SqlCommand cmd = new SqlCommand(sqlInsertCmd, DatabaseConnection.dbConnection);
                cmd.ExecuteNonQuery();
                DB.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        public void UpdateLecturer(Lecturers lec)
        {
            try
            {
                DatabaseConnection DB = new DatabaseConnection();
                DB.openConnection();
                vLecturerId = lec.txUpdateLecturerId.Text;
                vFirstName = lec.txUpdateFirstName.Text;
                vLastName = lec.txUpdateLastName.Text;
                vAddress = lec.txUpdateAddress.Text;
                vContactNo = lec.txUpdateContactNo.Text;                
                vDOB = lec.txUpdateDOB.Text;
                vSalary = Convert.ToDouble(lec.txUpdateSalary.Text);
                vEmailAddress = lec.txUpdateEmail.Text;

                string sqlUpdateCmd = "Update Employees SET firstName = '" + vFirstName + "', lastName = '" + vLastName + "', address = '" + vAddress + "', contactNo = '" + vContactNo + "', DOB = '" + vDOB + "', salary = '" + vSalary + "', emailAddress = '" + vEmailAddress + "' WHERE employeeId = '" + vLecturerId + "'";
                SqlCommand cmd = new SqlCommand(sqlUpdateCmd, DatabaseConnection.dbConnection);
                cmd.ExecuteNonQuery();
                DB.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        public void SearchLecturer(DropDownList ddLecturerSearch, System.Web.UI.WebControls.TextBox txLecturerSearch, GridView GridViewLecturers)
        {
            try
            {
                DatabaseConnection DB = new DatabaseConnection();
                DB.openConnection();
                string selectQuery = null;
                string vSearchValue = txLecturerSearch.Text + '%';

                switch (ddLecturerSearch.SelectedIndex)
                {
                    case 0:
                        selectQuery = "SELECT employeeId, firstName, lastName, address, contactNo, DOB, salary, emailAddress, addedBy, addedDateTime FROM Employees WHERE employeeId LIKE '" + vSearchValue + "' AND authorityLevel = '2' ";
                        break;

                    case 1:
                        selectQuery = "SELECT employeeId, firstName, lastName, address, contactNo, DOB, salary, emailAddress, addedBy, addedDateTime FROM Employees WHERE firstName LIKE '" + vSearchValue + "' AND authorityLevel = '2' ";
                        break;

                    case 2:
                        selectQuery = "SELECT employeeId, firstName, lastName, address, contactNo, DOB, salary, emailAddress, addedBy, addedDateTime FROM Employees WHERE lastName LIKE '" + vSearchValue + "' AND authorityLevel = '2' ";
                        break;
                }
                var dataAdapter = new SqlDataAdapter(selectQuery, DatabaseConnection.dbConnection);
                var DS = new DataSet();
                dataAdapter.Fill(DS);
                GridViewLecturers.DataSourceID = null;
                GridViewLecturers.DataSource = DS.Tables[0];
                GridViewLecturers.DataBind();
                DB.closeConnection();
                txLecturerSearch.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }
    }
}