using ComponentManagerWCF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ReaderComponentService
{
    partial class Service1 : ServiceBase
    {
        internal static ServiceHost myServiceHost = null;

        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Starting WCF...");
                new Service1();
                Console.WriteLine("WCF is running...");
            }
            catch (Exception e)
            {
                Console.WriteLine("-------ERROR--------");
                Console.WriteLine(e.Message);
                Console.WriteLine("--------------------\n");
            }
            
        }

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (myServiceHost != null)
            {
                myServiceHost.Close();
            }
            myServiceHost = new ServiceHost(typeof(ComponentManager));
            myServiceHost.Open();
        }

        protected override void OnStop()
        {
            if (myServiceHost != null && myServiceHost.State == CommunicationState.Opened)
            {
                myServiceHost.Close();
                myServiceHost = null;
            }
        }
    }
}
