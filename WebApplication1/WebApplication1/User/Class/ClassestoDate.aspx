<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClassestoDate.aspx.cs" Inherits="WebApplication1.User.Class.ClassestoDate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <div id="EnrollmentListTitle" runat="server" class="ContentHead">
                <h1>Class Enrollments to Date: </h1>
            </div>
            <section class="featured">
                <asp:GridView runat="server" ID="ClassInfo" Width="800px"
                    ItemType="WebApplication1.HalonModels.Class" DataKeyNames="Class_ID" AllowPaging="false" AutoGenerateColumns="false" AllowSorting="false"
                    SelectMethod="GetClasses" BorderWidth="1px" OnRowDataBound="Classes_RowDataBound">

                    <Columns>
                        <asp:BoundField HeaderText="Class ID" DataField="Class_ID" />
                        <asp:HyperLinkField HeaderText="Teacher Name" Text=""
                            DataNavigateUrlFields="Firefighter_ID"
                            DataNavigateUrlFormatString="/Firefighter/Firefighter_Display.aspx?Firefighter_ID={0}" />
                        <asp:BoundField HeaderText="Class Date" DataField="Class_Date" />
                        <asp:HyperLinkField HeaderText="Course Name" Text=""
                            DataNavigateUrlFields="Course_ID"
                            DataNavigateUrlFormatString="/Class/Class_Display.aspx?Class_ID={0}" />
                        <asp:BoundField HeaderText="Class Note" DataField="Class_Note" />
                    </Columns>
                </asp:GridView>
            </section>
        </div>
    </section>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>