<%@ Page Language="VB" MasterPageFile="PWIP_MasterPage.master" AutoEventWireup="false" CodeFile="findpeople.aspx.vb" Inherits="FindPeople" title="Japan Indians " %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form id="frmSearchpeople" runat="server">
<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="background-color:White">
              <tr><td>&nbsp;</td></tr>
              <tr> 
                <td   align="center"><strong style="color:#0000FF; font-size:16px; color:#024C83;">Find Indians in Your Location</strong><%--<img src="images/header-find-shop2.gif" border="0" width="559" height="38" alt="Find shop" />--%><%--<b>Find A Quilt Shop near you</b>--%></td>
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
        <asp:DropDownList ID="dd_state" OnSelectedIndexChanged="State_click" width="150"  runat="server" AutoPostBack="true" ></asp:DropDownList>&nbsp;</td>
 
    <td align="right" width="14%" valign="top"><strong>City :</strong> </td>
    <td align="left" width="14%" valign="top">
        <asp:DropdownList ID="dd_city" width="150" runat="server" ></asp:DropdownList>&nbsp;</td>
		<td width="14%" valign="top">&nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server"  Text="Search" /></td>
  </tr>
                            </tr>
                          </table>
				    
				  </td>
              </tr> 
              <tr><td>&nbsp;</td></tr>
			  
			  <!-- search by name -->
			   <tr>
                <td align="center" style="font-size:12px; ">
				      								
								<table width="70%" border="0">
								
								<tr>
    <td align="left" width="14%" valign="top"><strong>Person Name : &nbsp; &nbsp; &nbsp; &nbsp;</strong>
        <asp:Textbox ID="txtSearch"  runat="server" AutoPostBack="true" ></asp:Textbox>&nbsp;</td>
 
   
		<td width="14%" valign="top" align="left">&nbsp;&nbsp;<asp:Button ID="btnSearchbyName" OnClick="btnSearchbyName_click" runat="server"  Text="Search" /></td>
  </tr>
                            </tr>
                          </table>
				    
				  </td>
              </tr> 
			  <!-- end search by name -->
             
            
         
			
			 <tr> 
                <td>
				    <table width="85%" align="center">
				        <tr>
				            <td align="Center">
					        	        <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
				            </td>
				        </tr>
			        </table>
				</td>
              </tr>
			<tr>
			<td>
			
 <asp:datalist ID="storeslist" runat="server" ItemStyle-VerticalAlign="middle" Width="100%" RepeatColumns="1"  CellSpacing="5"    RepeatDirection="Horizontal" BorderWidth="0">
					<ItemTemplate>			  
						  <table    border="0" bordercolor="#ffffff" width="100%"  cellspacing="5" cellpadding="9"  bgcolor="lightblue">
         
            <tr>
              <td  >
			  <%#GetImgURL(DataBinder.Eval(Container.DataItem, "cust_picture"), DataBinder.Eval(Container.DataItem, "cust_id"))%>
			  
			
              
           	 </td>
			 <td align="left" width="100%">
			 <table width="100%">
			 	<tr>
                    <td  valign="Top" align="left"  width="100%"  >
					<font size="2"  face="Arial, Helvetica, sans-serif"><b><%# DataBinder.Eval(Container.DataItem, "cust_name") %></b>
            <br><%#GetData(DataBinder.Eval(Container.DataItem, "cust_email"), "<br>Email: ")%>

              		<br />Address:<br><%# DataBinder.Eval(Container.DataItem, "cust_address") %>
					             
				  <br><%#Getcity(DataBinder.Eval(Container.DataItem, "cust_city")) %>	&nbsp; , 
				  &nbsp;<%#GetState(DataBinder.Eval(Container.DataItem, "cust_state"))%>&nbsp;&nbsp;
				 
				  <br>
              	  <%#GetData(DataBinder.Eval(Container.DataItem, "cust_cellNumber"), "<br>Phone number: ")%>
                 
			
             </font>
			  <br><br>
			  </td>
			 
                                  
                                </tr>                          
                                
                              </table><td></tr></table>
							</ItemTemplate>
	</asp:datalist>
	</td>
	</tr>
			
             </table>
             
         </form>
	 </asp:content>



