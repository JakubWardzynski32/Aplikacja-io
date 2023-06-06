using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplikacja_io
{
    public partial class Przepis1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    int przepisID = Convert.ToInt32(Request.QueryString["ID"]);
                    Przepis p = GetPrzepis(przepisID);

                    if (p != null)
                    {
                        LiteralNazwa.Text = p.Nazwa;
                        LiteralOpis.Text = p.Opis;

                        List<SkladnikInfo> skladnikiInfo = GetSkladniki(przepisID);
                        RepeaterSkladniki.DataSource = skladnikiInfo;
                        RepeaterSkladniki.DataBind();

                        List<Zdjecia> zdjecia = GetZdjecia(przepisID);
                        RepeaterZdjecia.DataSource = zdjecia;
                        RepeaterZdjecia.DataBind();
                    }
                }
                else
                {
                    Response.Redirect("Home.aspx");
                }
            }
        }

        protected Przepis GetPrzepis(int id)
        {
            using (UsersDataContext Bz = new UsersDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UsersConnectionString"].ConnectionString))
            {
                return Bz.Przepis.FirstOrDefault(p => p.Id == id);
            }
        }

        protected List<SkladnikInfo> GetSkladniki(int przepisID)
        {
            List<SkladnikInfo> skladnikiInfo = new List<SkladnikInfo>();

            using (UsersDataContext Bz = new UsersDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UsersConnectionString"].ConnectionString))
            {
                var psList = Bz.PS.Where(ps => ps.Id_przepisu == przepisID);

                foreach (var ps in psList)
                {
                    SkladnikInfo skladnikInfo = new SkladnikInfo();
                    skladnikInfo.Nazwa = ps.Skladnik.Nazwa;
                    skladnikInfo.Ilosc = ps.Ilosc;
                    skladnikInfo.Opis = ps.Skladnik.Opis; 
                    skladnikiInfo.Add(skladnikInfo);
                }
            }

            return skladnikiInfo;
        }

        protected List<Zdjecia> GetZdjecia(int przepisID)
        {
            using (UsersDataContext Bz = new UsersDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UsersConnectionString"].ConnectionString))
            {
                return Bz.Zdjecia.Where(z => z.id_przepisu == przepisID).ToList();
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

    public class SkladnikInfo
    {
        public string Nazwa { get; set; }
        public int Ilosc { get; set; }
        public string Opis { get; set; }
    }
}
