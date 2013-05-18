using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;


namespace NetworksLab2CSharp.Classes
{
    class RequestBuilder
    {
        //struct Values
        //{
        //    public Socket sock;
        //    public string msTime;
        //    public string ip;
        //    public string portNum;
        //    public int scenarioNo;
        //    public string serverPort;
        //    public string serverIP;
        //    public int i;
        //}

        public RequestBuilder()
        {
            // Build constructor if needed
        }

        public RequestBuilder(Socket sock, string msTime, string ip, string portNum,
            int scenarioNo, string serverPort, string serverIP, int i)
        {
            //Values v = new Values();
            //v.sock = sock;
            //v.msTime = msTime;
            //v.ip = ip;
            //v.portNum = portNum;
            //v.scenarioNo = scenarioNo;
            //v.serverPort = serverPort;
            //v.serverIP = serverIP;
            //v.i = i;

            //switch (v.scenarioNo)
            //{
            //    case 1:
            //        MessageBuildScenario1(v);
            //        break;
            //    case 2:

            //        break;
            //    case 3:

            //        break;
            //}
        }

        /// <summary>
        /// Scenario 1 Message builder
        /// </summary>
        /// <param name="sock">
        /// socket to query for socket info
        /// </param>
        /// <param name="msTime">
        /// time parameter to state time in message
        /// </param>
        /// <param name="ip">
        /// ip addres connected to
        /// </param>
        /// <param name="portNum">
        /// port number being used
        /// </param>
        /// <param name="serverPort">
        /// port number being used</param>
        /// <param name="serverIP">
        /// server ip address
        /// </param>
        /// <param name="i">
        /// count value
        /// </param>
        /// <returns>
        /// a byte array containing formatted message
        /// </returns>
        public byte[] MessageBuildScenarioOne(Socket sock, string msTime, string ip, string portNum,
            string serverPort, string serverIP, int i)
        {
            // Hard code and build string.
            string msgString = "REQ|" + msTime
                + "|RequestNo:" + i + "|WurdingerO|19-3410|" + "0|" + ip.ToString()
                + "|" + portNum + "|" + sock.Handle.ToString() + "|" + serverIP + "|"
                + serverPort + "|StudentData:" + i + "|1|";

            //System.Windows.Forms.MessageBox.Show(msgString);
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(msgString);

            // Length of msg
            short msgLength = (short)msg.Length;

            // convert message length to byte array
            byte[] byteLength = BitConverter.GetBytes(msgLength);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(byteLength); //.Reverse();
            }

            byte[] sendMsg = new byte[byteLength.Length + msgLength];

            // Copy arrays to get one single sendMsg array
            Array.Copy(byteLength, sendMsg, byteLength.Length);
            Array.Copy(msg, 0, sendMsg, byteLength.Length, msgLength);
            
            return sendMsg;
        }

        /// <summary>
        /// Scenario 2 Message builder
        /// </summary>
        /// <param name="sock">
        /// socket to query for socket info
        /// </param>
        /// <param name="msTime">
        /// time parameter to state time in message
        /// </param>
        /// <param name="ip">
        /// ip addres connected to
        /// </param>
        /// <param name="portNum">
        /// port number being used
        /// </param>
        /// <param name="serverPort">
        /// port number being used</param>
        /// <param name="serverIP">
        /// server ip address
        /// </param>
        /// <param name="i">
        /// count value
        /// </param>
        /// <returns>
        /// a byte array containing formatted message
        /// </returns>
        public byte[] MessageBuildScenarioTwo(Socket sock, string msTime, string ip, string portNum,
            string serverPort, string serverIP, int i, int responseTime, LogBuilder lb)
        {
            // Hard code and build string.
            string stringMsg = "REQ|" + msTime
                + "|RequestNo:" + i + "|WurdingerO|19-3410|" + responseTime + "|" + ip
                + "|" + portNum + "|" + sock.Handle.ToString() + "|" + serverIP + "|"
                + serverPort + "|StudentData:" + i + "|2|";

            lb.sentMsgs.Add(stringMsg);

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(stringMsg);

            // Length of msg
            short msgLength = (short)msg.Length;

            // convert message length to byte array
            byte[] byteLength = BitConverter.GetBytes(msgLength);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(byteLength); //.Reverse();
            }

