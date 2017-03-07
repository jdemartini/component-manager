using ComponentManagerWCF.Handlers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ComponentManagerWCF
{
    public class ComponentManager : IComponentManager
    {
        private AbstractHandler serviceReader;

        public ComponentManager()
        {
            this.serviceReader = new FactoryHandler().GetHandler();
        }

        public IEnumerable<PersonalData> ReadData()
        {
            return this.serviceReader.ReadData();
        }

        public async Task<IEnumerable<PersonalData>> ReadData_Async()
        {
            return await this.serviceReader.ReadDataAsync();
        }

    }
}
