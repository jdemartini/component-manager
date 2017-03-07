using ReadDataApplication.ComponentManager;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ReadDataApplication.Proxies
{
    public class ComponentManagerClient : ClientBase<IComponentManager>, IComponentManager
    {
        public IEnumerable<PersonalData> ReadData()
        {
            return Channel.ReadData();
        }

        public Task<PersonalData[]> ReadDataAsync()
        {
            return Channel.ReadData_Async();
        }

        public PersonalData[] ReadData_()
        {
            return Channel.ReadData();
        }

        public async Task<IEnumerable<PersonalData>> ReadData_Async()
        {
            return await Channel.ReadData_Async();
        }

        PersonalData[] IComponentManager.ReadData()
        {
            return Channel.ReadData();
        }

        Task<PersonalData[]> IComponentManager.ReadData_Async()
        {
            return Channel.ReadData_Async();
        }
    }
/*
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
    }*/
}
