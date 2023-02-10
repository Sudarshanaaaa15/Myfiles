<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Cacheing.aspx.cs" Inherits="SampleWebApp.Cacheing" %>
<%@ Register TagPrefix="myctrls" TagName="CustomTime" Src="~/CustomControls/ServerTime.ascx" %>
<%@ OutputCache Duration="10" VaryByParam="City"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <h1>Time at the server</h1>
    <hr />
    <asp:Label Text="" ID="lblTime" runat="server" />
    <div style="border:2px solid black">
        <h2>Time at vaious places</h2>
        <hr />
        <p>
            Select your city:
            <asp:DropDownList runat="server" ID="dpCities" AutoPostBack="false">
                <asp:ListItem Text="New Delhi" />
                <asp:ListItem Text="London" />
                <asp:ListItem Text="New York" />
                <asp:ListItem Text="Tokyo" />
            </asp:DropDownList>
            <asp:Button Text="GetTime" runat="server" ID="btnTime" OnClick="btnTime_Click" />
            <asp:Label Text="" ID="lblClock" runat="server" />
        </p>
    </div>
    <div>
        <myctrls:CustomTime runat="server" />
    </div>
</asp:Content>
