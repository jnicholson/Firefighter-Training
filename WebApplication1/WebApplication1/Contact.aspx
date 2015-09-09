﻿<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebApplication1.Contact" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>
            </hgroup>
            <section class="featured">
                <header>
                    <h3>Phone:</h3>
                </header>
                <p>
                    <span class="label">Main:</span>
                    <span>425.555.0100</span>
                </p>
                <p>
                    <span class="label">After Hours:</span>
                    <span>425.555.0199</span>
                </p>
            </section>

            <section class="featured">
                <header>
                    <h3>Email:</h3>
                </header>
                <p>
                    <span class="label">Support:</span>
                    <span><a href="mailto:Support@example.com">Support@example.com</a></span>
                </p>
                <p>
                    <span class="label">Marketing:</span>
                    <span><a href="mailto:Marketing@example.com">Marketing@example.com</a></span>
                </p>
                <p>
                    <span class="label">General:</span>
                    <span><a href="mailto:General@example.com">General@example.com</a></span>
                </p>
            </section>

            <section class="featured">
                <header>
                    <h3>Address:</h3>
                </header>
                <p>
                    One Microsoft Way<br />
                    Redmond, WA 98052-6399
                </p>
            </section>
        </div>
    </section>
</asp:Content>