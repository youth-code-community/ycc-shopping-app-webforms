<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signin.aspx.cs" Inherits="ycc_shopping_app_webforms.Shop.Signin" MasterPageFile="~/Shop/Main.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="body">
    <div class="btn-group">
        <a class="btn btn-success btn-lg" href="shopnow.aspx">Summary</a>
        <a class="btn btn-success btn-lg" href="Signin.aspx">Sign in</a>
        <a class="btn btn-success btn-lg" href="Address.aspx">Current address</a>
        <a class="btn btn-success btn-lg" href="Payment.aspx">Payments</a>
    </div>
    <hr />
    <div class="card">
        <div class="card-body">
            <!--sign in-->
            <div class="omb_login">

                <div class="row omb_row-sm-offset-3">
                    <div class="col-md-12 col-sm-6">
                        <form>
                            <div class="form-group">
                                <label for="username">Username</label>
                                <input type="text" class="form-control" id="username" placeholder="Username" />
                            </div>
                            <div class="form-group">
                                <label for="password">Password</label>
                                <input type="password" class="form-control" id="password" placeholder="Password" />
                            </div>
                            <button type="submit" class="btn btn-primary">Submit</button>
                        </form>

                    </div>
                </div>

            </div>

        </div>
    </div>

</asp:Content>
