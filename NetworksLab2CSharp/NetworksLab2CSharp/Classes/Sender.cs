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
        private const int MESSAGE_COUNT = 100;
        

        // Private Variables
        private int scenarioNo;
        private const string serverIP = "192.168.64.1";
        private const string serverPort = "2605";
        private Thread[] threads = new Thread[MESSAGE_COUNT];
        private List<byte[]> sentMesgs = new List<byte[]>();

        //private static bool SendDone = false;

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
        /// Sends data through the connected socket, pulled
        /// from the IOFiles/Request.txt file. Converted to bytes.
        /// </summary>
        /// <param name="sock"></param>
        public void SendData(Socket sock)
        {
            // Set socket timeout
            //sock.ReceiveTimeout = 4070;

            // create instance of LogBuilder
            LogBuilder lb = new LogBuilder();

            // Prepare file for IO operations
            //string path = @"c:\Logs\Lab2.Scenario2.WurdingerO.txt";
            string path = @"Lab2.Scenario2.WurdingerO.WORKING_SERVER.txt";
            StreamWriter logWrite = File.AppendText(path);

            // Get local ip address:
            IPAddress ip = Dns.GetHostAddresses(Dns.GetHostName()).Where(address => address.AddressFamily == AddressFamily.InterNetwork).First();
            string portNum = ((IPEndPoint)sock.LocalEndPoint).Port.ToString();

            // response time for scenario 2 and 3
            int responseTime = 0;
            
            // Set up Stopwatch to keep track of time
            Stopwatch stpWatch = new Stopwatch();
            stpWatch.Start();

            // setup for logging class
            ReceiverClass rc = new ReceiverClass();

            // setup receiving thread
            Thread receiveThread = new Thread(delegate()
                {
                    ReceiveThread(sock, rc);
                });
            receiveThread.Start();

            // Counter to call client operations
            for (int i = 0; i < MESSAGE_COUNT; i++)
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
                                responseTime = 1500;
                                break;
                            case 7:
                                responseTime = 1000;
                                break;
                            default: 
                                responseTime = 0;
                                break;
                        }

                        sendMsg = reqB.MessageBuildScenarioTwo(sock, msTime,
                            ip.ToString(), portNum, serverPort, serverIP, i, responseTime, lb);

                        break;
                    case 3:
                        // set up response time delay
                        switch (i)
                        {
                            case 1:
                                responseTime = 4000;
                                break;
                            case 3:
                                responseTime = 4000;
                                break;
                            default:
                                responseTime = 0;
                                break;
                        }

                        sendMsg = reqB.MessageBuildScenarioThree(sock, msTime,
                            ip.ToString(), portNum, serverPort, serverIP, i, responseTime, lb);
                        break;

                    default:
                        sendMsg = reqB.MessageBuildScenarioOne(sock, msTime,
                            ip.ToString(), portNum, serverPort, serverIP, i);
                        break;

                }

                try
                {
                    sock.Send(sendMsg);
                    Thread.Sleep(2);

                    #region savePiece
                    //receiveThread.Start();

                    //int receivedBytes = sock.Receive(receiveMsg);
                    //byte[] printMsg = new byte[receivedBytes];
                    //Array.Copy(receiveMsg, printMsg, receivedBytes);

                    //logWrite.Write("<CR><LF>");
                    //logWrite.Write(System.Text.Encoding.ASCII.GetString(printMsg));
                    //logWrite.Write("\r");
                    #endregion

                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                //System.Windows.Forms.MessageBox.Show(System.Text.Encoding.ASCII.GetString(sendMsg));
            }

            // Socket shutdown
            sock.Shutdown(SocketShutdown.Send);

            receiveThread.Join();

            sock.Shutdown(SocketShutdown.Receive);
            //sock.Disconnect(false);
            sock.Close();

            string date = System.DateTime.Now.ToString("MMddyyyy");
            string time = System.DateTime.Now.ToString("HHmmss");

            logWrite.Write(rc.sb.ToString());
            logWrite.Write(date + "|" + time + "|0|0|");

            // Close log file
            logWrite.Close();

            System.Windows.Forms.MessageBox.Show("Finished");
        }

        private void WriteLog(LogBuilder lb)
        {
            string path = @"c:\Logs\Lab2.Scenario2.SentMessages.txt";
            StreamWriter sentMsg = new StreamWriter(path);

            foreach (string s in lb.sentMsgs)
            {
                sentMsg.Write(s + "\r\n");
            }

            sentMsg.Close();
        }

        /// <summary>
        /// Thread start function to listen on an althernate
        /// therad and begin print and logging operations
        /// </summary>
        /// <param name="data">
        /// Takes an Object, in this case it will
        /// be a Socket.
        /// </param>
        private static void ReceiveThread(Socket sock, ReceiverClass rc)
        {

                // Create a socket and pass in parameter converted from object socket
                //Socket sock = (Socket)data;
                int receivedBytes = 0;

                do
                {            
                    try
                    {
                        // receive data from socket
                        receivedBytes = sock.Receive(rc.buffer);
                        byte[] formattedMsg = new byte[receivedBytes];
                        Array.Copy(rc.buffer, formattedMsg, receivedBytes);
                        rc.sb.Append(System.Text.Encoding.ASCII.GetString(formattedMsg) + "\r\n");
                    }
                    catch (SocketException se)
                    {
                        System.Windows.Forms.MessageBox.Show(se.Message);
                    }
                }
                while (receivedBytes > 0);
        }
    }
}
