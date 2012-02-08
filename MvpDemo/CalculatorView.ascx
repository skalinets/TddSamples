<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CalculatorView.ascx.cs"
    Inherits="MvpDemo.CalculatorView" %>
<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Calculate" />
<br />
<br />
The result is:
<asp:Label ID="Label1" runat="server" Text="<%#Model.Result %>"></asp:Label>
