using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegionListFinder
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }

        public void BindData()
        {
            SqlDataAdapter da;

            DataSet ds = new DataSet();
            string gg = ConfigurationManager.ConnectionStrings["connProd"].ConnectionString;
            using (System.Data.SqlClient.SqlConnection Connection = new SqlConnection("Data Source=127.0.0.1,1030;Initial Catalog=SpeedexDB;User=sa;Password=123456;persist security info=false"))
            {
                System.Data.SqlClient.SqlCommand Command = new System.Data.SqlClient.SqlCommand();
                Command.CommandText = "dbo.GetAllRegions";
                 Command.Connection = Connection;
                   da = new SqlDataAdapter(Command);
                  da.Fill(ds);
                 Connection.Open();
                 Command.ExecuteNonQuery();
                 GridViewBasic.DataSource = ds;
                 GridViewBasic.DataBind();


            }
        }

        protected void GridViewBasic_ItemCommand(object source, DataGridCommandEventArgs e)
        {
           // DataRow dr = Cart.NewRow();

            // e.Item is the table row where the command is raised.
            // For bound columns, the value is stored in the Text property of a TableCell.
            int zipId =int.Parse(e.Item.Cells[2].Text);
             int stateId =int.Parse(e.Item.Cells[3].Text);

            Response.Redirect("~/InsertOrUpdate.aspx?ZipId="+zipId+"&stateId="+stateId+" ");
           
            
             //   .Cells["zipId"];
            //TableCell priceCell = e.Item.Cells[1];
           // string item = itemCell.Text;
           // string price = priceCell.Text;

        }
    }
}