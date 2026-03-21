<%@ Page Title="Events" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="Community_Volunteers_Management.Events" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container my-5">

        <h1 class="text-center mb-5">All Community Events</h1>


        <h3 class="mb-4">Upcoming Events</h3>
        <div class="row g-4">
            <asp:Repeater ID="rptUpcoming" runat="server">
                <ItemTemplate>
                    <div class="col-md-4">
                        <div class="card event-card shadow-sm h-100 clickable-card" 
                             onclick="location.href='EventDetails.aspx?EventID=<%# Eval("EventID") %>'">
                            <img src='<%# string.IsNullOrEmpty(Eval("ImagePath")?.ToString()) 
                                ? "Images/default.jpg" 
                                : Eval("ImagePath") %>' 
                                 class="card-img-top" />
                            <div class="card-body">
                                <h5><%# Eval("EventName") %></h5>
                                <p><%# Eval("Description") %></p>
                                <p class="text-muted">
                                    <%# Eval("Barangay") %>, <%# Eval("City") %><br />
                                    <%# Eval("EventDate", "{0:MMMM dd, yyyy}") %>
                                </p>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <hr class="my-5" />


        <h3 class="mb-4">Ongoing Events</h3>
        <div class="row g-4">
            <asp:Repeater ID="rptOngoing" runat="server">
                <ItemTemplate>
                    <div class="col-md-4">
                        <div class="card event-card shadow-sm h-100 clickable-card" 
                             onclick="location.href='EventDetails.aspx?EventID=<%# Eval("EventID") %>'">
                            <img src='<%# string.IsNullOrEmpty(Eval("ImagePath")?.ToString()) 
                                ? "Images/default.jpg" 
                                : Eval("ImagePath") %>' 
                                 class="card-img-top" />
                            <div class="card-body">
                                <h5><%# Eval("EventName") %></h5>
                                <p><%# Eval("Description") %></p>
                                <p class="text-muted">
                                    <%# Eval("Barangay") %>, <%# Eval("City") %><br />
                                    <%# Eval("EventDate", "{0:MMMM dd, yyyy}") %>
                                </p>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <hr class="my-5" />


        <h3 class="mb-4">Past Events</h3>
        <div class="row g-4">
            <asp:Repeater ID="rptPast" runat="server">
                <ItemTemplate>
                    <div class="col-md-4">
                        <div class="card bg-light shadow-sm h-100">
                            <div class="card-body">
                                <h5><%# Eval("EventName") %></h5>
                                <p><%# Eval("Description") %></p>
                                <p class="text-muted">
                                    Completed on <%# Eval("EventDate", "{0:MMMM dd, yyyy}") %>
                                </p>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

    </div>

</asp:Content>