<%@ Page Title="SendUserRequest" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="SendUserRequest.aspx.cs" Inherits="WebApplication5.Account.SendUserRequest" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        request
    </h2>
                    <div class="accountInfo">
                     <fieldset class="register">
                            <legend>User Request</legend>
                            <p>
                                <asp:Label ID="UserNameLabel1" runat="server" 
                                    AssociatedControlID="UserName1">User Name:</asp:Label>
                                <asp:TextBox ID="UserName1" runat="server" CssClass="passwordEntry"></asp:TextBox>
                            </p>
                            <p>
                                <asp:Label ID="IssueLabel" runat="server" 
                                    AssociatedControlID="Issue">Issue:</asp:Label>
                                <asp:TextBox ID="Issue" runat="server" CssClass="passwordEntry"></asp:TextBox>
                            </p>
                            <p>
                                <asp:Label ID="DateLabel1" runat="server" AssociatedControlID="Date1">Date:</asp:Label>
                                <asp:TextBox ID="Date1" runat="server" CssClass="passwordEntry"></asp:TextBox>
                            </p>
                            <p>
                                <asp:Label ID="DescriptionlLabel" runat="server" 
                                    AssociatedControlID="Description">Description:</asp:Label>
                                <asp:TextBox ID="Description" runat="server" CssClass="textEntry" 
                                    Height="148px" Width="322px" ontextchanged="Description_TextChanged"></asp:TextBox>
                            </p>
                            <p>
                                <asp:Label ID="StatusLabel" runat="server" 
                                    AssociatedControlID="StatusDropDownList">Status:</asp:Label>
                                <asp:DropDownList ID="StatusDropDownList" runat="server">
                                    <asp:ListItem>Outstanding</asp:ListItem>
                                    <asp:ListItem>In Progress</asp:ListItem>
                                    <asp:ListItem>Completed</asp:ListItem>
                                </asp:DropDownList>
                            </p>
                        </fieldset>
                            <br />
                            <asp:Button ID="btnSendRequest" runat="server"  Text="Send Request" OnClick="btnSendRequest_Click"
                            Width="124px" />
                        <br />
                        <br />
                        <br />
                    </div>
        </asp:Content>
