using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplikacja_io
{
    public partial class RecipeEdit : System.Web.UI.Page
    {
        UsersDataContext Bz = new UsersDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UsersConnectionString"].ConnectionString);
        private Przepis p = new Przepis();
        private List<Skladnik> skladniki = new List<Skladnik>();
        private List<Zdjecia> zdjecia = new List<Zdjecia>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    int przepisID = Convert.ToInt32(Request.QueryString["ID"]);
                    GetPrzepis(przepisID);

                    Page.Title = "Edycja" + p.Nazwa;

                    TextBoxName.Text = p.Nazwa;
                    TextBoxDescription.Text = p.Opis;

                    foreach (Skladnik sk in Bz.Skladnik)
                    {
                        ListItem item = new ListItem(sk.Nazwa, sk.Id.ToString());
                        CheckBoxListS.Items.Add(item);

                        foreach (Skladnik skk in skladniki)
                        {
                            if (skk.Id == sk.Id)
                            {
                                item.Selected = true;
                            }
                        }
                    }
                }
                else
                {
                    Response.Redirect("Home.aspx");
                }
            }
        }

        protected void GetPrzepis(int id)
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

        protected void ButtonZat_Click(object sender, EventArgs e)
        {
            int przepisID = Convert.ToInt32(Request.QueryString["ID"]);
            Przepis ExistingPrzepis = Bz.Przepis.FirstOrDefault(pr => pr.Id == przepisID);

            if (ExistingPrzepis != null)
            {
                ExistingPrzepis.Nazwa = TextBoxName.Text;
                ExistingPrzepis.Opis = TextBoxDescription.Text;

                foreach (ListItem item in CheckBoxListS.Items)
                {
                    int skladnikId = Convert.ToInt32(item.Value);
                    Skladnik skladnik = Bz.Skladnik.FirstOrDefault(s => s.Id == skladnikId);

                    bool isChecked = item.Selected;
                    bool isAssociated = Bz.PS.Any(ps => ps.Id_przepisu == przepisID && ps.Id_skladnika == skladnikId);

                    if (isChecked && !isAssociated)
                    {
                        bool psExists = Bz.PS.Any(ps => ps.Przepis.Id == przepisID && ps.Skladnik.Id == skladnikId);

                        if (!psExists)
                        {
                            PS nowy = new PS();
                            nowy.Przepis = ExistingPrzepis;
                            nowy.Skladnik = skladnik;
                            Bz.PS.InsertOnSubmit(nowy);
                        }
                    }
                    else if (!isChecked && isAssociated)
                    {
                        PS DoUsuniecia = Bz.PS.FirstOrDefault(ps => ps.Id_przepisu == przepisID && ps.Id_skladnika == skladnikId);
                        if (DoUsuniecia != null)
                        {
                            Bz.PS.DeleteOnSubmit(DoUsuniecia);
                        }
                    }
                }

                if (upload.HasFile)
                {
                    byte[] imageBytes;

                    using (BinaryReader reader = new BinaryReader(upload.PostedFile.InputStream))
                    {
                        imageBytes = reader.ReadBytes(upload.PostedFile.ContentLength);
                    }

                    Zdjecia zdj = new Zdjecia();
                    zdj.Przepis = ExistingPrzepis;
                    zdj.zdjecie = new System.Data.Linq.Binary(imageBytes); // Konwersja na typ Binary

                    Bz.Zdjecia.InsertOnSubmit(zdj);
                }

                Bz.SubmitChanges();
                Response.Redirect("Przepis.aspx?ID=" + ExistingPrzepis.Id);
            }
        }
    }
}