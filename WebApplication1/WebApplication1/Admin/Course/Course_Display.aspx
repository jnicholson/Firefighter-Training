<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Course_Display.aspx.cs" Inherits="WebApplication1.Admin.Course.Course_Display" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function CheckSingleCheckbox(ob) {
            var grid = ob.parentNode.parentNode.parentNode;
            var inputs = grid.getElementsByTagName("input");
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "checkbox") {
                    if (ob.checked && inputs[i] != ob && inputs[i].checked) {
                        inputs[i].checked = false;
                    }
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <div id="CourseListTitle" runat="server" class="ContentHead">
                <h1>Courses: </h1>
            </div>
            <section class="featured">
                <asp:GridView runat="server" ID="CourseInfo" Width="800px"
                    ItemType="WebApplication1.HalonModels.Course" DataKeyNames="Course_ID" AllowPaging="false" AutoGenerateColumns="false" AllowSorting="false"
                    SelectMethod="GetCourses" BorderWidth="1px">

                    <Columns>
                        <asp:BoundField HeaderText="Course ID" DataField="Course_ID" />
                        <asp:BoundField HeaderText="Course Name" DataField="Course_Name" />
                        <asp:BoundField HeaderText="Course Discontinued" DataField="Course_Discontinued" />
                        <asp:BoundField HeaderText="Course Credit Hours" DataField="Course_Credit_Hours" />
                        <asp:TemplateField HeaderText="Edit/Delete">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="editDeleteBox" onclick="CheckSingleCheckbox(this)" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </section>
            <p></p>
            <p></p>
            <asp:Button ID="EditCourseButton" runat="server" Text="Edit Course" OnClick="EditCourseButton_Click" CausesValidation="true" />
            <asp:Button ID="DeleteCourseButton" runat="server" Text="Delete Course" OnClick="DeleteCourseButton_Click" CausesValidation="true" />
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>