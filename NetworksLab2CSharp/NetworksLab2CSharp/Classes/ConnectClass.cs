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
        //private readonly byte[] ipConnection = new byte[4] { 192, 168, 101, 210 };
        //private readonly byte[] ipConnection = new byte[4] { 10, 220, 8, 134 };
        //private readonly byte[] ipConnection = new byte[4] { 10, 220, 8, 161 };
        //private readonly byte[] ipConnection = new byte[4] { 24, 21, 179, 96 };
        private readonly byte[] ipConnection = new byte[4] { 192, 168, 1, 27 };

        // Private Variables
        private static int scenarioNo = 0;
        private static string response = String.Empty;
        private static ManualResetEvent sendDone = new ManualResetEvent(true);
        private static ManualResetEvent connectDone = new ManualResetEvent(true);
        private static ManualResetEvent receiveDone = new ManualResetEvent(false);

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

        //public static void Connect(EndPoint remoteEP, Socket client)
        //{
        //    client.BeginConnect(remoteEP,
        //        new AsyncCallback(ConnectCallback), client);

        //    connectDone.WaitOne();
        //}

        //private static void ConnectCallback(IAsyncResult ar)
        //{
        //    try
        //    {
        //        // Retrieve the socket from the state object.
        //        Socket client = (Socket)ar.AsyncState;

        //        // Complete the connection.
        //        client.EndConnect(ar);

        //        Console.WriteLine("Socket connected to {0}",
        //            client.RemoteEndPoint.ToString());

        //        // Signal that the connection has been made.
        //        connectDone.Set();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.ToString());
        //    }
        //}

        //private static void Send(Socket client, String data)
        //{
        //    // Convert the string data to byte data using ASCII encoding.
        //    byte[] byteData = Encoding.ASCII.GetBytes(data);

        //    // Begin sending the data to the remote device.
        //    client.BeginSend(byteData, 0, byteData.Length, SocketFlags.None,
        //        new AsyncCallback(SendCallback), client);
        //}

        //private static void SendCallback(IAsyncResult ar)
        //{
        //    try
        //    {
        //        // Retrieve the socket from the state object.
        //        Socket client = (Socket)ar.AsyncState;

        //        // Complete sending the data to the remote device.
        //        int bytesSent = client.EndSend(ar);
        //        Console.WriteLine("Sent {0} bytes to server.", bytesSent);

        //        // Signal that all bytes have been sent.
        //        sendDone.Set();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.ToString());
        //    }
        //}

        //private static void Receive(Socket client)
        //{
        //    try
        //    {
        //        // Create the state object.
        //        ReceiverClass state = new ReceiverClass();
        //        state.Sock = client;

        //        // Begin receiving the data from the remote device.
        //        client.BeginReceive(state.buffer, 0, ReceiverClass.BufferSize, 0,
        //            new AsyncCallback(ReceiveCallback), state);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.ToString());
        //    }
        //}

        //private static void ReceiveCallback(IAsyncResult ar)
        //{
        //    try
        //    {
        //        // Retrieve the state object and the client socket 
        //        // from the asynchronous state object.
        //        ReceiverClass state = (ReceiverClass)ar.AsyncState;
        //        Socket client = state.Sock;
        //        // Read data from the remote device.
        //        int bytesRead = client.EndReceive(ar);
        //        if (bytesRead > 0)
        //        {
        //            // There might be more data, so store the data received so far.
        //            state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
        //            //  Get the rest of the data.
        //            client.BeginReceive(state.buffer, 0, ReceiverClass.BufferSize, 0,
        //                new AsyncCallback(ReceiveCallback), state);
        //        }
        //        else
        //        {
        //            // All the data has arrived; put it in response.
        //            if (state.sb.Length > 1)
        //            {
        //                response = state.sb.ToString();
        //            }
        //            // Signal that all bytes have been received.
        //            receiveDone.Set();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.ToString());
        //    }
        //}

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
            byte[] ip = ipConnection;


            IPAddress ipAddr = new IPAddress(ip);

            // Make IPv4 socket with said IPAddress
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Try to connect the socket to server:
            try
            {
                sock.Connect(ipAddr, PORT);
                sock.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, true);

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
        //private static void ReceiverThreadStart(object data)
        //{
        //    // Create socket and make it be the socket currently connected
        //    // to the server
        //    Socket sock = (Socket)data;

        //    // Create instance of ReceiverClass
        //    ReceiverClass rClass = new ReceiverClass();

        //    // Set ReceiverClass scenario property
        //    rClass.ScenarioNo = scenarioNo;

        //    // Begin recieve algorithm
        //    //rClass.ReceiveFunction(sock);

        //    //string threadWork = rClass.ReceiverCreated();
        //    //System.Windows.Forms.MessageBox.Show("Thread running for receiver! " + threadWork);
        //}

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
            //SenderClassScenario3 s3Class = new SenderClassScenario3();

            // Set scenario version with the SenderClass
            sClass.ScenarioNo = scenarioNo;
            //s3Class.ScenarioNo = scenarioNo;

            // Begin send algorithm
            sClass.SendData(sock);
            //s3Class.SendData(sock);


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
            //Thread receiverThread = new Thread(ConnectClass.ReceiverThreadStart);
            //receiverThread.Start(inputSock);

            // Sender thread
            Thread senderThread = new Thread(ConnectClass.SenderThreadStart);
            senderThread.Start(inputSock);
        }
    }
}
