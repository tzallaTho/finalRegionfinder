using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegionListFinder
{
    public partial class InsertOrUpdate : System.Web.UI.Page
    {
        public bool isUpdate = false;
        public string TheTitle;
        protected void Page_Load(object sender, EventArgs e)
        {
            string zipId = Request.QueryString["zipId"];
            string regionId = Request.QueryString["stateId"];
            if (String.IsNullOrEmpty(regionId)) //Insert
            {
                isUpdate = false;
                this.btnInsDeviceOk.Text = "Προσθήκη περιοχής";
            }
            else
            {
                isUpdate = true;
                this.btnInsDeviceOk.Text = "Μετατροπή Περιοχής";
            }
            if (IsPostBack)
                return;
            fillDDLStates();
            fillDDLZipCodes();
           
           if(isUpdate)
           {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connProd"].ConnectionString))
                {
                    string scmd = "dbo.GetAllRegions  " + zipId + "," 
                        + regionId;
                    using (SqlCommand command = new SqlCommand(scmd, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                            txtState.Text = reader["name"].ToString();
                        }
                    }
                }
            }


        }

        protected void btnInsDeviceOk_Click(object sender, EventArgs e)
        {
           // string pattern = @"^\b(\p{IsGreek})+[ ]?[.]?\b(\p{IsGreek})+$";
            string pattern = @"[\b(\p{IsGreek})]+[ ]?[.]?[\b(\p{IsGreek})]+$";
            string input = txtState.Text;

           
            if (!Regex.IsMatch(input, pattern))
            {
                RequiredFieldValidator1.IsValid = false;
                RequiredFieldValidator1.ErrorMessage = "ελληνικοί χαρακτήρες";
            }
            else
            {
                 RequiredFieldValidator1.IsValid = true;
            }

            return;
               // this.Label1.Text = "swsta";
            string regionId = Request.QueryString["regionId"];
            if (isUpdate) //Insert region
            {

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connProd"].ConnectionString))
                {
                    string scmd = "dbo.UpdateRegionData  " + Request.QueryString["zipId"].ToString() + ","
                        + Request.QueryString["stateId"].ToString() + "," + txtState.Text;
                    using (SqlCommand command = new SqlCommand(scmd, connection))
                    {
                        connection.Open();

                        command.ExecuteNonQuery();

                    }


                }

            }
            else   //kataxwrhsh
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connProd"].ConnectionString))
                {
                    string scmd = "[dbo].[InsertRegion]   '" + txtState.Text + "',"
                                    + ddlStates.SelectedItem.Value.ToString() + "," + ddlZips.SelectedItem.Value;
                      
                    using (SqlCommand command = new SqlCommand(scmd, connection))
                    {
                        connection.Open();
                        var ff = command.ExecuteScalar();
                        if (int.Parse(ff.ToString()) > -1)
                        {
                            this.lblResult.Visible = true;
                            this.lblResult.Text = "Επιτυχής καταχώρηση";
                            this.lblResult.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            this.lblResult.Visible = true;
                            this.lblResult.Text = "Αποτυχία καταχώρηση";
                            this.lblResult.ForeColor = System.Drawing.Color.Red;
                        }



                    }


                }
            }
        }


        public void fillDDLZipCodes()
        {
            using (System.Data.SqlClient.SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connProd"].ConnectionString))
            {

                System.Data.SqlClient.SqlCommand Command = new System.Data.SqlClient.SqlCommand();
                Command.CommandText = "[dbo].[GetZipCodes] ";
                if (ddlStates.SelectedItem!=null && int.Parse(ddlStates.SelectedItem.Value) > -1)
                {
                    Command.CommandText = "[dbo].[GetZipCodes] " + ddlStates.SelectedItem.Value.ToString();
                }
               
                Command.Connection = Connection;

                Connection.Open();
                SqlDataReader ClientNameData = Command.ExecuteReader();
                if (ClientNameData.HasRows)
                {
                    ddlZips.DataSource = ClientNameData;
                    ddlZips.DataTextField = "zip_Desc";
                    ddlZips.DataValueField = "zipId";
                    ddlZips.DataBind();

                }


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

      

        protected void ddlStates_SelectedIndexChanged1(object sender, EventArgs e)
        {
            fillDDLZipCodes();
        }
    }
}