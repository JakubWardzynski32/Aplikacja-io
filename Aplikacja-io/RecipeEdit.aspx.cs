using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Aplikacja_io.Register;

namespace Aplikacja_io
{
    public partial class RecipeEdit : System.Web.UI.Page
    {
        UsersDataContext Bz = new UsersDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UsersConnectionString"].ConnectionString);
        private Przepis p = new Przepis();
        private List<Skladnik> skladniki = new List<Skladnik>();
        private List<Zdjecia> zdjecia = new List<Zdjecia>();

        public class SkladnikRepository
        {
            UsersDataContext Bz = new UsersDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UsersConnectionString"].ConnectionString);
            public List<Skladnik> GetSkladniki()
            {
                return Bz.Skladnik.ToList();
            }
        }

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


                    List<Skladnik> skladnikiwypis;
                    SkladnikRepository skladnikRepo = new SkladnikRepository();
                    skladnikiwypis = skladnikRepo.GetSkladniki();
                    repeaterSkladniki.DataSource = skladnikiwypis;
                    repeaterSkladniki.DataBind();

                }
                else
                {
                    Response.Redirect("Home.aspx");
                }
            }
        }

        protected void repeaterSkladniki_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                CheckBox checkBox = (CheckBox)e.Item.FindControl("CheckBox");
                TextBox textBox = (TextBox)e.Item.FindControl("TextBox");
                Label label = (Label)e.Item.FindControl("Label");

                Skladnik skladnik = (Skladnik)e.Item.DataItem;
                string nazwa = skladnik.Nazwa;
                int id = skladnik.Id;

                checkBox.ID = "CheckBox";
                textBox.ID = "TextBox";
                label.Text = id.ToString();
                foreach(Skladnik s in skladniki)
                {
                    if(s.Id == id)
                    {
                        checkBox.Checked = true;
                    }
                }
                foreach(PS ps in Bz.PS)
                {
                    if(ps.Id_skladnika == id && ps.Id_przepisu == p.Id)
                    {
                        textBox.Text = ps.Ilosc.ToString();
                    }
                }
                
            }
        }
        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            int przepisID = Convert.ToInt32(Request.QueryString["ID"]);
            Przepis ExistingPrzepis = Bz.Przepis.FirstOrDefault(pr => pr.Id == przepisID);

            Response.Redirect("Przepis.aspx?ID=" + ExistingPrzepis.Id);
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


                foreach (RepeaterItem item in repeaterSkladniki.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        CheckBox checkBox = (CheckBox)item.FindControl("CheckBox");
                        TextBox textBox = (TextBox)item.FindControl("TextBox");
                        Label label = (Label)item.FindControl("Label");

                        string skladnikId = label.Text.ToString();
                        string ilosc = textBox.Text;
                        int iloscInt;
                        int skladnikIdInt;

                        bool isChecked = checkBox.Checked;

                        if (checkBox.Checked)
                        {
                            
                            if (int.TryParse(skladnikId, out skladnikIdInt))
                            {
                                bool isAssociated = Bz.PS.Any(ps => ps.Id_przepisu == p.Id && ps.Id_skladnika == skladnikIdInt);
                                if (int.TryParse(ilosc, out iloscInt) && !isAssociated)
                                {

                                    Skladnik skladnik = Bz.Skladnik.FirstOrDefault(sk => sk.Id == skladnikIdInt);
                                    PS pS = new PS();
                                    pS.Skladnik= skladnik;
                                    pS.Przepis = ExistingPrzepis;
                                    pS.Ilosc = iloscInt;
                                    Bz.PS.InsertOnSubmit(pS);

                                }

                            }
                        }
                        else
                        {
                            if(int.TryParse(skladnikId, out skladnikIdInt))
                            {
                                bool isAssociated = Bz.PS.Any(ps => ps.Id_przepisu == p.Id && ps.Id_skladnika == skladnikIdInt);
                                if(int.TryParse(ilosc, out iloscInt) && isAssociated)
                                {
                                    PS doUsuniecia = new PS();
                                    doUsuniecia = Bz.PS.FirstOrDefault(pu => pu.Id_przepisu == p.Id && pu.Id_skladnika == skladnikIdInt);

                                    if (doUsuniecia != null)
                                    {
                                        Bz.PS.DeleteOnSubmit(doUsuniecia);
                                    }
                                }
                            }
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