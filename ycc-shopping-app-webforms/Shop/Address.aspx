<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Address.aspx.cs" Inherits="ycc_shopping_app_webforms.Shop.Address" MasterPageFile="~/Shop/Main.Master"%>

<asp:Content runat="server" ContentPlaceHolderID="body">
    <div class="btn-group">
        <a class="btn btn-success btn-lg" href="shopnow.aspx">Summary</a>
        <a class="btn btn-success btn-lg" href="Signin.aspx">Sign in</a>
        <a class="btn btn-success btn-lg" href="Address.aspx">Current address</a>
        <a class="btn btn-success btn-lg" href="Payment.aspx">Payments</a>
    </div>
    <hr />
    <!--current address-->
    <div class="card">
        <div class="card-body">
            <h1>Current location</h1>
            <div id="map">My map will go here</div>
        </div>

    </div>

</asp:Content>