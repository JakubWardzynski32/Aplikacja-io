using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplikacja_io
{
    
    public partial class Home : System.Web.UI.Page
    {
        UsersDataContext Bz = new UsersDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UsersConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            Przepis p = new Przepis();
            p.Nazwa = "BUla";
            Skladnik skladnik = new Skladnik();
            skladnik.Nazwa = "maslo";
            skladnik.Opis = "w kostce";

            PS pS = new PS();
            pS.Skladnik = skladnik;
            pS.Przepis = p;

            Bz.Przepis.InsertOnSubmit(p);
            Bz.Skladnik.InsertOnSubmit(skladnik);
            Bz.PS.InsertOnSubmit(pS);
            Bz.SubmitChanges();
            */
            if (Session["login"] != "test")
            {
                Response.Redirect("Test.aspx");
            }
            //Przepis p = new Przepis();
            foreach(Przepis pp in Bz.Przepis)
            {
                if (pp.Id == 1)
                {
                    //Label1.Text = pp.Nazwa;
                }
            }
        }
    }
}