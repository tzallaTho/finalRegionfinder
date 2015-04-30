using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RegionFinder
{
   public class Service1 : IService1
    {
    public List<StateClass> GetRegionStates(string stateDesc)
        {
            List<StateClass> mystates = new List<StateClass>();
           // StateClass test = new StateClass();
          //  test.StateDescription = "Zefiri leme";
          //  mystates.Add(test);
           
         using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connProd"].ConnectionString))
            {
                string scmd = "[dbo].[GetRegionStatesForService]  " + stateDesc;
                using (SqlCommand command = new SqlCommand(scmd, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        StateClass test = new StateClass();
                        test.StateDescription = reader["state"].ToString();
                         test.ZipCodeDescription = reader["zip"].ToString();
                        mystates.Add(test);

                       
                    }
                }
            }
            return mystates;

        }
    }
}
