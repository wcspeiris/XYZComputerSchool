using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Windows.Forms;
using XYZComputerSchool.Database;
using XYZComputerSchool.WebForms;

namespace XYZComputerSchool.Classes
{
    public class ClassExam
    {        
        private static DataSet DS = new DataSet();
        private double vTotalMarksCount;
        private string vAverageMarks;

        public void SelectRandomExamQuestions(string selectedModule, System.Web.UI.WebControls.Label lblloggedInStudent)
        {
            try
            {
                DatabaseConnection DB = new DatabaseConnection();
                DB.openConnection();

                string sqlSelectCmd = "SELECT TOP 15 questionId, question, answer01, answer02, answer03, answer04, correctAnswer FROM Questions WHERE questionModuleId = '" + selectedModule + "' order by NEWID()";
                var dataAdapter = new SqlDataAdapter(sqlSelectCmd, DatabaseConnection.dbConnection);                
                dataAdapter.Fill(DS);
                DB.closeConnection();
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Error" + e);
            }
        }

        public void LoadExamQuestions(System.Web.UI.WebControls.Label lblQuestion, System.Web.UI.WebControls.RadioButtonList rbListQuestion, int pageIndex, System.Web.UI.WebControls.HiddenField hiddenField, System.Web.UI.WebControls.HiddenField hfCorrectAns)
        {
            try
            {
                hiddenField.Value = DS.Tables[0].Rows[pageIndex][0].ToString();
                lblQuestion.Text = DS.Tables[0].Rows[pageIndex][1].ToString();
                rbListQuestion.Items.Add(DS.Tables[0].Rows[pageIndex][2].ToString());
                rbListQuestion.Items.Add(DS.Tables[0].Rows[pageIndex][3].ToString());
                rbListQuestion.Items.Add(DS.Tables[0].Rows[pageIndex][4].ToString());
                rbListQuestion.Items.Add(DS.Tables[0].Rows[pageIndex][5].ToString());
                hfCorrectAns.Value = DS.Tables[0].Rows[pageIndex][6].ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error" + e);
            }
        }

        public void RecordExamAnswers(string vStudentId, string vQuestionId, int vQuestionAttempt, int vProvidedAnswer, string vSelectedModule, int vCorrectAnswer)
        {
            try
            {
                DatabaseConnection DB = new DatabaseConnection();
                DB.openConnection();
                string sqlSelectCmd = "SELECT COUNT(*) FROM StudentAnswer WHERE answeredStudentId = '" + vStudentId + "' AND answeredQuestionId = '" + vQuestionId + "' AND answerModuleId = '" + vSelectedModule + "' AND questionAttempt = '" + vQuestionAttempt + "'";
                SqlCommand com = new SqlCommand(sqlSelectCmd, DatabaseConnection.dbConnection);
                int rowCount = (Int32)com.ExecuteScalar();

                if (rowCount == 0)
                {
                    string sqlInsertCmd = "INSERT INTO StudentAnswer VALUES('" + vStudentId + "', '" + vQuestionId + "', '" + vSelectedModule + "', '" + vQuestionAttempt + "', '" + vProvidedAnswer + "')";
                    SqlCommand cmd = new SqlCommand(sqlInsertCmd, DatabaseConnection.dbConnection);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    string sqlUpdateCmd = "UPDATE StudentAnswer SET providedAnswer = '" + vProvidedAnswer + "' WHERE answeredStudentId = '" + vStudentId + "' AND answeredQuestionId = '" + vQuestionId + "' AND answerModuleId = '" + vSelectedModule + "' AND questionAttempt = '" + vQuestionAttempt + "'";
                    SqlCommand cmd = new SqlCommand(sqlUpdateCmd, DatabaseConnection.dbConnection);
                    cmd.ExecuteNonQuery();
                }

                if (vProvidedAnswer == vCorrectAnswer)
                {
                    string sqlUpdateCmnd = "UPDATE StudentStudy SET examMarks = examMarks + 1 WHERE studyStudentId = '" + vStudentId + "' AND studyModuleId = '" + vSelectedModule + "' AND examAttempt = '" + vQuestionAttempt + "'";
                    SqlCommand cmnd = new SqlCommand(sqlUpdateCmnd, DatabaseConnection.dbConnection);
                    cmnd.ExecuteNonQuery();
                }

                string sqlSelectCmnd = "SELECT examMarks FROM StudentStudy WHERE studyStudentId = '" + vStudentId + "' ";
                var DAdapter = new SqlDataAdapter(sqlSelectCmnd, DatabaseConnection.dbConnection);
                DataSet DeSet = new DataSet();
                DAdapter.Fill(DeSet);

                vTotalMarksCount = 0;
                int count = 0;
                foreach (DataRow DR in DeSet.Tables[0].Rows)
                {
                    vTotalMarksCount = vTotalMarksCount + (Convert.ToDouble(DR[0])) / 15 * 100;
                    count++;
                }
                vAverageMarks = (vTotalMarksCount / count).ToString("00.00");

                string sqlUpdateCom = "UPDATE Students SET averageMarks = '" + vAverageMarks + "' WHERE StudentId = '" + vStudentId + "'";
                SqlCommand comm = new SqlCommand(sqlUpdateCom, DatabaseConnection.dbConnection);
                comm.ExecuteNonQuery();

                DB.closeConnection();
            }

            catch (Exception e)
            {
                MessageBox.Show("Error" + e);
            }
        }

