using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Text.RegularExpressions;

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

            Socket sock = new Socket(SocketType.Stream, ProtocolType.IPv4);
            
            // IPAddress class set to long int ip to connect to
            IPAddress ipAddr = new IPAddress(192168101210);

            // Try to connect the socket to server:
            try
            {
                sock.Connect(ipAddr, 2605);
            }
            catch (ArgumentNullException ane)
            {
                System.Windows.Forms.MessageBox.Show(ane.Message);
            }
            catch (SocketException se)
            {
                System.Windows.Forms.MessageBox.Show(se.Message);
            }
            catch (ArgumentException ae)
            {
                System.Windows.Forms.MessageBox.Show(ae.Message);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }

            return sock;
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
            string threadWork = rClass.ReceiverCreated();
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
            Thread senderThread = new Thread(ConnectClass.SenderThreadStart);
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
        /// <summary>
        /// Default constructor for SenderClass
        /// </summary>
        public SenderClass()
        {
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
        /// <summary>
        /// Default constructor
        /// </summary>
        public LogBuilder()
        {
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
