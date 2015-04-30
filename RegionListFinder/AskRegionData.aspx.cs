using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegionListFinder
{
    public partial class AskRegionData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        
        }

        protected void btnFind_Click(object sender, EventArgs e)
        {
           RegionServiceReference.Service1Client ss = new RegionServiceReference.Service1Client();

           RegionServiceReference.StateClass[] ff= ss.GetRegionStates(this.txtState.Text);

           
              

            
        }

    }
}