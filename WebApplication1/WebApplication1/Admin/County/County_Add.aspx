<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="County_Add.aspx.cs" Inherits="WebApplication1.Admin.County.County_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <div id="countyAddTitle" runat="server" class="ContentHead">
                <h1>Add County</h1>
            </div>
            <section class="featured">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelName" runat="server">County Name:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="AddCounty_Name" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="Validator1" runat="server" Text="* County Name required." ControlToValidate="AddCounty_Name" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="StateLabel" runat="server">State:</asp:Label></td>
                        <td>
                            <asp:DropDownList ID="StateDD" runat="server" ItemType="WebApplication1.HalonModels.State"
                                SelectMethod="GetStates" AppendDataBoundItems="true"
                                DataTextField="State_Name" DataValueField="State_ID" Style="" Font-Size="Larger" Width="175px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </section>
            <asp:Button ID="AddCountyButton" runat="server" Text="Add County" OnClick="AddCounty_Click" CausesValidation="true" />
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>