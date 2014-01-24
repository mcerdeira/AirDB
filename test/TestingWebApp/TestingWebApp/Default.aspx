<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestingWebApp._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <asp:Button ID="Button1" runat="server" Text="Create" OnClick="Button1_Click" Width="285px" />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <asp:Button ID="Button3" runat="server" Height="39px" Text="Insert Row" Width="284px" OnClick="Button3_Click" />
            <asp:Label ID="Label3" runat="server"></asp:Label>
            <br />

            <asp:Button ID="Button5" runat="server" Height="39px" Text="Select Row" Width="284px" OnClick="Button5_Click" />
            <asp:Label ID="Label5" runat="server"></asp:Label>
            <br />

            <asp:Button ID="Button4" runat="server" Height="39px" Text="Delete Row" Width="284px" OnClick="Button4_Click" />
            <asp:Label ID="Label4" runat="server"></asp:Label>
            <br />

            <asp:Button ID="Button2" runat="server" Height="39px" OnClick="Button2_Click" Text="Drop" Width="284px" />
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <br />            
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    </asp:Content>
