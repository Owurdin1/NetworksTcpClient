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
                }
                catch (Exception ex)
                {

                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                System.Windows.Forms.MessageBox.Show(System.Text.Encoding.ASCII.GetString(sendMsg));
            }

            #region blackout
            /*
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
                
                System.Windows.Forms.MessageBox.Show(sb.ToString());

                byte[] msg = System.Text.Encoding.ASCII.GetBytes(sb.ToString());
                int msgLength = msg.Length;

                byte[] lengthByte = System.Text.Encoding.ASCII.GetBytes((msgLength
                    + msgLength.ToString().Length).ToString());

                byte[] sendMsg = new byte[msgLength + lengthByte.Length];

                Array.Copy(lengthByte, 0, sendMsg, 0, lengthByte.Length);
                Array.Copy(msg, 0, sendMsg, lengthByte.Length, msg.Length);

                try
                {
                    sock.Send(msg);

                    System.Windows.Forms.MessageBox.Show("Sent this.ToString(): " 
                        + System.Text.Encoding.ASCII.GetString(msg)); // msg.ToString());
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show(e.Message);
                }
                sb.Clear();

                // send data
            }
                */

            #endregion
        }
    }
}
