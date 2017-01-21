

<%@ Page Language="VB"  MasterPageFile="PWIP_MasterPage.master"  AutoEventWireup="false" CodeFile="Forum.aspx.vb" Inherits="JumpyForum.Forum"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

		<script language="javascript" type="text/javascript">
if (top != self) top.location.href = location.href;
		</script>
		<script language="JavaScript" type="text/javascript">
		onerror = report;
var Selected = 1;


function OnOffPost(e)
{

   if ( !e ) e = window.event;
   var target = e.target ? e.target : e.srcElement;
   

if (!target) return;
   
 while (target.id.indexOf('LinkTrigger')<0)
 {
	//alert(target.id + target.id.indexOf('LinkTrigger')+target.parentNode);
	
     target = target.parentNode;
     if (target.id ==null) return;
     }
  if ( target.id.indexOf('LinkTrigger')<0 )
   return;
   

   if (Selected)
   {
      var body = document.getElementById(Selected + "ON");
      if (body)
         body.style.display = 'none';
      var head = document.getElementById(Selected + "OFF");
      if (head)
         head.bgColor = '#EDF8F4';
   }

   if (Selected == target.name) // just collapse
      Selected="";
   else
   {
      Selected = target.name;
      var body = document.getElementById(Selected + "ON");
      if (body)
      {
         if (body.style.display=='none')
            body.style.display='';
         else
            body.style.display = 'none';
      }
      var head = document.getElementById(Selected + "OFF");
      if (head)
         head.bgColor = '#B7DFD5';

      if ( body && head && body.style.display != 'none' )
      {
         document.body.scrollTop = FindPosition(head, "Top") - document.body.clientHeight/10;
         OpenMessage(target.name, true);
      }
   }

   if ( e.preventDefault )
      e.preventDefault();
   else
      e.returnValue = false;
   return false;
}

// does its best to make a message visible on-screen (vs. scrolled off somewhere).
function OpenMessage(msgID, bShowTop) {
   var msgHeader = document.getElementById(msgID + "OFF");
   var msgBody = document.getElementById(msgID + "ON");

   // determine scroll position of top and bottom
   var MyBody = document.body;
   var top = FindPosition(msgHeader, 'Top');
   var bottom = FindPosition(msgBody, 'Top') + msgBody.offsetHeight;

   // if not already visible, scroll to make it so
   if ( MyBody.scrollTop > top && !bShowTop)
      MyBody.scrollTop = top - document.body.clientHeight/10;
   if ( MyBody.scrollTop+MyBody.clientHeight < bottom )
      MyBody.scrollTop = bottom-MyBody.clientHeight;
   if ( MyBody.scrollTop > top && bShowTop)
      MyBody.scrollTop = top - document.body.clientHeight/10;
}

// utility
function FindPosition(i,which)
{
   iPos = 0
   while (i!=null)
   {
      iPos += i["offset" + which];
      i = i.offsetParent;
   }
   return iPos
}

function report(message,url,line) {
    alert('Error : ' + message + ' at line ' + line + ' in ' + url);
}

// cause an <B style="COLOR: black; BACKGROUND-COLOR: #ffff66">error</B>:
		</script>
		<table cellSpacing="0" cellPadding="0" width="100%" border="0">
			<tbody>
				<tr vAlign="top">
					<td class="ContentPane">
						<!-- Main Page Contents Start -->
						<DIV onClick="OnOffPost(event)">
							<table cellSpacing="0" cellPadding="0" width="100%" bgColor="lightblue" border="0">
								<TBODY>
									<tr>
										<td width="100%">
											<form name="myform" id="myform" runat="server">
												<table id="ForumTable" cellSpacing="1" cellPadding="0" width="100%" bgColor="lightblue" border="0">
													<TBODY>
														<tr>
															<td align="left">
																<table border="0" width="100%" cellpadding="0" cellspacing="0">
																	<tr>
																		<td align="left"><%--<FONT face="Arial" color="#ffffff" size="2"><STRONG><A href="Forum.aspx?id=1"><FONT color="#ffffff">Article 
																							1</FONT></A> &nbsp;||&nbsp; <A href="Forum.aspx?id=2"><FONT color="#ffffff">Article 
																							2</FONT></A> ||&nbsp; <A href="Forum.aspx?id=3"><FONT color="#ffffff">Article 3</FONT></A></STRONG></FONT>--%></td>
																		<td align="right"><%--<FONT face="arial" size="2" color="#ffffff">Per page</FONT>&nbsp;--%>
																			<asp:DropDownList Visible="false" id="txtpagesize" runat="server">
																				<asp:ListItem Value="5">5</asp:ListItem>
																				<asp:ListItem Value="10">10</asp:ListItem>
																				<asp:ListItem Value="20" Selected="True">20</asp:ListItem>
																				<asp:ListItem Value="30">30</asp:ListItem>
																				<asp:ListItem Value="40">40</asp:ListItem>
																				<asp:ListItem Value="50">50</asp:ListItem>
																			</asp:DropDownList>
																			<asp:Button id="btnsetpaging" Visible="false" runat="server" Text="Set Pagesize"></asp:Button></td>
																	</tr>
																</table>
															</td>
														</tr>
														<tr bgColor="lightblue">
															<td><a name="xx0xx"></a>
																<table cellPadding="2" width="100%" bgColor="lightblue" border="0">
																	<tr>
																		<td><IMG height="16" alt="screen" src="images/forum_newmsg.gif" width="16" align="top" border="0">&nbsp;
																			<asp:label id="lblnewmessage" ForeColor="Green" runat="server"></asp:label></td>
																		<td><FONT face="Arial" size="2"></FONT></td>
																		<td noWrap align="right">
																		</td>
																	</tr>
																</table>
															</td>
														</tr>
														<tr bgColor="white">
															<td>
																<table cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<TBODY>
																		<tr>
																			<td width="100%">
																				<table width="100%" cellSpacing="0" border=0 cellPadding="2" bgColor="#f1f1f1" border="0">
																					<tr>
																						<td width="80%"><FONT face="Arial" size="2">Subject&nbsp;</FONT></td>
																						<td noWrap width="10%"><FONT face="Arial" size="2">User&nbsp;</FONT></td>
																						<td noWrap align="right" width="10%"><font><FONT face="Arial" size="2">Date</FONT>&nbsp;</font></td>
																					</tr>
																				</table>
																			</td>
																		</tr>
																		<tr>
																			<td colSpan="1"><IMG height="5" src="/script/images/t.gif" width="1" border="0" alt="">
																			</td>
																		</tr>
																		<asp:literal id="ltlPost" runat="server"></asp:literal>
																		<tr>
																			<td colSpan="1"><IMG height="5" src="/script/images/t.gif" width="1" border="0" alt=""></td>
																		</tr>
																	</TBODY>
																</table>
															</td>
														</tr>
														<tr bgColor="#f1f1f1">
															<td>
																<table cellPadding="0" width="100%" border="0">
																	<tr>
																		<TD align="left"><asp:label id="lbldate" runat="server" Font-Names="Arial" Font-Size="Smaller">Label</asp:label></TD>
																		<td vAlign="middle" align="right" width="40%"><FONT face="Arial" size="2"><asp:label id="lblPaging" runat="server">Label</asp:label></FONT></td>
																	</tr>
																</table>
															</td>
														</tr>
													</TBODY>
												</table>
											</form>
										</td>
									</tr>
								</TBODY>
							</table>
						</DIV>
					</td>
				</tr>
			</tbody>
		</table>
		<table width='100%'>
			<tr>
				<td align="center">
					<p>
						
					</p>
				</td>
			</tr>
		</table>
	</asp:content>