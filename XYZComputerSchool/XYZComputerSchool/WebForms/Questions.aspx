<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/XYZMasterPage.Master" AutoEventWireup="true" CodeBehind="Questions.aspx.cs" Inherits="XYZComputerSchool.WebForms.Questions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Bootstrap Custom Designs/Grid Design/GridStyle.css" rel="stylesheet" />
    <link href="Bootstrap Custom Designs/css/button-designs.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="ContentBody" ContentPlaceHolderID="body" runat="Server">
    <form id="QuestionsForm" runat="server" defaultfocus="txSearch">
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <h2 style="text-align: center; font-family: CHAMBERS; font-size: 30px">Manage Questions</h2>
                </div>
            </div>
        </div>
        <div class="container-fluid">
            <div class="row">
                <div class="col-xs-10">
                    <div class="input-group">
                        <asp:DropDownList CssClass="btn-success" runat="server" ID="ddModules" Width="300px" DataSourceID="SqlDataSourceModulesList" DataTextField="moduleName" DataValueField="moduleId" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddModules_SelectedIndexChanged">
                            <asp:ListItem>---   Select   ---</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSourceModulesList" runat="server" ConnectionString="<%$ ConnectionStrings:XYZComputerSchoolConnectionString %>" SelectCommand="SELECT [moduleId], [moduleName] FROM [Modules] WHERE ([moduleStatus] = @moduleStatus)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="Active" Name="moduleStatus" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                        <asp:DropDownList CssClass="btn-success" runat="server" ID="ddQuestionSearch" Width="100px">
                            <asp:ListItem>ID</asp:ListItem>
                            <asp:ListItem>Question</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txQuestionSearch" placeholder="Search Text" BackColor="#eaeaea"></asp:TextBox>
                        <asp:Button runat="server" CssClass="btn-success" Text="   Search   " ID="btnQuestionSearch" OnClick="btnQuestionSearch_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div class="container-fluid">
            <div class="row">
                <div class="col-sm-10 table-responsive" style="overflow-x: auto">
                    <asp:GridView ID="gridViewQuestions" runat="server" AutoGenerateColumns="False" EmptyDataText="There are no data records to display." CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="mGrid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" AllowPaging="True" PageSize="7" DataKeyNames="questionId" OnSelectedIndexChanged="gridViewQuestions_SelectedIndexChanged" OnPageIndexChanging="gridViewQuestions_PageIndexChanging">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn btn-primary" ControlStyle-Height="35px" ItemStyle-Width="30px" ShowSelectButton="True" />
                            <asp:BoundField DataField="questionId" HeaderText="Question Id" SortExpression="questionId" ItemStyle-Wrap="True" HeaderStyle-Wrap="True" FooterStyle-Wrap="True" ReadOnly="True" ItemStyle-Width="100px">
                                <FooterStyle Wrap="True"></FooterStyle>
                                <HeaderStyle Wrap="True"></HeaderStyle>
                                <ItemStyle Wrap="True"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="question" HeaderText="Question" SortExpression="question" />
                            <asp:BoundField DataField="managedBy" HeaderText="Managed By" SortExpression="managedBy" />
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

                    <!-- Add New Question Modal-->
                    <div class="modal fade" id="addQuestionModal" data-backdrop="static" data-keyboard="false">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header" style="background: linear-gradient(#052a39, #03562c); color: white">
                                    <h5 class="modal-title">Add New Question</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close" style="color: white">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <div class="container-fluid">
                                        <div class="row main col-xs-12">
                                            <div class="main-login col-xs-12 ">
                                                <div class="form-group">
                                                    <label for="questionId" class="cols-sm-2 control-label">Question ID</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-id-badge fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" ID="txAddQuestionId" ReadOnly="True" ValidationGroup="groupAdd"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvAddQuestionId" runat="server" ErrorMessage="" ValidationGroup="groupAdd" ControlToValidate="txAddQuestionId">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="moduleId" class="cols-sm-2 control-label">Module ID</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-id-badge fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" ID="txAddModuleId" ReadOnly="True" ValidationGroup="groupAdd"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvAddModuleId" runat="server" ErrorMessage="" ValidationGroup="groupAdd" ControlToValidate="txAddModuleId">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="questionName" class="cols-sm-2 control-label">Question</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-question fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Question" ID="txAddQuestion" ValidationGroup="groupAdd" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvAddQuestion" runat="server" ErrorMessage="" ControlToValidate="txAddQuestion" ValidationGroup="groupAdd">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div> 
                                                <div class="form-group">
                                                    <label for="answer01" class="cols-sm-2 control-label">Answer 01</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-tasks fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Answer 01" ID="txAddAnswer01" ValidationGroup="groupAdd" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvAddAnswer01" runat="server" ErrorMessage="" ControlToValidate="txAddAnswer01" ValidationGroup="groupAdd">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="answer02" class="cols-sm-2 control-label">Answer 02</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-tasks fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Answer 02" ID="txAddAnswer02" ValidationGroup="groupAdd" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvAddAnswer02" runat="server" ErrorMessage="" ControlToValidate="txAddAnswer02" ValidationGroup="groupAdd">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="answer03" class="cols-sm-2 control-label">Answer 03</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-tasks fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Answer 03" ID="txAddAnswer03" ValidationGroup="groupAdd" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvAddAnswer03" runat="server" ErrorMessage="" ControlToValidate="txAddAnswer03" ValidationGroup="groupAdd">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="answer04" class="cols-sm-2 control-label">Answer 04</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-tasks fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Answer 04" ID="txAddAnswer04" ValidationGroup="groupAdd" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvAddAnswer04" runat="server" ErrorMessage="" ControlToValidate="txAddAnswer04" ValidationGroup="groupAdd">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div> 
                                                <div class="form-group">
                                                    <label for="correctAnswer" class="cols-sm-2 control-label">Correct Answer Number</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-check fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Correct Answer Number" ID="txAddCorrectAnswer" ValidationGroup="groupAdd" Rows="0" pattern="\d*" title="Only Numbers allowed"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvAddCorrectAnswer" runat="server" ErrorMessage="" ControlToValidate="txAddCorrectAnswer" ValidationGroup="groupAdd">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>                                                
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <asp:Button runat="server" CssClass="btn btn-success btn-lg btn-block login-button" Text="Submit" ID="btnAddQuestionSubmit" ValidationGroup="groupAdd" OnClick="btnAddQuestionSubmit_Click"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- Update Question Modal-->
                    <div class="modal fade" id="updateQuestionModal" data-backdrop="static" data-keyboard="false">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header" style="background: linear-gradient(#052a39, #03562c); color: white">
                                    <h5 class="modal-title">Update Question</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close" style="color: white">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <div class="container-fluid">
                                        <div class="row main col-xs-12">
                                            <div class="main-login col-xs-12 ">
                                                <div class="form-group">
                                                    <label for="questionId" class="cols-sm-2 control-label">Question ID</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-id-badge fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" ID="txUpdateQuestionId" ReadOnly="True" ValidationGroup="groupUpdate"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvUpdateQuestionId" runat="server" ErrorMessage="" ValidationGroup="groupUpdate" ControlToValidate="txUpdateQuestionId">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="moduleId" class="cols-sm-2 control-label">Module ID</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-id-badge fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" ID="txUpdateModuleId" ReadOnly="True" ValidationGroup="groupUpdate"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvUpdateModuleId" runat="server" ErrorMessage="" ValidationGroup="groupUpdate" ControlToValidate="txUpdateModuleId">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="questionName" class="cols-sm-2 control-label">Question</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-question fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Question" ID="txUpdateQuestion" ValidationGroup="groupUpdate" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvUpdateQuestion" runat="server" ErrorMessage="" ControlToValidate="txUpdateQuestion" ValidationGroup="groupUpdate">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div> 
                                                <div class="form-group">
                                                    <label for="answer01" class="cols-sm-2 control-label">Answer 01</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-tasks fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Answer 01" ID="txUpdateAnswer01" ValidationGroup="groupUpdate" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvUpdateAnswer01" runat="server" ErrorMessage="" ControlToValidate="txUpdateAnswer01" ValidationGroup="groupUpdate">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="answer02" class="cols-sm-2 control-label">Answer 02</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-tasks fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Answer 02" ID="txUpdateAnswer02" ValidationGroup="groupUpdate" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvUpdateAnswer02" runat="server" ErrorMessage="" ControlToValidate="txUpdateAnswer02" ValidationGroup="groupUpdate">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="answer03" class="cols-sm-2 control-label">Answer 03</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-tasks fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Answer 03" ID="txUpdateAnswer03" ValidationGroup="groupUpdate" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvUpdateAnswer03" runat="server" ErrorMessage="" ControlToValidate="txUpdateAnswer03" ValidationGroup="groupUpdate">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="answer04" class="cols-sm-2 control-label">Answer 04</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-tasks fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Answer 04" ID="txUpdateAnswer04" ValidationGroup="groupUpdate" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvUpdateAnswer04" runat="server" ErrorMessage="" ControlToValidate="txUpdateAnswer04" ValidationGroup="groupUpdate">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div> 
                                                <div class="form-group">
                                                    <label for="correctAnswer" class="cols-sm-2 control-label">Correct Answer Number</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-check fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Correct Answer Number" ID="txUpdateCorrectAnswer" ValidationGroup="groupUpdate" Rows="0" pattern="\d*" title="Only Numbers allowed"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvUpdateCorrectAnswer" runat="server" ErrorMessage="" ControlToValidate="txUpdateCorrectAnswer" ValidationGroup="groupUpdate">&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>                                                
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <asp:Button type="submit" runat="server" CssClass="btn btn-success btn-lg btn-block login-button" Text="Submit" ID="btnUpdateQuestionSubmit" ValidationGroup="groupUpdate" OnClick="btnUpdateQuestionSubmit_Click"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- View Question Modal-->
                    <div class="modal fade" id="viewQuestionModal" data-backdrop="static" data-keyboard="false">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header" style="background: linear-gradient(#052a39, #03562c); color: white">
                                    <h5 class="modal-title">View Question</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close" style="color: white">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <div class="container-fluid">
                                        <div class="row main col-xs-12">
                                            <div class="main-login col-xs-12 ">
                                                <div class="form-group">
                                                    <label for="questionId" class="cols-sm-2 control-label">Question ID</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-id-badge fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" ID="txViewQuestionId" ReadOnly="True"></asp:TextBox>                                                            
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="moduleId" class="cols-sm-2 control-label">Module ID</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-id-badge fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" ID="txViewModuleId" ReadOnly="True"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="questionName" class="cols-sm-2 control-label">Question</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-question fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Question" ID="txViewQuestion" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div> 
                                                <div class="form-group">
                                                    <label for="answer01" class="cols-sm-2 control-label">Answer 01</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-tasks fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Answer 01" ID="txViewAnswer01" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="answer02" class="cols-sm-2 control-label">Answer 02</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-tasks fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Answer 02" ID="txViewAnswer02" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="answer03" class="cols-sm-2 control-label">Answer 03</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-tasks fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Answer 03" ID="txViewAnswer03" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="answer04" class="cols-sm-2 control-label">Answer 04</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-tasks fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Answer 04" ID="txViewAnswer04" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div> 
                                                <div class="form-group">
                                                    <label for="correctAnswer" class="cols-sm-2 control-label">Correct Answer Number</label>
                                                    <div class="cols-sm-10">
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-check fa" aria-hidden="true"></i></span>
                                                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Correct Answer Number" ID="txViewCorrectAnswer" Rows="0" pattern="\d*" title="Only Numbers allowed" ReadOnly="True"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>                                                
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <asp:Button runat="server" CssClass="btn btn-success btn-lg btn-block login-button" Text="Close" ID="btnClose" data-dismiss="modal"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- Delete Question Modal -->
                    <div class="modal fade" id="deleteQuestionModal" data-backdrop="static" data-keyboard="false">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title">Delete Confirmation</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    Are you sure you want to delete Question
                                    <asp:Label runat="server" ID="lblDeleteQuestionId"></asp:Label>
                                    ?
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancel</button>
                                    <asp:Button type="submit" runat="server" CssClass="btn btn-primary" Text="Delete" ID="btnDeleteQuestion" OnClick="btnDeleteQuestion_Click"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>

                <!--Buttons-->
                <div class="col-sm-2">
                    <div>
                        <asp:LinkButton runat="server" CssClass="push_button green" data-toggle="modal" data-target="#addQuestionModal" ID="btnAdd"><span class="fa fa-user-plus"></span>&nbsp&nbsp Add</asp:LinkButton>
                    </div>
                    <div>
                        <asp:LinkButton runat="server" CssClass="push_button blue" data-toggle="modal" data-target="#viewQuestionModal" ID="btnView"><span class="fa fa-search"></span>&nbsp&nbsp View</asp:LinkButton>
                    </div>
                    <div>
                        <asp:LinkButton runat="server" CssClass="push_button orange" data-toggle="modal" data-target="#updateQuestionModal" ID="btnUpdate"><span class="fa fa-edit"></span>&nbsp&nbsp Update</asp:LinkButton>
                    </div>
                    <div>
                        <asp:LinkButton runat="server" CssClass="push_button red" data-toggle="modal" data-target="#deleteQuestionModal" ID="btnDelete"><span class="fa  fa-trash-o"></span>&nbsp&nbsp Delete</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>

    </form>



</asp:Content>
