<%@ Page Title="UserPreference" Language="C#" MasterPageFile="~/ShareholderMain.master" AutoEventWireup="true"
    CodeBehind="UserPreference.aspx.cs" Inherits="WebApplication5.UserPreference" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

    <style type="text/css">
        .style1
        {
            color: #660066;
        }
        .style2
        {
            color: #FF0000;
        }
        </style>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<%--<script runat = "server">
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        Profile.MyTheme = DropDownList1.SelectedValue;

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DropDownList2.Items.FindByValue(Profile.MyTheme).Selected = true;


        }
    }
    </script>--%>
    <h2 class="style1">
        SET PREFERENCES</h2>
    <p class="style1">
        <marquee behavior="scroll" direction="left">British Airways £ 124;  The New York Times $ 6.19;  Toyota $ 75.38;  BNP Paribas € 45.97;  EDF € 32.17;  Tesco £ 426.72;  IBM $ 131.29;  Google $ 468.15.
</marquee></p>

    <p>&nbsp;<p>&nbsp;<asp:Label ID="Label4" runat="server" 
            Text="ADD OWNED SHARE TO FAVOURITE LIST :&nbsp;"></asp:Label>
&nbsp;<asp:TextBox ID="FavouriteListTextBox" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="addToFavouriteListButton" runat="server" 
            onclick="addToFavouriteListButton_Click" Text="Add" />
    &nbsp;&nbsp;&nbsp;
        <asp:Button ID="deleteFromFavouriteListButton" runat="server" 
            onclick="deleteFromFavouriteListButton_Click" Text="Delete" />
    <p>
        <asp:Label ID="Label3" runat="server" 
            Text="ADD INTERESTED SHARE TO WATCH LIST :"></asp:Label>
&nbsp;<asp:TextBox ID="WatchListTextBox" runat="server" 
            ontextchanged="WatchListTextBox_TextChanged"></asp:TextBox>
&nbsp;<asp:Button ID="addToWatchListButton" runat="server" Text="Add" 
            onclick="addToWatchListButton_Click1" />
    &nbsp;&nbsp;&nbsp;
        <asp:Button ID="deleteFromWatchListButton" runat="server" Text="Delete" 
            onclick="deleteFromWatchListButton_Click" />
    <p>
        <asp:Label ID="Label2" runat="server" 
            Text="ADD FAVOURITE BROKER :&nbsp;&nbsp;&nbsp;"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem>John Smith</asp:ListItem>
            <asp:ListItem>Herbert Jackson</asp:ListItem>
            <asp:ListItem>Richard Bradley</asp:ListItem>
            <asp:ListItem>Frank Denzel</asp:ListItem>
            <asp:ListItem>Elric Crofton</asp:ListItem>
            <asp:ListItem>Ted Gore</asp:ListItem>
            <asp:ListItem>John Bush</asp:ListItem>
            <asp:ListItem>Andre Sinclair</asp:ListItem>
            <asp:ListItem>Danielle Perety</asp:ListItem>
            <asp:ListItem>Arabella Volvitz</asp:ListItem>
            <asp:ListItem>Parker Hamilton</asp:ListItem>
            <asp:ListItem>Andrew Wallace</asp:ListItem>
            <asp:ListItem>Bruce Smith</asp:ListItem>
            <asp:ListItem>Tommy Mack</asp:ListItem>
            <asp:ListItem>Frederick Raven</asp:ListItem>
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="addToFavouriteBrokerButton" runat="server" 
            onclick="addToFavouriteBrokerButton_Click" Text="Add" />
    &nbsp;&nbsp;&nbsp;
        <asp:Button ID="deleteFromFavouriteBrokerButton" runat="server" Text="Delete" 
            onclick="deleteFromFavouriteBrokerButton_Click" />
    <p>
        <asp:Label ID="Label1" runat="server" Text="Choose A THEME :&nbsp;&nbsp;&nbsp;" 
            Visible="False"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;
        <asp:DropDownList ID="DropDownList2" runat="server" 
            onselectedindexchanged="DropDownList2_SelectedIndexChanged" 
            Visible="False">
            <asp:ListItem>Summer</asp:ListItem>
            <asp:ListItem>Winter</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button 
            ID="Button1" runat="server" onclick="Button1_Click" Text="Save" 
            Visible="False" />
        




    <p>
        <span class="style1"><strong>FAVOURITE LIST</strong></span><asp:GridView 
            ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>


        




    <p>
        &nbsp;<p>
        <span class="style1"><strong>WATCH LIST</strong></span><span class="style2"><asp:GridView ID="GridView2" 
            runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        </span>
    <p>
        &nbsp;<p>
        <span class="style1"><strong>FAVOURITE BROKER</strong></span><span class="style2"><asp:GridView 
            ID="GridView3" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        </span> <p>
        &nbsp;<p>
        &nbsp;</asp:Content>