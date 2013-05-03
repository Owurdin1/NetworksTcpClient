using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NetworksLab2CSharp.Classes
{
    class RequestBuilder
    {
        // Global Constant
        private const int BASE = 2;
        private const string messageType = "REQ";

        // Private global variables
        private string tcpHeader;
        private char[] msTimeStamp = new char[10];
        private string requestID;
        private string studentName;
        private string studentID;
        private int[] responseDelay = new int[5];
        private string clientIPAddress;
        private int[] clientServicePort = new int[5];
        private int[] clientSocketNumber = new int[5];
        private string foreignHostIPAddress;
        private int[] foreignHostServicePort = new int[5];
        private string studentData;
        private int scenarioNo;

        // Properties for private variables
        /// <summary>
        /// TCPHeader property, pass in string, converts to int
        /// then converts to a binary string.
        /// </summary>
        public string TCPHeader
        {
            get
            {
                return tcpHeader;
            }
            set
            {
                try
                {
                    int convertValue = Convert.ToInt32(value);
                    tcpHeader = Convert.ToString(convertValue, BASE);
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Error: " + e.Message);
                }
            }
        }

        /// <summary>
        /// String messageType property
        /// </summary>
        public string MessageType
        {
            get
            {
                return messageType;
            }
        }

        /// <summary>
        /// msTimeStamp  property, char[]
        /// </summary>
        public char[] MSTimeStamp
        {
            get
            {
                return msTimeStamp;
            }
            set
            {
                value.CopyTo(msTimeStamp, 0);
            }
        }

        /// <summary>
        /// RequestID Property
        /// </summary>
        public string RequestID
        {
            get
            {
                return requestID;
            }
            set
            {
                requestID = value;
            }
        }

        /// <summary>
        /// Student Name property
        /// Defualt = "WurdingerO"
        /// </summary>
        public string StudentName
        {
            get
            {
                return studentName;
            }
            set 
            {
                studentName = value;
            }
        }

        /// <summary>
        /// StudentID Property
        /// Default = "19-3410"
        /// </summary>
        public string StudentID
        {
            get
            {
                return studentID;
            }
            set
            {
                studentID = value;
            }
        }

        /// <summary>
        /// Response Delay property.
        /// ASCII Numeric (Int)
        /// </summary>
        public int[] ResponseDelay
        {
            get
            {
                return responseDelay;
            }
            set
            {
                value.CopyTo(responseDelay, 0);
            }
        }

        /// <summary>
        /// Client IP Address Property
        /// Defualt = iPConfig value
        /// </summary>
        public string ClientIPAddress
        {
            get
            {
                return clientIPAddress;
            }
            set
            {
                clientIPAddress = value;
            }
        }

        /// <summary>
        /// Client Service Port Property.
        /// Default IPConfig port value
        /// </summary>
        public int[] ClientServicePort
        {
            get
            {
                return clientServicePort;
            }
            set
            {
                value.CopyTo(clientServicePort, 0);
            }
        }

        /// <summary>
        /// Client Socket Number Property.
        /// Default Integer array IPConfig
        /// </summary>
        public int[] ClientSocketNumber
        {
            get
            {
                return clientSocketNumber;
            }
            set
            {
                value.CopyTo(clientSocketNumber, 0);
            }
        }

        /// <summary>
        /// Foreign Host IP Address Property.
        /// Default connecting to IP Address
        /// </summary>
        public string ForeignHostIPAddress
        {
            get
            {
                return foreignHostIPAddress;
            }
            set
            {
                value = foreignHostIPAddress;
            }
        }

        /// <summary>
        /// Foreign Host Service Port
        /// </summary>
        public int[] ForeignHostServicePort
        {
            get
            {
                return foreignHostServicePort;
            }
            set
            {
                value.CopyTo(foreignHostServicePort, 0);
            }
        }

        /// <summary>
        /// Student Data Property
        /// Default value string ""
        /// </summary>
        public string StudentData
        {
            get
            {
                return studentData;
            }
            set
            {
                studentData = value;
            }
        }

        /// <summary>
        /// Scenario Number for lab part
        /// Default: Scenario 1, 2, or 3
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
        /// Default Constructor
        /// Sets default values to mutable properties.
        /// </summary>
        public RequestBuilder()
        {
            tcpHeader = "";
            requestID = "";
            studentName = "";
            studentID = "";
            clientIPAddress = "";
            foreignHostIPAddress = "";
            studentData = "";
            scenarioNo = 0;
        }
    }
}
