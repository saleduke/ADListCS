<%@ Page Title="Execom" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
	CodeBehind="Default.aspx.cs" Inherits="ADListCS._Default" %>

<asp:Content ID="HeaderContent"  ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent"  ContentPlaceHolderID="MainContent" runat="server">
			<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" >
	<title>Execom PhoneBook</title> 
	
</head>
<body style="margin: 20px;">
<form id="form1" action="Default.aspx" >
<center>
<div style="padding-top: 0.5em;padding-left: 0.5em;padding-bottom: 0.5em; text-align:left">
	
	 
	
	</div><br /><br />
	<asp:Table ID="Table3" runat="server" CellPadding="5" CellSpacing="5" style="color: #000000;background-color: #EA4E51;padding-top: 0.5em;padding-left: 0.5em;
	font-family: Arial, Verdana, Tahoma;
	font-size:16px;
	font-weight:normal;
	
	font-size:15px;
	line-height: 1.2;
	top: 2em;
	left: 2em; text-align:left" BorderWidth="1" BorderColor="#999999" BorderStyle="Ridge"  Width="300">
			<asp:TableRow ID="TableRow2"  >
				<asp:TableCell ID="TableCell3"  ><asp:Label ID="Label7"  Text="PhoneBook" ForeColor="#FFFFFF" 
			Font-Bold="False" Font-Names="Arial,Verdana,Tahoma" Font-Size="18pt" runat="server"></asp:Label></asp:TableCell>
				<asp:TableCell ID="TableCell4"  HorizontalAlign="Right">
					<asp:ImageButton ID="ImageButton1"   ImageUrl="phone.png" style="text-align: right" PostBackUrl="PhoneBook.aspx" runat="server"/></asp:TableCell>
			</asp:TableRow>
			</asp:Table>
		   <asp:Table ID="Table1"  CellPadding="5" CellSpacing="5" style="color: #000000;background-color: #EA4E51;padding-top: 0.5em;padding-left: 0.5em;
	font-family: Arial, Verdana, Tahoma;
	font-size:16px;
	font-weight:normal;
	
	font-size:15px;
	line-height: 1.2;
	top: 2em;
	left: 2em; text-align:left" BorderWidth="1" BorderColor="#999999" BorderStyle="Ridge" Width="300" runat="server">
			<asp:TableRow ID="TableRow1" >
				<asp:TableCell ID="TableCell1" ><asp:Label ID="Label1"  Text="Teams" ForeColor="#FFFFFF" 
			Font-Bold="False" Font-Names="Arial,Verdana,Tahoma" Font-Size="18pt" runat="server"></asp:Label></asp:TableCell>
				<asp:TableCell ID="TableCell2"  HorizontalAlign="Right"><asp:ImageButton ID="ImageButton3"   ImageUrl="team.png" style="text-align: right" PostBackUrl="team.aspx" runat="server"/></asp:TableCell>
			</asp:TableRow>
			</asp:Table> 
			<asp:Table ID="Table2"  CellPadding="5" CellSpacing="5" style="color: #000000;background-color: #EA4E51;padding-top: 0.5em;padding-left: 0.5em;
	font-family: Arial, Verdana, Tahoma;
	font-size:16px;
	font-weight:normal;
	
	font-size:15px;
	line-height: 1.2;
	top: 2em;
	left: 2em; text-align:left" BorderWidth="1" BorderColor="#999999" BorderStyle="Ridge" Width="300" runat="server">
			<asp:TableRow ID="TableRow3" >
				<asp:TableCell ID="TableCell5" ><asp:Label ID="Label2"  Text="Offices" ForeColor="#FFFFFF" 
			Font-Bold="False" Font-Names="Arial,Verdana,Tahoma" Font-Size="18pt" runat="server"></asp:Label></asp:TableCell>
				<asp:TableCell ID="TableCell6"  HorizontalAlign="Right"><asp:ImageButton ID="ImageButton4"   ImageUrl="office.png" style="text-align: right" PostBackUrl="office.aspx" runat="server"/></asp:TableCell>
			</asp:TableRow>
			</asp:Table>
			</center>
	</form>
	</body>
	</html>
</asp:Content>
