using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using XYZComputerSchool.Database;

namespace XYZComputerSchool.Classes
{
    public class ClassUser
    {
        protected string vUserId, vPassword, vEmailAddress, vFirstName, vLastName, vAddress, vDOB, vContactNo, vAddedBy, vAddedDateTime;
        protected int vAuthorityLevel;

        public void Login(System.Web.UI.WebControls.TextBox txUserId, System.Web.UI.WebControls.TextBox txPassword, System.Web.UI.WebControls.Label lblLoginMessage)
        {
            vUserId = txUserId.Text;
            vPassword = txPassword.Text;
            DatabaseConnection DB = new DatabaseConnection();
            DB.openConnection();

            string sqlSelectCmd = "SELECT authorityLevel FROM Employees WHERE employeeId = '" + vUserId + "' AND password COLLATE Latin1_General_CS_AS = '" + vPassword + "'";
            SqlCommand cmd = new SqlCommand(sqlSelectCmd, DatabaseConnection.dbConnection);
            vAuthorityLevel = Convert.ToInt32(cmd.ExecuteScalar());

            if (vAuthorityLevel == 2)
            {
                HttpContext.Current.Session["loggedInUser"] = vUserId;
                HttpContext.Current.Session["userLevel"] = 2;
                HttpContext.Current.Response.Redirect("index.aspx");                              
            }
            else if (vAuthorityLevel == 3)
            {
                HttpContext.Current.Session["loggedInUser"] = vUserId;
                HttpContext.Current.Session["userLevel"] = 3;
                HttpContext.Current.Response.Redirect("index.aspx");                
            }
            else
            {
                string sqlSelectCom = "SELECT authorityLevel FROM Students WHERE studentId = '" + vUserId + "' AND password COLLATE Latin1_General_CS_AS = '" + vPassword + "'";
                SqlCommand com = new SqlCommand(sqlSelectCom, DatabaseConnection.dbConnection);
                vAuthorityLevel = Convert.ToInt32(com.ExecuteScalar());

                if(vAuthorityLevel == 1)
                {
                    HttpContext.Current.Session["loggedInUser"] = vUserId;
                    HttpContext.Current.Response.Redirect("studentIndex.aspx");                    
                }
                else
                {
                    txUserId.Text = "";
                    txPassword.Text = "";
                    lblLoginMessage.Text = "Invalid User ID or Password";                    
                }
            } 
            
            DB.closeConnection();
        }
    }
}