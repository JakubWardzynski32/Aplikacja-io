using System;
using System.Collections.Generic;
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

            foreach (var nazwa in CheckBoxListS.Items)
            {
                foreach (Skladnik sk in Bz.Skladnik)
                {
                    if (sk.Nazwa.Equals(nazwa.ToString()))
                    {
                        PS pS = new PS();
                        pS.Skladnik = sk;
                        pS.Przepis = p;
                        Bz.PS.InsertOnSubmit(pS);
                        


                    }
                }
            }
            Bz.SubmitChanges();
            //Bz.Skladnik.InsertOnSubmit(skladnik);
            //Bz.PS.InsertOnSubmit(pS);
        }

        protected void showThumbnail(object sender, EventArgs e)
        {
            if (upload.HasFile)
            {
                byte[] fileBytes = upload.FileBytes;
                string base64String = Convert.ToBase64String(fileBytes);
                string imageSource = "data:" + upload.PostedFile.ContentType + ";base64," + base64String;
                thumbnail.ImageUrl = imageSource;
                thumbnail.Style["display"] = "block";
            }
            else
            {
                thumbnail.Style["display"] = "none";
            }
        }







    }
}