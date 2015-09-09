<%@ Page Title="Edit Firefighter" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Firefighter_Edit.aspx.cs" Inherits="WebApplication1.Admin.Firefighter.Firefighter_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <div id="FirefighterDetailsTitle" runat="server" class="ContentHead">
                <h1>Edit Firefighter </h1>
                <p>
                    <asp:Label ID="UpdateStatusLabel" runat="server" Text="" ForeColor="White" Font-Size="Larger" />
                </p>
            </div>
            <section class="featured">

                <fieldset style="border-style: solid; border-color: gray; border-width: 1px; width: auto; padding-left: 10px;">
                    <legend><b>Personal Information</b></legend>
                    <table>
                        <tr class="ffLabel">
                            <td>
                                <asp:Label ID="FnameLabel" runat="server" Text="First Name" />
                                <asp:RequiredFieldValidator ID="RFV1" ControlToValidate="FnameTB" runat="server" Display="dynamic"
                                    ErrorMessage="Enter a First Name" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Label ID="MILabel" runat="server" Text="MI" /></td>
                            <td>
                                <asp:Label ID="LnameLabel" runat="server" Text="Last Name" />
                                <asp:RequiredFieldValidator ID="RFV2" ControlToValidate="LnameTB" runat="server" Display="dynamic"
                                    ErrorMessage="Enter a Last Name" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr class="ffText">
                            <td>
                                <asp:TextBox ID="FnameTB" runat="server" Text=""></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="MITB" runat="server" Text="" MaxLength="1" Width="40px"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="LnameTB" runat="server" Text=""></asp:TextBox></td>
                        </tr>

                        <tr class="ffLabel">
                            <td>
                                <asp:Label ID="DOBLabel" runat="server" Text="DOB (MM/DD/YYYY)" />
                                <asp:RangeValidator ID="DOBRV1" ControlToValidate="DOBTB1" runat="server" Display="dynamic" MinimumValue="01" MaximumValue="12"
                                    ErrorMessage="Birth Month Out of Range" ForeColor="Red">*</asp:RangeValidator>
                                <asp:RangeValidator ID="DOBRV2" ControlToValidate="DOBTB2" runat="server" Display="dynamic" MinimumValue="01" MaximumValue="31"
                                    ErrorMessage="Birth Day Out of Range" ForeColor="Red">*</asp:RangeValidator>
                                <asp:RegularExpressionValidator ID="DOBREV1" ControlToValidate="DOBTB1" runat="server" Display="Dynamic" ValidationExpression="^\d{2}$"
                                    ErrorMessage="Birth Month Out of Format" ForeColor="Red">*</asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="DOBREV2" ControlToValidate="DOBTB2" runat="server" Display="Dynamic" ValidationExpression="^\d{2}$"
                                    ErrorMessage="Birth Day Out of Format" ForeColor="Red">*</asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="DOBREV3" ControlToValidate="DOBTB3" runat="server" Display="Dynamic" ValidationExpression="^\d{4}$"
                                    ErrorMessage="Birth Year Out of Format" ForeColor="Red">*</asp:RegularExpressionValidator>
                            </td>
                            <td>
                                <asp:Label ID="DLNumLabel" runat="server" Text="DL Number" /></td>
                            <td>
                                <asp:Label ID="DLStateLabel" runat="server" Text="DL State" /></td>
                        </tr>
                        <tr class="ffText">
                            <td>
                                <asp:TextBox ID="DOBTB1" runat="server" Text="" Width="40px" MaxLength="2"></asp:TextBox>
                                <asp:TextBox ID="DOBTB2" runat="server" Text="" Width="40px" MaxLength="2"></asp:TextBox>
                                <asp:TextBox ID="DOBTB3" runat="server" Text="" Width="50px" MaxLength="4"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="DLNumTB" runat="server" Text=""></asp:TextBox></td>
                            <td>
                                <asp:DropDownList ID="DLStateDD" runat="server" ItemType="WebApplication1.HalonModels.State"
                                    SelectMethod="GetStates" AppendDataBoundItems="true"
                                    DataTextField="State_Abbreviation" DataValueField="State_ID" Style="" Font-Size="Larger">
                                    <asp:ListItem Text="N/A" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr class="ffLabel">
                            <td>
                                <asp:Label ID="AddressLabel" runat="server" Text="Street Address" /></td>
                            <td>
                                <asp:Label ID="CityLabel" runat="server" Text="City" /></td>
                            <td>
                                <asp:Label ID="StateLabel" runat="server" Text="State" /></td>
                            <td>
                                <asp:Label ID="ZipLabel" runat="server" Text="ZIP" />
                                <asp:RegularExpressionValidator ID="ZipREV" ControlToValidate="ZipTB" runat="server" Display="Dynamic"
                                    ValidationExpression="^\d{5}$" ErrorMessage="ZIP Out of Format" ForeColor="Red">*</asp:RegularExpressionValidator>
                            </td>
                            <td>
                                <asp:Label ID="CountyLabel" runat="server" Text="County" />
                            </td>
                        </tr>
                        <tr class="ffText">
                            <td>
                                <asp:TextBox ID="AddressTB" runat="server" Text=""></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="CityTB" runat="server" Text=""></asp:TextBox></td>
                            <td>
                                <asp:DropDownList ID="StateDD" runat="server" ItemType="WebApplication1.HalonModels.State"
                                    SelectMethod="GetStates" AppendDataBoundItems="true"
                                    DataTextField="State_Name" DataValueField="State_ID" Style="" Font-Size="Larger" Width="175px">
                                </asp:DropDownList></td>
                            <td>
                                <asp:TextBox ID="ZipTB" runat="server" Text="" MaxLength="5" Width="60px"></asp:TextBox></td>
                            <td>
                                <asp:DropDownList ID="CountyDD" runat="server" ItemType="WebApplication1.HalonModels.County"
                                    SelectMethod="GetCounties" AppendDataBoundItems="true"
                                    DataTextField="County_Name" DataValueField="County_ID" Style="" Font-Size="Larger" Width="175px">
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td class="ffLabel">
                                <asp:Label ID="EducationLabel" runat="server" Text="Highest Education" /></td>

                            <td>
                                <asp:Label ID="EthnicityLabel" runat="server" Text="Ethnicity" />
                            </td>
                        </tr>
                        <tr class="ffText">
                            <td>

                                <asp:DropDownList ID="EducationDD" runat="server" Style="" Font-Size="Medium" Width="175px">
                                    <asp:ListItem Selected="True" Value="Less Than High School"> Less Than High School </asp:ListItem>
                                    <asp:ListItem Value="H.S. Diploma/G.E.D."> H.S. Diploma/G.E.D. </asp:ListItem>
                                    <asp:ListItem Value="Some College"> Some College </asp:ListItem>
                                    <asp:ListItem Value="Bachelor's"> Bachelor's </asp:ListItem>
                                    <asp:ListItem Value="Master's"> Master's </asp:ListItem>
                                    <asp:ListItem Value="Doctorate"> Doctorate </asp:ListItem>
                                </asp:DropDownList>
                            </td>

                            <td>
                                <asp:DropDownList ID="EthnicityDD" runat="server" Style="" Font-Size="Medium" Width="175px">
                                    <asp:ListItem Text="White" />
                                    <asp:ListItem Text="Black" />
                                    <asp:ListItem Text="Hispanic" />
                                    <asp:ListItem Text="Asian" />
                                    <asp:ListItem Text="Native American" />
                                    <asp:ListItem Text="Middle Eastern" />
                                    <asp:ListItem Text="Other" />
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr class="ffLabel">

                            <td style="width: 175px">
                                <asp:Label ID="HSDiplomaLabel" runat="server" Text="H.S. Diploma:" />
                            </td>

                            <td>
                                <asp:Label ID="GenderLabel" runat="server" Text="Gender:" /></td>
                        </tr>
                        <tr>
                            <td class="ffText">
                                <asp:RadioButtonList ID="HSDiplomaRBL" runat="server" RepeatColumns="2" Width="54px" Font-Size="Small" CellPadding="0">
                                    <asp:ListItem Text="Yes" Value="True" />
                                    <asp:ListItem Text="No" Value="False" />
                                </asp:RadioButtonList>
                            </td>

                            <td style="vertical-align: top">

                                <asp:RadioButtonList ID="GenderRBL" runat="server" RepeatColumns="2" Width="54px" Font-Size="Small" CellPadding="0">
                                    <asp:ListItem Text="Male" Value="M" />
                                    <asp:ListItem Text="Female" Value="F" />
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <fieldset style="border-style: solid; border-color: gray; border-width: 1px; padding-left: 10px">
                    <legend><b>Department Information</b></legend>
                    <table>
                        <tr style="font-size: larger">
                            <td>
                                <asp:Label ID="VerifiedLabel" runat="server" Text="Verified: " />
                            </td>
                            <td>
                                <asp:RadioButtonList ID="VerifiedRBL" runat="server" RepeatColumns="2" Width="54px" Font-Size="Small" CellPadding="0">
                                    <asp:ListItem Text="Yes" Value="True" />
                                    <asp:ListItem Text="No" Value="False" />
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <asp:Label ID="EMTCertLabel" runat="server" Text="EMT Certified: " />
                            </td>
                            <td>
                                <asp:RadioButtonList ID="EMTCertRBL" runat="server" RepeatColumns="2" Width="54px" Font-Size="Small" CellPadding="0">
                                    <asp:ListItem Text="Yes" Value="True" />
                                    <asp:ListItem Text="No" Value="False" />
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <asp:Label ID="RetiredLabel" runat="server" Text="Retired: " />
                            </td>
                            <td>
                                <asp:RadioButtonList ID="RetiredRBL" runat="server" RepeatColumns="2" Width="54px" Font-Size="Small" CellPadding="0">
                                    <asp:ListItem Text="Yes" Value="True" />
                                    <asp:ListItem Text="No" Value="False" />
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr style="font-size: larger">
                            <td>
                                <asp:Label ID="FFCertLabel" runat="server" Text="Firefighter Certified: " />
                            </td>
                            <td>
                                <asp:RadioButtonList ID="FFCertRBL" runat="server" RepeatColumns="2" Width="54px" Font-Size="Small" CellPadding="0">
                                    <asp:ListItem Text="Yes" Value="True" />
                                    <asp:ListItem Text="No" Value="False" />
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <asp:Label ID="CertSuspLabel" runat="server" Text="FF Cert Suspended: " />
                            </td>
                            <td>
                                <asp:RadioButtonList ID="CertSuspRBL" runat="server" RepeatColumns="2" Width="54px" Font-Size="Small" CellPadding="0">
                                    <asp:ListItem Text="Yes" Value="True" />
                                    <asp:ListItem Text="No" Value="False" />
                                </asp:RadioButtonList>
                            </td>

                            <td>
                                <asp:Label ID="SuspExpLabel" runat="server" Text="Suspension Explanation: " />
                            </td>

                            <td>
                                <asp:TextBox ID="SuspExpTB" runat="server" TextMode="MultiLine" placeholder="Limit 250 characters" Style="font-size: smaller; width: 200px" Wrap="true" MaxLength="250" /></td>
                        </tr>
                    </table>
                    <table>
                        <tr class="ffLabel">
                            <td>
                                <asp:Label ID="DeptLabel" runat="server" Text="Department" /></td>
                            <td>
                                <asp:Label ID="RankLabel" runat="server" Text="Rank" /></td>
                            <td>
                                <asp:Label ID="CallsignLabel" runat="server" Text="Callsign" /></td>
                        </tr>
                        <tr class="ffText">
                            <td>
                                <asp:DropDownList ID="DeptDD" runat="server" ItemType="WebApplication1.HalonModels.Department"
                                    SelectMethod="GetDepartments" AppendDataBoundItems="true"
                                    DataTextField="Dept_Name" DataValueField="Dept_ID" Style="" Font-Size="Larger" Width="175px">
                                </asp:DropDownList></td>
                            <td>
                                <asp:DropDownList ID="RankDD" runat="server" Style="" Font-Size="Larger" Width="175px">
                                    <asp:ListItem Selected="True" Value="Firefighter"> Firefighter </asp:ListItem>
                                    <asp:ListItem Value="Lieutenant"> Lieutenant </asp:ListItem>
                                    <asp:ListItem Value="Captain"> Captain </asp:ListItem>
                                    <asp:ListItem Value="Safety Officer"> Safety Officer </asp:ListItem>
                                    <asp:ListItem Value="Equipment Officer"> Equipment Officer </asp:ListItem>
                                    <asp:ListItem Value="Training Officer"> Training Officer </asp:ListItem>
                                    <asp:ListItem Value="Treasurer"> Treasurer </asp:ListItem>
                                    <asp:ListItem Value="Secretary"> Secretary </asp:ListItem>
                                    <asp:ListItem Value="Asst. Fire Chief"> Asst. Fire Chief </asp:ListItem>
                                    <asp:ListItem Value="Fire Chief"> Fire Chief </asp:ListItem>
                                </asp:DropDownList></td>
                            <td>
                                <asp:TextBox ID="CallsignTB" runat="server" Text=""></asp:TextBox></td>
                        </tr>
                    </table>
                </fieldset>
                <fieldset style="border-style: solid; border-color: gray; border-width: 1px; padding-left: 10px">
                    <legend><b>Contact Information</b></legend>
                    <table>

                        <tr>
                            <td>
                                <asp:Label ID="EmailLabel" runat="server" Text="Email" /></td>
                            <td>
                                <asp:TextBox ID="EmailTB" runat="server" Text=""></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="HomePhoneLabel" runat="server" Text="Home Phone" />
                                <asp:RegularExpressionValidator ID="HPREV1" ControlToValidate="HomePhoneTB1" runat="server" Display="Dynamic"
                                    ValidationExpression="^\d{3}$" ErrorMessage="Home Phone Area Code Out of Format" ForeColor="Red">*</asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="HPREV2" ControlToValidate="HomePhoneTB2" runat="server" Display="Dynamic"
                                    ValidationExpression="^\d{3}$" ErrorMessage="Home Phone First Three Out of Format" ForeColor="Red">*</asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="HPREV3" ControlToValidate="HomePhoneTB3" runat="server" Display="Dynamic"
                                    ValidationExpression="^\d{4}$" ErrorMessage="Home Phone Last Four Out of Format" ForeColor="Red">*</asp:RegularExpressionValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="HomePhoneTB1" runat="server" Text="" Width="40px" MaxLength="3"></asp:TextBox>
                                <asp:TextBox ID="HomePhoneTB2" runat="server" Text="" Width="40px" MaxLength="3"></asp:TextBox>
                                <asp:TextBox ID="HomePhoneTB3" runat="server" Text="" Width="50px" MaxLength="4"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="CellPhoneLabel" runat="server" Text="Cell Phone" />
                                <asp:RegularExpressionValidator ID="CPREV1" ControlToValidate="CellPhoneTB1" runat="server" Display="Dynamic"
                                    ValidationExpression="^\d{3}$" ErrorMessage="Cell Phone Area Code Out of Format" ForeColor="Red">*</asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="CPREV2" ControlToValidate="CellPhoneTB2" runat="server" Display="Dynamic"
                                    ValidationExpression="^\d{3}$" ErrorMessage="Cell Phone First Three Out of Format" ForeColor="Red">*</asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="CPREV3" ControlToValidate="CellPhoneTB3" runat="server" Display="Dynamic"
                                    ValidationExpression="^\d{4}$" ErrorMessage="Cell Phone Last Four Out of Format" ForeColor="Red">*</asp:RegularExpressionValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="CellPhoneTB1" runat="server" Text="" Width="40px" MaxLength="3"></asp:TextBox>
                                <asp:TextBox ID="CellPhoneTB2" runat="server" Text="" Width="40px" MaxLength="3"></asp:TextBox>
                                <asp:TextBox ID="CellPhoneTB3" runat="server" Text="" Width="50px" MaxLength="4"></asp:TextBox>
                            </td>
                        </tr>
                        <tr class="ffText">
                            <td>
                                <asp:Label ID="EmerPhoneLabel" runat="server" Text="Emergency Phone" />
                                <asp:RegularExpressionValidator ID="EPREV1" ControlToValidate="EmerPhoneTB1" runat="server" Display="Dynamic"
                                    ValidationExpression="^\d{3}$" ErrorMessage="Emergency Phone Area Code Out of Format" ForeColor="Red">*</asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="EPREV2" ControlToValidate="EmerPhoneTB2" runat="server" Display="Dynamic"
                                    ValidationExpression="^\d{3}$" ErrorMessage="Emergency Phone First Three Out of Format" ForeColor="Red">*</asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="EPREV3" ControlToValidate="EmerPhoneTB3" runat="server" Display="Dynamic"
                                    ValidationExpression="^\d{4}$" ErrorMessage="Emergency Phone Last Four Out of Format" ForeColor="Red">*</asp:RegularExpressionValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="EmerPhoneTB1" runat="server" Text="" Width="40px" MaxLength="3"></asp:TextBox>
                                <asp:TextBox ID="EmerPhoneTB2" runat="server" Text="" Width="40px" MaxLength="3"></asp:TextBox>
                                <asp:TextBox ID="EmerPhoneTB3" runat="server" Text="" Width="50px" MaxLength="4"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <asp:ValidationSummary ID="valSum" DisplayMode="BulletList" runat="server" ForeColor="Red" HeaderText="Please Correct These Errors: " />
            </section>
            <asp:Button runat="server" ID="submitButton" Text="Submit" OnClick="UpdateFirefighter_Click" />
            <asp:Button runat="server" ID="cancelButton" Text="Cancel" OnClick="CancelUpdateFirefighter_Click" />
            <asp:Button runat="server" ID="deleteButton" Text="Remove" OnClick="RemoveUpdateFirefighter_Click" />
            <asp:CheckBox runat="server" ID="deleteCB" Text="Box Must Be Checked Before Removing Firefighter" ForeColor="Black"/>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>