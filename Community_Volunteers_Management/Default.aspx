<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Community_Volunteers_Management._Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>


        <section class="home-banner d-flex align-items-center text-center text-white"
                 style="background-image: url('<%= ResolveUrl("~/Images/Community_Banner.jpg") %>');">
            <div class="container position-relative text-center w-100">
                <h1 class="display-3 fw-bold">Connect With The Community</h1>
                <p class="lead mb-4">Volunteer, meet your fellow community members, and make a difference.</p>
                <a href="Events.aspx" class="btn btn-primary btn-lg">Explore Events</a>
            </div>
        </section>



        <section class="container my-5">
            <h2 class="text-center mb-4">Future Events</h2>
                <a href="Events.aspx" class="see-all-events btn btn-link">See all Events</a>


            <div class="row g-4">
                <asp:Repeater ID="rptEvents" runat="server">
                    <ItemTemplate>
                        <div class="col-md-4">
                            <a href='EventDetails.aspx?EventID=<%# Eval("EventID") %>' style="text-decoration:none; color:inherit;">
                                <div class="card event-card shadow-sm h-100">
                                    <img src='<%# string.IsNullOrEmpty(Eval("ImagePath")?.ToString()) 
                                    ? "Images/default.jpg" 
                                    : Eval("ImagePath") %>' 
                                     class="card-img-top" />
                                    <div class="card-body">
                                        <h5 class="card-title"><%# Eval("EventName") %></h5>
                                        <p class="card-text"><%# Eval("Description") %></p>
                                        <p class="card-text text-muted">
                                            <%# Eval("Barangay") %>, <%# Eval("City") %> | <%# Eval("EventDate", "{0:MMMM dd, yyyy}") %>
                                        </p>
                                    </div>
                                </div>
                            </a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </section>


            <div class="section-divider"></div>


                <section class="container my-5">
            <h2 class="text-center mb-5">Meet Our Volunteers</h2>


            <div class="row align-items-center mb-5 testimonial-row">
                <div class="col-md-4 position-relative">
                    <img src="Images/volunteer1.jpg" class="testimonial-img" />
                </div>
                <div class="col-md-8">
                    <p class="testimonial-text">"Volunteering here has been life-changing! I’ve met amazing people and made lasting memories."</p>
                    <h6 class="text-muted mt-2">– Maria S., Volunteer</h6>
                </div>
            </div>


            <div class="row align-items-center mb-5 testimonial-row flex-md-row-reverse">
                <div class="col-md-4 position-relative">
                    <img src="Images/volunteer2.jpg" class="testimonial-img" />
                </div>
                <div class="col-md-8">
                    <p class="testimonial-text">"I'm just happy to  be out and about. It’s rewarding to see our community grow together."</p>
                    <h6 class="text-muted mt-2">– Juan D., Volunteer</h6>
                </div>
            </div>


            <div class="row align-items-center testimonial-row">
                <div class="col-md-4 position-relative">
                    <img src="Images/volunteer3.jpg" class="testimonial-img" />
                </div>
                <div class="col-md-8">
                    <p class="testimonial-text">"If I can give some of my time, maybe you can too, and that would be enough."</p>
                    <h6 class="text-muted mt-2">– Ana P., Volunteer</h6>
                </div>
            </div>
        </section>


        <div class="section-divider"></div>


        <section class="cta-section text-center py-5">
            <div class="container">
                <h2 class="fw-bold mb-3">Start joining your community events today!</h2>
                <p class="lead mb-4">
                    Join, connect, and see all of what your community has in store.
                </p>
                <a href="Register.aspx" class="btn btn-primary btn-lg px-4">Join Us</a>
            </div>
        </section>




    </main>

</asp:Content>
