<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/XYZMasterPage.Master" AutoEventWireup="true" CodeBehind="StudentGrades.aspx.cs" Inherits="XYZComputerSchool.WebForms.StudentGrades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Bootstrap Custom Designs/Grid Design/GridStyle.css" rel="stylesheet" />
    <link href="Bootstrap Custom Designs/css/button-designs.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="body" runat="Server">
    <form id="StudentGradesForm" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <h2 style="text-align: center; font-family: CHAMBERS; font-size: 30px">Student Grades</h2>
                </div>
            </div>
        </div>
        <div class="container-fluid">
            <div class="row">
                <div class="col-sm-6 table-responsive" style="overflow-x: auto">
                    <asp:GridView ID="GridViewStudents" runat="server" AutoGenerateColumns="False" EmptyDataText="There are no data records to display." CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="mGrid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" AllowPaging="True" PageSize="7" DataKeyNames="studentId" OnSelectedIndexChanged="GridViewStudents_SelectedIndexChanged" OnPageIndexChanging="GridViewStudents_PageIndexChanging">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn btn-primary" ControlStyle-Height="35px" ShowSelectButton="True" />
                            <asp:BoundField DataField="studentId" HeaderText="Stu Id" SortExpression="studentId" ItemStyle-Wrap="True" HeaderStyle-Wrap="True" FooterStyle-Wrap="True" ReadOnly="True">
                                <FooterStyle Wrap="True"></FooterStyle>
                                <HeaderStyle Wrap="True"></HeaderStyle>
                                <ItemStyle Wrap="True"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="firstName" HeaderText="First Name" SortExpression="firstName" />
                            <asp:BoundField DataField="lastName" HeaderText="Last Name" SortExpression="lastName" />
                            <asp:BoundField DataField="courseName" HeaderText="Course" SortExpression="courseName" />
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

                <div class="col-sm-6 table-responsive" style="overflow-x: auto">
                    <asp:GridView ID="GridViewStudentModules" runat="server" AutoGenerateColumns="False" EmptyDataText="There are no data records to display." CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="mGrid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" AllowPaging="True" PageSize="5" OnPageIndexChanging="GridViewStudentModules_PageIndexChanging" OnSelectedIndexChanged="GridViewStudentModules_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn btn-primary" ControlStyle-Height="35px" ShowSelectButton="True" />
                            <asp:BoundField DataField="moduleId" HeaderText="Module ID" SortExpression="moduleId" ItemStyle-Wrap="True" HeaderStyle-Wrap="True" FooterStyle-Wrap="True" ReadOnly="True">
                                <FooterStyle Wrap="True" />
                                <HeaderStyle Wrap="True" />
                                <ItemStyle Wrap="True" />
                            </asp:BoundField>
                            <asp:BoundField DataField="moduleName" HeaderText="Module Name" SortExpression="moduleName" />
                            <asp:BoundField DataField="examAttempt" HeaderText="Attempt" SortExpression="examAttempt" />
                            <asp:BoundField DataField="examAttemptedDateTime" HeaderText="Attempted Date" SortExpression="examAttemptedDateTime" />
                            <asp:BoundField DataField="examMarks" HeaderText="Correct Answers" SortExpression="examMarks" />
                            <asp:BoundField DataField="percentage" HeaderText="%" SortExpression="percentage" />
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

                <!-- View Answer Paper Modal-->
                <div class="modal fade" id="viewAnswerPaperModal" data-backdrop="static" data-keyboard="false">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header" style="background: linear-gradient(#052a39, #03562c); color: white">
                                <h5 class="modal-title">Answer Paper</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close" style="color: white">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <div class="container-fluid">
                                    <div class="row main col-xs-12">
                                        <asp:Panel runat="server" class="main-login col-xs-12" ID="panelDataView">
                                            
                                        </asp:Panel>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button runat="server" CssClass="btn btn-success btn-lg btn-block login-button" Text="Close" ID="btnClose" data-dismiss="modal"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>

                <!--Buttons-->
                
            </div>
        </div>

        <div class="container-fluid">
            <div class="row">
                <div class="col-sm-2 col-sm-push-8">
                    <div>
                        <asp:LinkButton runat="server" CssClass="push_button blue" data-toggle="modal" data-target="#viewAnswerPaperModal" ID="btnView"><span class="fa fa-search"></span>&nbsp&nbsp View</asp:LinkButton>
                    </div>                    
                </div>
            </div>
        </div>
    </form>
</asp:Content>
