<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/MainMaster.Master" AutoEventWireup="true" CodeBehind="Billing.aspx.cs" Inherits="HospitalSoftware.WebForms.Billing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="maincontent" runat="server">
    <div class="container">
        <div class="row">
            Enter the Patient Id:
            <asp:TextBox runat="server" ID="pid" CssClass="form-control" Width="200px"  />
            <br />
            <asp:Button Text="Get" ID="btnGet" CssClass="btn btn-dark" runat="server" Width="100px" />
        </div>
        <div class="row">
            <h2>Billing Details</h2>
            
            <div class="container">
                <div class="row">
                    <div class="col-md-8">
                        Bill No:
                        <asp:TextBox runat="server" Width="200px" ID="txtBillNo" Enabled="false" CssClass="form-control" />
                    </div>
                    <div class="col-md-3 mx-2">
                        Bill Date: 
                        <asp:TextBox TextMode="Date" CssClass="form-control" ID="txtBill" runat="server" Width="200px" />
                    </div>
                </div>
            </div>
            <p>
                Patient Name: 
                    <asp:TextBox Enabled="false" runat="server" ID="txtName" CssClass="form-control" Width="200px" />
            </p>
            <p>
                Patient Mobile No:
                    <asp:TextBox Enabled="false" TextMode="Number" ID="txtMobile" CssClass="form-control" runat="server" Width="200px" />
            </p>
            <p>
                Doctor Name: 
                <asp:TextBox runat="server" ID="txtDoctor" Enabled="false" CssClass="form-control" Width="200px" />
            </p>
            <p>
                Bill Amount: 
                <asp:TextBox runat="server" ID="txtAmount" CssClass="form-control" Enabled="false" Width="200px" />
            </p>
            <p>
                <asp:Button Text="Generate Bill" runat="server" ID="btnBill" CssClass="btn btn-info" />
            </p>
        </div>
    </div>
</asp:Content>
