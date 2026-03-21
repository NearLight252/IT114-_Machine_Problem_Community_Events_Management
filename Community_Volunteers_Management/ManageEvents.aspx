<%@ Page Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="ManageEvents.aspx.cs"
    Inherits="Community_Volunteers_Management.ManageEvents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="mb-4 text-center">Manage Events</h2>


        <h3 class="mb-3">Add New Event</h3>
    <asp:Panel ID="pnlAddEvent" runat="server" CssClass="mb-4">
        <div class="row g-2">
            <div class="col-md-3">
                <asp:TextBox ID="txtEventName" runat="server" CssClass="form-control" Placeholder="Event Name" />
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txtEventDate" runat="server" CssClass="form-control" Placeholder="YYYY-MM-DD" />
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" Placeholder="City" />
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txtBarangay" runat="server" CssClass="form-control" Placeholder="Barangay" />
            </div>
            <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" Placeholder="Description" TextMode="MultiLine" />
            <div class="col-md-1">
                <asp:TextBox ID="txtMaxVolunteers" runat="server" CssClass="form-control" Placeholder="Capacity" />
            </div>
            <div class="col-md-3">
            <asp:TextBox ID="txtImagePath" runat="server" CssClass="form-control" Placeholder="Image Path (e.g. Images/event1.jpg)" />
        </div>

            <div class="col-md-2">
                <asp:Button ID="btnAddEvent" runat="server" Text="Add Event" CssClass="btn btn-success w-100" OnClick="btnAddEvent_Click" />
            </div>


        </div>
        <asp:Label ID="lblAddEventMessage" runat="server" CssClass="text-success mt-2"></asp:Label>
    </asp:Panel>


    <asp:GridView ID="gvEvents" runat="server" AutoGenerateColumns="False"
        CssClass="table table-striped"
        DataKeyNames="EventID"
        OnRowDataBound="gvEvents_RowDataBound">

        <Columns>
            <asp:BoundField DataField="EventName" HeaderText="Event Name" />
            <asp:BoundField DataField="EventDate" HeaderText="Date" DataFormatString="{0:MMMM dd, yyyy}" />
            <asp:BoundField DataField="City" HeaderText="City" />
            <asp:BoundField DataField="Barangay" HeaderText="Barangay" />
            <asp:BoundField DataField="MaxVolunteers" HeaderText="Capacity" />
            <asp:BoundField DataField="TotalVolunteers" HeaderText="Total Volunteers" />


            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlStatus" runat="server"
                        AutoPostBack="true"
                        OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged"
                        CssClass="form-select">

                        <asp:ListItem Text="Upcoming" Value="Upcoming"></asp:ListItem>
                        <asp:ListItem Text="On-going" Value="On-going"></asp:ListItem>
                        <asp:ListItem Text="Concluded" Value="Concluded"></asp:ListItem>

                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="btnDelete" runat="server" 
                        Text="Delete" 
                        CssClass="btn btn-danger btn-sm"
                        CommandArgument='<%# Eval("EventID") %>'
                        OnClick="btnDelete_Click"
                        OnClientClick="return confirm('Are you sure you want to delete this event?');" />
                </ItemTemplate>
            </asp:TemplateField>


        </Columns>
    </asp:GridView>

</asp:Content>