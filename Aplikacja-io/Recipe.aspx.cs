using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Aplikacja_io
{

    public partial class Register : System.Web.UI.Page
    {
        UsersDataContext Bz = new UsersDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UsersConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            //Przepis ps = new Przepis();
            //Skladnik sk = new Skladnik();

            if (!IsPostBack)
            {
                foreach (Skladnik skk in Bz.Skladnik)
                {

                    CheckBoxListS.Items.Add(skk.Nazwa);

                }
              
            }

            upload.Attributes["onchange"] = "showThumbnail(this)";

        }

        protected void ButtonZat_Click(object sender, EventArgs e)
        {

            Przepis p = new Przepis();
            p.Nazwa = TextBoxName.Text;
            p.Opis = TextBoxDescription.Text;
            //Skladnik skladnik = new Skladnik();
            //skladnik.Nazwa = "maslo";
            //skladnik.Opis = "w kostce";



            Bz.Przepis.InsertOnSubmit(p);
            //Bz.SubmitChanges();

            foreach (ListItem nazwa in CheckBoxListS.Items)
            {
                foreach (Skladnik sk in Bz.Skladnik)
                {
                    if (sk.Nazwa.Equals(nazwa.Text)&& nazwa.Selected)
                    {
                        PS pS = new PS();
                        pS.Skladnik = sk;
                        pS.Przepis = p;
                        Bz.PS.InsertOnSubmit(pS);
                    }
                }
            }
            Bz.SubmitChanges();



            if (upload.HasFile)
            {
                byte[] imageBytes;

                using (BinaryReader reader = new BinaryReader(upload.PostedFile.InputStream))
                {
                    imageBytes = reader.ReadBytes(upload.PostedFile.ContentLength);
                }

                Zdjecia zdj = new Zdjecia();
                zdj.id_przepisu = p.Id;
                zdj.zdjecie = new System.Data.Linq.Binary(imageBytes); // Konwersja na typ Binary

                Bz.Zdjecia.InsertOnSubmit(zdj);
                Bz.SubmitChanges();
            }

            //Bz.Skladnik.InsertOnSubmit(skladnik);
            //Bz.PS.InsertOnSubmit(pS);
        }
    }
}