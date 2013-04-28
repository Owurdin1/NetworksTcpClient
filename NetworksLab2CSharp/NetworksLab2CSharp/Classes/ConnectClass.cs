using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Text.RegularExpressions;

namespace NetworksLab2CSharp
{
    class ConnectClass
    {
        /// <summary>
        /// Default Constructor for ConnectClass
        /// </summary>
        public ConnectClass()
        {
        }

        /// <summary>
        /// Creates a socket and connects to server
        /// then spawns threads and sends them to
        /// receiver and sender classes.
        /// </summary>
        public string ConnectToServer()
        {
            // Declare variables
            /*
             * The internal name of the server is 
             * “Coco” and is located at the private 
             * IP address of 192.168.101.210, 
             * and you are to use service port 2605
             */
            Socket sock = new Socket(SocketType.Stream, ProtocolType.IPv4);
            IPAddress ipAddr = new IPAddress(192168101210);
            try
            {
                sock.Connect(ipAddr, 2605);
            }
            catch (ArgumentNullException ane)
            {
                return ane.Message;
            }

            return "Ran through ConnectToServer function";
        }

        /// <summary>
        /// Test function to ensure class has ability to be accessed
        /// </summary>
        /// <returns>
        /// string to confirm function has run.
        /// </returns>
        public string ConnectCreated()
        {
            string positive = "We have created a ConnectClass!";
            return positive;
        }

        /// <summary>
        /// Creates sockets and begins connection process
        /// </summary>
        public void CreateSockets()
        {

        }

        /// <summary>
        /// Begins building connection to server
        /// </summary>
        /// <param name="inputSock">
        /// Takes a socket that will be 
        /// used to read/write to from server
        /// </param>
        private void BeginConnection(Socket inputSock)
        {

        }
    }

    class ReceiverClass
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ReceiverClass()
        {
        }

        /// <summary>
        /// Test function to ensure class has been created.
        /// </summary>
        /// <returns>
        /// String confirming class was created!
        /// </returns>
        public string ReceiverCreated()
        {
            string positive = "We've created a ReceiverClass!";
            return positive;
        }
    }

    class SenderClass
    {
        /// <summary>
        /// Default constructor for SenderClass
        /// </summary>
        public SenderClass()
        {
        }

        /// <summary>
        /// Test function to ensure that class has been created.
        /// </summary>
        /// <returns>
        /// String confirming function can be called!
        /// </returns>
        public string SenderCreated()
        {
            string positive = "We've created a SenderClass!";
            return positive;
        }
    }

    class LogBuilder
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public LogBuilder()
        {
        }

        /// <summary>
        /// Test function to ensure that class and members can be accessed
        /// </summary>
        /// <returns>
        /// returns a string that helps confirm that function is accessible.
        /// </returns>
        public string LogBuilderCreated()
        {
            string positive = "We've created a LogBuilder class!";
            return positive;
        }
    }
}
