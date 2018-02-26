using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYZComputerSchool.Classes;

namespace XYZComputerSchool.WebForms
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                Session.Abandon();                
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userId = txUsername.Text;
            string password = txPassword.Text;
            ClassUser login = new ClassUser();
            login.Login(txUsername, txPassword, lblLoginMessage);      
        }        
    }
}