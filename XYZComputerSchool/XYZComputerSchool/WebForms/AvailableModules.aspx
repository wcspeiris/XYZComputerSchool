<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/XYZStudentMasterPage.Master" AutoEventWireup="true" CodeBehind="AvailableModules.aspx.cs" Inherits="XYZComputerSchool.WebForms.AvailableModules" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Bootstrap Custom Designs/Grid Design/GridStyle.css" rel="stylesheet" />
    <link href="Bootstrap Custom Designs/css/button-designs.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="body" runat="Server">
    <form id="StudentGradesForm" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <h2 style="text-align: center; font-family: CHAMBERS; font-size: 30px">Available Modules</h2>
                </div>
            </div>
        </div>
        <div class="container-fluid">
            <div class="row">
                <div class="col-sm-10 table-responsive" style="overflow-x: auto">
                    <asp:GridView ID="GridViewAvailbleModules" runat="server" AutoGenerateColumns="False" EmptyDataText="There are no data records to display." CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="mGrid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" AllowPaging="True" PageSize="7" OnSelectedIndexChanged="GridViewAvailbleModules_SelectedIndexChanged" OnPageIndexChanging="GridViewAvailbleModules_PageIndexChanging">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn btn-primary" ControlStyle-Height="35px" ShowSelectButton="True" />
                            <asp:BoundField DataField="containModuleId" HeaderText="Module Id" SortExpression="containModuleId" ItemStyle-Wrap="True" HeaderStyle-Wrap="True" FooterStyle-Wrap="True" ReadOnly="True">
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

                <!-- Begin Exam Modal -->
                    <div class="modal fade" id="beginExamModal" data-backdrop="static" data-keyboard="false">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title">Begin Exam</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <asp:Label runat="server" ID="lblMsg01">You are about to begin the exam for the module</asp:Label> 
                                    <asp:Label runat="server" ID="lblModuleName"></asp:Label>
                                    <asp:Label runat="server" ID="lblMsg02">. Once started the process cannot be stopped until the completing the Exam successfully. Do you want to continue?</asp:Label>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancel</button>
                                    <asp:Button type="submit" runat="server" CssClass="btn btn-primary" Text="Begin Exam" ID="btnBeginExam" OnClick="btnBeginExam_Click"></asp:Button>                                    
                                </div>
                            </div>
                        </div>
                    </div>

                <!--Attempts-->
                <div class="col-sm-2">
                    <div class="text-center">
                        <asp:Label ID="lblAttemptsText" runat="server" Text=""><h5>Attempts Taken</h5></asp:Label>                        
                        <h5><asp:Label ID="lblAttemptsTaken" runat="server" Text=""></asp:Label></h5>
                    </div>
                    <div>
                        <br />
                        <asp:LinkButton runat="server" CssClass="push_button red" data-toggle="modal" data-target="#beginExamModal" ID="btnBeginExamView"><span class="fa fa-hourglass-start"></span>&nbsp&nbsp Begin Exam</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>


    </form>
</asp:Content>