<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShopNow.aspx.cs" Inherits="ycc_shopping_app_webforms.Shop.ShopNow" MasterPageFile="~/Shop/Main.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="body">
    <div class="btn-group">
        <a class="btn btn-success btn-lg" href="shopnow.aspx">Summary</a>
        <a class="btn btn-success btn-lg" href="Signin.aspx">Sign in</a>
        <a class="btn btn-success btn-lg" href="Address.aspx">Current address</a>
        <a class="btn btn-success btn-lg" href="Payment.aspx">Payments</a>
    </div>
    <hr />
    <!-- product button-->
    <div class="card">
        <div class="card-body">
            <table id="cart" class="table table-hover table-condensed">
                <thead>
                    <tr>
                        <th style="width: 50%">Product</th>
                        <th style="width: 10%">Price</th>
                        <th style="width: 8%">Quantity</th>
                        <th style="width: 22%" class="text-center">Subtotal</th>
                        <th style="width: 10%"></th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td data-th="Product">
                            <div class="row">
                                <div class="col-sm-2 hidden-xs">
                                    <img src="" alt="..." class="img-responsive" />
                                </div>
                                <div class="col-sm-10">
                                    <h4 class="nomargin"></h4>
                                    <!--product-->

                                </div>
                            </div>
                        </td>
                        <td data-th="Price"></td>
                        <!--price-->
                        <td data-th="Quantity">
                            <input type="number" class="form-control text-center" value=""><!--amount of items picked-->
                        </td>
                        <td data-th="Subtotal" class="text-center"></td>
                        <!--price-->
                        <td class="actions" data-th="">
                            <button class="btn btn-info btn-sm"><i class="fa fa-refresh"></i></button>
                            <button class="btn btn-danger btn-sm"><i class="fa fa-trash-o"></i></button>
                        </td>
                    </tr>
                </tbody>
                <tfoot>
                    <tr class="visible-xs">
                        <td class="text-center"><strong></strong></td>
                        <!--total amount-->
                    </tr>
                    <tr>
                        <td><a href="Default.aspx" class="btn btn-warning"><i class="fa fa-angle-left"></i>Continue Shopping</a></td>
                        <td colspan="2" class="hidden-xs"></td>
                        <td class="hidden-xs text-center"><strong></strong></td>
                        <!--total amount-->
                        <td><a href="Signin.aspx" class="btn btn-success btn-block">Next <i class="fa fa-angle-right"></i></a></td>
                    </tr>
                </tfoot>
            </table>
        </div>
    </div>


</asp:Content>