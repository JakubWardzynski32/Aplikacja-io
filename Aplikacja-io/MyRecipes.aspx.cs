﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplikacja_io
{
    public partial class MyRecipes : System.Web.UI.Page
    {
        UsersDataContext Bz = new UsersDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UsersConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != "Test")
            {
                Response.Redirect("LogReg.aspx");
            }
            foreach (Przepis pp in Bz.Przepis)
            {
                DropDownListRecipes.Items.Add(pp.Nazwa);
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            
        }


    }
}