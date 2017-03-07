using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentManagerWCF.Handlers
{
    class FactoryHandler
    {
        public AbstractHandler GetHandler()
        {
            AbstractHandler result = null;
            string handler = ConfigurationManager.AppSettings.Get("handler");
            switch (handler.ToLower())
            {
                case "polar":
                    result = new PolarHandler();
                    break;
                case "generic":
                    result = new GenericHandler();
                    break;
                default:
                    result = null;
                    break;
            }
            return result;

        }
    }
}
