using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYZComputerSchool.Classes;

namespace XYZComputerSchool.WebForms
{
    public partial class Questions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClassQuestions generateId = new ClassQuestions();
            txAddQuestionId.Text = generateId.GenerateQuestionId();
        }

        protected void ddModules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddModules.SelectedIndex == 0)
            {
                txAddModuleId.Text = "";
            }
            else
            {
                txAddModuleId.Text = ddModules.SelectedValue;
            }

            ClassQuestions loadQuestions = new ClassQuestions();
            loadQuestions.LoadQuestionsList(ddModules, gridViewQuestions);
        }

        protected void btnAddQuestionSubmit_Click(object sender, EventArgs e)
        {
            Label lblAddedBy = this.Master.FindControl("lblLoggedInUser") as Label;
            ClassQuestions addQuestion = new ClassQuestions();
            addQuestion.AddNewQuestion(this, lblAddedBy);
            string messageString = txAddQuestionId.Text + " successfully added";
            ClientScript.RegisterStartupScript(this.GetType(), "Successful", "alert('" + messageString + "'); window.location='Questions.aspx';", true);
        }

        protected void btnUpdateQuestionSubmit_Click(object sender, EventArgs e)
        {
            Label lblUpdatedBy = this.Master.FindControl("lblLoggedInUser") as Label;
            ClassQuestions updateQuestion = new ClassQuestions();
            updateQuestion.UpdateQuestion(this, lblUpdatedBy);
            string messageString = txUpdateQuestionId.Text + " has successfully updated.";
            ClientScript.RegisterStartupScript(this.GetType(), "Successful", "alert('" + messageString + "'); window.location='Questions.aspx';", true);
        }

        protected void gridViewQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDeleteQuestionId.Text = gridViewQuestions.SelectedRow.Cells[1].Text;
                       
            ClassQuestions LoadData = new ClassQuestions();
            LoadData.LoadQuestionsToViewOrUpdate(this);
        }

        protected void btnDeleteQuestion_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblDeleteQuestionId.Text))
            {
                ClassQuestions deleteQuestion = new ClassQuestions();
                deleteQuestion.DeleteQuestions(lblDeleteQuestionId);
                string messageString = lblDeleteQuestionId.Text + " has successfully deleted.";
                ClientScript.RegisterStartupScript(this.GetType(), "Successful", "alert('" + messageString + "'); window.location='Questions.aspx';", true);
            }
        }

        protected void gridViewQuestions_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ClassQuestions loadQuestions = new ClassQuestions();
            loadQuestions.SearchQuestion(ddQuestionSearch, txQuestionSearch, gridViewQuestions, ddModules);
            gridViewQuestions.PageIndex = e.NewPageIndex;
            gridViewQuestions.DataBind();
        }

        protected void btnQuestionSearch_Click(object sender, EventArgs e)
        {
            ClassQuestions searchQuestion = new ClassQuestions();
            searchQuestion.SearchQuestion(ddQuestionSearch, txQuestionSearch, gridViewQuestions, ddModules);
        }
    }
}