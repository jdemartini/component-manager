using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentManagerWCF.Handlers
{
    abstract class AbstractHandler
    {
        protected ServiceReader componentReader;
       
        public IEnumerable<PersonalData> ReadData()
        {
            var result = this.componentReader.RequestDataAsync().Result;
            return this.parse(result);
        }
        public async Task<IEnumerable<PersonalData>> ReadDataAsync()
        {
            var result = await this.componentReader.RequestDataAsync();
            return this.parse(result);
        }

        protected abstract IEnumerable<PersonalData> parse(string data);
        
    }
}
