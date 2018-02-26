using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYZComputerSchool.Classes;

namespace XYZComputerSchool.WebForms
{
    public partial class Lecturers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClassLecturer generateLecturerId = new ClassLecturer();
            txAddLecturerId.Text = generateLecturerId.GenerateLecturerId();
        }

        protected void btnAddLecturerSubmit_Click(object sender, EventArgs e)
        {
            Label lblAddedBy = this.Master.FindControl("lblLoggedInUser") as Label;
            ClassLecturer addLecturer = new ClassLecturer();
            addLecturer.AddNewLecturer(this, lblAddedBy);
            string messageString = txAddFirstName.Text + " " + txAddLastName.Text + " has successfully registered. Lecturer ID is " + txAddLecturerId.Text;
            ClientScript.RegisterStartupScript(this.GetType(), "Successful", "alert('" + messageString + "'); window.location='Lecturers.aspx';", true);
        }

        protected void GridViewLecturers_SelectedIndexChanged(object sender, EventArgs e)
        {
            txUpdateLecturerId.Text = GridViewLecturers.SelectedRow.Cells[1].Text;
            txUpdateFirstName.Text = GridViewLecturers.SelectedRow.Cells[2].Text;
            txUpdateLastName.Text = GridViewLecturers.SelectedRow.Cells[3].Text;
            txUpdateAddress.Text = GridViewLecturers.SelectedRow.Cells[4].Text;
            txUpdateContactNo.Text = GridViewLecturers.SelectedRow.Cells[5].Text;            
            txUpdateDOB.Text = GridViewLecturers.SelectedRow.Cells[6].Text;
            txUpdateSalary.Text = GridViewLecturers.SelectedRow.Cells[7].Text +".00";
            txUpdateEmail.Text = GridViewLecturers.SelectedRow.Cells[8].Text;
        }

        protected void btnUpdateLecturerSubmit_Click(object sender, EventArgs e)
        {
            ClassLecturer updateLecturer = new ClassLecturer();
            updateLecturer.UpdateLecturer(this);
            string messageString = txUpdateFirstName.Text + " " + txUpdateLastName.Text + " has successfully updated.";
            ClientScript.RegisterStartupScript(this.GetType(), "Successful", "alert('" + messageString + "'); window.location='Lecturers.aspx';", true);
        }

        protected void GridViewLecturers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ClassLecturer searchLecturer = new ClassLecturer();
            searchLecturer.SearchLecturer(ddSearch, txSearch, GridViewLecturers);
            GridViewLecturers.PageIndex = e.NewPageIndex;
            GridViewLecturers.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ClassLecturer searchLecturer = new ClassLecturer();
            searchLecturer.SearchLecturer(ddSearch, txSearch, GridViewLecturers);
        }
    }
}