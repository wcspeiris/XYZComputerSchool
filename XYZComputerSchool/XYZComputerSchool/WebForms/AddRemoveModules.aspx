﻿<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/XYZMasterPage.Master" AutoEventWireup="true" CodeBehind="AddRemoveModules.aspx.cs" Inherits="XYZComputerSchool.WebForms.AddRemoveModules" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Bootstrap Custom Designs/Grid Design/GridStyle.css" rel="stylesheet" />
    <link href="Bootstrap Custom Designs/css/button-designs.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="ContentBody" ContentPlaceHolderID="body" runat="Server">
    <form id="AddRemoveModulesForm" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <h2 style="text-align: center; font-family: CHAMBERS; font-size: 30px">Add / Remove Modules from Courses</h2>
                </div>
            </div>
        </div>
        <div class="container-fluid">
            <div class="row">
                <div class="col-sm-5 table-responsive" style="overflow-x: auto">
                    <asp:GridView ID="GridViewCourses" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceCourseDetails" EmptyDataText="There are no data records to display." CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="mGrid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" AllowPaging="True" PageSize="7" DataKeyNames="courseId" OnSelectedIndexChanged="GridViewCourses_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn btn-primary" ControlStyle-Height="35px" ShowSelectButton="True" />
                            <asp:BoundField DataField="courseId" HeaderText="Course Id" SortExpression="courseId" ItemStyle-Wrap="True" HeaderStyle-Wrap="True" FooterStyle-Wrap="True" ReadOnly="True">
                                <FooterStyle Wrap="True" />
                                <HeaderStyle Wrap="True" />
                                <ItemStyle Wrap="True" />
                            </asp:BoundField>
                            <asp:BoundField DataField="courseName" HeaderText="Course Name" SortExpression="courseName" />
                        </Columns>
                        <EditRowStyle Wrap="False" />
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#97c1ac" ForeColor="#333333" HorizontalAlign="Center" VerticalAlign="Bottom" Height="35px" />
                        <RowStyle BackColor="#86bdb5" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#167d8f" Font-Bold="True" ForeColor="Navy" />
                        <SortedAscendingCellStyle BackColor="#FDF5AC" />
                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                        <SortedDescendingCellStyle BackColor="#FCF6C0" />
                        <SortedDescendingHeaderStyle BackColor="#820000" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSourceCourseDetails" runat="server" ConnectionString="<%$ ConnectionStrings:XYZComputerSchoolConnectionString %>" SelectCommand="SELECT [courseId], [courseName] FROM [Courses] WHERE ([courseStatus] = @courseStatus)">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="Active" Name="courseStatus" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>

                <div class="col-sm-5 table-responsive" style="overflow-x: auto">
                    <asp:GridView ID="GridViewModules" runat="server" AutoGenerateColumns="False" EmptyDataText="There are no data records to display." CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="mGrid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" AllowPaging="True" PageSize="7" DataKeyNames="moduleId" OnSelectedIndexChanged="GridViewModules_SelectedIndexChanged" OnPageIndexChanging="GridViewModules_PageIndexChanging">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn btn-primary" ControlStyle-Height="35px" ShowSelectButton="True" />
                            <asp:BoundField DataField="moduleId" HeaderText="Module Id" SortExpression="moduleId" ItemStyle-Wrap="True" HeaderStyle-Wrap="True" FooterStyle-Wrap="True" ReadOnly="True">
                                <FooterStyle Wrap="True" />
                                <HeaderStyle Wrap="True" />
                                <ItemStyle Wrap="True" />
                            </asp:BoundField>
                            <asp:BoundField DataField="moduleName" HeaderText="Module Name" SortExpression="moduleName" />
                        </Columns>
                        <EditRowStyle Wrap="False" />
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#97c1ac" ForeColor="#333333" HorizontalAlign="Center" VerticalAlign="Bottom" Height="35px" />
                        <RowStyle BackColor="#86bdb5" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#167d8f" Font-Bold="True" ForeColor="Navy" />
                        <SortedAscendingCellStyle BackColor="#FDF5AC" />
                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                        <SortedDescendingCellStyle BackColor="#FCF6C0" />
                        <SortedDescendingHeaderStyle BackColor="#820000" />
                    </asp:GridView>                    
                </div>

                <!-- Add Module to Course Modal-->
                <div class="modal fade" id="addModuleModal" data-backdrop="static" data-keyboard="false">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header" style="background: linear-gradient(#052a39, #03562c); color: white">
                                <h5 class="modal-title">Add New Module to a Course</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close" style="color: white">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <div class="container-fluid">
                                    <div class="row main col-xs-12">
                                        <div class="main-login col-xs-12 ">
                                            <div class="form-group">
                                                <label for="CourseId" class="cols-sm-2 control-label">Course ID</label>
                                                <div class="cols-sm-10">
                                                    <div class="input-group">
                                                        <span class="input-group-addon"><i class="fa fa-id-badge fa" aria-hidden="true"></i></span>
                                                        <asp:TextBox CssClass="form-control" runat="server" ID="txAddCourseId" ReadOnly="True" ValidationGroup="addGroup"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvAddCourseId" runat="server" ErrorMessage="" ControlToValidate="txAddCourseId" ValidationGroup="addGroup">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="ModuleName" class="cols-sm-2 control-label">Module Name</label>
                                                <div class="cols-sm-10">
                                                    <div class="input-group">
                                                        <span class="input-group-addon"><i class="fa fa-edit fa-lg" aria-hidden="true"></i></span>
                                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddAddModuleName" DataSourceID="SqlDataSourceAvailableModules" DataTextField="moduleName" DataValueField="moduleId" ValidationGroup="addGroup" AppendDataBoundItems="True">
                                                            <asp:ListItem>---   Select   ---</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfvAddModuleName" runat="server" ErrorMessage="" ControlToValidate="ddAddModuleName" InitialValue="---   Select   ---" ValidationGroup="addGroup">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        <asp:SqlDataSource ID="SqlDataSourceAvailableModules" runat="server" ConnectionString="<%$ ConnectionStrings:XYZComputerSchoolConnectionString %>" SelectCommand="SELECT [moduleId], [moduleName] FROM [Modules]"></asp:SqlDataSource>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button type="submit" runat="server" CssClass="btn btn-success btn-lg btn-block login-button" Text="Submit" ID="btnAddModuleSubmit" OnClick="btnAddModuleSubmit_Click" ValidationGroup="addGroup"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Delete Module Modal -->
                <div class="modal fade" id="deleteModuleModal" data-backdrop="static" data-keyboard="false">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">Delete Confirmation</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                Are you sure you want to delete
                                    <asp:Label runat="server" ID="lblDeleteModuleId"></asp:Label>
                                    <asp:Label runat="server" ID="lblDeleteModuleName"></asp:Label>
                                from Course 
                                    <asp:Label runat="server" ID="lblDeleteCourseName"></asp:Label>
                                ?
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancel</button>
                                <asp:Button type="submit" runat="server" CssClass="btn btn-primary" Text="Delete" ID="btnDeleteModule" OnClick="btnDeleteModule_Click"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
                
                <!--Buttons-->
                <div class="col-sm-2">                    
                    <div>
                        <asp:LinkButton runat="server" CssClass="push_button green" data-toggle="modal" data-target="#addModuleModal" ID="btnAdd"><span class="fa fa-user-plus"></span>&nbsp&nbsp Add</asp:LinkButton>
                    </div>
                    <div>
                        <asp:LinkButton runat="server" CssClass="push_button red" data-toggle="modal" data-target="#deleteModuleModal" ID="btnDelete"><span class="fa  fa-trash-o"></span>&nbsp&nbsp Delete</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
