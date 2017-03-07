using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ComponentManagerWCF
{
    [ServiceContract]
    public interface IComponentManager
    {
        [OperationContract]
        IEnumerable<PersonalData> ReadData();

        [OperationContract]
        Task<IEnumerable<PersonalData>> ReadData_Async();
    }

    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/ReaderComponentService")]
    public class PersonalData
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public int Age { get; set; }
    }
}
