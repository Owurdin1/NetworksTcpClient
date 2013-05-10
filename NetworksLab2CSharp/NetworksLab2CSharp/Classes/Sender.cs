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
    class SenderClass
    {
        // Constant variables
        private const string PATH = "C:\\Users\\Postholes\\Documents\\Visual Studio 2012\\Projects\\NetworksTcpClient\\NetworksLab2CSharp\\NetworksLab2CSharp\\IOFiles\\Request.txt";
        private const int BYTE_LENGTH = 2;

        // Private Variables
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

        }

        /// <summary>
        /// Sends data through the connected socket, pulled
        /// from the IOFiles/Request.txt file. Converted to bytes.
        /// </summary>
        /// <param name="sock"></param>
        public void SendData(Socket sock)
        {
            // Prepare file for IO operations
            string path = @"c:\Logs\Lab2.Scenario1.WurdingerO.txt";
            StreamWriter logWrite = File.AppendText(path);

            // Get local ip address:
            IPAddress ip = Dns.GetHostAddresses(Dns.GetHostName()).Where(address => address.AddressFamily == AddressFamily.InterNetwork).First();
            string portNum = ((IPEndPoint)sock.LocalEndPoint).Port.ToString();

            // response time for scenario 2 and 3
            int responseTime = 0;
            
            // Set up Stopwatch to keep track of time
            Stopwatch stpWatch = new Stopwatch();
            stpWatch.Start();

            // setup receiving thread
            //Thread receiveThread = new Thread(ReceiveThread);
            //receiveThread.Start(sock);

            // Counter to call client operations
            for (int i = 0; i < 100; i++)
            {
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

                Classes.RequestBuilder reqB = new Classes.RequestBuilder();

                byte[] sendMsg;

                switch (scenarioNo)
                {
                    case 1:
                        sendMsg = reqB.MessageBuildScenarioOne(sock, msTime,
                            ip.ToString(), portNum, serverPort, serverIP, i);
                        break;
                    case 2:
                        // set up response time delay

                        switch (i)
                        {
                            case 1:
                                responseTime = 1000;
                                break;
                            case 3:
                                responseTime = 3000;
                                break;
                            default: 
                                responseTime = 0;
                                break;
                        }

                        sendMsg = reqB.MessageBuildScenarioTwo(sock, msTime,
                            ip.ToString(), portNum, serverPort, serverIP, i, responseTime);

                        break;
                    case 3:
                        sendMsg = reqB.MessageBuildScenarioThree(sock, msTime,
                            ip.ToString(), portNum, serverPort, serverIP, i);
                        break;
                    default:
                        sendMsg = reqB.MessageBuildScenarioOne(sock, msTime,
                            ip.ToString(), portNum, serverPort, serverIP, i);
                        break;

                }

                try
                {
                    // Send the message to server.
                    byte[] receiveMsg = new byte[256];
                    sock.Send(sendMsg);
                    int receivedBytes = sock.Receive(receiveMsg);
                    byte[] printMsg = new byte[receivedBytes];
                    Array.Copy(receiveMsg, printMsg, receivedBytes);

                    logWrite.Write("<CR><LF>");
                    logWrite.Write(System.Text.Encoding.ASCII.GetString(printMsg));
                    logWrite.Write("\r");
                }
                catch (Exception ex)
                {

                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                //System.Windows.Forms.MessageBox.Show(System.Text.Encoding.ASCII.GetString(sendMsg));
            }

            // Socket shutdown
            sock.Shutdown(SocketShutdown.Receive);
            sock.Shutdown(SocketShutdown.Send);

            string date = System.DateTime.Now.ToString("MMddyyyy");
            string time = System.DateTime.Now.ToString("HHmmss");

            logWrite.Write(date + "|" + time + "|0|0|");

            // Close log file
            logWrite.Close();
            System.Windows.Forms.MessageBox.Show("Finished");

            //LogBuilder lb = new LogBuilder();
            //lb.LogClose(sock);
        }

        /// <summary>
        /// Thread start function to listen on an althernate
        /// therad and begin print and logging operations
        /// </summary>
        /// <param name="data">
        /// Takes an Object, in this case it will
        /// be a Socket.
        /// </param>
        private static void ReceiveThread(object data)
        {
                // Create a socket and pass in parameter converted from object to socket
                Socket sock = (Socket)data;

                int receivedBytes = 0;

                // create instance of LogBuilder
                LogBuilder lb = new LogBuilder();

                // create byte arrays for receive messages
                byte[] oldMsg = new byte[256];
                byte[] receiveMsg = new byte[256];

                // while receiving something spin on receive
            do
            {
                try
                {
                        // Receive message and print to log file.
                        receivedBytes = sock.Receive(receiveMsg);

                        if (!receiveMsg.Equals(oldMsg))
                        {
                            // write to log file
                            lb.LogWriter(receivedBytes, receiveMsg, sock);

                            // clear oldMsg array for next piece
                            Array.Clear(oldMsg, 0, 256);
                            Array.Copy(receiveMsg, oldMsg, receivedBytes);
                        }
                }
                catch (ObjectDisposedException ode)
                {
                    System.Windows.Forms.MessageBox.Show(ode.Message);
                }
                catch (SocketException se)
                {
                    System.Windows.Forms.MessageBox.Show(se.Message);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
            while (receivedBytes > 0);

            #region savedCode
            //// Create instance of SenderClass
            //SenderClass sClass = new SenderClass();

            //// Set scenario version with the SenderClass
            //sClass.ScenarioNo = scenarioNo;

            //// Begin send algorithm
            //sClass.SendData(sock);


            //string threadWork = sClass.SenderCreated();
            //System.Windows.Forms.MessageBox.Show("Thread running for sender! " + threadWork);
            #endregion
        }
    }
}
