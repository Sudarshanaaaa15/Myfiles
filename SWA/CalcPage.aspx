<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CalcPage.aspx.cs" Inherits="SampleWebApp.CalcPage" %>

<asp:Content ID="content1" ContentPlaceHolderID="mainContent" runat="server">
        <div>
            <h1 style="text-align: center; background-color: #3399FF">Calculator</h1>
            <br />
            <p style="text-align: center">
                Enter the First value:
                <asp:TextBox runat="server" ID="firstText"></asp:TextBox>
            </p>
            <p style="text-align: center">
                Select the option:
                <asp:DropDownList runat="server" ID="dplist">
                    <asp:ListItem Text="add" />
                    <asp:ListItem Text="subtract" />
                    <asp:ListItem Text="multiply" />
                    <asp:ListItem Text="division" />
                </asp:DropDownList>
            </p>
            <p style="text-align: center">
                Enter the second value:
                <asp:TextBox runat="server" ID="secondText" />
            </p>
            <p style="text-align: center">
                <asp:Button Text="Get Result" runat="server" ID="btnResult" OnClick="btnResult_Click"/>
            </p>
            <p style="text-align: center">
                <asp:Label Text="The Result" runat="server" ID="displaylbl" />
            </p>
        </div>
    </asp:Content>
