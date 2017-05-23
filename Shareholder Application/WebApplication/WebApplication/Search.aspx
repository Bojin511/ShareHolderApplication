<%@ Page Title="Search" Language="C#" MasterPageFile="~/ShareholderMain.master" AutoEventWireup="true"
    CodeBehind="Search.aspx.cs" Inherits="WebApplication5.Search" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            color: #660066;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2 class="style1">
        SEARCH</h2>
    <p class="style1">
    <marquee behavior="scroll" direction="left">British Airways £ 124;  The New York Times $ 6.19;  Toyota $ 75.38;  BNP Paribas € 45.97;  EDF € 32.17;  Tesco £ 426.72;  IBM $ 131.29;  Google $ 468.15.
</marquee>
        </p>
    <p class="style1">
        &nbsp;</p>
    <p class="style1">
        <asp:GridView ID="GridView3" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None" onselectedindexchanged="GridView3_SelectedIndexChanged">
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
    <p class="style1">
        &nbsp;</p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Companies:"></asp:Label>
&nbsp;<asp:DropDownList ID="CompaniesDropDownList" runat="server" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged"
            AutoPostBack="True" SelectionMode="Single"  >
            <asp:ListItem>British Airways</asp:ListItem>
            <asp:ListItem>The New York Times</asp:ListItem>
            <asp:ListItem>Toyota</asp:ListItem>
            <asp:ListItem>BNP Paribas</asp:ListItem>
            <asp:ListItem>EDF</asp:ListItem>
            <asp:ListItem>Tesco</asp:ListItem>
            <asp:ListItem>IBM</asp:ListItem>
            <asp:ListItem>Google</asp:ListItem>
            <asp:ListItem>Castlemaine</asp:ListItem>
        </asp:DropDownList>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Brokers:&nbsp;&nbsp;&nbsp;"></asp:Label>
            &nbsp;&nbsp;
        <asp:DropDownList ID="BrokersDropDownList" runat="server" 
            onselectedindexchanged="BrokersDropDownList_SelectedIndexChanged"
            AutoPostBack="True" SelectionMode="Single" >
            <asp:ListItem>John Smith </asp:ListItem>
            <asp:ListItem>Herbert Jackson </asp:ListItem>
            <asp:ListItem>Richard Bradley </asp:ListItem>
            <asp:ListItem>Frank Denzel </asp:ListItem>
            <asp:ListItem>Elric Crofton </asp:ListItem>
            <asp:ListItem>Ted Gore </asp:ListItem>
            <asp:ListItem>John Bush </asp:ListItem>
            <asp:ListItem>Andre Sinclair </asp:ListItem>
            <asp:ListItem>Danielle Perety </asp:ListItem>
            <asp:ListItem>Arabella Volvitz </asp:ListItem>
            <asp:ListItem>Parker Hamilton </asp:ListItem>
            <asp:ListItem>Andrew Wallace </asp:ListItem>
            <asp:ListItem>Bruce Smith </asp:ListItem>
            <asp:ListItem>Tommy Mack </asp:ListItem>
            <asp:ListItem>Frederick Raven </asp:ListItem>
        </asp:DropDownList>
        <p>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" CellPadding="4" 
                ForeColor="#333333" GridLines="None" 
                onpageindexchanging="GridView1_PageIndexChanging">
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="Data Source=oracle.fdmgroup.com:1521/campus;User ID=bojinzhou;Password=BZA278sG;Unicode=True" 
        ProviderName="System.Data.OracleClient" 
        SelectCommand="SELECT SP.PRICE, SP.TIME_START FROM COMPANIES C, PLACES P, SHARES S, SHARES_AMOUNT SA, SHARES_PRICES SP, CURRENCIES CU WHERE C.PLACE_ID = P.PLACE_ID AND S.COMPANY_ID = C.COMPANY_ID AND SA.SHARE_ID = S.SHARE_ID AND SP.SHARE_ID = S.SHARE_ID AND CU.CURRENCY_ID = S.CURRENCY_ID AND (C.NAME = 'company_name')">
    </asp:SqlDataSource>
    <p>
        <asp:Chart ID="Chart1" runat="server" 
            onload="Chart1_Load">
            <Series>
                <asp:Series Name="Series1" XValueMember="TIME_START" YValueMembers="PRICE" 
                    ChartType="Line">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    <p>
        &nbsp;<p>
            &nbsp;</asp:Content>