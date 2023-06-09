﻿using System;
using System.Collections.Generic;
using System.Data;
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

                if (Session["login"] != null)
                {
                   
                 
                    List<Skladnik> skladniki;
                    SkladnikRepository skladnikRepo = new SkladnikRepository();
                    skladniki = skladnikRepo.GetSkladniki();
                    repeaterSkladniki.DataSource = skladniki;
                    repeaterSkladniki.DataBind();
                    


                    }
                else
                {
                    Response.Redirect("Test.aspx");
                }
              
            }

            upload.Attributes["onchange"] = "showThumbnail(this)";

        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
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
                
                checkBox.ID ="CheckBox";
                textBox.ID = "TextBox";
                label.Text = id.ToString();
            }
        }

        
        protected void ButtonZat_Click(object sender, EventArgs e)
        {
            

            Przepis p = new Przepis();
                p.Nazwa = TextBoxName.Text;
                p.Opis = TextBoxDescription.Text;
                



                Bz.Przepis.InsertOnSubmit(p);
                Bz.SubmitChanges();

                


                foreach (RepeaterItem item in repeaterSkladniki.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        CheckBox checkBox = (CheckBox)item.FindControl("CheckBox");
                        TextBox textBox = (TextBox)item.FindControl("TextBox");
                        Label label = (Label)item.FindControl("Label");

                        if (checkBox.Checked)
                        {
                            string skladnikId = label.Text.ToString();
                            string ilosc = textBox.Text;
                            int iloscInt;
                            int skladnikIdInt;

                            if (int.TryParse(skladnikId, out skladnikIdInt))
                            {

                                if (int.TryParse(ilosc, out iloscInt))
                                {
                                    PS pS = new PS();
                                    pS.Id_skladnika = skladnikIdInt;
                                    pS.Id_przepisu = p.Id;
                                    pS.Ilosc = iloscInt;
                                    Bz.PS.InsertOnSubmit(pS);

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
                    zdj.id_przepisu = p.Id;
                    zdj.zdjecie = new System.Data.Linq.Binary(imageBytes); // Konwersja na typ Binary

                    Bz.Zdjecia.InsertOnSubmit(zdj);
                    Bz.SubmitChanges();
                }

            
            Response.Redirect("Przepis.aspx?ID=" + p.Id);


        }
    }
}