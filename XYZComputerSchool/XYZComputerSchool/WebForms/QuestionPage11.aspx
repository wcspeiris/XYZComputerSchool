<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/XYZExamPaper.Master" AutoEventWireup="true" CodeBehind="QuestionPage11.aspx.cs" Inherits="XYZComputerSchool.WebForms.QuestionPage11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-9">
                <h2 style="text-align: center; font-family: CHAMBERS; font-size: 30px">Online Exam</h2>
            </div>
        </div>
    </div>
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-11 col-sm-push-1" style="height:330px">
                <div class="form-group">
                    <br />
                    <asp:HiddenField ID="hf11" runat="server" />
                    <asp:HiddenField ID="hfCorrectAns11" runat="server" />
                    <asp:Label runat="server" Text="11." ID="lbl11"></asp:Label>
                    <asp:Label runat="server" Text="Question" ID="lblQuestion11"></asp:Label><br /><br />                   
                    <asp:RadioButtonList runat="server" ID="rbListQuestion11" AutoPostBack="True" OnSelectedIndexChanged="rbListQuestion11_SelectedIndexChanged">
                    </asp:RadioButtonList>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                <asp:LinkButton runat="server" CssClass="btn btn-primary" ID="btnGotoPrevious" OnClick="btnGotoPrevious_Click"><span class="fa  fa-arrow-left"></span>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp Goto Previous &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</asp:LinkButton>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                <asp:LinkButton runat="server" CssClass="btn btn-warning" ID="btnMarkForReview" OnClick="btnMarkForReview_Click">Mark for Review & Next</asp:LinkButton>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                <asp:LinkButton runat="server" CssClass="btn btn-success" ID="btnSaveAndNext" OnClick="btnSaveAndNext_Click">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp Save & Next &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp <span class="fa  fa-arrow-right"></span></asp:LinkButton>                
            </div>
        </div>
    </div>
</asp:Content>