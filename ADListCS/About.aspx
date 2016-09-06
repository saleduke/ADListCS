<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="ADListCS.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <br />
    <br />
    <p>
    <h2>
        About
    </h2>
    </p>
   <p>
         ActiveDirectory® user data browser application
        
        
    </p>
<p>
        Author: <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="PhoneBook.aspx?account=Aleksandar Vojvodic">Aleksandar Vojvodic</asp:HyperLink>
        
    </p>
    <p>
       May,2013.
    </p>
</asp:Content>
