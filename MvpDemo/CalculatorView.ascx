<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CalculatorView.ascx.cs"
            Inherits="MvpDemo.CalculatorView" %>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Calculate" />
    <br />
    <br />
    The result is:
    <asp:Label ID="Label1" runat="server" Text="<%# Model.Result %>"></asp:Label>

    <br/>
    <br/>
    <br/>
    Enter Password For Validation: <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Validate" />
    <br/>
    Password validation result:
    <asp:Label ID="Label2" runat="server" Text="<%# Model.PasswordValidationResult %>"></asp:Label>
    </ContentTemplate>
</asp:UpdatePanel>