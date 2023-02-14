using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Security.Principal;
using com.jbase.jremote;
using static System.Net.Mime.MediaTypeNames;

namespace UOJ_Example_WebProject_2023
{
    public class jrcsUniware
    {
        private string _connectionUser = "webrpc";
        private string _connectionPass = "@Uniware123!";
        private IPAddress _connectionHost = IPAddress.Parse("192.168.54.37");
        //private int _connectionPort = int.Parse("8236");
        private int _connectionPort = int.Parse("20022");
        private string _connectionDataBase = "DEVAPI";
        private JConnection? _session;

        public jrcsUniware()
        {
            pSession = Connect();
        }


        public JConnection? pSession
        {
            get => _session;
            set { _session = value; }
        }

        public JConnection Connect() 
        {
            // Get ...
            try
            {
                // Call the Open Session function with our predefined connection variables.
                _session = connectToServer(_connectionHost.ToString(), _connectionPort);
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




        private JConnection connectToServer(string ServerHost, int ServerPort)
        {
            DefaultJConnectionFactory myDefaultConnectionFactory = new DefaultJConnectionFactory();
            JConnection? myConnection = null;
            myDefaultConnectionFactory.Host = ServerHost;
            myDefaultConnectionFactory.Port = ServerPort;
            Console.WriteLine("Attempting connection to " + ServerHost + " on port " + ServerPort.ToString());
            try
            {
                myConnection = myDefaultConnectionFactory.getConnection();
                Console.WriteLine("Connected.");
            }
            catch (System.Net.Sockets.SocketException Sx)
            {
                Console.WriteLine(Sx.Message.ToString());
                Console.WriteLine("We got an error.");
                Console.WriteLine("Failed to connect.");
            }
            return myConnection;
        }

    }
}
