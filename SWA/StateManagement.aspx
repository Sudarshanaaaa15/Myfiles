<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="StateManagement.aspx.cs" Inherits="SampleWebApp.StateManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server"> 
    <style>
        .item{
            border:2px solid red;
        }
    </style>
        <h1 class="h1">Server-side management using session and application state</h1>

        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <asp:Repeater runat="server" ID="repeat">
                        <HeaderTemplate>
                            <div>
                                <h2>List of Products....!</h2>
                                <hr />
                            </div>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="row item">
                                <div class="col-md-7">
                                   <asp:Image ImageUrl=<%# Eval("Image") %> runat="server" Width="200px" Height="150px"/>
                                    <p>Cost : <%# Eval("Price") %></p>
                                    <asp:Button Text="View More Details" OnCommand="Click_Onview" CommandArgument=<%#Eval ("ProductId")%>  CommandName="Details" runat="server" CssClass="btn btn-info" />
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="col-md-5">
                    <h2>Details of the choosed products</h2>
                    <div>
                    <asp:Image ID="imgsel"  runat="server" Width="200px" Height="150px" />
                    </div>
                    <div>
                        <asp:TextBox ID="textpid" runat="server" Enabled="false" />
                    </div>
                    <div>
                        <asp:TextBox ID="textpname" runat="server" Enabled="false" />
                    </div>
                    <div>
                        <asp:TextBox ID="textpcost" runat="server" Enabled="false" />
                    </div>
                    <div>
                        <asp:TextBox ID="textpquanty" runat="server" Enabled="false" />
                    </div>
                    <div>
                        <asp:Button Text="Add to cart" runat="server" Width="100px" />
                    </div>
                </div>
            </div>
            <div class="row">
                <asp:DataList ID="recentlst" runat="server" CellPadding="2" CellSpacing="4" RepeatColumns="5">
                    <ItemTemplate>
                        <div class="row items">
                            <div class="col-md-8">
                                <h2><%#Eval("ProductName") %></h2>
                                <asp:Image ImageUrl=<%#Eval ("Image") %> runat="server" Width="200px" Height="150px" />
                                <p>Cost: <%#Eval("Price") %></p>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </asp:Content>