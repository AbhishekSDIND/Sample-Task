<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="taks28.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Registration</title>
    <link rel="stylesheet" href="style.css"/>
</head>
<body>
    <%--<form id="Register" runat="server">--%>

    <div class="login-wrapper">
        <header class="header-wrap">
            <div class="container">
                <img class="logo" src="img/SystemsInteractive.png" alt="logo"/>
            </div>
        </header>
        <main class="main-wrap">
            <div class="container">
                <div class="content">
                    <div class="reg">
                        <a href="Login.aspx">Login</a>
                     
                    </div>
                    <div class="main-login-content">
                        <h4>Registration</h4>
                        <form id="Register" runat="server">
                            <div class="field-wrap">
                                <div class="input-wrap">
                                    <label for="firstname" class="form-lable">
                                        <span>First Name</span>
                                        <!-- <span>
                                            <span>*</span>
                                            your email address
                                        </span> -->
                                    </label>
                                     <asp:TextBox ID="UserId" runat="server" Visible="false" class="form-input"></asp:TextBox>
                                     <asp:TextBox ID="FirstName" runat="server"  class="form-input"></asp:TextBox>
                                </div>
                                <div class="error-msg">
                                    <span>test</span>
                                </div>
                            </div>

                            <div class="field-wrap">
                                <div class="input-wrap">
                                    <label for="lastname" class="form-lable">
                                        <span>Last Name</span>
                                        <!-- <span>
                                        <span>*</span>
                                        your email address
                                    </span> -->
                                    </label>
                                    <asp:TextBox ID="LastName" runat="server" class="form-input"></asp:TextBox>
                                </div>
                                <div class="error-msg">
                                    <span>test</span>
                                </div>
                            </div>
                            <div class="field-wrap">
                                <div class="input-wrap">
                                    <label for="username" class="form-lable">
                                        <span>Username</span>
                                        <!-- <span>
                                        <span>*</span>
                                        your email address
                                    </span> -->
                                    </label>
                                    <asp:TextBox ID="UserName" runat="server" class="form-input"></asp:TextBox>
                                </div>
                                <div class="error-msg">
                                    <span>test</span>
                                </div>
                            </div>
                            <div class="field-wrap">
                                <div class="input-wrap">
                                    <label for="password" class="form-lable">
                                        <span>Password</span>
                                        <!-- <span>
                                        <span>*</span>
                                        your email address
                                    </span> -->
                                    </label>
                                     <asp:TextBox ID="Password" runat="server" TextMode="Password" class="form-input"></asp:TextBox>
                                    <%--<input class="form-input" type="password" name="" id="password">--%>
                                </div>
                                <div class="error-msg">
                                   
                                </div>
                            </div>

                             <div class="field-wrap">
                                <div class="input-wrap">
                                    <label for="UserType" class="form-lable">
                                        <span>User Type</span>
                                        <!-- <span>
                                        <span>*</span>
                                        your email address
                                    </span> -->
                                    </label>
                                   <asp:DropDownList ID="UserType" runat="server">
                                     <asp:ListItem Value="0">-- Select User Type--</asp:ListItem>
                                     <asp:ListItem Value="1">Admin</asp:ListItem>
                                     <asp:ListItem Value="2">Manager</asp:ListItem>
                                     <asp:ListItem Value="3">Users</asp:ListItem>
                                        </asp:DropDownList>
                                </div>
                                <div class="error-msg">
                                    <span>test</span>
                                </div>
                            </div>
                           
                            <div class="btn-wrap">
                                <asp:Button ID ="Submit" Text="Submit" runat="server" OnClick="Submit_Click" class="submit-btn"/>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </main>
        <footer>
            <div class="container">
                <span>© Systems Interactive Inc. 2011</span>
            </div>
        </footer>
    </div>



    <%--</form>--%>
</body>
</html>