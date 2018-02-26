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
    public class ClassQuestions
    {
        private string vQuestionId, vQuestion, vReadQuestionId, vAnswer01, vAnswer02, vAnswer03, vAnswer04, vManagedBy, vModuleId, vSelectedQuestionId;
        private int vNewQuestionId, vCorrectAnswer;
        public void LoadQuestionsList(DropDownList ddModules, GridView gridViewQuestions)
        {
            try
            {
                DatabaseConnection DB = new DatabaseConnection();
                DB.openConnection();


                string vSelectedModuleId = ddModules.SelectedValue;
                string sqlViewcmd = "SELECT questionId, question, managedBy FROM Questions WHERE questionModuleId='" + vSelectedModuleId + "'";

                var dataAdapter = new SqlDataAdapter(sqlViewcmd, DatabaseConnection.dbConnection);
                var DS = new DataSet();
                dataAdapter.Fill(DS);
                gridViewQuestions.DataSource = DS.Tables[0];
                gridViewQuestions.DataBind();
                DB.closeConnection();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error" + e);
            }
        }

        public string GenerateQuestionId()
        {
            DatabaseConnection DB = new DatabaseConnection();
            DB.openConnection();

            string sqlSelectCmd = "SELECT MAX(questionId) FROM Questions WHERE questionId LIKE 'Q%'";
            SqlCommand com = new SqlCommand(sqlSelectCmd, DatabaseConnection.dbConnection);
            SqlDataReader read = com.ExecuteReader();
            read.Read();
            vReadQuestionId = read[0].ToString();

            if (string.IsNullOrEmpty(vReadQuestionId))
            {
                vQuestionId = "Q001";
            }
            else
            {
                vNewQuestionId = Convert.ToInt32(vReadQuestionId.Substring(1)) + 1;
                vQuestionId = "Q" + vNewQuestionId.ToString("000");
            }
            DB.closeConnection();
            return vQuestionId;
        }

        public void AddNewQuestion(Questions questions, System.Web.UI.WebControls.Label lblAddedBy)
        {
            try
            {
                DatabaseConnection DB = new DatabaseConnection();
                DB.openConnection();
                vQuestionId = questions.txAddQuestionId.Text;
                vModuleId = questions.txAddModuleId.Text;
                vQuestion = questions.txAddQuestion.Text;
                vAnswer01 = questions.txAddAnswer01.Text;
                vAnswer02 = questions.txAddAnswer02.Text;
                vAnswer03 = questions.txAddAnswer03.Text;
                vAnswer04 = questions.txAddAnswer04.Text;
                vCorrectAnswer = Convert.ToInt32(questions.txAddCorrectAnswer.Text);                
                vManagedBy = lblAddedBy.Text;

                string sqlInsertCmd = "INSERT INTO Questions VALUES('" + vQuestionId + "', '" + vModuleId + "', '" + vQuestion + "', '" + vAnswer01 + "', '" + vAnswer02 + "', '" + vAnswer03 + "', '" + vAnswer04 + "', '" + vCorrectAnswer + "', '" + vManagedBy + "')";
                SqlCommand cmd = new SqlCommand(sqlInsertCmd, DatabaseConnection.dbConnection);
                cmd.ExecuteNonQuery();
                DB.closeConnection();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        public void LoadQuestionsToViewOrUpdate(Questions questions)
        {
            try
            {
                DatabaseConnection DB = new DatabaseConnection();
                DB.openConnection();

                vSelectedQuestionId = questions.gridViewQuestions.SelectedRow.Cells[1].Text;                
                string sqlViewcmd = "SELECT questionModuleId, question, answer01, answer02, answer03, answer04, correctAnswer FROM Questions WHERE questionId='" + vSelectedQuestionId + "'";
                SqlCommand cmd = new SqlCommand(sqlViewcmd, DatabaseConnection.dbConnection);
                SqlDataReader read = cmd.ExecuteReader();
                read.Read();
                questions.txUpdateQuestionId.Text = vSelectedQuestionId;
                questions.txUpdateModuleId.Text = read[0].ToString();
                questions.txUpdateQuestion.Text = read[1].ToString();
                questions.txUpdateAnswer01.Text = read[2].ToString();
                questions.txUpdateAnswer02.Text = read[3].ToString();
                questions.txUpdateAnswer03.Text = read[4].ToString();
                questions.txUpdateAnswer04.Text = read[5].ToString();
                questions.txUpdateCorrectAnswer.Text = read[6].ToString();

                questions.txViewQuestionId.Text = vSelectedQuestionId;
                questions.txViewModuleId.Text = read[0].ToString();
                questions.txViewQuestion.Text = read[1].ToString();
                questions.txViewAnswer01.Text = read[2].ToString();
                questions.txViewAnswer02.Text = read[3].ToString();
                questions.txViewAnswer03.Text = read[4].ToString();
                questions.txViewAnswer04.Text = read[5].ToString();
                questions.txViewCorrectAnswer.Text = read[6].ToString();
                read.Close();                                
                DB.closeConnection();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error" + e);
            }
        }

        public void UpdateQuestion(Questions questions, System.Web.UI.WebControls.Label lblUpdatedBy)
        {
            try
            {
                DatabaseConnection DB = new DatabaseConnection();
                DB.openConnection();
                vQuestionId = questions.txUpdateQuestionId.Text;                
                vQuestion = questions.txUpdateQuestion.Text;
                vAnswer01 = questions.txUpdateAnswer01.Text;
                vAnswer02 = questions.txUpdateAnswer02.Text;
                vAnswer03 = questions.txUpdateAnswer03.Text;
                vAnswer04 = questions.txUpdateAnswer04.Text;
                vCorrectAnswer = Convert.ToInt32(questions.txUpdateCorrectAnswer.Text);
                vManagedBy = lblUpdatedBy.Text;

                string sqlUpdateCmd = "UPDATE Questions SET question = '" + vQuestion + "', answer01 =  '" + vAnswer01 + "', answer02 = '" + vAnswer02 + "', answer03 = '" + vAnswer03 + "', answer04 = '" + vAnswer04 + "', correctAnswer = '" + vCorrectAnswer + "', managedBy = '" + vManagedBy + "' WHERE questionId = '" + vQuestionId + "'";
                SqlCommand cmd = new SqlCommand(sqlUpdateCmd, DatabaseConnection.dbConnection);
                cmd.ExecuteNonQuery();
                DB.closeConnection();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        public void DeleteQuestions(System.Web.UI.WebControls.Label lblDeleteQuestion)
        {
            try
            {
                DatabaseConnection DB = new DatabaseConnection();
                DB.openConnection();
                vQuestionId = lblDeleteQuestion.Text;

                string sqlDeleteCmd = "DELETE FROM Questions WHERE questionId = '" + vQuestionId + "'";
                SqlCommand cmd = new SqlCommand(sqlDeleteCmd, DatabaseConnection.dbConnection);
                cmd.ExecuteNonQuery();
                DB.closeConnection();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        public void SearchQuestion(DropDownList ddQuestionSearch, System.Web.UI.WebControls.TextBox txQuestionSearch, GridView GridViewQuestions, System.Web.UI.WebControls.DropDownList ddModuleId)
        {
            try
            {
                DatabaseConnection DB = new DatabaseConnection();
                DB.openConnection();
                string selectQuery = null;
                string vSearchValue = txQuestionSearch.Text + '%';

                switch (ddQuestionSearch.SelectedIndex)
                {
                    case 0:
                        selectQuery = "SELECT questionId, question, managedBy FROM Questions WHERE questionId LIKE '" + vSearchValue + "' AND questionModuleId = '" + ddModuleId.SelectedValue + "'";
                        break;

                    case 1:
                        selectQuery = "SELECT questionId, question, managedBy FROM Questions WHERE question LIKE '" + vSearchValue + "' AND questionModuleId = '" + ddModuleId.SelectedValue + "'";
                        break;
                }
                var dataAdapter = new SqlDataAdapter(selectQuery, DatabaseConnection.dbConnection);
                var DS = new DataSet();
                dataAdapter.Fill(DS);
                GridViewQuestions.DataSourceID = null;
                GridViewQuestions.DataSource = DS.Tables[0];
                GridViewQuestions.DataBind();
                DB.closeConnection();
                txQuestionSearch.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }
    }
}