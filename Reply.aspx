<%@ Page language="VB" CodeFile="Reply.aspx.vb" MasterPageFile="PWIP_MasterPage.master" AutoEventWireup="false" validateRequest="false" Inherits="JumpyForum.Reply" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

		<script language="Javascript1.2"><!-- // load htmlarea
_editor_url = "htmlarea/";                     // URL to htmlarea files
var win_ie_ver = parseFloat(navigator.appVersion.split("MSIE")[1]);
if (navigator.userAgent.indexOf('Mac')        >= 0) { win_ie_ver = 0; }
if (navigator.userAgent.indexOf('Windows CE') >= 0) { win_ie_ver = 0; }
if (navigator.userAgent.indexOf('Opera')      >= 0) { win_ie_ver = 0; }
if (win_ie_ver >= 5.5) {
 document.write('<scr' + 'ipt src="' +_editor_url+ 'editor.js"');
 document.write(' language="Javascript1.2"></scr' + 'ipt>');  
} else { document.write('<scr'+'ipt>function editor_generate() { return false; }</scr'+'ipt>'); }
// --></script>
	
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" width="100%">
				<TR>
					<TD></TD>
					<TD>
						<asp:Label id="lblStatus" runat="server" Font-Bold="True" Font-Names="Arial">Add a comment</asp:Label></TD>
				</TR>
				<TR>
					<TD>&nbsp;
					</TD>
					<TD valign="top">
						<TABLE width="100%" border="0">
							<TR>
								<TD colSpan="2"><FONT face="arial" size="2"><B>View comment</B>
										<HR>
										<FONT face="Arial"><FONT size="2"><FONT color="maroon"></FONT></FONT></FONT></FONT>
								</TD>
							</TR>
							<TR>
								<TD width="10%"><FONT face="Arial" size="2">Title:</FONT></TD>
								<TD><asp:label id="lbltitle" runat="server" Font-Size="X-Small" Font-Names="Arial">Label</asp:label><FONT face="Arial"></FONT></TD>
							</TR>
							<TR>
								<TD width="10%"><FONT face="Arial" size="2">Comments:</FONT></TD>
								<TD><asp:label id="lblComment" runat="server" Font-Size="X-Small" Font-Names="Arial">Label</asp:label><FONT face="Arial"></FONT></TD>
							</TR>
							<TR>
								<TD width="10%"><FONT face="Arial" size="2">Name:</FONT></TD>
								<TD><asp:label id="lblname" runat="server" Font-Size="X-Small" Font-Names="Arial">Label</asp:label><FONT face="Arial"></FONT></TD>
							</TR>
							<TR>
								<TD width="10%"><FONT face="Arial" size="2">Email:</FONT></TD>
								<TD><asp:label id="lblemail" runat="server" Font-Size="X-Small" Font-Names="Arial">Label</asp:label><FONT face="Arial"></FONT></TD>
							</TR>
							<TR>
								<TD width="10%"><FONT face="Arial" size="2">DateAdded:</FONT></TD>
								<TD><asp:label id="lblDate" runat="server" Font-Size="X-Small" Font-Names="Arial">Label</asp:label><FONT face="Arial"></FONT></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;
					</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>&nbsp;
					</TD>
					<TD>
						<TABLE id="Table2" width="100%" border="0">
							<TR>
								<TD colSpan="2"><FONT face="arial" size="2"><B>Reply to&nbsp;Comment</B>
										<HR>
										<FONT face="Arial"><FONT size="2"><FONT color="maroon"></FONT></FONT></FONT></FONT>
								</TD>
							</TR>
							<tr valign="middle">
								<td valign="middle" nowrap align="left" width="10%"><FONT face="Arial" size="2">Message 
										Type:</FONT></td>
								<td valign="top"><FONT face="Arial" size="2"> <input type="radio" name="MsgType" ID="MsgType_4" value="4" runat="server">
										<Label for="MsgType_4"><img title='Question' align="absMiddle" src='images/question.gif'>
											Question &nbsp;&nbsp;</Label> <input type="radio" name="MsgType" ID="MsgType_1" value="1" checked runat="server">
										<Label for="MsgType_1"><img title='General Comment' align="absMiddle" src='images/general.gif'>
											General &nbsp;&nbsp;</Label> <input type="radio" name="MsgType" ID="MsgType_2" value="2" runat="server">
										<Label for="MsgType_2"><img title='News' align="absMiddle" src='images/info.gif'> News 
											&nbsp;&nbsp;</Label> <input type="radio" name="MsgType" ID="MsgType_3" value="3" runat="server">
										<Label for="MsgType_8"><img title='Answer' align="absMiddle" src='images/answer.gif'>
											Answer &nbsp;&nbsp;</Label> <input type="radio" name="MsgType" ID="MsgType_5" value="5" runat="server">
										<Label for="MsgType_16"><img title='Joke / Game' align="absMiddle" src='images/game.gif'>
											Joke/Game&nbsp;&nbsp;&nbsp;</Label></FONT></td>
							</tr>
							<TR>
								<TD width="10%"><FONT face="Arial" size="2">Title</FONT></TD>
								<TD>
									<asp:textbox id="txtsubject" width="500px" runat="server"></asp:textbox>
									<asp:requiredfieldvalidator id="Requiredfieldvalidator4" runat="server" Font-Names="Arial" Font-Size="10pt"
										ControlToValidate="txtsubject" ErrorMessage="Subject Required"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD vAlign="top" width="10%"><FONT face="Arial" size="2">Reply:</FONT></TD>
								<TD><FONT face="Arial">
										<asp:textbox id="txtcomment" runat="server" Font-Names="Arial" Font-Size="10pt" TextMode="MultiLine"
											width="500px" Height="104px"></asp:textbox>
										<asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" Font-Size="10pt" ControlToValidate="txtcomment"
											ErrorMessage="Comment required"></asp:requiredfieldvalidator></FONT></TD>
							</TR>
							<TR>
								<TD width="10%"><FONT face="Arial" size="2">Name:</FONT></TD>
								<TD><FONT face="Arial">
										<asp:textbox id="txtname" width="500px" runat="server"></asp:textbox>
										<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" Font-Size="10pt" ControlToValidate="txtname"
											ErrorMessage="Name required"></asp:requiredfieldvalidator></FONT></TD>
							</TR>
							<TR>
								<TD width="10%"><FONT face="Arial" size="2">Email:</FONT></TD>
								<TD><FONT face="Arial">
										<asp:textbox id="txtemail" width="500px" runat="server"></asp:textbox>
										<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" Font-Size="10pt" ControlToValidate="txtemail"
											ErrorMessage="Email required"></asp:requiredfieldvalidator></FONT></TD>
							</TR>
							<TR>
								<TD width="10%"><FONT face="Arial" size="2">User Profile/URL</FONT>
								</TD>
								<TD>
									<asp:textbox id="txtProfile" runat="server" Width="500px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD width="10%">&nbsp;</TD>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD width="10%"></TD>
								<TD><FONT size="5"><FONT face="Arial"><FONT size="2"><FONT color="maroon">
													<asp:button id="Button1" runat="server" Width="90" Height="24" Text="Add Reply"></asp:button>&nbsp;&nbsp;
													<asp:Button id="Button2" runat="server" Width="90px" Height="24px" Text="Back" CausesValidation="False"></asp:Button></FONT></FONT></FONT></FONT></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<script language="JavaScript1.2" defer>
						editor_generate('txtcomment');
</script>
		</form>
	</asp:content>