            byte[] sendMsg = new byte[byteLength.Length + msgLength];

            // Copy arrays to get one single sendMsg array
            Array.Copy(byteLength, sendMsg, byteLength.Length);
            Array.Copy(msg, 0, sendMsg, byteLength.Length, msgLength);

            return sendMsg;
        }

        /// <summary>
        /// Scenario 3 Message builder
        /// </summary>
        /// <param name="sock">
        /// socket to query for socket info
        /// </param>
        /// <param name="msTime">
        /// time parameter to state time in message
        /// </param>
        /// <param name="ip">
        /// ip addres connected to
        /// </param>
        /// <param name="portNum">
        /// port number being used
        /// </param>
        /// <param name="serverPort">
        /// port number being used</param>
        /// <param name="serverIP">
        /// server ip address
        /// </param>
        /// <param name="i">
        /// count value
        /// </param>
        /// <returns>
        /// a byte array containing formatted message
        /// </returns>
        public byte[] MessageBuildScenarioThree(Socket sock, string msTime, string ip, string portNum, 
            string serverPort, string serverIP, int i, int responseTime, LogBuilder lb)
        {
            // Hard code and build string.
            //byte[] msg = System.Text.Encoding.ASCII.GetBytes("REQ|" + msTime
            //    + "|RequestNo:" + i + "|WurdingerO|19-3410|" + ip.ToString()
            //    + "|" + portNum + "|" + sock.Handle.ToString() + "|" + serverIP + "|"
            //    + serverPort + "|StudentData:" + i + "|3|");

            byte[] msg = System.Text.Encoding.ASCII.GetBytes("REQ|" + msTime
                + "|RequestNo:" + i + "|WurdingerO|19-3410|" + responseTime + "|" + ip
                + "|" + portNum + "|" + sock.Handle.ToString() + "|" + serverIP + "|"
                + serverPort + "|StudentData:" + i + "|3|");

            int msgLength = msg.Length;

            byte[] lengthByte = System.Text.Encoding.ASCII.GetBytes((msgLength
                + msgLength.ToString().Length).ToString());

            byte[] sendMsg = new byte[msgLength + lengthByte.Length];

            Array.Copy(lengthByte, 0, sendMsg, 0, lengthByte.Length);
            Array.Copy(msg, 0, sendMsg, lengthByte.Length, msg.Length);

            return sendMsg;
        }

#region FailedIdea
        //        // Global Constant
//        private const int BASE = 2;
//        private const string messageType = "REQ";

//        // Private global variables
//        private string tcpHeader;
//        private string msTimeStamp;
//        private string requestID;
//        private string studentName;
//        private string studentID;
//        private string responseDelay;
//        private string clientIPAddress;
//        private string clientServicePort;
//        private string clientSocketNumber;
//        private string foreignHostIPAddress;
//        private string foreignHostServicePort;
//        private string studentData;
//        private string scenarioNo;

//        // Properties for private variables
//        /// <summary>
//        /// TCPHeader property, pass in string, converts to int
//        /// then converts to a binary string.
//        /// </summary>
//        public string TCPHeader
//        {
//            get
//            {
//                return tcpHeader;
//            }
//            set
//            {
//                tcpHeader = value;
//                //try
//                //{
//                //    int convertValue = Convert.ToInt32(value);
//                //    tcpHeader = Convert.ToString(convertValue, BASE);
//                //}
//                //catch (Exception e)
//                //{
//                //    System.Windows.Forms.MessageBox.Show("Error: " + e.Message);
//                //}
//            }
//        }

//        /// <summary>
//        /// String messageType property
//        /// </summary>
//        public string MessageType
//        {
//            get
//            {
//                return messageType;
//            }
//        }

