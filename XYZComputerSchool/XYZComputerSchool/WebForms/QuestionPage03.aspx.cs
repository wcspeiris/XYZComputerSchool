using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYZComputerSchool.Classes;

namespace XYZComputerSchool.WebForms
{
    public partial class QuestionPage03 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblloggedInStudent = this.Master.FindControl("lblLoggedInUser") as Label;
                lblloggedInStudent.Text = Session["loggedInUser"].ToString();
                Session["btn03Color"] = "btn btn-primary btn-circle";
                int pageIndex = 2;
                ClassExam loadData = new ClassExam();
                loadData.LoadExamQuestions(lblQuestion03, rbListQuestion03, pageIndex, hf03, hfCorrectAns03);
                rbListQuestion03.SelectedIndex = Convert.ToInt32(Session["rbListQuestion03"]);

                string studentId = Session["loggedInUser"].ToString();
                int questionAttempt = Convert.ToInt32(Session["questionAttempt"]);
                int providedAnswer = rbListQuestion03.SelectedIndex + 1;
                string selectedModuleId = Session["selectedModule"].ToString();
                int correctAnswer = Convert.ToInt32(hfCorrectAns03.Value);
                loadData.ReduceExamMarks(studentId, questionAttempt, providedAnswer, selectedModuleId, correctAnswer);
            }
        }

        protected void btnGotoPrevious_Click(object sender, EventArgs e)
        {
            if (rbListQuestion03.SelectedIndex == -1)
            {
                Session["btn03Color"] = "btn btn-danger btn-circle";
            }
            else
            {
                Session["btn03Color"] = "btn btn-success btn-circle";
                string studentId = Session["loggedInUser"].ToString();
                string questionId = hf03.Value;
                int questionAttempt = Convert.ToInt32(Session["questionAttempt"]);
                int providedAnswer = rbListQuestion03.SelectedIndex + 1;
                int correctAnswer = Convert.ToInt32(hfCorrectAns03.Value);
                string selectedModuleId = Session["selectedModule"].ToString();
                ClassExam record = new ClassExam();
                record.RecordExamAnswers(studentId, questionId, questionAttempt, providedAnswer, selectedModuleId, correctAnswer);
            }

            Response.Redirect("QuestionPage02.aspx");
        }

        protected void btnMarkForReview_Click(object sender, EventArgs e)
        {
            Session["rbListQuestion03"] = -1;
            Session["btn03Color"] = "btn btn-warning btn-circle";
            Response.Redirect("QuestionPage04.aspx");
        }

        protected void btnSaveAndNext_Click(object sender, EventArgs e)
        {
            if (rbListQuestion03.SelectedIndex == -1)
            {
                Session["btn03Color"] = "btn btn-danger btn-circle";
            }
            else
            {
                Session["btn03Color"] = "btn btn-success btn-circle";
                string studentId = Session["loggedInUser"].ToString();
                string questionId = hf03.Value;
                int questionAttempt = Convert.ToInt32(Session["questionAttempt"]);
                int providedAnswer = rbListQuestion03.SelectedIndex + 1;
                int correctAnswer = Convert.ToInt32(hfCorrectAns03.Value);
                string selectedModuleId = Session["selectedModule"].ToString();
                ClassExam record = new ClassExam();
                record.RecordExamAnswers(studentId, questionId, questionAttempt, providedAnswer, selectedModuleId, correctAnswer);
            }

            Response.Redirect("QuestionPage04.aspx");
        }

        protected void rbListQuestion03_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["rbListQuestion03"] = rbListQuestion03.SelectedIndex;
        }
    }
}