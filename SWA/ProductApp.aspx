<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ProductApp.aspx.cs" Inherits="SampleWebApp.ProductApp" %>

<asp:Content ID="content1" ContentPlaceHolderID="mainContent" runat="server">
        <h1 class="h1 text-primary" style="text-align:center">Musical Instruments</h1>
         <div class="container">
            <div class="row">
                <div class="col-md-4">
                    <asp:ListBox ID="lstProducts" runat="server" Height="310px" Width="202px" AutoPostBack="True" onSelectedIndexChanged="lstProducts_SelectedIndexChanged">
                    </asp:ListBox>
                </div>
                <div class="col-md-7">
                    <div class="row">
                        <div class="col-md-6">
                    <h2>Details of the Musical Product</h2>
          <asp:Image ID="imgPic" Height="253px" runat="server" Width="225px" />
                            <asp:FileUpload ID="fileUploader" runat="server" />
                        </div>
                        <div class="col-md-4">
                            <p>Product Id: <asp:TextBox runat="server" CssClass="form-control" ID="txtId" /></p>
                            <p>Instrument Name: <asp:TextBox CssClass="form-control" runat="server" ID="txtName"/></p>
                            <p>Price: <asp:TextBox CssClass="form-control" runat="server" ID="txtPrice" /></p>
                            <p>Quantity: 
                                <asp:DropDownList CssClass="form-control" ID="dpQuantity" runat="server">
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>7</asp:ListItem>
                                </asp:DropDownList>
                            </p>

                        </div>
                        <div class="col-md-2 align-center">
                            <asp:Button Text="EDIT" runat="server" CssClass="btn btn-info my-4" OnClick="btnEdit_Click" />
                            <i class="fafa-edit"></i>
                            <asp:Button Text="DELETE" runat="server" CssClass="btn btn-danger my-3" OnClick="btnDelete_Click"/>
                            <i class="fa fa-delete"></i>
                            <asp:Button Text="ADD" runat="server" CssClass="btn btn-primary my-4" OnClick="btnAdd_Click" />
                            <i class ="fa fa-plus-o"></i>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Content>
   
