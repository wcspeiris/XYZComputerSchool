<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/XYZExamPaper.Master" AutoEventWireup="true" CodeBehind="ExamComplete.aspx.cs" Inherits="XYZComputerSchool.WebForms.ExamComplete" %>
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
                <div class="form-group" style="margin-top:80px">
                    <h4 style="font-family:Rockwell; text-align:justify"> You are at the final page of the current Exam. Go back if you are not answered all the questions or click finish to complete the Exam. </h4>
                    <br />                    
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                <asp:LinkButton runat="server" CssClass="btn btn-primary" ID="btnGoBack" OnClick="btnGoBack_Click"><span class="fa  fa-arrow-left"></span>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp Go Back &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</asp:LinkButton>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                <asp:LinkButton runat="server" CssClass="btn btn-success" ID="btnFinish" OnClick="btnFinish_Click">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp Finish &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp <span class="fa  fa-flag-checkered"></span></asp:LinkButton>                
            </div>
        </div>
    </div>
</asp:Content>
