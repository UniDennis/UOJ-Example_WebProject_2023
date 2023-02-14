using IBMU2.UODOTNET;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Security.Principal;

namespace UOJ_Example_WebProject_2023
{
    public class UOJUniware
    {
        private string _connectionUser = "webrpc";
        private string _connectionPass = "@Uniware123!";
        private IPAddress _connectionHost = IPAddress.Parse("192.168.54.37");
        private int _connectionPort = int.Parse("31438");
        private string _connectionDataBase = "/unidata/development/TESTW1";
        private UniSession? _session;


        public UOJUniware()
        {
            pSession = Connect();
        }


        public UniSession? pSession
        {
            get => _session;
            set { _session = value; }
        }

        public UniSession Connect() 
        {
            // Get ...
            try
            {
                // Call the Open Session function with our predefined connection variables.
                _session = UniObjects.OpenSession(_connectionHost.ToString(), 31438, _connectionUser, _connectionPass, _connectionDataBase, "udcs");
                return _session;
            }catch(Exception ex)
            {
                // Add some proper logging.
                Console.WriteLine(ex.ToString());
            }
            return null;
        }
        public void Disconnect() { }
        public bool IsConnected() { return true; }






    }
}
