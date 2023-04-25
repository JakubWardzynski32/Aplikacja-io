using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplikacja_io
{
    public partial class Test : System.Web.UI.Page
    {
        UsersDataContext Bz = new UsersDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UsersConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLog_Click(object sender, EventArgs e)
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
        protected void ButtonReg_Click(object sender, EventArgs e)
        {
            if (TextBoxRImie.Text != "")
            {
                User u = new User();
                u.Imie = TextBoxRImie.Text;
                //u.Nazwisko = TextBoxNazwisko.Text;
                u.Haslo = TextBoxRHaslo.Text;
                u.Mail = TextBoxREmail.Text;
                u.Login = TextBoxRLogin.Text;
                u.Nazwisko = "kowal";
                Bz.Users.InsertOnSubmit(u);
                Bz.SubmitChanges();


                TextBoxRImie.Text = default;
                TextBoxRHaslo.Text = default;
                TextBoxREmail.Text = default;
                TextBoxRLogin.Text = default;
                //TextBoxNazwisko.Text = default;

            }
            else
            {

            }




        }
    }
}