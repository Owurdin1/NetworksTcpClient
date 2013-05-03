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

namespace NetworksLab2CSharp
{
    class ConnectClass
    {
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
            /*
             * The internal name of the server is 
             * “Coco” and is located at the private 
             * IP address of 192.168.101.210, 
             * and you are to use service port 2605
             */
            Socket sock;

            // IPAddress class set to long int ip to connect to
            byte[] ip = new byte[4];
            ip[0] = 192;
            ip[1] = 168;
            ip[2] = 101;
            ip[3] = 210;
            IPAddress ipAddr = new IPAddress(ip);

            try
            {
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //sock.
                // Try to connect the socket to server:
                try
                {
                    sock.Connect(ipAddr, 2605);
                    return sock;
                }
                catch (ArgumentNullException ane)
                {
                    System.Windows.Forms.MessageBox.Show("ArgNullException" + ane.Message);
                }
                catch (SocketException se)
                {
                    System.Windows.Forms.MessageBox.Show("SocketException" + se.Message);
                }
                catch (ArgumentException ae)
                {
                    System.Windows.Forms.MessageBox.Show("ArgException" + ae.Message);
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Exception e" + e.Message);
                }
            }
            catch (SocketException se)
            {
                System.Windows.Forms.MessageBox.Show("SocketException last" + se.Message);
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
            Socket sock = (Socket)data;
            ReceiverClass rClass = new ReceiverClass();
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
            Socket sock = (Socket)data;
            SenderClass sClass = new SenderClass();
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
            Thread receiverThread = new Thread(ConnectClass.ReceiverThreadStart);
            receiverThread.Start(inputSock);

            Thread senderThread = new Thread(ConnectClass.SenderThreadStart);
            senderThread.Start(inputSock);
        }
    }

    class ReceiverClass
    {
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
            bytesReceived = sock.Receive(receivedBuffer);
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
        const string PATH = "C:\\Users\\Postholes\\Documents\\Visual Studio 2012\\Projects\\NetworksTcpClient\\NetworksLab2CSharp\\NetworksLab2CSharp\\IOFiles\\Request.txt";

        private Classes.RequestBuilder requestBuilder;

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
            FileStream f = new FileStream(PATH, FileMode.Open);
            StreamReader sr = new StreamReader(f);

            //========================================================================================
            string line = sr.ReadLine();
            System.Windows.Forms.MessageBox.Show("Line read from file: " + line);
            //========================================================================================
            sr.Close();
            f.Close();
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
