<%@ Page Title="Execom Offices" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="office.aspx.cs" Inherits="ADListCS.office" EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<form id="form1" action="office.aspx">
	<center>
	
	<div style="color: #000000;padding-left: 0.5em;">
		<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True">
		<Services>
<asp:ServiceReference Path="~/AutoCompleteCS.asmx" />
			
 </Services>

		</asp:ScriptManager>
	
		<asp:Table ID="Table3" runat="server" CellPadding="5" CellSpacing="5" style="color: #000000;background-color: #EA4E51;padding-top: 0.5em;padding-left: 0.5em;
	font-family: Arial, Verdana, Tahoma;
	font-size:16px;
	font-weight:normal;
	
	font-size:15px;
	line-height: 1.2;
	top: 2em;
	left: 2em;text-align:left" BorderWidth="1" BorderColor="#999999" BorderStyle="Ridge">
			<asp:TableRow ID="TableRow2x" runat="server">
				<asp:TableCell ID="TableCell3x" runat="server"><asp:Label ID="Label7" runat="server" Text="Office" ForeColor="#FFFFFF" 
			Font-Bold="False" Font-Names="Arial,Verdana,Tahoma" Font-Size="18pt"></asp:Label></asp:TableCell>
				<asp:TableCell ID="TableCell4x" runat="server" HorizontalAlign="Left"><img src="office.png" /></asp:TableCell><asp:TableCell></asp:TableCell><asp:TableCell><asp:ImageButton ID="ImageButton1" runat="server" PostBackUrl="default.aspx" ImageUrl="Home-icon.png" Width="60" Height="60" /></asp:TableCell>
			</asp:TableRow><asp:TableRow ID="TableRow1x" runat="server">
				<asp:TableCell ID="TableCell1x" runat="server"><asp:Label runat="server" Text="Select" Font-Bold="true"></asp:Label></asp:TableCell>
				<asp:TableCell ID="TableCell2x" runat="server"></asp:TableCell>
			</asp:TableRow>
			<asp:TableRow><asp:TableCell><asp:Label ID="Label2" runat="server">Floor</asp:Label></asp:TableCell><asp:TableCell>
				<asp:DropDownList ID="DropDownListFloor" runat="server" OnSelectedIndexChanged="FloorSelected" AutoPostBack="True"><asp:ListItem>-- select floor --</asp:ListItem><asp:ListItem>P</asp:ListItem>
				<asp:ListItem>G</asp:ListItem>
				<asp:ListItem>1</asp:ListItem>
				<asp:ListItem>2</asp:ListItem>
				<asp:ListItem>3</asp:ListItem>
				<asp:ListItem>4</asp:ListItem>
				</asp:DropDownList>
			</asp:TableCell><asp:TableCell><asp:Label ID="Label9z" runat="server">Room Number</asp:Label>&nbsp;&nbsp;&nbsp;<asp:DropDownList runat="server" ID="DDLRoom" OnSelectedIndexChanged="RoomSelected" AutoPostBack="True">
			</asp:DropDownList></asp:TableCell>
			<asp:TableCell>
			</asp:TableCell></asp:TableRow>
			<asp:TableRow>
		<asp:TableCell></asp:TableCell>
			</asp:TableRow>
			<asp:TableRow><asp:TableCell><asp:Label ID="Label3" runat="server" Text="QuickFind" Font-Bold="true"></asp:Label></asp:TableCell></asp:TableRow>
			<asp:TableRow ID="TableRow1xz" runat="server">
				<asp:TableCell ID="TableCell1xz" runat="server"><asp:Label ID="Label9" runat="server" Text="Label">Room Number</asp:Label></asp:TableCell>
				<asp:TableCell ID="TableCell2xz" runat="server" ColumnSpan=2><asp:TextBox ID="TextBox4" runat="server" AutoPostBack="True" BackColor="#FFFFFF" 
			Width="380px" EnableTheming="True" BorderStyle="Solid" 
			BorderColor="#8497BF" BorderWidth="1" OnTextChanged="TextBox4_TextChanged" ToolTip="Please enter few letters/numbers of name and wait for list to drop"></asp:TextBox></asp:TableCell>
			</asp:TableRow>
		   <%-- <asp:TableRow ID="TableRow2" runat="server">
				<asp:TableCell ID="TableCell3" runat="server"></asp:TableCell>
				<asp:TableCell ID="TableCell4" runat="server"><asp:Label ID="Label8" runat="server" ForeColor="#555555" Width="400px" Font-Size="10"> Please enter few letters/numbers of name and wait for list to drop:</asp:Label></asp:TableCell>
			</asp:TableRow>--%>
			<asp:TableRow ID="TableRow7" runat="server">
				<asp:TableCell ID="TableCell13" runat="server"></asp:TableCell>
				<asp:TableCell ID="TableCell14" runat="server"></asp:TableCell>
			</asp:TableRow>
		</asp:Table>
		
		
		<cc1:AutoCompleteExtender ID="TextBox4_AutoCompleteExtender" runat="server" 
			ServiceMethod="GetCompletionListOffice" ServicePath="AutoCompleteCS.asmx" 
			TargetControlID="TextBox4" MinimumPrefixLength="1">
		</cc1:AutoCompleteExtender>

		 <asp:Table ID="Table1" runat="server" CellPadding="5" CellSpacing="5" style="color: #000000;padding-top: 0.5em;padding-left: 0.5em;left: 2em;text-align:left">
		<asp:TableRow ID="TableRow8" runat="server">
			<asp:TableCell ID="TableCell15" runat="server" VerticalAlign="Top"> 
		
		 <asp:Label ID="Label1" runat="server" Text="People" ForeColor="#EA4E51" 
			Font-Bold="False" Font-Names="Arial,Verdana,Tahoma" Font-Size="15pt"></asp:Label>


			</asp:TableCell>
			<asp:TableCell ID="TableCell16" runat="server" Width="50"></asp:TableCell>
			<asp:TableCell ID="TableCell17" runat="server" HorizontalAlign="NotSet"><asp:Panel ID="Panel1" runat="server" style="color: #000000;padding-top: 0.5em;padding-left: 0.5em;">
				</asp:Panel>
			</asp:TableCell>
		</asp:TableRow>
	</asp:Table>
		
			  
	</div>
	
	
	<p style="font-size: x-small; position: fixed; bottom: 5px; left: 15px;">
		A.Vojvodic, 2013.</p>
		<br /> 
   
	</center>
	</form>

</asp:Content>
