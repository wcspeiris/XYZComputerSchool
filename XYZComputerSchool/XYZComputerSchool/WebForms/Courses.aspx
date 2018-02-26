<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/XYZMasterPage.Master" AutoEventWireup="true" CodeBehind="Courses.aspx.cs" Inherits="XYZComputerSchool.WebForms.Courses" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="Server">
    <link href="Bootstrap Custom Designs/Grid Design/GridStyle.css" rel="stylesheet" />
    <link href="Bootstrap Custom Designs/css/button-designs.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="body" runat="Server">
    <form id="CoursesForm" runat="server" defaultfocus="txSearch">
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <h2 style="text-align: center; font-family: CHAMBERS; font-size: 30px">Manage Courses</h2>
                </div>
            </div>
        </div>
        <div class="container-fluid">
            <div class="row">
                <div class="col-xs-10">
                    <div class="input-group">
                        <asp:DropDownList CssClass="btn-success" runat="server" ID="ddSearch" Width="200px">
                            <asp:ListItem>ID</asp:ListItem>
                            <asp:ListItem>Course Name</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txCourseSearch" placeholder="Search Text" BackColor="#eaeaea"></asp:TextBox>
                        <asp:Button runat="server" CssClass="btn-success" Text="   Search   " CausesValidation="false" ID="btnCourseSearch" OnClick="btnCourseSearch_Click"/>
                    </div>
                </div>
            </div>
        </div>
        <div class="container-fluid">
            <div class="row">
                <div class="col-sm-10 table-responsive" style="overflow-x: auto">
                    <asp:GridView ID="GridViewCourses" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceCourses" EmptyDataText="There are no data records to display." CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="mGrid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" AllowPaging="True" PageSize="7" DataKeyNames="courseId" OnSelectedIndexChanged="GridViewCourses_SelectedIndexChanged" OnPageIndexChanging="GridViewCourses_PageIndexChanging">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn btn-primary" ControlStyle-Height="35px" ShowSelectButton="True">
                                <ControlStyle CssClass="btn btn-primary" Height="35px"></ControlStyle>
                            </asp:CommandField>
                            <asp:BoundField DataField="courseId" HeaderText="Course Id" SortExpression="courseId" ItemStyle-Wrap="True" HeaderStyle-Wrap="True" FooterStyle-Wrap="True" ReadOnly="True">
                                <FooterStyle Wrap="True"></FooterStyle>
                                <HeaderStyle Wrap="True"></HeaderStyle>
                                <ItemStyle Wrap="True"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="courseName" HeaderText="Course Name" SortExpression="courseName" />
                            <asp:BoundField DataField="courseDuration" HeaderText="Course Duration" SortExpression="courseDuration" />
                            <asp:BoundField DataField="courseFee" HeaderText="Course Fee" SortExpression="courseFee" />
                            <asp:BoundField DataField="addedBy" HeaderText="Added By" SortExpression="addedBy" />
                            <asp:BoundField DataField="addedDateTime" HeaderText="Added Date Time" SortExpression="addedDateTime" />
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
                    <asp:SqlDataSource ID="SqlDataSourceCourses" runat="server" ConnectionString="<%$ ConnectionStrings:XYZComputerSchoolConnectionString %>" SelectCommand="SELECT * FROM [Courses] WHERE ([courseStatus] = @courseStatus)">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="Active" Name="courseStatus" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <!-- Add New Course Modal-->
                    <div class="modal fade" id="addCourseModal" data-backdrop="static" data-keyboard="false">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header" style="background: linear-gradient(#052a39, #03562c); color: white">
                                    <h5 class="modal-title">Add New Course</h5>
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
                                                            <asp:TextBox CssClass="form-control" runat="server" ID="txAddCourseId" ReadOnly="True" ValidationGroup="groupAdd"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvAddCourseId" runat="server" ErrorMessage="" ValidationGroup="groupAdd" ControlToValidate="txAddCourseId">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="CourseName" class="cols-sm-2 control-label">Course Name</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-book fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Course Name" ID="txAddCourseName" ValidationGroup="groupAdd"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvAddCourseName" runat="server" ErrorMessage="" ControlToValidate="txAddCourseName" ValidationGroup="groupAdd">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="courseDuration" class="cols-sm-2 control-label">Course Duration</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-clock-o fa-lg" aria-hidden="true"></i></span>
                                                            <asp:DropDownList CssClass="form-control" runat="server" ID="ddAddCourseDuration" placeholder="Please select the Duration" ValidationGroup="groupAdd">
                                                                <asp:ListItem>---    Select   ---</asp:ListItem>
                                                                <asp:ListItem>01 Month</asp:ListItem>
                                                                <asp:ListItem>02 Months</asp:ListItem>
                                                                <asp:ListItem>04 Months</asp:ListItem>
                                                                <asp:ListItem>06 Months</asp:ListItem>
                                                                <asp:ListItem>12 Months</asp:ListItem>
                                                                <asp:ListItem>18 Months</asp:ListItem>
                                                                <asp:ListItem>24 Months</asp:ListItem>
                                                                <asp:ListItem>36 Months</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfvAddCourseDuration" runat="server" ErrorMessage="" ControlToValidate="ddAddCourseDuration" InitialValue="---    Select   ---" ValidationGroup="groupAdd">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="courseFee" class="cols-sm-2 control-label">Course Fee</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-money fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Course Fee" ID="txAddCourseFee" pattern="^\d+\.\d{2}$" title="Insert a valid amount. Eg:10000.00" ValidationGroup="groupAdd"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvAddCourseFee" runat="server" ErrorMessage="" ControlToValidate="txAddCourseFee" ValidationGroup="groupAdd">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>                                
                                <div class="modal-footer">
                                    <asp:Button runat="server" CssClass="btn btn-success btn-lg btn-block login-button" Text="Submit" ID="btnAddCourseSubmit" OnClick="btnAddCourseSubmit_Click" ValidationGroup="groupAdd"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- Update Course Modal-->
                    <div class="modal fade" id="updateCourseModal" data-backdrop="static" data-keyboard="false">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header" style="background: linear-gradient(#052a39, #03562c); color: white">
                                    <h5 class="modal-title">Update Course</h5>
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
                                                            <asp:TextBox CssClass="form-control" runat="server" ID="txUpdateCourseId" ReadOnly="True"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvUpdateCourseId" runat="server" ErrorMessage="" ControlToValidate="txUpdateCourseId" ValidationGroup="updateGroup">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="CourseName" class="cols-sm-2 control-label">Course Name</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-book fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Course Name" ID="txUpdateCourseName" ValidationGroup="updateGroup"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvUpdateCourseName" runat="server" ErrorMessage="" ControlToValidate="txUpdateCourseName" ValidationGroup="updateGroup">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="courseDuration" class="cols-sm-2 control-label">Course Duration</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-clock-o fa-lg" aria-hidden="true"></i></span>
                                                            <asp:DropDownList CssClass="form-control" runat="server" ID="ddUpdateCourseDuration" required="required" placeholder="Please select the Duration" ValidationGroup="updateGroup">
                                                                <asp:ListItem>---    Select   ---</asp:ListItem>
                                                                <asp:ListItem>01 Month</asp:ListItem>
                                                                <asp:ListItem>02 Months</asp:ListItem>
                                                                <asp:ListItem>04 Months</asp:ListItem>
                                                                <asp:ListItem>06 Months</asp:ListItem>
                                                                <asp:ListItem>12 Months</asp:ListItem>
                                                                <asp:ListItem>18 Months</asp:ListItem>
                                                                <asp:ListItem>24 Months</asp:ListItem>
                                                                <asp:ListItem>36 Months</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfvUpdateCourseDuration" runat="server" ErrorMessage="" ControlToValidate="ddUpdateCourseDuration" InitialValue="---    Select   ---" ValidationGroup="updateGroup">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="courseFee" class="cols-sm-2 control-label">Course Fee</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-money fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Course Fee" ID="txUpdateCourseFee" pattern="^\d+\.\d{2}$" title="Insert a valid amount. Eg:10000.00" ValidationGroup="updateGroup"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvUpdateCourseFee" runat="server" ErrorMessage="" ControlToValidate="txUpdateCourseFee" ValidationGroup="updateGroup">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <asp:Button type="submit" runat="server" CssClass="btn btn-success btn-lg btn-block login-button" Text="Submit" ID="btnUpdateCourseSubmit" OnClick="btnUpdateCourseSubmit_Click" ValidationGroup="updateGroup"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>
                    
                    <!-- Delete Course Modal -->
                    <div class="modal fade" id="deleteCourseModal" data-backdrop="static" data-keyboard="false">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title">Delete Confirmation</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    Are you sure you want to delete <asp:Label runat="server" ID="lblDeleteCourseId"></asp:Label> <asp:Label runat="server" ID="lblDeleteCourseName"></asp:Label> ?
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancel</button>
                                    <asp:Button type="submit" runat="server" CssClass="btn btn-primary" Text="Delete" ID="btnDeleteCourse" OnClick="btnDeleteCourse_Click"></asp:Button>                                    
                                </div>
                            </div>
                        </div>
                    </div>

                </div>

                <!--Buttons-->
                <div class="col-sm-2">
                    <div>
                        <asp:LinkButton runat="server" CssClass="push_button green" data-toggle="modal" data-target="#addCourseModal" ID="btnAdd"><span class="fa fa-user-plus"></span>&nbsp&nbsp Add</asp:LinkButton>
                    </div>
                    <div>
                        <asp:LinkButton runat="server" CssClass="push_button orange" data-toggle="modal" data-target="#updateCourseModal" ID="btnUpdate"><span class="fa fa-edit"></span>&nbsp&nbsp Update</asp:LinkButton>
                    </div>
                    <div>
                        <asp:LinkButton runat="server" CssClass="push_button red" data-toggle="modal" data-target="#deleteCourseModal" ID="btnDelete"><span class="fa  fa-trash-o"></span>&nbsp&nbsp Delete</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        
    </form>

    
    
</asp:Content>
