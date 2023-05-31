using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplikacja_io
{
    public partial class Przepis1 : System.Web.UI.Page
    {
        UsersDataContext Bz = new UsersDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UsersConnectionString"].ConnectionString);
        private Przepis p = new Przepis();
        private int ilosc;
        private List<Skladnik> skladniki = new List<Skladnik>();
        private List<Zdjecia> zdjecia = new List<Zdjecia>();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    //pobranie id z adresu wyszukiwania, znalezienie przepisu o podanym id i zmiana tytułu strony na nazwę przepisu
                    int przepisID = Convert.ToInt32(Request.QueryString["ID"]);
                    getPrzepis(przepisID);
                    Page.Title = p.Nazwa;

                    if (p != null)
                    {
                        // Przypisz wartości do odpowiednich Literali
                        LiteralNazwa.Text = p.Nazwa;
                        LiteralOpis.Text = p.Opis;
                        //LiteralIlosc.Text = ilosc.ToString();

                        RepeaterSkladniki.DataSource = skladniki;
                        RepeaterSkladniki.DataBind();


                        RepeaterZdjecia.DataSource = zdjecia;
                        RepeaterZdjecia.DataBind();

                    }

                    // Pobierz informacje o przepisie na podstawie przepisID z bazy danych
                    // i wyświetl je na stronie
                    // ...

                }
                else
                {
                    Response.Redirect("Home.aspx");
                }
            }
        }
        protected void getPrzepis(int id)
        {
            foreach (Przepis ps in Bz.Przepis)
            {
                if (ps.Id == id)
                {
                    p = ps;
                    break;
                }
            }

            foreach (PS i in Bz.PS)
            {
                if (i.Id_przepisu == id)
                {
                    ilosc = i.Ilosc;

                    foreach (Skladnik sk in Bz.Skladnik)
                    {
                        if (i.Id_skladnika == sk.Id)
                        {
                            skladniki.Add(sk);
                        }
                    }
                }
            }

            foreach (Zdjecia z in Bz.Zdjecia)
            {
                if (z.id_przepisu == id)
                {
                    zdjecia.Add(z);
                }
            }
        }

        protected string GetImageUrl(object image)
        {
            System.Data.Linq.Binary imageData = (System.Data.Linq.Binary)image;
            byte[] imageBytes = imageData.ToArray();
            string base64String = Convert.ToBase64String(imageBytes);
            string imageUrl = "data:image/jpeg;base64," + base64String;
            return imageUrl;
        }

        protected void ButtonEditClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["ID"]);
            Response.Redirect("RecipeEdit.aspx?ID=" + id);
        }

    }
}