//        /// <summary>
//        /// msTimeStamp  property, char[]
//        /// </summary>
//        public string MSTimeStamp
//        {
//            get
//            {
//                return msTimeStamp;
//            }
//            set
//            {
//                msTimeStamp = value;
//            }
//        }

//        /// <summary>
//        /// RequestID Property
//        /// </summary>
//        public string RequestID
//        {
//            get
//            {
//                return requestID;
//            }
//            set
//            {
//                requestID = value;
//            }
//        }

//        /// <summary>
//        /// Student Name property
//        /// Defualt = "WurdingerO"
//        /// </summary>
//        public string StudentName
//        {
//            get
//            {
//                return studentName;
//            }
//            set 
//            {
//                studentName = value;
//            }
//        }

//        /// <summary>
//        /// StudentID Property
//        /// Default = "19-3410"
//        /// </summary>
//        public string StudentID
//        {
//            get
//            {
//                return studentID;
//            }
//            set
//            {
//                studentID = value;
//            }
//        }

//        /// <summary>
//        /// Response Delay property.
//        /// ASCII Numeric (Int)
//        /// </summary>
//        public string ResponseDelay
//        {
//            get
//            {
//                return responseDelay;
//            }
//            set
//            {
//                responseDelay = value;
//                //value.CopyTo(responseDelay, 0);
//            }
//        }

//        /// <summary>
//        /// Client IP Address Property
//        /// Defualt = iPConfig value
//        /// </summary>
//        public string ClientIPAddress
//        {
//            get
//            {
//                return clientIPAddress;
//            }
//            set
//            {
//                clientIPAddress = value;
//            }
//        }

//        /// <summary>
//        /// Client Service Port Property.
//        /// Default IPConfig port value
//        /// </summary>
//        public string ClientServicePort
//        {
//            get
//            {
//                return clientServicePort;
//            }
//            set
//            {
//                clientServicePort = value;  
//                //value.CopyTo(clientServicePort, 0);
//            }
//        }

//        /// <summary>
//        /// Client Socket Number Property.
//        /// Default Integer array IPConfig
//        /// </summary>
//        public string ClientSocketNumber
//        {
//            get
//            {
//                return clientSocketNumber;
//            }
//            set
//            {
//                clientSocketNumber = value;
//                //value.CopyTo(clientSocketNumber, 0);
//            }
//        }

//        /// <summary>
//        /// Foreign Host IP Address Property.
//        /// Default connecting to IP Address
//        /// </summary>
//        public string ForeignHostIPAddress
//        {
//            get
//            {
//                return foreignHostIPAddress;
//            }
//            set
//            {
//                value = foreignHostIPAddress;
//            }
//        }

//        /// <summary>
//        /// Foreign Host Service Port
//        /// </summary>
//        public string ForeignHostServicePort
//        {
//            get
//            {
//                return foreignHostServicePort;
//            }
//            set
//            {
//                foreignHostServicePort = value;
//                //value.CopyTo(foreignHostServicePort, 0);
//            }
//        }

//        /// <summary>
//        /// Student Data Property
//        /// Default value string ""
//        /// </summary>
//        public string StudentData
//        {
//            get
//            {
//                return studentData;
//            }
//            set
//            {
//                studentData = value;
//            }
//        }

//        /// <summary>
//        /// Scenario Number for lab part
//        /// Default: Scenario 1, 2, or 3
//        /// </summary>
//        public string ScenarioNo
//        {
//            get
//            {
//                return scenarioNo;
//            }
//            set
//            {
//                scenarioNo = value;
//            }
//        }

//        /// <summary>
//        /// Default Constructor
//        /// Sets default values to mutable properties.
//        /// </summary>
//        public RequestBuilder()
//        {
//            tcpHeader = "";
//            msTimeStamp = "";
//            requestID = "";
//            studentName = "";
//            studentID = "";
//            responseDelay = "";
//            clientIPAddress = "";
//            clientServicePort = "";
//            clientSocketNumber = "";
//            foreignHostIPAddress = "";
//            foreignHostServicePort = "";
//            studentData = "";
//            scenarioNo = "";
//        }
#endregion
    }
}
