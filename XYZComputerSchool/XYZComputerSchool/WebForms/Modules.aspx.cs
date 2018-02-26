using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYZComputerSchool.Classes;

namespace XYZComputerSchool.WebForms
{
    public partial class Modules : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClassModules generateModuleId = new ClassModules();
            txAddModuleId.Text = generateModuleId.GenerateModuleId();
        }

        protected void btnAddModuleSubmit_Click(object sender, EventArgs e)
        {
            Label lblAddedBy = this.Master.FindControl("lblLoggedInUser") as Label;
            ClassModules addModule = new ClassModules();
            addModule.AddNewModule(this, lblAddedBy);
            string messageString = txAddModuleName.Text + " successfully added. Module ID is " + txAddModuleId.Text;
            ClientScript.RegisterStartupScript(this.GetType(), "Successful", "alert('" + messageString + "'); window.location='Modules.aspx';", true);
        }        

        protected void GridViewModules_SelectedIndexChanged(object sender, EventArgs e)
        {
            txUpdateModuleId.Text = GridViewModules.SelectedRow.Cells[1].Text;
            txUpdateModuleName.Text = GridViewModules.SelectedRow.Cells[2].Text;

            lblDeleteModuleId.Text = GridViewModules.SelectedRow.Cells[1].Text;
            lblDeleteModuleName.Text = GridViewModules.SelectedRow.Cells[2].Text;
        }

        protected void btnUpdateModuleSubmit_Click(object sender, EventArgs e)
        {
            ClassModules updateModule = new ClassModules();
            updateModule.UpdateModule(this);
            string messageString = txUpdateModuleName.Text + " has successfully updated.";
            ClientScript.RegisterStartupScript(this.GetType(), "Successful", "alert('" + messageString + "'); window.location='Modules.aspx';", true);
        }

        protected void btnDeleteModule_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblDeleteModuleId.Text))
            {
                ClassModules deleteModule = new ClassModules();
                deleteModule.DeleteModule(this);
                string messageString = lblDeleteModuleId.Text + " " + lblDeleteModuleName.Text + " has successfully deleted.";
                ClientScript.RegisterStartupScript(this.GetType(), "Successful", "alert('" + messageString + "'); window.location='Modules.aspx';", true);
            }
        }

        protected void btnModuleSearch_Click(object sender, EventArgs e)
        {
            ClassModules searchModule = new ClassModules();
            searchModule.SearchModule(ddModuleSearch, txModuleSearch, GridViewModules);
        }

        protected void GridViewModules_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ClassModules searchModule = new ClassModules();
            searchModule.SearchModule(ddModuleSearch, txModuleSearch, GridViewModules);
            GridViewModules.PageIndex = e.NewPageIndex;
            GridViewModules.DataBind();
        }
    }
}