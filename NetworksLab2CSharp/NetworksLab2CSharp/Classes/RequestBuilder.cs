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
        private string msTimeStamp;
        private string requestID;
        private string studentName;
        private string studentID;
        private string responseDelay;
        private string clientIPAddress;
        private string clientServicePort;
        private string clientSocketNumber;
        private string foreignHostIPAddress;
        private string foreignHostServicePort;
        private string studentData;
        private string scenarioNo;

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
                tcpHeader = value;
                //try
                //{
                //    int convertValue = Convert.ToInt32(value);
                //    tcpHeader = Convert.ToString(convertValue, BASE);
                //}
                //catch (Exception e)
                //{
                //    System.Windows.Forms.MessageBox.Show("Error: " + e.Message);
                //}
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
        public string MSTimeStamp
        {
            get
            {
                return msTimeStamp;
            }
            set
            {
                msTimeStamp = value;
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
        public string ResponseDelay
        {
            get
            {
                return responseDelay;
            }
            set
            {
                responseDelay = value;
                //value.CopyTo(responseDelay, 0);
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
        public string ClientServicePort
        {
            get
            {
                return clientServicePort;
            }
            set
            {
                clientServicePort = value;  
                //value.CopyTo(clientServicePort, 0);
            }
        }

        /// <summary>
        /// Client Socket Number Property.
        /// Default Integer array IPConfig
        /// </summary>
        public string ClientSocketNumber
        {
            get
            {
                return clientSocketNumber;
            }
            set
            {
                clientSocketNumber = value;
                //value.CopyTo(clientSocketNumber, 0);
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
        public string ForeignHostServicePort
        {
            get
            {
                return foreignHostServicePort;
            }
            set
            {
                foreignHostServicePort = value;
                //value.CopyTo(foreignHostServicePort, 0);
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
        public string ScenarioNo
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
            msTimeStamp = "";
            requestID = "";
            studentName = "";
            studentID = "";
            responseDelay = "";
            clientIPAddress = "";
            clientServicePort = "";
            clientSocketNumber = "";
            foreignHostIPAddress = "";
            foreignHostServicePort = "";
            studentData = "";
            scenarioNo = "";
        }
    }
}
