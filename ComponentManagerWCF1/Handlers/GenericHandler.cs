using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentManagerWCF.Handlers
{
    internal class GenericHandler : AbstractHandler
    {
        const int END_POINT_PORT = 11001;
        const string COMMAND = "READDATA";
        
        internal GenericHandler()
        {
            componentReader = new ServiceReader(END_POINT_PORT, COMMAND);
        }

        protected override IEnumerable<PersonalData> parse(string data)
        {
            /*
            //First 4 characters indicates length of message in hex
            //Next 4 characters indicates component status
            //Next 8 characters for date
            //Next characters are the DATA as follow: 
            //FirstName/LastName/Country/Age (can happen multiple times)
            // | is the separator for multiple data
            return "0047021520160101JOHN/WILLIAMS/USA/21|JOHN/DOE/USA/46|MARY/SMITH/CAN/38|TAYLOR/JOHNSON/CAN/13";
            */
            var result = new List<PersonalData>();

            if (string.IsNullOrEmpty(data) == false &&
                data.Equals("Unrecognized") == false)
            {
                data = data.Substring(16);
                List<string> persons = new List<string>(data.Split('|'));
                persons.ForEach((person) =>
                {

                    string[] personData = person.Split('/');
                    result.Add(new PersonalData()
                    {
                        FirstName = personData[0],
                        LastName = personData[1],
                        Country = personData[2],
                        Age = Convert.ToInt32(personData[3])
                    });
                });
            }
            return result;
        }
    }
}
