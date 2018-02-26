using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYZComputerSchool.Classes;

namespace XYZComputerSchool.WebForms
{
    public partial class AddRemoveModules : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridViewCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            txAddCourseId.Text = GridViewCourses.SelectedRow.Cells[1].Text;

            ClassModules LoadModules = new ClassModules();
            LoadModules.LoadCourseModules(this);
        }

        protected void btnAddModuleSubmit_Click(object sender, EventArgs e)
        {
            ClassModules validateModule = new ClassModules();
            bool moduleExist = validateModule.ValidateModules(GridViewModules, ddAddModuleName);

            if (moduleExist == true)
            {
                string messageString = "Selected module is already added";
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('" + messageString + "'); window.location='AddRemoveModules.aspx';", true);
            }
            else
            {
                if (GridViewCourses.SelectedValue != null)
                {
                    ClassModules addModule = new ClassModules();
                    addModule.AddModuleToCourse(this);
                    string messageString = "Successfully added";
                    ClientScript.RegisterStartupScript(this.GetType(), "Successful", "alert('" + messageString + "'); window.location='AddRemoveModules.aspx';", true);
                }
            }                  
        }

        protected void GridViewModules_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDeleteModuleId.Text = GridViewModules.SelectedRow.Cells[1].Text;
            lblDeleteModuleName.Text = GridViewModules.SelectedRow.Cells[2].Text;
            lblDeleteCourseName.Text = GridViewCourses.SelectedRow.Cells[2].Text;
        }

        protected void btnDeleteModule_Click(object sender, EventArgs e)
        {
            if (GridViewCourses.SelectedValue != null && GridViewModules.SelectedValue != null)
            {
                ClassModules removeModule = new ClassModules();
                removeModule.RemoveModuleFromCourse(this);
                string messageString = "Successfully Removed";
                ClientScript.RegisterStartupScript(this.GetType(), "Successful", "alert('" + messageString + "'); window.location='AddRemoveModules.aspx';", true);
            }
        }

        protected void GridViewModules_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ClassModules LoadModules = new ClassModules();
            LoadModules.LoadCourseModules(this);
            GridViewModules.PageIndex = e.NewPageIndex;
            GridViewModules.DataBind();
        }
    }
}