<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/XYZStudentMasterPage.Master" AutoEventWireup="true" CodeBehind="Exam.aspx.cs" Inherits="XYZComputerSchool.WebForms.Exam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Bootstrap Custom Designs/Grid Design/GridStyle.css" rel="stylesheet" />
    <link href="Bootstrap Custom Designs/css/button-designs.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="body" runat="Server">
    <form id="StudentGradesForm" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <h2 style="text-align: center; font-family: CHAMBERS; font-size: 30px">Online Exam</h2>
                </div>
            </div>
        </div>
        <div class="container-fluid">
            <div class="row">
                <div class="col-sm-10 col-sm-push-1" style="overflow-x: auto">
                    <div class="form-group">
                        <asp:label runat="server" text="01." id="lbl01"></asp:label>
                        <asp:label runat="server" text="Question" ID="lblQuestion01"></asp:label>
                        <asp:requiredfieldvalidator ID="rfvQuestion01" runat="server" errormessage="" ControlToValidate="rbListQuestion01">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:requiredfieldvalidator>
                        <asp:radiobuttonlist runat="server" ID="rbListQuestion01">
                        </asp:radiobuttonlist>
                    </div>

                    <div class="form-group">
                        <asp:label runat="server" text="02." id="lbl02"></asp:label>
                        <asp:label runat="server" text="Question" ID="lblQuestion02"></asp:label>
                        <asp:requiredfieldvalidator ID="rfvQuestion02" runat="server" errormessage="" controltovalidate="rbListQuestion02">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:requiredfieldvalidator>
                        <asp:radiobuttonlist runat="server" ID="rbListQuestion02">
                        </asp:radiobuttonlist>
                    </div>

                    <div class="form-group">
                        <asp:label runat="server" text="03." id="lbl03"></asp:label>
                        <asp:label runat="server" text="Question" ID="lblQuestion03"></asp:label>
                        <asp:requiredfieldvalidator ID="rfvQuestion03" runat="server" errormessage="" controltovalidate="rbListQuestion03">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:requiredfieldvalidator>
                        <asp:radiobuttonlist runat="server" ID="rbListQuestion03">
                        </asp:radiobuttonlist>
                    </div>

                    <div class="form-group">
                        <asp:label runat="server" text="04." id="lbl04"></asp:label>
                        <asp:label runat="server" text="Question" ID="lblQuestion04"></asp:label>
                        <asp:requiredfieldvalidator ID="rfvQuestion04" runat="server" errormessage="" controltovalidate="rbListQuestion04">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:requiredfieldvalidator>
                        <asp:radiobuttonlist runat="server" ID="rbListQuestion04">
                        </asp:radiobuttonlist>
                    </div>

                    <div class="form-group">
                        <asp:label runat="server" text="05." id="lbl05"></asp:label>
                        <asp:label runat="server" text="Question" ID="lblQuestion05"></asp:label>
                        <asp:requiredfieldvalidator ID="rfvQuestion05" runat="server" errormessage="" controltovalidate="rbListQuestion05">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:requiredfieldvalidator>
                        <asp:radiobuttonlist runat="server" ID="rbListQuestion05">
                        </asp:radiobuttonlist>
                    </div>

                    <div class="form-group">
                        <asp:label runat="server" text="06." id="lbl06"></asp:label>
                        <asp:label runat="server" text="Question" ID="lblQuestion06"></asp:label>
                        <asp:requiredfieldvalidator ID="rfvQuestion06" runat="server" errormessage="" controltovalidate="rbListQuestion06">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:requiredfieldvalidator>
                        <asp:radiobuttonlist runat="server" ID="rbListQuestion06">
                        </asp:radiobuttonlist>
                    </div>

                    <div class="form-group">
                        <asp:label runat="server" text="07." id="lbl07"></asp:label>                        
                        <asp:label runat="server" text="Question" ID="lblQuestion07"></asp:label>
                        <asp:requiredfieldvalidator ID="rfvQuestion07" runat="server" errormessage="" controltovalidate="rbListQuestion07">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:requiredfieldvalidator>
                        <asp:radiobuttonlist runat="server" ID="rbListQuestion07">
                        </asp:radiobuttonlist>
                    </div>

                    <div class="form-group">
                        <asp:label runat="server" text="08." id="lbl08"></asp:label>
                        <asp:label runat="server" text="Question" ID="lblQuestion08"></asp:label>
                        <asp:requiredfieldvalidator ID="rfvQuestion08" runat="server" errormessage="" controltovalidate="rbListQuestion08">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:requiredfieldvalidator>
                        <asp:radiobuttonlist runat="server" ID="rbListQuestion08">
                        </asp:radiobuttonlist>
                    </div>

                    <div class="form-group">
                        <asp:label runat="server" text="09." id="lbl09"></asp:label>
                        <asp:label runat="server" text="Question" ID="lblQuestion09"></asp:label>
                        <asp:requiredfieldvalidator ID="rfvQuestion09" runat="server" errormessage="" controltovalidate="rbListQuestion09">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:requiredfieldvalidator>
                        <asp:radiobuttonlist runat="server" ID="rbListQuestion09">
                        </asp:radiobuttonlist>
                    </div>

                    <div class="form-group">
                        <asp:label runat="server" text="10." id="lbl10"></asp:label>
                        <asp:label runat="server" text="Question" ID="lblQuestion10"></asp:label>
                        <asp:requiredfieldvalidator ID="rfvQuestion10" runat="server" errormessage="" controltovalidate="rbListQuestion10">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:requiredfieldvalidator>
                        <asp:radiobuttonlist runat="server" ID="rbListQuestion10">
                        </asp:radiobuttonlist>
                    </div>

                    <div class="form-group">
                        <asp:label runat="server" text="11." id="lbl11"></asp:label>
                        <asp:label runat="server" text="Question" ID="lblQuestion11"></asp:label>
                        <asp:requiredfieldvalidator ID="rfvQuestion11" runat="server" errormessage="" controltovalidate="rbListQuestion11">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:requiredfieldvalidator>
                        <asp:radiobuttonlist runat="server" ID="rbListQuestion11">
                        </asp:radiobuttonlist>
                    </div>

                    <div class="form-group">
                        <asp:label runat="server" text="12." id="lbl12"></asp:label>
                        <asp:label runat="server" text="Question" ID="lblQuestion12"></asp:label>
                        <asp:requiredfieldvalidator ID="rfvQuestion12" runat="server" errormessage="" controltovalidate="rbListQuestion12">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:requiredfieldvalidator>
                        <asp:radiobuttonlist runat="server" ID="rbListQuestion12">
                        </asp:radiobuttonlist>
                    </div>

                    <div class="form-group">
                        <asp:label runat="server" text="13." id="lbl13"></asp:label>
                        <asp:label runat="server" text="Question" ID="lblQuestion13"></asp:label>
                        <asp:requiredfieldvalidator ID="rfvQuestion13" runat="server" errormessage="" controltovalidate="rbListQuestion13">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:requiredfieldvalidator>
                        <asp:radiobuttonlist runat="server" ID="rbListQuestion13">
                        </asp:radiobuttonlist>
                    </div>

                    <div class="form-group">
                        <asp:label runat="server" text="14." id="lbl14"></asp:label>
                        <asp:label runat="server" text="Question" ID="lblQuestion14"></asp:label>
                        <asp:requiredfieldvalidator ID="rfvQuestion14" runat="server" errormessage="" controltovalidate="rbListQuestion14">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:requiredfieldvalidator>
                        <asp:radiobuttonlist runat="server" ID="rbListQuestion14">
                        </asp:radiobuttonlist>
                    </div>

                    <div class="form-group">
                        <asp:label runat="server" text="15." id="lbl15"></asp:label>
                        <asp:label runat="server" text="Question" ID="lblQuestion15"></asp:label>
                        <asp:requiredfieldvalidator ID="rfvQuestion15" runat="server" errormessage="" controltovalidate="rbListQuestion15">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<img src="Images/Required.png"/></asp:requiredfieldvalidator>
                        <asp:radiobuttonlist runat="server" ID="rbListQuestion15">
                        </asp:radiobuttonlist>
                    </div>

                    <div>
                        <asp:button type="submit" runat="server" cssclass="btn btn-primary" text="Complete Exam" id="btnCompleteExam" OnClick="btnCompleteExam_Click"></asp:button>
                    </div>
                </div>
            </div>
        </div>


    </form>
</asp:Content>
