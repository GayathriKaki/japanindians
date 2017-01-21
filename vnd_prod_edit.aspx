<%@ Page Language="VB" MasterPageFile="pwip_MasterPage.master" AutoEventWireup="false" CodeFile="vnd_prod_edit.aspx.vb" Inherits="pwip_vnd_prod_edit"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script language="javascript" type="text/javascript" src="js/datetimepicker.js"></script>
<form id="frm_prdedit" runat ="server" >

<table width="100%" border="0" cellspacing="1" cellpadding="2"  class="main">

 <tr>
      <td colspan="2" align="center"><asp:Label Font-Size="14px"  id="lblWarning" ForeColor="#FF0000" Visible="false" Font-Bold="true" Text="lbl" runat="server"></asp:Label></td>
    </tr>
	
	
	<tr><td valign="top">
  <table width="100%" border="0" >
  <tr><td colspan="2" align="right">
      <asp:LinkButton ID="lnkBack" runat="server" Font-Bold="true" CausesValidation="False"></asp:LinkButton></td></tr>
     <tr>
      <td colspan="2" align="center" class="tblhead"><b><font color="#000000">Click on "MY Products" link in the menu to view all the products added by you.<br />On "My Products you have the option to send an email notification regarding your products to all the customers.</font></b></td>
    </tr>  
	
	<tr><td colspan="2">&nbsp;</td></tr>
      <tr>
      <td colspan="2" align="center" class="tblhead"><b><font color="#000000">Add Product</font></b></td>
    </tr>
   
   
    <tr>
      <td colspan="2" align="center">&nbsp;</td>
    </tr>
    <tr>
      <td align="right" style="width: 50%"><strong>Name :</strong></td>
      <td  align="left"><asp:TextBox ID="txtname" runat="server"   Width="230px"/></td>
    </tr>
   
  
  
    <tr >
      <td align="right" width="50%"><strong>Description:</strong></td>
      <td align="left"><asp:TextBox ID="txtDesc" runat="server"  Rows="4" Columns="27" TextMode="MultiLine"/>      </td>
    </tr>
   
   
   
   
   
    
	
        <tr>
          <td align="right" style="height: 29px; width: 302px;">
              <strong>Cost &nbsp;:</strong></td>
          <td align="left" style="height: 29px">
              <asp:TextBox ID="txtprice" runat="server" Width="230px"></asp:TextBox></td>
      </tr>
      
     
	 
      
     
	 
      
    <tr>
        <td colspan="2">
        
        &nbsp;<asp:Panel ID="PanelDates" runat="server"  Width="100%">
            </asp:Panel>
        </td>
       
    </tr>
       
      <tr>
          <td width="50%">
          </td>
          <td align="left">
              <asp:CheckBox ID="chkhide" runat="server" Text="Hide this product" /></td>
      </tr>
       
	   
   
 
 
    
     <tr>
      <td align="right" style="height: 45px; width: 302px;"><strong>Product Picture:</strong></td>
      <td align="left" style="height: 45px"><input type="file" name="FImgLarge" id="FImgLarge"  runat="server"/>
        &nbsp; <asp:Label ID="lblLimg2" Visible="false" runat="server"></asp:Label>
        <asp:Label ID="lblLimg" runat="server"></asp:Label>  <br />      
        The image size should be Appox. 300 x 300 px</td>
    </tr>
	
	   <tr>
      <td align="right"><strong>Last Day to Go By :</strong></td>
      <td  align="left"><asp:TextBox ID="txt_date" runat="server"   Width="230"/>&nbsp; <a href="javascript:NewCal('ctl00_ContentPlaceHolder1_txt_date','ddmmmyyyy',true,12)"><img src="images/cal.gif" width="16" height="16" border="0"></a></td>
    </tr>
	
	
  
    <tr >
      <td align="right" width="50%"><strong>Product Pick up Address:</strong></td>
      <td align="left"><asp:TextBox ID="txtAddr" runat="server"  Rows="4" Columns="27" TextMode="MultiLine"/>      </td>
    </tr>
	 <tr>
      <td align="right" style="visibility:hidden;" width="50%"><strong>Product Category :</strong></td>
      <td  align="left">
          <asp:DropDownList ID="cmbprodcat" Visible="false" runat="server" Width="230px">
          </asp:DropDownList></td>
    </tr>
    <tr>
      <td width="50%">&nbsp;</td>
      <td align="left"><asp:Button ID="btnSubmit" Text="Submit" runat="server" />
        &nbsp;
        <asp:Button ID="btncancel" Text="&nbsp;Back&nbsp;" runat="server" />
          &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
    </tr></table></td><td valign="top">
   <table>
		<tr><td valign="top" align="center">&nbsp;&nbsp;<asp:Button ID="btnSendMail2" OnClick="sendmail"   Visible="false"  runat="server"  Text="Send selected products to All" />&nbsp;&nbsp;<asp:Button ID="btnSendMail3" OnClick="sendmail2"   Visible="false"  runat="server"  Text="Send All products" /></td></tr>	<tr><td>
 <asp:datalist ID="storeslist" runat="server" ItemStyle-VerticalAlign="middle" RepeatColumns="1"  CellSpacing="5"    RepeatDirection="Horizontal" BorderWidth="0">
					<ItemTemplate>			  
						  <table    border="0" bordercolor="#ffffff"  cellspacing="5" cellpadding="9"  bgcolor="lightblue">
         
            <tr>
              <td  width="5%" >
			  
			   <%#SelectProd(DataBinder.Eval(Container.DataItem, "prod_id")) %></td><td>
			  <%#GetImgURL(DataBinder.Eval(Container.DataItem, "prod_largeimage"), DataBinder.Eval(Container.DataItem, "cust_id"))%>
			  
			
              
           	 </td>
			 <td align="left" width="100%">
			 <table width="100%">
			 	<tr>
                    <td  valign="Top" align="left"  width="70%"  >
					<font size="2"  face="Arial, Helvetica, sans-serif">
					
					<b><%# DataBinder.Eval(Container.DataItem, "prod_name") %></b>
            <br><%# DataBinder.Eval(Container.DataItem, "prod_desc") %>
			  <br><%# DataBinder.Eval(Container.DataItem, "prod_price") %>
			  			  <br><%# DataBinder.Eval(Container.DataItem, "last_day_togo") %>
              		<br />Address:<br><%# DataBinder.Eval(Container.DataItem, "prod_pickup_address") %>
					             
				
              	  <%#GetData(DataBinder.Eval(Container.DataItem, "cust_cellnumber"), "<br>Phone number: ")%>
              	   <%# GetData(DataBinder.Eval(Container.DataItem, "cust_name"),"<br>Contact Person:") %>
                  <a href="mailto:<%# DataBinder.Eval(Container.DataItem, "cust_email") %>">
				  <%#GetData(DataBinder.Eval(Container.DataItem, "cust_email"), "<br>Email:")%></a>                     
                        
			
             </font>
			  <br><br>
			  </td>
			                      
                                </tr>                          
                                
                              </table><td></tr></table>
							</ItemTemplate>
	</asp:datalist></td></tr></table>
	</td>
	</tr>
	
</table>
</form>
</asp:Content>

