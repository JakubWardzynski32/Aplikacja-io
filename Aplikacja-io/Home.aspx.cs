using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplikacja_io
{
    
    public partial class Home : System.Web.UI.Page
    {

       UsersDataContext Bz = new UsersDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UsersConnectionString"].ConnectionString);

        public string searchQuery;


        public class PrzepisRepository
        {
            UsersDataContext Bz = new UsersDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UsersConnectionString"].ConnectionString);
            public List<Przepis> GetPrzepisy()
            {
               return Bz.Przepis.ToList();
            }

            public List<Przepis> GetPrzepisyByQuery(string searchQuery)
            {
                return Bz.Przepis.Where(p => p.Nazwa.Contains(searchQuery)).ToList();
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {

            //if (Session["login"] != "test")
            // {
            //    Response.Redirect("Test.aspx");
            // }
            //Przepis p = new Przepis();

           
            }

        protected void ButtonSzukaj_Click(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
                PrzepisRepository przepisRepo = new PrzepisRepository();

                searchQuery = TextBoxPrzepis.Text; // Pobierz wartość zapytania wyszukiwania

                List<Przepis> przepisy;

                if (!string.IsNullOrEmpty(searchQuery))
                {
                    // Jeśli jest zapytanie wyszukiwania, pobierz przepisy pasujące do wyszukiwanego ciągu
                    przepisy = przepisRepo.GetPrzepisyByQuery(searchQuery);
                }
                else
                {
                    // W przeciwnym razie pobierz wszystkie przepisy
                    przepisy = przepisRepo.GetPrzepisy();
                }

                repeaterPrzepisy.DataSource = przepisy;
                repeaterPrzepisy.DataBind();
            //}
    }
    }
}