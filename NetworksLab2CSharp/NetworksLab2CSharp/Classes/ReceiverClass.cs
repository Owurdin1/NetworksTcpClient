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
    /// <summary>
    /// Essentially a receive message storage class. Will build whole
    /// log through the string builder then when finished print
    /// stringbuilder to the log file.
    /// </summary>
    class ReceiverClass
    {
        // Private variables
        private int scenarioNo;
        private Socket sock = null;

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
        public Socket Sock
        {
            get
            {
                return sock;
            }
            set
            {
                sock = value;
            }
        }
        public static int BufferSize
        {
            get
            {
                return bufferSize;
            }
        }

        // public variables
        public const int bufferSize = 256;
        public byte[] buffer = new byte[bufferSize];
        public StringBuilder sb = new StringBuilder();
        
        
        /// <summary>
        /// Thread start function to listen on an althernate
        /// therad and begin print and logging operations
        /// </summary>
        /// <param name="data">
        /// Takes an Object, in this case it will
        /// be a Socket.
        /// </param>
//        public static void ReceiveThread(object data)
//        {
//            // Create a socket and pass in parameter converted from object to socket
//            Socket sock = (Socket)data;
//            //sock.ReceiveTimeout = 4000;

//            // Set up log builder
//            ReceiverClass rc = new ReceiverClass();
//            //rc.sock = sock;

//            // set up buffer for receiving
//            byte[] oldMsg = new byte[rc.BufferSize];
//            int receivedBytes = 0;
//            //int counter = 0;

//            do
//            {
//                //try
//                //{
//                receivedBytes = sock.Receive(rc.buffer);
//                byte[] formattedMsg = new byte[receivedBytes];
//                Array.Copy(rc.buffer, formattedMsg, receivedBytes);
//                //rc.sb.Append("<LF><CR>" + System.Text.Encoding.ASCII.GetString(rc.buffer) + "\r");
//                rc.sb.Append("<LF><CR>" + System.Text.Encoding.ASCII.GetString(formattedMsg) + "\r\n");

//                #region moreOld
//                //if (oldMsg.Equals(rc.buffer) && counter < 100)
//                //{
//                //}
//                //else
//                //{
//                //    Array.Clear(oldMsg, 0, rc.BufferSize);
//                //    Array.Copy(rc.buffer, oldMsg, receivedBytes);

//                //    Array.Clear(rc.buffer, 0, rc.BufferSize);
//                //    counter++;
//                //}

//                //if (SendDone && counter > 50)
//                //{
//                //    receivedBytes = 0;
//                //    sock.Shutdown(SocketShutdown.Receive);
//                //}
//                //}
//                //catch (Exception ex)
//                //{
//                //    System.Windows.Forms.MessageBox.Show(ex.Message);
//                //}
//#endregion

//            }
//            while (receivedBytes > 0);

//            //sock.Shutdown(SocketShutdown.Receive);

//            LogBuilder lb = new LogBuilder();
//            lb.BuildLog(rc);


//            #region Oldcode
//            //    int receivedBytes = 0;

//            //    // create instance of LogBuilder
//            //    LogBuilder lb = new LogBuilder();

//            //    // create byte arrays for receive messages
//            //    byte[] oldMsg = new byte[256];
//            //    byte[] receiveMsg = new byte[256];

//            //    // while receiving something spin on receive
//            //do
//            //{
//            //    try
//            //    {
//            //            // Receive message and print to log file.
//            //            receivedBytes = sock.Receive(receiveMsg);

//            //            if (!receiveMsg.Equals(oldMsg))
//            //            {
//            //                // write to log file
//            //                lb.LogWriter(receivedBytes, receiveMsg, sock);

//            //                // clear oldMsg array for next piece
//            //                Array.Clear(oldMsg, 0, 256);
//            //                Array.Copy(receiveMsg, oldMsg, receivedBytes);
//            //            }
//            //    }
//            //    catch (ObjectDisposedException ode)
//            //    {
//            //        System.Windows.Forms.MessageBox.Show(ode.Message);
//            //    }
//            //    catch (SocketException se)
//            //    {
//            //        System.Windows.Forms.MessageBox.Show(se.Message);
//            //    }
//            //    catch (Exception ex)
//            //    {
//            //        System.Windows.Forms.MessageBox.Show(ex.Message);
//            //    }
//            //}
//            //while (receivedBytes > 0);
//            #endregion

//            #region savedCode
//            //// Create instance of SenderClass
//            //SenderClass sClass = new SenderClass();

//            //// Set scenario version with the SenderClass
//            //sClass.ScenarioNo = scenarioNo;

//            //// Begin send algorithm
//            //sClass.SendData(sock);


//            //string threadWork = sClass.SenderCreated();
//            //System.Windows.Forms.MessageBox.Show("Thread running for sender! " + threadWork);
//            #endregion
//        }
    }
        #region removeableCode
        /// <summary>
        /// Listen function begins listening for data on the socket.
        /// </summary>
        /// <param name="sock">
        /// Takes the socket that is connected to the server
        /// </param>
        /// <returns>
        /// a string containing data.
        /// </returns>
        //public void ReceiveFunction(Socket sock)
        //{
        //    int bytesReceived;
        //    byte[] receivedBuffer = new byte[1024];
        //    try
        //    {
        //        do
        //        {
        //            bytesReceived = sock.Receive(receivedBuffer, receivedBuffer.Length, 0);
        //            string msg = Encoding.ASCII.GetString(receivedBuffer, 0, bytesReceived);
        //            System.Windows.Forms.MessageBox.Show("Receive function running, have a msg " + msg);
        //        }
        //        while (bytesReceived > 0);

        //    }
        //    catch (Exception e)
        //    {
        //        System.Windows.Forms.MessageBox.Show(e.Message);

        //    }

        //}

        /// <summary>
        /// Test function to ensure class has been created.
        /// </summary>
        /// <returns>
        /// String confirming class was created!
        /// </returns>
        //public string ReceiverCreated()
        //{
        //    string positive = "We've created a ReceiverClass!";
        //    return positive;
        //}
#endregion
}
