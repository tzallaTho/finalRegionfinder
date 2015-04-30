using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RegionFinder
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<StateClass> GetRegionStates(string stateDesc);

     }


    [DataContract]
    public class StateClass
    {
        bool boolValue = true;
        string _stateDesc = "ellada ";
        string _zipCode = "2222 ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string  ZipCodeDescription
        {
            get { return _zipCode; }
            set { _zipCode = value; }
        }

        [DataMember]
        public string StateDescription
        {
            get { return _stateDesc; }
            set { _stateDesc = value; }
        }
    }
}
