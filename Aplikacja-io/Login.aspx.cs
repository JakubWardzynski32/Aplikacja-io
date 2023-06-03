using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplikacja_io
{
    public partial class Login : System.Web.UI.Page
    {
        UsersDataContext Bz = new UsersDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UsersConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

            


        }
        protected void ButtonZal_Click(object sender, EventArgs e)
        {
            User u = new User();
            foreach (User uu in Bz.Users)
            {
                if (TextBoxLogin.Text == uu.Login && TextBoxHaslo.Text == uu.Haslo)
                {
                    //Label.Text = "Witaj ";
                    //Label.Text +=  uu.imie;
                    TextBoxLogin.Text = "";
                    TextBoxLogin.BackColor = default;
                    TextBoxHaslo.BackColor = default;
                    Session.Add("login", "test");

                    Response.Redirect("Home.aspx");
                }
                else
                {
                    //TextBoxLogin.BackColor = Color.LightPink;
                    //TextBoxHaslo.BackColor = Color.LightPink;
                    //Label.Text = "Błędne Hasło lub Login";
                }

            }

            TextBoxHaslo.Text = "";
        }

    }
}