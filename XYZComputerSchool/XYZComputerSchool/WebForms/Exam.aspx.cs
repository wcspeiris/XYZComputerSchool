using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYZComputerSchool.Classes;

namespace XYZComputerSchool.WebForms
{
    public partial class Exam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string selectedModule = Session["selectedModule"].ToString();
            ClassExam loadData = new ClassExam();
            loadData.LoadExamQuestions(this, selectedModule);
        }

        protected void btnCompleteExam_Click(object sender, EventArgs e)
        {
            Label lblLoggedInUser = this.Master.FindControl("lblLoggedInUser") as Label;
            ClassExam recordAnswers = new ClassExam();
            recordAnswers.RecordExamAnswers(this, lblLoggedInUser);
        }
    }
}