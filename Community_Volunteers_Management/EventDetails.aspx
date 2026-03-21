<%@ Page Title="Event Details" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="EventDetails.aspx.cs"
    Inherits="Community_Volunteers_Management.EventDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container my-5">
        <asp:HiddenField ID="hfEventID" runat="server" />

        <div class="row g-4 align-items-center">

            <div class="col-md-5 text-center">
                <asp:Image ID="imgEvent" runat="server" CssClass="img-fluid rounded" />
            </div>


            <div class="col-md-7">
                <h2><asp:Label ID="lblEventName" runat="server"></asp:Label></h2>
                <p class="text-muted mb-2"><asp:Label ID="lblEventDate" runat="server"></asp:Label></p>
                <p class="mb-3"><asp:Label ID="lblDescription" runat="server"></asp:Label></p>
                <p class="mb-2"><strong>Location:</strong> <asp:Label ID="lblLocation" runat="server"></asp:Label></p>
                <p class="mb-2"><strong>Max Volunteers:</strong> <asp:Label ID="lblMaxVolunteers" runat="server"></asp:Label></p>
                <p class="mb-4"><strong>Current Participants:</strong> <asp:Label ID="lblCurrentVolunteers" runat="server"></asp:Label></p>

                <asp:Button ID="btnJoin" runat="server" Text="Join Event" CssClass="btn btn-primary btn-lg" OnClick="btnJoin_Click" />
            </div>
        </div>
    </div>
</asp:Content>