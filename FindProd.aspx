<%@ Page Language="VB" MasterPageFile="PWIP_MasterPage.master" AutoEventWireup="false" CodeFile="FindProd.aspx.vb" Inherits="FindProd"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form id="frmSearchstore" runat="server">
<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="background-color:White">

<asp:Panel ID="searchPanel"   runat="server">
              <tr><td>&nbsp;</td></tr>
              <tr> 
                <td   align="center"><strong style="color:#0000FF; font-size:16px; color:#024C83;">Find Resale Products Near You</strong><%--<img src="images/header-find-shop2.gif" border="0" width="559" height="38" alt="Find shop" />--%><%--<b>Find A Quilt Shop near you</b>--%></td>
              </tr>
              <tr><td>&nbsp;</td></tr>
             
              <tr> 
                <td>&nbsp;</td>
              </tr>
              <tr>
                <td align="center" style="font-size:12px; ">
				      								
								<table width="70%" border="0">
								
								<tr>
    <td align="right" width="14%" valign="top"><strong>State/Prefecture : </strong></td>
    <td align="left" width="14%" valign="top">
        <asp:DropDownList ID="dd_state" OnSelectedIndexChanged="State_click"  Width="150" runat="server" AutoPostBack="true" ></asp:DropDownList>&nbsp;</td>
 
    <td align="right" width="14%" valign="top"><strong>City :</strong> </td>
    <td align="left" width="14%" valign="top">
        <asp:DropdownList ID="dd_city" runat="server"  Width="150"></asp:DropdownList>&nbsp;</td>
		<td width="14%" valign="top">&nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server"  Text="Search" /></td>
  </tr>					
                          
                          </table>
				    
				  </td>
              </tr> 
			  
			  <!-- Search by name -->
			  
			   <tr>
                <td align="center" style="font-size:12px; ">
				      								
								<table width="70%" border="0">
								
								<tr>
    <td align="left" width="14%" valign="top"><strong>Product name :&nbsp;&nbsp;&nbsp;&nbsp; </strong>
        <asp:Textbox ID="txtSearch" runat="server" ></asp:Textbox>&nbsp;</td>
 
   
		<td width="14%" valign="top" align="left">&nbsp;&nbsp;<asp:Button ID="btnSearchbyName" OnClick="btnSearchbyName_click" runat="server"  Text="Search by Product Name" /></td>
  </tr>					
                          
                          </table>
				    
				  </td>
              </tr> 
			  <!-- end search by name -->
              <tr><td>&nbsp;</td></tr>
            
              <tr><td>&nbsp;</td></tr>
             
            </asp:panel>  
         
			
			 <tr> 
                <td>
				    <table width="85%" align="center">
					
					 <tr>
				            <td align="Center">
					        	        <asp:Label ID="lblsend" runat="server" Font-Bold="true" Text="Select the items  you want to send and click on <br>'Send Your selected items to ALL' to send the items to all the registered memeber in a Email. "></asp:Label><br /><br />
				            </td>
				        </tr>
				        <tr>
				            <td align="Center">
					        	        <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
				            </td>
				        </tr>
			        </table>
				</td>
              </tr>
			  
			   <tr> 
                <td    align="center" ><strong style="color:#0000FF; font-size:16px; color:#024C83;">Product Owners</strong>
                </td>
              </tr>
              <tr><td>&nbsp;</td></tr>
             
              <tr> 
                <td align="center">&nbsp;<a href="vnd_prod_edit.aspx"> <b>Click here to Add Your Product</b></a><br /></td>
              </tr>
			  <tr><td valign="top" align="center">&nbsp;&nbsp;<asp:Button ID="btnSendMail2" OnClick="sendmail"   Visible="false"  runat="server"  Text="Send selected items to All" /></td></tr>	
			<tr>
			<td>
			
 <asp:datalist ID="storeslist" runat="server" ItemStyle-VerticalAlign="middle" Width="100%" RepeatColumns="1"  CellSpacing="5"    RepeatDirection="Horizontal" BorderWidth="0">
					<ItemTemplate>			  
						  <table    border="0" bordercolor="#ffffff" width="100%"  cellspacing="5" cellpadding="9"  bgcolor="lightblue">
         
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
                  <br/><br/><a href="FindProd.aspx?custid=<%# DataBinder.Eval(Container.DataItem, "cust_id") %>">View All Products posted by this User</a>             
			
             </font>
			  <br><br>
			  </td>
			 <td> <%#GetEditData(DataBinder.Eval(Container.DataItem, "cust_id"),DataBinder.Eval(Container.DataItem, "prod_id"))%></td>
                                  
                                </tr>                          
                                
                              </table><td></tr></table>
							</ItemTemplate>
	</asp:datalist>
	</td>
	</tr>
		
             </table>
             
         </form>
	 </asp:content>



