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
    public partial class ZipCodes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

             fillDDLStates();
            fillzipDataGrid(-1);


              
        }


       
        public void fillzipDataGrid(int stateId)
        {
            GridViewZips.DataSource = null;
            SqlDataAdapter da;

            DataSet ds = new DataSet();
             using (System.Data.SqlClient.SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connProd"].ConnectionString))
            {
                System.Data.SqlClient.SqlCommand Command = new System.Data.SqlClient.SqlCommand();
                if (txtState.Text != "")
                    Command.CommandText = "dbo.[GetZipCodes] " + stateId.ToString() + ",'" + txtState.Text.ToString() +"'";
                else
                    Command.CommandText = "dbo.[GetZipCodes] " + stateId.ToString();
                Command.Connection = Connection;
                da = new SqlDataAdapter(Command);
                da.Fill(ds);
                Connection.Open();
                Command.ExecuteNonQuery();
                GridViewZips.DataSource = ds;
                GridViewZips.DataBind();
       
            }
        }

       
        public void fillDDLStates()
        {
            using (System.Data.SqlClient.SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connProd"].ConnectionString))
            {

                System.Data.SqlClient.SqlCommand Command = new System.Data.SqlClient.SqlCommand();
                Command.CommandText = "dbo.GetAllStates";
                Command.Connection = Connection;

                Connection.Open();
                SqlDataReader ClientNameData = Command.ExecuteReader();
                if (ClientNameData.HasRows)
                {
                    ddlStates.DataSource = ClientNameData;
                    ddlStates.DataTextField = "descr";
                    ddlStates.DataValueField = "stateID";
                    ddlStates.DataBind();

                 }


            }
        }

        protected void myListDropDown_Change(object sender, EventArgs e)
        {
            if (this.txtState.Text != "")
            {
                this.txtState.BorderColor = System.Drawing.Color.Red;
            }
            else
            {
                this.txtState.BorderColor = System.Drawing.Color.Black;
            }
            fillzipDataGrid(int.Parse(ddlStates.SelectedItem.Value));
        }

        protected void addZip_Click(object sender, EventArgs e)
        {
           // SqlDataAdapter da;

          //  DataSet ds = new DataSet();
             using (System.Data.SqlClient.SqlConnection Connection = 
                new SqlConnection(ConfigurationManager.ConnectionStrings["connProd"].ConnectionString))
            {
                System.Data.SqlClient.SqlCommand Command = new System.Data.SqlClient.SqlCommand();
                Command.CommandText = "[dbo].[InsertZip] " + txtZip.Text + ","+ ddlStates.SelectedItem.Value;
                Command.Connection = Connection;
              //  da = new SqlDataAdapter(Command);
              //  da.Fill(ds);
                Connection.Open();
                if (int.Parse(Command.ExecuteScalar().ToString()) == -1)
                {
                    regexpName.IsValid = false;
                }

                


            }
        }

        protected void btnSearchZip_Click(object sender, EventArgs e)
        {
            fillzipDataGrid(-1);
           
        }

       

      
      
    }
}