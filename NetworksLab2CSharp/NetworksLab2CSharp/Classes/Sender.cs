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

            // Set time stamp
            // Set up Stopwatch to keep track of time
            Stopwatch stpWatch = new Stopwatch();
            stpWatch.Start();
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
                //Classes.RequestBuilder reqB = new Classes.RequestBuilder(sock, msTime, ip.ToString(), 
                //    portNum, scenarioNo, serverPort, serverIP, i);

                byte[] sendMsg;

                switch (scenarioNo)
                {
                    case 1:
                        sendMsg = reqB.MessageBuildScenarioOne(sock, msTime,
                            ip.ToString(), portNum, serverPort, serverIP, i);
                        break;
                    case 2:
                        sendMsg = reqB.MessageBuildScenarioTwo(sock, msTime,
                            ip.ToString(), portNum, serverPort, serverIP, i);
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
                    sock.Send(sendMsg);

                    // Receive message and print to log file.
                    byte[] receiveMsg = new byte[256]; // = new byte[sendMsg.Length + 10];

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
            // Close log file
            logWrite.Close();
            System.Windows.Forms.MessageBox.Show("Finished");
        }
    }
}
