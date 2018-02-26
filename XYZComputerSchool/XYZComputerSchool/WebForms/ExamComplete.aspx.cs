using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYZComputerSchool.Classes;

namespace XYZComputerSchool.WebForms
{
    public partial class ExamComplete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuestionPage15.aspx");
        }

        protected void btnFinish_Click(object sender, EventArgs e)
        {            
            string messageString = "Exam Completed successfully";
            ClientScript.RegisterStartupScript(this.GetType(), "Successful", "alert('" + messageString + "'); window.location='AvailableModules.aspx';", true);            
        }
    }
}