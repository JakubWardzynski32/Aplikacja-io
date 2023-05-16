<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogReg.aspx.cs" Inherits="Aplikacja_io.Test" %>

<!DOCTYPE html>

<html lang="en">
<head>
  <title>Webleb</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <link rel="stylesheet" href="https://unicons.iconscout.com/release/v2.1.9/css/unicons.css">
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.0/css/bootstrap.min.css">
<link rel="stylesheet" href="styles.css">
</head>
<body>
	<form id="form1" runat="server">
	<div class="section">
		<div class="container">
			<div class="row full-height justify-content-center">
				<div class="col-12 text-center align-self-center py-5">
					<div class="section pb-5 pt-5 pt-sm-2 text-center">
						<h6 class="mb-0 pb-3"><span>Zaloguj </span><span>Zarejestruj</span></h6>
			          	<input class="checkbox" type="checkbox" id="reg-log" name="reg-log"/>
			          	<label for="reg-log"></label>
						<div class="card-3d-wrap mx-auto">
							<div class="card-3d-wrapper">
								<div class="card-front">
									<div class="center-wrap">
										<div class="section text-center">
											<h4 class="mb-4 pb-3">Logowanie</h4>
											<div class="form-group">
												<asp:TextBox ID="TextBoxLogin" runat="server" placeholder="Login" CssClass="form-style" ></asp:TextBox>
												
											</div>	
											<div class="form-group mt-2">
												<asp:TextBox ID="TextBoxHaslo" runat="server" placeholder="Haslo" CssClass="form-style" TextMode="Password" ></asp:TextBox>
												
											</div>
											
											<asp:Button ID="ButtonLog" runat="server" Text="Zaloguj" OnClick="ButtonLog_Click" class="btn mt-4"/>
                      
				      					</div>
			      					</div>
			      				</div>
								<div class="card-back">
									<div class="center-wrap">
										<div class="section text-center">
											<h4 class="mb-3 pb-3">Rejstracja</h4>
											<div class="form-group">
												
												<asp:TextBox ID="TextBoxRImie" runat="server" CssClass="form-style" placeholder="Imię"></asp:TextBox>
												
											</div>	
											<div class="form-group mt-2">
												
												<asp:TextBox ID="TextBoxRLogin" runat="server" CssClass="form-style" placeholder="Login"></asp:TextBox>
											</div>	
										 <div class="form-group mt-2">
												
												 <asp:TextBox ID="TextBoxREmail" runat="server" CssClass="form-style" placeholder="e-mail"></asp:TextBox>
												
											</div>
											<div class="form-group mt-2">
												
												<asp:TextBox ID="TextBoxRHaslo" runat="server" TextMode="Password" placeholder="Hasło" CssClass="form-style"></asp:TextBox>
												
											</div>
										
											<asp:Button ID="ButtonReg" runat="server" Text="Zarejestruj" OnClick="ButtonReg_Click" class="btn mt-4"/>
				      					</div>
			      					</div>
			      				</div>
			      			</div>
			      		</div>
			      	</div>
		      	</div>
	      	</div>
	    </div>
	</div>
		</form>
</body>
</html>
