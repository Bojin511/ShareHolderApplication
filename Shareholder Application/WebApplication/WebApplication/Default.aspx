<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/ShareholderMain.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApplication5._Default" %>

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
        TRADE</h2>

    <p><marquee behavior="scroll" direction="left">British Airways £ 124;  The New York Times $ 6.19;  Toyota $ 75.38;  BNP Paribas € 45.97;  EDF € 32.17;  Tesco £ 426.72;  IBM $ 131.29;  Google $ 468.15.
</marquee>

        </p>
    <p>&nbsp;</p>
    <p>Company Name :&nbsp;
        <asp:DropDownList ID="CompanyDropDownList" runat="server" 
            onselectedindexchanged="CompanyDropDownList_SelectedIndexChanged">
            <asp:ListItem>British Airways</asp:ListItem>
            <asp:ListItem>The New York Times</asp:ListItem>
            <asp:ListItem>Toyota</asp:ListItem>
            <asp:ListItem>BNP Paribas</asp:ListItem>
            <asp:ListItem>EDF</asp:ListItem>
            <asp:ListItem>Tesco</asp:ListItem>
            <asp:ListItem>IBM</asp:ListItem>
            <asp:ListItem>Google</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        Broker Name&nbsp;:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="BrokerDropDownList" runat="server" 
            onselectedindexchanged="BrokerDropDownList_SelectedIndexChanged">
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
    </p>
    <p>
        Stock Exchange :&nbsp;&nbsp;
        <asp:DropDownList ID="SeDropDownList" runat="server" 
            onselectedindexchanged="SeDropDownList_SelectedIndexChanged">
            <asp:ListItem>London Stock Exchange</asp:ListItem>
            <asp:ListItem>Euronext Paris</asp:ListItem>
            <asp:ListItem>New York Stock Exchange</asp:ListItem>
            <asp:ListItem>Tokyo Stock Exchange</asp:ListItem>
            <asp:ListItem>Moscow Stock Exchange</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        Transaction Type : 
        <asp:DropDownList ID="TransactionTypeDropDownList" runat="server" 
            onselectedindexchanged="TransactionTypeDropDownList_SelectedIndexChanged">
            <asp:ListItem>Buying</asp:ListItem>
            <asp:ListItem>Selling</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        Share Amount :&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="shareAmountTextBox" runat="server" 
            ontextchanged="shareAmountTextBox_TextChanged"></asp:TextBox>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Transaction has been done!" 
            Visible="False"></asp:Label>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Request Trade" Width="135px" 
            onclick="Button1_Click" />
    </p>
</asp:Content>
