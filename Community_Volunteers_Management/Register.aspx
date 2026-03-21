<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Register.aspx.cs"
    Inherits="Community_Volunteers_Management.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="register-form-container w-100 d-flex flex-column align-items-center">
        <h2 class="text-center mb-4">Create an Account</h2>

        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control mb-3 w-100" Placeholder="First Name" />
        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control mb-3 w-100" Placeholder="Last Name" />
        <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control mb-3 w-100" TextMode="Date" />
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control mb-3 w-100" Placeholder="Email" />
        <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control mb-3 w-100" Placeholder="Phone Number" />
        <asp:TextBox ID="txtCity" runat="server" CssClass="form-control mb-3 w-100" Placeholder="City" />
        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control mb-3 w-100" TextMode="Password" Placeholder="Password" />

        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger mb-2 d-block"></asp:Label>

        <asp:Button ID="btnRegister" runat="server"
            Text="Register"
            CssClass="btn btn-primary mb-3 w-100"
            OnClick="btnRegister_Click" />
    </div>


</asp:Content>