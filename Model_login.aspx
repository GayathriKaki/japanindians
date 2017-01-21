<%@ Page Language="VB" MasterPageFile="PWIP_MasterPage.master" AutoEventWireup="false" CodeFile="Model_login.aspx.vb" Inherits="pwip_Model_login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form id="frm_login" runat="server">
<table align="center" >

 <tr>
        <td colspan="2"><asp:Label   CssClass ="lblred" Visible="false" ID="lblmsg" runat="server" Text=""></asp:Label></td>
        
    </tr>
    
    <tr>
        <td>Username</td>
        <td><asp:TextBox ID="txt_username"  CssClass="Csstxtbox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Password</td>
        <td><asp:TextBox ID="txt_password"  CssClass="Csstxtbox" TextMode="Password" runat="server"></asp:TextBox></td>
    </tr>
    
    <tr>
        <td></td>
        
        <td><asp:Button ID="btn_submit" runat="server" Text="Login" /></td>
    </tr>
    
     <tr>
    <td>&nbsp;</td>
    <td align="left">
        <a href="CustRegister.aspx">Register</a>&nbsp;&nbsp;<a href="forgot_password.aspx">Forgot Password</a></td>
  </tr>
  
</table>
</form>
</asp:Content>

