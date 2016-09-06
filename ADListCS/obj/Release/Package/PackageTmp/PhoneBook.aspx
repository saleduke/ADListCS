<%@ Page Title="Schneider Electric DMS NS PhoneBook" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PhoneBook.aspx.cs" Inherits="ADListCS.PhoneBook" EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <form id="form1" action="PhoneBook.aspx" >
	<center>
	
	<div style="color: #000000;padding-left: 0.5em;">
		<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True">
			<Services>
				<asp:ServiceReference Path="~/AutoCompleteCS.asmx" />
			</Services>
		</asp:ScriptManager>
		
		<asp:Table ID="Table3" runat="server" CellPadding="5" CellSpacing="5" 
			style="
			color: #000000;
			background-color: #089642;
			padding-top: 0.5em;
			padding-left: 0.5em;
			font-family: Arial, Verdana, Tahoma;
			font-size:16px;
			font-weight:normal;
			font-size:15px;
			line-height: 1.2;
			top: 2em;
			left: 2em; 
			text-align:left" 
			BorderWidth="1" BorderColor="#99cc99" BorderStyle="Ridge">
			<asp:TableRow ID="TableRow2" runat="server">
				<asp:TableCell ID="TableCell3" runat="server"><asp:Label ID="Label7" runat="server" Text="PhoneBook" ForeColor="#FFFFFF" 
			Font-Bold="False" Font-Names="Arial,Verdana,Tahoma" Font-Size="18pt"></asp:Label></asp:TableCell>
				<asp:TableCell ID="TableCell4" runat="server" HorizontalAlign="Left"><img src="phone.png" alt=""/></asp:TableCell><asp:TableCell><asp:ImageButton ID="ImageButton5" runat="server" PostBackUrl="default.aspx" ImageUrl="Home-icon.png" Width="60" Height="60" /></asp:TableCell>
			</asp:TableRow><asp:TableRow ID="TableRow1" runat="server"> 
				<asp:TableCell ID="TableCell1" runat="server"></asp:TableCell>
				<asp:TableCell ID="TableCell2" runat="server"></asp:TableCell>
			</asp:TableRow>
			<asp:TableRow  runat="server">
				<asp:TableCell  runat="server"><asp:Label ID="Label9" runat="server" Text="Label">Full Name</asp:Label></asp:TableCell>
				<asp:TableCell  runat="server"><asp:TextBox ID="TextBox4" runat="server" AutoPostBack="True" BackColor="#FFFFFF" 
			Width="380px" EnableTheming="True" BorderStyle="Solid" 
			BorderColor="#8497BF" BorderWidth="1" OnTextChanged="TextBox4_TextChanged" ToolTip="Please enter few letters of name and wait for list to drop"></asp:TextBox></asp:TableCell>
			</asp:TableRow>
		   <%-- <asp:TableRow  runat="server">
				<asp:TableCell  runat="server"></asp:TableCell>
				<asp:TableCell  runat="server"><asp:Label ID="Label8" runat="server" ForeColor="#555555" Width="400px" Font-Size="10"> Please enter few letters of name and wait for list to drop:</asp:Label></asp:TableCell>
			</asp:TableRow>--%>
			<asp:TableRow ID="TableRow3" runat="server">
				<asp:TableCell ID="TableCell5" runat="server"><asp:Label ID="Label12" runat="server" Text="Label">Mobile phone</asp:Label></asp:TableCell>
				<asp:TableCell ID="TableCell6" runat="server"><asp:TextBox ID="TextBox2" runat="server" BackColor="#FFFFFF" 
				AutoPostBack="True" BorderColor="#8497BF" BorderStyle="Solid" BorderWidth="1" Width="380" OnTextChanged="TextBox2_TextChanged" 
				ToolTip="Please enter few numbers and wait for list to drop"></asp:TextBox></asp:TableCell>
			</asp:TableRow>
			
			<%--<asp:TableRow ID="TableRow4" runat="server">
				<asp:TableCell ID="TableCell7" runat="server"></asp:TableCell>
				<asp:TableCell ID="TableCell8" runat="server"><asp:Label ID="Label10" runat="server" ForeColor="#555555" Width="400px" Font-Size="10">Please enter few numbers and wait for list to drop</asp:Label></asp:TableCell>
			</asp:TableRow>--%>
			<asp:TableRow ID="TableRow5" runat="server">
				<asp:TableCell ID="TableCell9" runat="server"><asp:Label ID="Label13" runat="server" Text="Label">Phone</asp:Label></asp:TableCell>
				<asp:TableCell ID="TableCell10" runat="server"><asp:TextBox ID="TextBox3" runat="server" AutoPostBack="True" 
				BackColor="#FFFFFF" BorderStyle="Solid" BorderColor="#8497BF" BorderWidth="1" Width="380" OnTextChanged="TextBox3_TextChanged" ToolTip="Please enter few numbers and wait for list to drop"></asp:TextBox></asp:TableCell>
			</asp:TableRow>
		   <%-- <asp:TableRow ID="TableRow6" runat="server">
				<asp:TableCell ID="TableCell11" runat="server"></asp:TableCell>
				<asp:TableCell ID="TableCell12" runat="server"><asp:Label ID="Label11" runat="server" ForeColor="#555555" Width="400px" Font-Size="10">Please enter few numbers and wait for list to drop</asp:Label></asp:TableCell>
			</asp:TableRow>--%>
			<asp:TableRow ID="TableRow7" runat="server">
				<asp:TableCell ID="TableCell13" runat="server"></asp:TableCell>
				<asp:TableCell ID="TableCell14" runat="server"></asp:TableCell>
			</asp:TableRow>
		</asp:Table>
		
		
		<cc1:AutoCompleteExtender ID="TextBox4_AutoCompleteExtender" runat="server" 
			ServiceMethod="GetCompletionList" ServicePath="AutoCompleteCS.asmx" 
			TargetControlID="TextBox4">
		</cc1:AutoCompleteExtender>
		<cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
			ServiceMethod="GetCompletionListmobile" ServicePath="AutoCompleteCS.asmx" 
			TargetControlID="TextBox2" MinimumPrefixLength="4">
		</cc1:AutoCompleteExtender>
		
		<cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" 
			ServiceMethod="GetCompletionListfix" ServicePath="AutoCompleteCS.asmx" 
			TargetControlID="TextBox3" MinimumPrefixLength="4">
		</cc1:AutoCompleteExtender>
		
	</div>
	
	<p style="font-size: x-small; position: fixed; bottom: 5px; left: 15px;">
		A.Vojvodic, Schneider-electric DMS NS, 2013.</p>
		<br /> 
	<asp:Table ID="Table4" runat="server" Visible="True" CellPadding="5" CellSpacing="5" style="text-align:left">
		<asp:TableRow ID="TableRow83" runat="server">
		<asp:TableCell ID="TableCell18" runat="server" ><asp:Table ID="Table2" runat="server"  BorderColor="#CCFFCC" 
			BorderStyle="Ridge" BorderWidth="2px" CellPadding="5" CellSpacing="5" BackColor="#AACCAA">
		<asp:TableRow ID="TableRow9" runat="server">
				<asp:TableCell ID="TableCell19" runat="server" RowSpan="6" Width="200" HorizontalAlign="Center">
				<asp:ImageButton ID="ImageButton1" runat="server" style="margin-left: 0px" 
						Visible="False" BorderColor="#666666" BorderStyle="Solid" 
						BorderWidth="1px" />
						<asp:Label ID="LabelNoPicture" runat="server" style="color: #555555;font-family: Arial,sans-serif;font-size: 11pt;line-height: 1.4;margin: 0pt;padding: 0pt;" Visible="false">
						</asp:Label>
		</asp:TableCell><asp:TableCell ID="TableCell20" runat="server" > 
					<asp:Label ID="Label1" runat="server" style="color: #555555;font-family: Arial,sans-serif;font-size: 11pt;line-height: 1.4;margin: 0pt;padding: 0pt;"></asp:Label>
		</asp:TableCell>
				<asp:TableCell ID="TableCell21" runat="server" RowSpan="6" Width="25"></asp:TableCell>
				
				
			</asp:TableRow>
			<asp:TableRow ID="TableRow10" runat="server">
				<asp:TableCell ID="TableCell22" runat="server">
					<asp:Label ID="Label5" runat="server" style="color: #555555;font-family: Arial,sans-serif;font-size: 10px;line-height: 1.4;margin: 0pt;padding: 0pt;"></asp:Label></asp:TableCell>
			</asp:TableRow>
		  <asp:TableRow ID="TableRowDepartment" runat="server">
				<asp:TableCell ID="TableCell23" runat="server">
					<asp:LinkButton ID="LinkButtondepartment" runat="server" ForeColor="#089642" Font-Underline="False" style="font-family: Arial,sans-serif;font-size: 10px;line-height: 1.4;margin: 0pt;padding: 0pt;"></asp:LinkButton>
					</asp:TableCell>
			</asp:TableRow>
			<asp:TableRow ID="TableRow11" runat="server">
				<asp:TableCell ID="TableCell24" runat="server"> 
					   <asp:Label ID="Label2" runat="server" style="color: #555555;font-family: Arial,sans-serif;font-size: 11pt;line-height: 1.4;margin: 0pt;padding: 0pt;"></asp:Label></asp:TableCell>
			</asp:TableRow>
			<asp:TableRow ID="TableRow12" runat="server">
				<asp:TableCell ID="TableCell25" runat="server">
					<asp:Label ID="Label3" runat="server" style="color: #555555;font-family: Arial,sans-serif;font-size: 11pt;line-height: 1.4;margin: 0pt;padding: 0pt;"></asp:Label></asp:TableCell>
			</asp:TableRow>
			<asp:TableRow ID="TableRow13" runat="server">
				<asp:TableCell ID="TableCell26" runat="server">
				<asp:Table ID="Table5" runat="server"  CellSpacing="1">
				
				<asp:TableRow ID="TableRow72" runat="server"><asp:TableCell ID="TableCell132" runat="server">
					<asp:Label ID="Label41" runat="server" style="color: #555555;font-family: Arial,sans-serif;font-size: 10px;line-height: 1.4;margin: 0pt;padding: 0pt;"></asp:Label></asp:TableCell></asp:TableRow>
		<asp:TableRow ID="TableRow73" runat="server"><asp:TableCell ID="TableCell133" runat="server">
		<asp:LinkButton ID="LinkButton1" runat="server" ForeColor="#089642" Font-Underline="False"></asp:LinkButton><asp:Label ID="Label42" runat="server" style="color: #555555;font-family: Arial,sans-serif;font-size: 10px;line-height: 1.4;margin: 0pt;padding: 0pt; vertical-align:text-top" Visible="false"></asp:Label></asp:TableCell></asp:TableRow>
		<asp:TableRow ID="TableRow71" runat="server"> <asp:TableCell ID="TableCell131" runat="server"><img src="Mail-icon.png" alt=""/>&nbsp;&nbsp;<asp:HyperLink ID="HyperLink1" runat="server" style="font-family: Arial,sans-serif;font-size: 10px;line-height: 1.4;margin: 0pt;padding: 0pt;"></asp:HyperLink>
				<%--<asp:Label ID="Label4" runat="server" style="color: #555555;font-family: Arial,sans-serif;font-size: 10px;line-height: 1.4;margin: 0pt;padding: 0pt;"></asp:Label>--%>
				</asp:TableCell></asp:TableRow>
				<asp:TableRow ID="TableRowSkype" runat="server"><asp:TableCell ID="TableCell27" runat="server" VerticalAlign="Middle">
		<img src="skypeicon.png" alt="" />&nbsp;&nbsp;<asp:HyperLink ID="HyperLink2" runat="server" style="font-family: Arial,sans-serif;font-size: 10px;line-height: 1.4;margin: 0pt;padding: 0pt;"></asp:HyperLink>&nbsp;&nbsp;<asp:HyperLink ID="HyperLink3" runat="server" style="font-family: Arial,sans-serif;font-size: 10px;line-height: 1.4;margin: 0pt;padding: 0pt;"></asp:HyperLink>
				
			   
				</asp:TableCell></asp:TableRow>
				</asp:Table>
					</asp:TableCell>
			</asp:TableRow>
			
		</asp:Table></asp:TableCell>
		<asp:TableCell ID="TableCell28" runat="server" ></asp:TableCell>
		<asp:TableCell ID="TableCell29" runat="server" HorizontalAlign="left" VerticalAlign="Top">
		<asp:Table ID="Table6" runat="server"  CellPadding="5" CellSpacing="5">
		<asp:TableRow ID="TableRow14"  runat="server">
		<asp:TableCell ID="TableCell30" runat="server" ><asp:Label ID="Label6" runat="server" Text="Organizational hierarchy" ForeColor="#089642" Font-Bold="False" Font-Names="Arial,Verdana,Tahoma" Font-Size="18pt"></asp:Label></asp:TableCell>
		</asp:TableRow>
		<asp:TableRow ID="TableRow15"  runat="server"><asp:TableCell ID="TableCell31" runat="server" ><asp:TreeView ID="TreeView1" runat="server" Width="251px" EnableTheming="True" NodeIndent="10" ShowExpandCollapse="False" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
		
		<HoverNodeStyle Font-Underline="False" />
		
		<LevelStyles>
		
		<asp:TreeNodeStyle  ForeColor="#078e52" Font-Underline="False" />
		
		<asp:TreeNodeStyle Font-Italic="True" Font-Underline="False" />
		
		<asp:TreeNodeStyle Font-Underline="False"  />
		
		</LevelStyles>
		
		<NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="#078e52" 
					HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
		
		<ParentNodeStyle Font-Bold="True" Font-Italic="True" ForeColor="#55DD55" />
		
		<RootNodeStyle  Font-Bold="True" Font-Size="Small" ForeColor="#555555"/>
		
		<SelectedNodeStyle   Font-Size="Small" 
					Font-Underline="True" ForeColor="#000000" HorizontalPadding="2px" 
					NodeSpacing="2px" VerticalPadding="2px" />
	
		</asp:TreeView></asp:TableCell></asp:TableRow>
		</asp:Table>
		</asp:TableCell>
		</asp:TableRow>

				</asp:Table>
				</center>
				</form>

</asp:Content>
