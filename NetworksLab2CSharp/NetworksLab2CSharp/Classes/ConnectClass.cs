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

    class ReceiverClass
    {
        // Private variables
        private int scenarioNo;

        // Properties
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
        /// Default constructor
        /// </summary>
        public ReceiverClass()
        {
        }

        /// <summary>
        /// Listen function begins listening for data on the socket.
        /// </summary>
        /// <param name="sock">
        /// Takes the socket that is connected to the server
        /// </param>
        /// <returns>
        /// a string containing data.
        /// </returns>
        public void ReceiveFunction(Socket sock)
        {
            int bytesReceived;
            byte[] receivedBuffer = new byte[1024];
            try
            {
                do
                {
                    bytesReceived = sock.Receive(receivedBuffer, receivedBuffer.Length, 0);
                    string msg = Encoding.ASCII.GetString(receivedBuffer, 0, bytesReceived);
                    System.Windows.Forms.MessageBox.Show("Receive function running, have a msg " + msg);
                }
                while (bytesReceived > 0);

            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);

            }

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
        // Constant variables
        private const string PATH = "C:\\Users\\Postholes\\Documents\\Visual Studio 2012\\Projects\\NetworksTcpClient\\NetworksLab2CSharp\\NetworksLab2CSharp\\IOFiles\\Request.txt";
        private const int BYTE_LENGTH = 2;
        // Private Variables
        private Classes.RequestBuilder requestBuilder;
        private int scenarioNo;
        private const string serverIP = "192.168.101.210";
        private const string serverPort = "2605";

        // Properites for class
        /// <summary>
        /// Scenario Number property
        /// </summary>
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
        /// Default constructor for SenderClass
        /// </summary>
        public SenderClass()
        {
            requestBuilder = new Classes.RequestBuilder();
        }

        public SenderClass(Classes.RequestBuilder rb)
        {
            requestBuilder = rb;
        }

        /// <summary>
        /// Sends data through the connected socket, pulled
        /// from the IOFiles/Request.txt file. Converted to bytes.
        /// </summary>
        /// <param name="sock"></param>
        public void SendData(Socket sock)
        {
            // Create new RequestBuilder class to build request message
            Classes.RequestBuilder rb = new Classes.RequestBuilder();

            // Get local ip address:
            IPAddress ip = Dns.GetHostAddresses(Dns.GetHostName()).Where(address => address.AddressFamily == AddressFamily.InterNetwork).First();
            //System.Windows.Forms.MessageBox.Show("IP Address: " + ip);

            // set up variables and static properties for the RequestBuilder
            StringBuilder sb = new StringBuilder();
            string requestID = "Request Num: ";
            string responseDelay;
            string studentData = "Student Data ";
            int iLength;
            string slash = "|";
            char[] iValue;

            rb.StudentName = "WurdingerO";
            rb.StudentID = "19-3410";
            rb.ClientSocketNumber = sock.Handle.ToString(); //"10"; // new int[5] { 0, 0, 0, 1, 0 };
            rb.ForeignHostIPAddress = serverIP;
            rb.ForeignHostServicePort = serverPort;
            rb.ScenarioNo = scenarioNo.ToString();

            // Set up Stopwatch to keep track of time
            Stopwatch stpWatch = new Stopwatch();
            stpWatch.Start();

            // Run send 100 times based on which scenario selected
            for (int i = 0; i < 100; i++)
            {
                switch (scenarioNo)
                {
                    case 1:
                        rb.RequestID = requestID + i.ToString();
                        responseDelay = "0"; // new int[5] { 0, 0, 0, 0, 0 };
                        rb.ResponseDelay = responseDelay;

                        break;

                    case 2:
                        rb.RequestID = requestID + i.ToString();
                        iValue = i.ToString().ToCharArray();
                        iLength = iValue.Length;
                        switch (iLength)
                        {
                            case 1:
                                responseDelay = "200" + i.ToString(); // new int[5] { 2, 0, 0, 0, iValue[0] };
                                rb.ResponseDelay = responseDelay;

                                break;

                            case 2:
                                responseDelay = "200" + i.ToString(); //new int[5] { 2, 0, 0, iValue[0], iValue[1] };
                                rb.ResponseDelay = responseDelay;

                                break;

                            default:
                                responseDelay = "20222"; // new int[5] { 2, 0, 2, 2, 2 };
                                rb.ResponseDelay = responseDelay;

                                break;
                        }

                        break;

                    case 3:
                        rb.RequestID = requestID + i.ToString();
                        iValue = i.ToString().ToCharArray();
                        iLength = iValue.Length;

                        switch (iLength)
                        {
                            case 1:
                                responseDelay = "3000"; // new int[5] { 3, 0, 0, 0, iValue[0] };
                                rb.ResponseDelay = responseDelay;
                                
                                break;

                            case 2:
                                responseDelay = "300" + i.ToString(); // new int[5] { 3, 0, 0, iValue[0], iValue[1] };
                                rb.ResponseDelay = responseDelay;
                                
                                break;

                            default:
                                responseDelay = "30333"; // new int[5] { 3, 0, 3, 3, 3 };
                                rb.ResponseDelay = responseDelay;
                                
                                break;
                        }

                        break;

                    default:

                        break;
                }
                // Set time stamp
                string msTime = Convert.ToString(stpWatch.ElapsedMilliseconds);
                if (msTime.Length > 10)
                {
                    string newMSTime = "";

                    for (int t = 9; t >= 0; t++)
                    {
                        newMSTime += msTime[t];
                    }
                    msTime = newMSTime;
                }
                rb.MSTimeStamp = msTime;

                // set client IP
                rb.ClientIPAddress = ip.ToString();

                // set client port
                string portNum = ((IPEndPoint)sock.LocalEndPoint).Port.ToString();
                rb.ClientServicePort = portNum;

                // set student data
                rb.StudentData = studentData + i.ToString();

                // Build the string builder object, get size insert header length
                sb.Append(rb.MessageType);
                sb.Append(slash);
                sb.Append(rb.MSTimeStamp);
                sb.Append(slash);
                sb.Append(rb.RequestID);
                sb.Append(slash);
                sb.Append(rb.StudentName);
                sb.Append(slash);
                sb.Append(rb.StudentID);
                sb.Append(slash);
                sb.Append(rb.ClientIPAddress);
                sb.Append(slash);
                sb.Append(rb.ClientServicePort);
                sb.Append(slash);
                sb.Append(rb.ClientSocketNumber);
                sb.Append(slash);
                sb.Append(rb.ForeignHostIPAddress);
                sb.Append(slash);
                sb.Append(rb.ForeignHostServicePort);
                sb.Append(slash);
                sb.Append(rb.StudentData);
                sb.Append(slash);
                sb.Append(rb.ScenarioNo);
                sb.Append(slash);

                // Get size and insert tcp header
                string getSize = sb.ToString();
                byte[] sizeFinder = System.Text.Encoding.ASCII.GetBytes(getSize);
                int size = sizeFinder.Length;
                size += size.ToString().Length;

                byte[] sizeBytes = System.Text.Encoding.ASCII.GetBytes(size.ToString());
                sb.Insert(0, sizeBytes);

                System.Windows.Forms.MessageBox.Show(sb.ToString());

                byte[] msg = System.Text.Encoding.ASCII.GetBytes(sb.ToString());

                try
                {
                    sock.Send(msg);
                    byte[] receiveMsg = new byte[size + 100];
                    //int status = sock.Receive(receiveMsg);
                    System.Windows.Forms.MessageBox.Show("Sent this.ToString(): " + msg.ToString() + " This size: " + size.ToString());
                    //System.Windows.Forms.MessageBox.Show("Received " + status.ToString() 
                    //    + " bytes, and this text: " + 
                    //    System.Text.Encoding.ASCII.GetChars(receiveMsg).ToString());
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show(e.Message);
                }
                sb.Clear();

                // send data
            }
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
        // Private Global Variables
        private Classes.ResponseClass responseClass;

        /// <summary>
        /// Response Class property
        /// </summary>
        public Classes.ResponseClass ResponseClass
        {
            get
            {
                return responseClass;
            }
            set
            {
                responseClass = value;
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public LogBuilder()
        {
        }

        /// <summary>
        /// non-default constructor
        /// Takes a ResponseClass object to
        /// be parsed for creating logs
        /// </summary>
        /// <param name="rc"></param>
        public LogBuilder(Classes.ResponseClass rc)
        {
            responseClass = rc;
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
