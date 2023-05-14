using System;
using System.Collections.Generic;
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
            Przepis ps = new Przepis();
            Skladnik sk = new Skladnik();

           foreach( Skladnik skk in Bz.Skladnik)
            {
                CheckBoxListS.Items.Add(skk.Nazwa);
            }



        }

        protected void ButtonZat_Click(object sender, EventArgs e)
        {
            
            



        }


    }
}