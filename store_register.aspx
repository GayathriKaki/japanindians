<%@ Page Language="VB" MasterPageFile="PWIP_MasterPage.master" AutoEventWireup="false" CodeFile="store_register.aspx.vb" Inherits="store_register"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form id="frm_store" runat="server">
<table width="100%" border="0" cellspacing="0" cellpadding="0"  style=" background-color:White">
<tr><td align="center">
<table width="80%" border="1" bordercolor="lightblue" cellspacing="1" cellpadding="2"  class="main"  >
  <tr>
    <td colspan="2" align="center" bgcolor="lightblue"><b><font color="#000000">Add Store</font></b></td>
  </tr>
  <tr>
    <td colspan="2" align="center"><asp:Label  ID="lblWarning"  ForeColor="#FF0000" Font-Bold="true"   runat="server"></asp:Label></td>
  </tr>
  <tr>
    <td width="50%" align="right"><strong>Name:<font style="color: red;"> *</font></strong></td>
    <td  align="left" width="50%"><asp:TextBox ID="txtname" runat="server"   Width="230"/>&nbsp;
     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtname" ErrorMessage="Enter Store Name"></asp:RequiredFieldValidator></td>
  </tr>
  
  
  <tr>
    <td width="50%" align="right"><strong>Description:</strong></td>
    <td  align="left" width="50%"><asp:TextBox ID="txtdesc" TextMode="MultiLine" Rows="5" Columns="20" runat="server"   Width="230"/>&nbsp;
    </td>
  </tr>
  <tr >
    <td align="right"><strong>Address:<font style="color: red;"> *</font></strong></td>
    <td align="left" ><asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Rows="5" Columns="20" Width="230" />&nbsp;
     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAddress" ErrorMessage="Enter Address"></asp:RequiredFieldValidator>
    </td>
  </tr>
  
  <tr >
    <td align="right"><strong>Country:</strong></td>
    <td align="left" ><asp:DropDownList ID="dd_country"   DataTextField="country_name" AutoPostBack="false" DataValueField="country_id" Width="235px" style="font-size:12px" runat="server"  />
    </td>
  </tr>

  <tr >
    <td align="right"><strong>State:<font style="color: red;"> *</font></strong></td>
    <td align="left" ><asp:DropDownList ID="dd_state" AutoPostBack="true" DataTextField="state_name" DataValueField="state_id"    Width="235px" style="font-size:12px" runat="server"  />&nbsp;
     <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="dd_state" ErrorMessage="Enter State"></asp:RequiredFieldValidator>
    </td>
  </tr>
  
  
    
  <tr >
    <td align="right"><strong>City:<font style="color: red;"> *</font></strong></td>
    <td align="left" ><asp:DropDownList ID="dd_city" runat="server"  Width="230" />&nbsp;
    
    </td>
  </tr>
  
  <tr >
    <td align="right"><strong>Zip:<font style="color: red;"> *</font></strong></td>
    <td align="left" ><asp:TextBox ID="txtzip" runat="server"  Width="230" />&nbsp;
     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtzip" ErrorMessage="Enter Zip"></asp:RequiredFieldValidator>
     
            <br />
            Ex: xxxxx
    </td>
  </tr>
  <tr >
    <td align="right"><strong>Phone:<font style="color: red;"> *</font></strong></td>
    <td align="left" ><asp:TextBox ID="txtphone" runat="server"  Width="230" />&nbsp;
     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtphone" ErrorMessage="Enter Phone"></asp:RequiredFieldValidator>
      <%--<asp:RegularExpressionValidator ID="rwphone" runat="server" ControlToValidate="txtphone"
                       ErrorMessage="InValid Phone" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" ></asp:RegularExpressionValidator>
            <br />
            Ex: xxx-xxx-xxxx--%>
    </td>
  </tr>
  <tr >
    <td align="right"> <strong>Email:<font style="color: red;"> *</font></strong></td>
    <td align="left" ><asp:TextBox ID="txtemail" runat="server"  Width="230" />&nbsp;
     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtemail" ErrorMessage="Enter Email"></asp:RequiredFieldValidator>
      <asp:RegularExpressionValidator ID="rgmail" runat="server" ControlToValidate ="txtemail" ErrorMessage="Enter valid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
    </td>
  </tr>
  <tr >
    <td align="right"><strong>Contact:</strong></td>
    <td align="left" ><asp:TextBox ID="txtcontact" runat="server"  Width="230" />
    </td>
  </tr>
  <tr >
    <td align="right"><strong>Website:</strong></td>
    <td align="left" ><asp:TextBox ID="txtwebsite" runat="server"  Width="230" />
    </td>
  </tr>
  
   <tr >
    <td align="right"><strong>Google Map Link:</strong></td>
    <td align="left" ><asp:TextBox ID="txtmap" runat="server"  Width="230" />
    </td>
  </tr>
  
    <tr>
      <td align="right" style="height: 45px"><strong>Upload Picture:</strong></td>
      <td align="left" style="height: 45px"><input type="file" name="FImgThumb" id="FImgThumb"  runat="server"/>
        &nbsp;
        <asp:Label ID="lblTimg" runat="server"></asp:Label>  <br />      
       </td>
    </tr>
  <tr >
    <td>&nbsp;</td>
    <td align="left" ><asp:Button ID="btnSubmit" Text="&nbsp;Submit&nbsp;" runat="server" />
      &nbsp;
      <asp:Button ID="btncancel" Text="Back"  CausesValidation="false" runat="server" />
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
  </tr>
  
  <tr>
    <td colspan="2">&nbsp;</td>
  </tr>
</table>
</td></tr>
</table>
</form>

</asp:Content>

