using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYZComputerSchool.Classes;

namespace XYZComputerSchool.WebForms
{
    public partial class QuestionPage11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblloggedInStudent = this.Master.FindControl("lblLoggedInUser") as Label;
                lblloggedInStudent.Text = Session["loggedInUser"].ToString();
                Session["btn11Color"] = "btn btn-primary btn-circle";
                int pageIndex = 10;
                ClassExam loadData = new ClassExam();
                loadData.LoadExamQuestions(lblQuestion11, rbListQuestion11, pageIndex, hf11, hfCorrectAns11);
                rbListQuestion11.SelectedIndex = Convert.ToInt32(Session["rbListQuestion11"]);

                string studentId = Session["loggedInUser"].ToString();
                int questionAttempt = Convert.ToInt32(Session["questionAttempt"]);
                int providedAnswer = rbListQuestion11.SelectedIndex + 1;
                string selectedModuleId = Session["selectedModule"].ToString();
                int correctAnswer = Convert.ToInt32(hfCorrectAns11.Value);
                loadData.ReduceExamMarks(studentId, questionAttempt, providedAnswer, selectedModuleId, correctAnswer);
            }
        }

        protected void btnGotoPrevious_Click(object sender, EventArgs e)
        {
            if (rbListQuestion11.SelectedIndex == -1)
            {
                Session["btn11Color"] = "btn btn-danger btn-circle";
            }
            else
            {
                Session["btn11Color"] = "btn btn-success btn-circle";
                string studentId = Session["loggedInUser"].ToString();
                string questionId = hf11.Value;
                int questionAttempt = Convert.ToInt32(Session["questionAttempt"]);
                int providedAnswer = rbListQuestion11.SelectedIndex + 1;
                int correctAnswer = Convert.ToInt32(hfCorrectAns11.Value);
                string selectedModuleId = Session["selectedModule"].ToString();
                ClassExam record = new ClassExam();
                record.RecordExamAnswers(studentId, questionId, questionAttempt, providedAnswer, selectedModuleId, correctAnswer);
            }

            Response.Redirect("QuestionPage10.aspx");
        }

        protected void btnMarkForReview_Click(object sender, EventArgs e)
        {
            Session["rbListQuestion11"] = -1;
            Session["btn11Color"] = "btn btn-warning btn-circle";
            Response.Redirect("QuestionPage12.aspx");
        }

        protected void btnSaveAndNext_Click(object sender, EventArgs e)
        {
            if (rbListQuestion11.SelectedIndex == -1)
            {
                Session["btn11Color"] = "btn btn-danger btn-circle";
            }
            else
            {
                Session["btn11Color"] = "btn btn-success btn-circle";
                string studentId = Session["loggedInUser"].ToString();
                string questionId = hf11.Value;
                int questionAttempt = Convert.ToInt32(Session["questionAttempt"]);
                int providedAnswer = rbListQuestion11.SelectedIndex + 1;
                int correctAnswer = Convert.ToInt32(hfCorrectAns11.Value);
                string selectedModuleId = Session["selectedModule"].ToString();
                ClassExam record = new ClassExam();
                record.RecordExamAnswers(studentId, questionId, questionAttempt, providedAnswer, selectedModuleId, correctAnswer);
            }

            Response.Redirect("QuestionPage12.aspx");
        }

        protected void rbListQuestion11_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["rbListQuestion11"] = rbListQuestion11.SelectedIndex;
        }
    }
}