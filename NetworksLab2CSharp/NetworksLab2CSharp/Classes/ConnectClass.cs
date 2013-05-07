using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;

namespace NetworksLab2CSharp
{
    class ConnectClass
    {
        // Constant variables
        private const int PORT = 2605;
        private readonly byte[] ipConnection = new byte[4] { 192, 168, 101, 210 };

        // Private Variables
        private static int scenarioNo = 0;

        // Class Properties
        public int ScenarioNo
        {
            get
            {
                return scenarioNo;
            }
            set
            {
                scenarioNo = value;
            }
        }

        /// <summary>
        /// Default Constructor for ConnectClass
        /// </summary>
        public ConnectClass()
        {
        }

        /// <summary>
        /// Creates a socket and connects to server
        /// </summary>
        /// <returns>
        /// Socket that is connected to server
        /// </returns>
        public Socket ConnectToServer()
        {
            // Declare variables
            Socket sock;

            // IPAddress class set to long int ip to connect to
            byte[] ip = ipConnection; // new byte[4];

            //ip[0] = 192;
            //ip[1] = 168;
            //ip[2] = 101;
            //ip[3] = 210;

            IPAddress ipAddr = new IPAddress(ip);

            // Make IPv4 socket with said IPAddress
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Try to connect the socket to server:
            try
            {
                //sock.BeginConnect(ipAddr, 
                sock.Connect(ipAddr, PORT); // 2605);
                //string testSend = "HI!";
                //byte[] dataSend = System.Text.Encoding.ASCII.GetBytes(testSend);
                //sock.Send(dataSend);
                //byte[] dataReceived = new byte[1024];
                //sock.Receive(dataReceived);

                //System.Windows.Forms.MessageBox.Show("Connected" + dataReceived.ToString());
                return sock;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Exception e" + e.Message);
            }
            
            return null;
        }

        /// <summary>
        /// Thread start function to create an instance of the
        /// ReceiverClass and begin listening on the socket for
        /// information from the server.
        /// </summary>
        /// <param name="data">
        /// Takes an Object, in this case it will
        /// be a Socket.
        /// </param>
        private static void ReceiverThreadStart(object data)
        {
            // Create socket and make it be the socket currently connected
            // to the server
            Socket sock = (Socket)data;

            // Create instance of ReceiverClass
            ReceiverClass rClass = new ReceiverClass();

            // Set ReceiverClass scenario property
            rClass.ScenarioNo = scenarioNo;

            // Begin recieve algorithm
            rClass.ReceiveFunction(sock);

            //string threadWork = rClass.ReceiverCreated();
            //System.Windows.Forms.MessageBox.Show("Thread running for receiver! " + threadWork);
        }

        /// <summary>
        /// Thread start function to create an instance of
        /// the SenderClass and begin any send operations on
        /// the socket for information to be sent to server
        /// </summary>
        /// <param name="data">
        /// Takes an Object, in this case it will
        /// be a Socket.
        /// </param>
        private static void SenderThreadStart(object data)
        {
            // Create a socket and pass in parameter converted from object to socket
            Socket sock = (Socket)data;

            // Create instance of SenderClass
            SenderClass sClass = new SenderClass();

            // Set scenario version with the SenderClass
            sClass.ScenarioNo = scenarioNo;

            // Begin send algorithm
            sClass.SendData(sock);


            //string threadWork = sClass.SenderCreated();
            //System.Windows.Forms.MessageBox.Show("Thread running for sender! " + threadWork);
        }

        /// <summary>
        /// Begins building connection to server
        /// </summary>
        /// <param name="inputSock">
        /// Takes a socket that will be 
        /// used to read/write to from server
        /// </param>
        public void ThreadBuilder(Socket inputSock)
        {
            // Create threads and send them off to do their thing

            // Receiver thread
            Thread receiverThread = new Thread(ConnectClass.ReceiverThreadStart);
            receiverThread.Start(inputSock);

            // Sender thread
            Thread senderThread = new Thread(ConnectClass.SenderThreadStart);
            senderThread.Start(inputSock);
        }
    }
}