        public void ReduceExamMarks(string vStudentId, int vQuestionAttempt, int vProvidedAnswer, string vSelectedModule, int vCorrectAnswer)
        {
            try
            {
                DatabaseConnection DB = new DatabaseConnection();
                DB.openConnection();

                if (vProvidedAnswer == vCorrectAnswer)
                {
                    string sqlUpdateCmnd = "UPDATE StudentStudy SET examMarks = examMarks - 1 WHERE studyStudentId = '" + vStudentId + "' AND studyModuleId = '" + vSelectedModule + "' AND examAttempt = '" + vQuestionAttempt + "'";
                    SqlCommand cmnd = new SqlCommand(sqlUpdateCmnd, DatabaseConnection.dbConnection);
                    cmnd.ExecuteNonQuery();
                }
            }

            catch (Exception e)
            {
                MessageBox.Show("Error" + e);
            }
        }

        public void RecordAttempt(string vStudentId, string vModuleId, int vExamAttempt)
        {
            string vExamAttemptedDateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            try
            {
                DatabaseConnection DB = new DatabaseConnection();
                DB.openConnection();

                string sqlInsertCmd = "INSERT INTO StudentStudy (studyStudentId, studyModuleId, examAttempt, examAttemptedDateTime) VALUES('" + vStudentId + "', '" + vModuleId + "', '" + vExamAttempt + "', '" + vExamAttemptedDateTime + "')";
                SqlCommand cmd = new SqlCommand(sqlInsertCmd, DatabaseConnection.dbConnection);
                cmd.ExecuteNonQuery();
                DB.closeConnection();
            }

            catch (Exception e)
            {
                MessageBox.Show("Error" + e);
            }
        }        

        public void ViewExamPaper(string vStudentId, string vModuleId, string vAttempt, System.Web.UI.WebControls.Panel panelDataView)
        {                  
            try
            {
                DatabaseConnection DB = new DatabaseConnection();
                DB.openConnection();

                string sqlSelectCmd = "SELECT t1.providedAnswer, t2.question, t2.answer01, t2.answer02, t2.answer03, t2.answer04, t2.correctAnswer FROM StudentAnswer AS t1 LEFT JOIN Questions AS t2 ON t1.answeredQuestionId = t2.questionId WHERE answeredStudentId = '" + vStudentId + "' AND answerModuleId = '" + vModuleId + "' AND questionAttempt = '" + vAttempt + "'";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlSelectCmd, DatabaseConnection.dbConnection);
                DataSet DSet = new DataSet();
                dataAdapter.Fill(DSet);
                DB.closeConnection();
                int number = 0;

                foreach (DataTable DT in DSet.Tables)
                {
                    foreach (DataRow row in DT.Rows)
                    {
                        System.Web.UI.WebControls.Label lblQuestion = new System.Web.UI.WebControls.Label();
                        lblQuestion.Text = row[1].ToString();                        

                        System.Web.UI.WebControls.RadioButtonList rbListQuestion = new System.Web.UI.WebControls.RadioButtonList();                        
                        rbListQuestion.Items.Add(row[2].ToString());
                        rbListQuestion.Items.Add(row[3].ToString());
                        rbListQuestion.Items.Add(row[4].ToString());
                        rbListQuestion.Items.Add(row[5].ToString());
                        rbListQuestion.SelectedIndex = Convert.ToInt32(row[0]) - 1;
                        if(row[0].ToString() != row[6].ToString())
                        {
                            rbListQuestion.SelectedItem.Attributes.Add("style", "color: red");
                        }
                        else
                        {
                            rbListQuestion.SelectedItem.Attributes.Add("style", "color: green");
                        }
                                                
                        System.Web.UI.WebControls.Label lbl = new System.Web.UI.WebControls.Label();
                        lbl.Text = ((number + 1) + ". ").ToString();
                        number++;

                        System.Web.UI.WebControls.Label label = new System.Web.UI.WebControls.Label();
                        label.Text = "";

                        panelDataView.Controls.Add(lbl);
                        panelDataView.Controls.Add(lblQuestion);
                        panelDataView.Controls.Add(rbListQuestion);
                        panelDataView.Controls.Add(new LiteralControl("<br />"));
                    }
                } 
            }
            catch (Exception e)
            {
                MessageBox.Show("Error" + e);
            }
        } 
        
        public void ResetDataSet()
        {
            DS = new DataSet();
        }       
    }
}