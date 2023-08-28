<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="taks28.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Login</title>
    <link rel="stylesheet" href="style.css"/>
 
</head>

    <body>
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
                        <a href="Register.aspx">Register</a>                       
                    </div>
                    <div class="main-login-content">
                        <h4>Login</h4>
                        <form id="LoginForm" runat="server">
                            <div class="field-wrap">
                                <div class="input-wrap">
                                    <label for="username" class="form-lable">
                                        <span>Username</span>
                                        <!-- <span>
                                        <span>*</span>
                                        your email address
                                    </span> -->
                                    </label>
                                  <asp:TextBox ID="UserName" class="form-input" runat="server"></asp:TextBox>
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
                                 <asp:TextBox ID="Password" class="form-input" runat="server"></asp:TextBox>
                                </div>
                                <div class="error-msg">
                                    <span>test</span>
                                </div>
                            </div>
                             <div class="field-wrap">
                                <div class="input-wrap">
                                    <asp:Button ID ="Login_Button" Text="Login" runat="server" class="submit-btn" OnClick="Login_Button_Click"/>
                                </div>
                                <div class="error-msg">
                                    <span>test</span>
                                </div>
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

</body>
</html>
