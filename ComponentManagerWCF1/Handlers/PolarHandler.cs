using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentManagerWCF.Handlers
{
    internal class PolarHandler : AbstractHandler
    {
        const int END_POINT_PORT = 11002;
        const string COMMAND = "CM-READ";
        
        internal PolarHandler()
        {
            componentReader = new ServiceReader(END_POINT_PORT, COMMAND);
        }

        protected override IEnumerable<PersonalData> parse(string data)
        {
            /*
             * //The DATA as follow (can happen multiple times): 
            //LastName,FirstName(20 bytes)
            //Country (3 bytes)
            //Age (3 bytes)
            // & is the separator for multiple data
            return "WILLIAMS,JOHN       USA021&DOE,JOHN            USA046&SMITH,MARY          CAN038&JOHNSON,TAYLOR      CAN015";
             */
            var result = new List<PersonalData>();

            if (string.IsNullOrEmpty(data) == false &&
                data.Equals("Unrecognized") == false)
            {
                List<string> persons = new List<string>(data.Split('&'));
                persons.ForEach((person) =>
                {
                    var name = person.Substring(0, 20);
                    result.Add(new PersonalData()
                    {
                        LastName = name.Substring(0, name.IndexOf(',')),
                        FirstName = name.Substring(name.IndexOf(',') + 1).Trim(),
                        Country = person.Substring(20, 3),
                        Age = Convert.ToInt32(person.Substring(23))
                    });
                });
            }
            return result;
        }
    }
}
