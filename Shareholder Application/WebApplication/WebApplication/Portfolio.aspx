<%@ Page Title="Portfolio" Language="C#" MasterPageFile="~/ShareholderMain.master" AutoEventWireup="true"
    CodeBehind="Portfolio.aspx.cs" Inherits="WebApplication5.Portfolio" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style3
        {
            color: #660066;
        }
        .style6
        {
            color: #FF0000;
        }
        .style7
        {
            text-decoration: underline;
            color: #660066;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2 class="style1">
        <strong><span class="style3">PROTFOLIO</span></strong></h2>
        <p>
        <marquee behavior="scroll" direction="left">British Airways £ 124;  The New York Times $ 6.19;  Toyota $ 75.38;  BNP Paribas € 45.97;  EDF € 32.17;  Tesco £ 426.72;  IBM $ 131.29;  Google $ 468.15.
</marquee></p>
&nbsp;<p class="style7">
        <strong>REGISTER</strong></p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Register for Stock Exchange: "></asp:Label>
        <asp:DropDownList ID="registerDropDownList" runat="server" 
            onselectedindexchanged="registerDropDownList_SelectedIndexChanged">
            <asp:ListItem>London Stock Exchange</asp:ListItem>
            <asp:ListItem>Euronext Paris</asp:ListItem>
            <asp:ListItem>New York Stock Exchange</asp:ListItem>
            <asp:ListItem>Tokyo Stock Exchange</asp:ListItem>
            <asp:ListItem>Moscow Stock Exchange</asp:ListItem>
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="seRegisterButton" runat="server" onclick="registerButton_Click" 
            Text="Register" />
    &nbsp;&nbsp;&nbsp;
        <asp:Button ID="seUnregisterButton" runat="server" 
            onclick="seUnregisterButton_Click" Text="Unregister" />
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Register with Broker:&nbsp;&nbsp;"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="brokersDropDownList" runat="server" 
            onselectedindexchanged="brokersDropDownList_SelectedIndexChanged">
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
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="brokerRegisterButton" runat="server" 
            onclick="brokerRegisterButton_Click" Text="Register" />
    &nbsp;&nbsp;&nbsp;
        <asp:Button ID="brokerUnregisterButton" runat="server" 
            onclick="brokerUnregisterButton_Click" Text="Unregister" />
    </p>
    <p>
        &nbsp;</p>

    <p class="style6">
        <span class="style3"><strong>Registered Stock Exchange</strong></span><asp:GridView ID="GridView1" runat="server" 
            CellPadding="4" ForeColor="#333333" GridLines="None">
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
        </p>
    <p class="style6">
        &nbsp;</p>
    <p class="style6">
        <span class="style3"><strong>Shares Owned</strong></span><asp:GridView ID="GridView2" runat="server" CellPadding="4" 
            ForeColor="#333333" GridLines="None">
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
    </p>
    <p class="style6">
        &nbsp;</p>
    <p class="style6">
        <span class="style3"><strong>Registered Brokers</strong></span><asp:GridView ID="GridView3" runat="server" CellPadding="4" 
            ForeColor="#333333" GridLines="None">
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
    </p>
    <p class="style6">
        &nbsp;</p>
    <p class="style6">
        <span class="style7"><strong>BROKERS BY STOCK EXCHANGE</strong></span>&nbsp;&nbsp;
        <asp:DropDownList ID="StockExDropDownList1" runat="server" 
            onselectedindexchanged="StockExDropDownList1_SelectedIndexChanged"
            AutoPostBack="True" SelectionMode="Single">
            <asp:ListItem>London Stock Exchange</asp:ListItem>
            <asp:ListItem>Euronext Paris</asp:ListItem>
            <asp:ListItem>New York Stock Exchange</asp:ListItem>
            <asp:ListItem>Tokyo Stock Exchange</asp:ListItem>
            <asp:ListItem>Moscow Stock Exchange</asp:ListItem>
        </asp:DropDownList>
&nbsp;
        <asp:GridView ID="GridView4" runat="server" CellPadding="4" ForeColor="#333333" 
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
    </p>
    <p>
        &nbsp;</asp:Content>