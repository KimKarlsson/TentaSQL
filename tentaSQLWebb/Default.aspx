<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!--spEtt-->
<asp:Label ID="Label1" runat="server" Text="Lista med filmer som ska återlämnas. Skriv tex: 2016-04-07"></asp:Label>
    <br />
<asp:TextBox ID="ReturnMovieID" runat="server"></asp:TextBox>
<asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1">
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FilmuthyrningDBConnectionString %>" SelectCommand="SPReturnMovieParamDate" SelectCommandType="StoredProcedure">
    <SelectParameters>
        <asp:ControlParameter ControlID="ReturnMovieID" Name="ParamRentDate" Type="DateTime" />
    </SelectParameters>
</asp:SqlDataSource>

   
    <br />

   <!--spTvå-->
<asp:Label ID="Label2" runat="server" Text="Lista filmer för viss medlem som ska återlämna"></asp:Label>
    <br />
    <asp:TextBox ID="KundID" runat="server"></asp:TextBox>
    <asp:Label ID="Label3" runat="server" Text="skriv kund id: tex 1 (1-9)"></asp:Label>
    <br />
    <asp:TextBox ID="date" runat="server"></asp:TextBox>
    <asp:Label ID="Label4" runat="server" Text="skriv datum då kunden hyrt film: tex 2016-04-01"></asp:Label>

    <asp:GridView ID="GridView2" runat="server" DataSourceID="SqlDataSource2">
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:FilmuthyrningDBConnectionString2 %>" SelectCommand="SPCustomerReturnParamCustomer" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="KundID" DefaultValue="" Name="ParamCustomerID" Type="Int32" />
            <asp:ControlParameter ControlID="date" Name="ParamRentDate" Type="DateTime" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
     <!--spTre-->
    <asp:Label ID="Label5" runat="server" Text="Lista filmer av en viss kategori, tex Action"></asp:Label>
    <br />
    <asp:TextBox ID="GenreID" runat="server"></asp:TextBox>
    <asp:GridView ID="GridView3" runat="server" DataSourceID="SqlDataSource3"></asp:GridView>
     <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:FilmuthyrningDBConnectionString3 %>" SelectCommand="SPGenreParamKategory" SelectCommandType="StoredProcedure">
         <SelectParameters>
             <asp:ControlParameter ControlID="GenreID" Name="ParamGenre" Type="String" />
         </SelectParameters>
    </asp:SqlDataSource>
     <!--Knappen-->
    <asp:Button ID="Button" runat="server" Text="Button" />

   
</asp:Content>
