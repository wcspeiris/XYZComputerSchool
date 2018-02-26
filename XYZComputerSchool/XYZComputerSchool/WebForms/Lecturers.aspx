<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/XYZMasterPage.Master" AutoEventWireup="true" CodeBehind="Lecturers.aspx.cs" Inherits="XYZComputerSchool.WebForms.Lecturers" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="Server">
    <link href="Bootstrap Custom Designs/Grid Design/GridStyle.css" rel="stylesheet" />
    <link href="Bootstrap Custom Designs/css/button-designs.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="body" runat="Server">
    <form id="LecturerForm" runat="server" defaultfocus="txSearch">
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <h2 style="text-align: center; font-family: CHAMBERS; font-size: 30px">Manage Lecturers</h2>
                </div>
            </div>
        </div>
        <div class="container-fluid">
            <div class="row">
                <div class="col-xs-10">
                    <div class="input-group">
                        <asp:DropDownList CssClass="btn-success" runat="server" ID="ddSearch" Width="200px">
                            <asp:ListItem>ID</asp:ListItem>
                            <asp:ListItem>First Name</asp:ListItem>
                            <asp:ListItem>Last Name</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txSearch" placeholder="Search Text" BackColor="#eaeaea"></asp:TextBox>
                        <asp:Button runat="server" CssClass="btn-success" Text="   Search   " ID="btnSearch" OnClick="btnSearch_Click"/>
                    </div>
                </div>
            </div>
        </div>
        <div class="container-fluid">
            <div class="row">
                <div class="col-sm-10 table-responsive" style="overflow-x: auto">
                    <asp:GridView ID="GridViewLecturers" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceLecturers" EmptyDataText="There are no data records to display." CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="mGrid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" AllowPaging="True" PageSize="7" OnSelectedIndexChanged="GridViewLecturers_SelectedIndexChanged" DataKeyNames="employeeId" OnPageIndexChanging="GridViewLecturers_PageIndexChanging" >
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn btn-primary" ControlStyle-Height="35px" ShowSelectButton="True" />
                            <asp:BoundField DataField="employeeId" HeaderText="Employee Id" SortExpression="employeeId" ItemStyle-Wrap="false" HeaderStyle-Wrap="false" FooterStyle-Wrap="True" ReadOnly="True" >
                            <FooterStyle Wrap="True" />
                            <HeaderStyle Wrap="True" />
                            <ItemStyle Wrap="True" />
                            </asp:BoundField>
                            <asp:BoundField DataField="firstName" HeaderText="First Name" SortExpression="firstName" />
                            <asp:BoundField DataField="lastName" HeaderText="Last Name" SortExpression="lastName" />
                            <asp:BoundField DataField="address" HeaderText="Address" SortExpression="address" />
                            <asp:BoundField DataField="contactNo" HeaderText="Contact No" SortExpression="contactNo" />
                            <asp:BoundField DataField="DOB" HeaderText="DOB" SortExpression="DOB" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="salary" HeaderText="Salary" SortExpression="salary" ItemStyle-Wrap="False" >
                            <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="emailAddress" HeaderText="Email Address" SortExpression="emailAddress" />
                            <asp:BoundField DataField="addedBy" HeaderText="Added By" SortExpression="addedBy" />
                            <asp:BoundField DataField="addedDateTime" HeaderText="Added Date Time" SortExpression="addedDateTime" ItemStyle-Wrap="False" >
                            <ItemStyle Wrap="False" />
                            </asp:BoundField>
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
                    <asp:SqlDataSource ID="SqlDataSourceLecturers" runat="server" ConnectionString="<%$ ConnectionStrings:XYZComputerSchoolConnectionString %>" SelectCommand="SELECT [employeeId], [firstName], [lastName], [address], [contactNo], [DOB], [salary], [emailAddress], [addedBy], [addedDateTime] FROM [Employees] WHERE ([employeeId] LIKE '%' + @employeeId + '%')">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="Lec" Name="employeeId" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>

                    <!-- Add New Lecturer Modal-->
                    <div class="modal fade" id="addLecturerModal" data-backdrop="static" data-keyboard="false">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header" style="background: linear-gradient(#052a39, #03562c); color: white">
                                    <h5 class="modal-title">Add New Lecturer</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close" style="color: white">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <div class="container-fluid">
                                        <div class="row main col-xs-12">
                                            <div class="main-login col-xs-12 ">
                                                <div class="form-group">
                                                    <label for="lecturerId" class="cols-sm-2 control-label">Lecturer ID</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-id-badge fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" ID="txAddLecturerId" ReadOnly="True" ValidationGroup="addGroup"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvAddLecturerId" runat="server" ErrorMessage="" ControlToValidate="txAddLecturerId" ValidationGroup="addGroup">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="firstName" class="cols-sm-2 control-label">First Name</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" placeholder="First Name" ID="txAddFirstName" pattern="[a-zA-Z]{3,}" title="Numbers / Symbols / Spaces not allowed. Minimum 3 letters" ValidationGroup="addGroup"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvAddFirstName" runat="server" ErrorMessage="" ControlToValidate="txAddFirstName" ValidationGroup="addGroup">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="lastName" class="cols-sm-2 control-label">Last Name</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Last Name" ID="txAddLastName" pattern="[a-zA-Z]{3,}" title="Numbers / Symbols / Spaces not allowed. Minimum 3 letters" ValidationGroup="addGroup"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvAddLastName" runat="server" ErrorMessage="" ControlToValidate="txAddLastName" ValidationGroup="addGroup">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="address" class="cols-sm-2 control-label">Address</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-address-card-o fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Address" ID="txAddAddress" pattern=".{3,}" title="Minimum 3 letters" ValidationGroup="addGroup"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvAddAddress" runat="server" ErrorMessage="" ControlToValidate="txAddAddress" ValidationGroup="addGroup">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="contactNo" class="cols-sm-2 control-label required">Contact No</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-phone fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" ID="txAddContactNo" placeholder="Contact No" pattern="[0][0-9]{9}" title="Only Numbers allowed. Must Starts with '0'. Exactly 10 numbers required" ValidationGroup="addGroup"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvAddContactNo" runat="server" ErrorMessage="" ControlToValidate="txAddContactNo" ValidationGroup="addGroup">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>                                                
                                                <div class="form-group">
                                                    <label for="bDay" class="cols-sm-2 control-label">Date of Birth</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-birthday-cake fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" ID="txAddDOB" placeholder="Date of Birth" TextMode="Date" ValidationGroup="addGroup"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvAddDOB" runat="server" ErrorMessage="" ControlToValidate="txAddDOB" ValidationGroup="addGroup">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="salary" class="cols-sm-2 control-label">Salary</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-money fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Salary" ID="txAddSalary" pattern="^\d+\.\d{2}$" title="Insert a valid amount. Eg:10000.00" ValidationGroup="addGroup"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvAddSalary" runat="server" ErrorMessage="" ControlToValidate="txAddSalary" ValidationGroup="addGroup">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="email" class="cols-sm-2 control-label">Email</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-envelope fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" placeholder="E-Mail" ID="txAddEmail" TextMode="Email" title="Minimum 3 letters" ValidationGroup="addGroup"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvAddEmail" runat="server" ErrorMessage="" ControlToValidate="txAddEmail" ValidationGroup="addGroup">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <asp:Button type="submit" runat="server" CssClass="btn btn-success btn-lg btn-block login-button" Text="Submit" ID="btnAddLecturerSubmit" OnClick="btnAddLecturerSubmit_Click" ValidationGroup="addGroup"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- Update Lecturer Modal-->
                    <div class="modal fade" id="updateLecturerModal" data-backdrop="static" data-keyboard="false">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header" style="background: linear-gradient(#052a39, #03562c); color: white">
                                    <h5 class="modal-title">Update Lecturer</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close" style="color: white">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <div class="container-fluid">
                                        <div class="row main col-xs-12">
                                            <div class="main-login col-xs-12 ">
                                                <div class="form-group">
                                                    <label for="lecturerId" class="cols-sm-2 control-label">Lecturer ID</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-id-badge fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" ID="txUpdateLecturerId" ReadOnly="True" ValidationGroup="updateGroup"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvUpdateLecturerId" runat="server" ErrorMessage="" ControlToValidate="txUpdateLecturerId" ValidationGroup="updateGroup">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="firstName" class="cols-sm-2 control-label">First Name</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" placeholder="First Name" ID="txUpdateFirstName" pattern="[a-zA-Z]{3,}" title="Numbers / Symbols / Spaces not allowed. Minimum 3 letters" ValidationGroup="updateGroup"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvUpdateFirstName" runat="server" ErrorMessage="" ControlToValidate="txUpdateFirstName" ValidationGroup="updateGroup">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="lastName" class="cols-sm-2 control-label">Last Name</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Last Name" ID="txUpdateLastName" pattern="[a-zA-Z]{3,}" title="Numbers / Symbols / Spaces not allowed. Minimum 3 letters" ValidationGroup="updateGroup"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvUpdateLastName" runat="server" ErrorMessage="" ControlToValidate="txUpdateLastName" ValidationGroup="updateGroup">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="address" class="cols-sm-2 control-label">Address</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-address-card-o fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Address" ID="txUpdateAddress" pattern=".{3,}" title="Minimum 3 letters" ValidationGroup="updateGroup"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvUpdateAddress" runat="server" ErrorMessage="" ControlToValidate="txUpdateAddress" ValidationGroup="updateGroup">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="contactNo" class="cols-sm-2 control-label required">Contact No</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-phone fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" ID="txUpdateContactNo" placeholder="Contact No" pattern="[0][0-9]{9}" title="Only Numbers allowed. Must Starts with '0'. Exactly 10 numbers required" ValidationGroup="updateGroup"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvUpdateContactNo" runat="server" ErrorMessage="" ControlToValidate="txUpdateContactNo" ValidationGroup="updateGroup">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>                                                
                                                <div class="form-group">
                                                    <label for="bDay" class="cols-sm-2 control-label">Date of Birth</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-birthday-cake fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" ID="txUpdateDOB" placeholder="Date of Birth" TextMode="Date" ValidationGroup="updateGroup"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvUpdateDOB" runat="server" ErrorMessage="" ControlToValidate="txUpdateDOB" ValidationGroup="updateGroup">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="salary" class="cols-sm-2 control-label">Salary</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-money fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Salary" ID="txUpdateSalary" pattern="^\d+\.\d{2}$" title="Insert a valid amount. Eg:10000.00" ValidationGroup="updateGroup"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvUpdateSalary" runat="server" ErrorMessage="" ControlToValidate="txUpdateSalary" ValidationGroup="updateGroup">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="email" class="cols-sm-2 control-label">Email</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-envelope fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" placeholder="E-Mail" ID="txUpdateEmail" TextMode="Email" title="Minimum 3 letters" ValidationGroup="updateGroup"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvUpdateEmail" runat="server" ErrorMessage="" ControlToValidate="txUpdateEmail" ValidationGroup="updateGroup">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <asp:Button type="submit" runat="server" CssClass="btn btn-success btn-lg btn-block login-button" Text="Submit" ID="btnUpdateLecturerSubmit" OnClick="btnUpdateLecturerSubmit_Click" ValidationGroup="updateGroup"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>

                <!--Buttons-->
                <div class="col-sm-2">
                    <div>
                        <asp:LinkButton runat="server" CssClass="push_button green" data-toggle="modal" data-target="#addLecturerModal" ID="btnAdd"><span class="fa fa-user-plus"></span>&nbsp&nbsp Add</asp:LinkButton>
                    </div>
                    <div>
                        <asp:LinkButton runat="server" CssClass="push_button orange" data-toggle="modal" data-target="#updateLecturerModal" ID="btnUpdate"><span class="fa fa-edit"></span>&nbsp&nbsp Update</asp:LinkButton>
                    </div>                    
                </div>
            </div>
        </div>          
    </form>
</asp:Content>


