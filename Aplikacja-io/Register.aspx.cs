using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplikacja_io
{
    public partial class Register : System.Web.UI.Page
    {
        UsersDataContext Bz = new UsersDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UsersConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonZat_Click(object sender, EventArgs e)
        {
            if (TextBoxImie.Text != "")
            {
                User u = new User();
                u.Imie = TextBoxImie.Text;
                u.Nazwisko = TextBoxNazwisko.Text;
                u.Haslo = TextBoxHaslo.Text;
                u.Mail = TextBoxEmail.Text;
                u.Login = TextBoxLogin.Text;
                
                Bz.Users.InsertOnSubmit(u);
                Bz.SubmitChanges();


                TextBoxImie.Text = default;
                TextBoxHaslo.Text = default;
                TextBoxEmail.Text = default;
                TextBoxLogin.Text = default;
                TextBoxNazwisko.Text = default;
                
            }
            else
            {
                
            }
            



        }


    }
}