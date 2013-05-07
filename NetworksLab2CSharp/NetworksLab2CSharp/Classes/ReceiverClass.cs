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
    class ReceiverClass
    {
        // Private variables
        private int scenarioNo;

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
            try
            {
                do
                {
                    bytesReceived = sock.Receive(receivedBuffer, receivedBuffer.Length, 0);
                    string msg = Encoding.ASCII.GetString(receivedBuffer, 0, bytesReceived);
                    System.Windows.Forms.MessageBox.Show("Receive function running, have a msg " + msg);
                }
                while (bytesReceived > 0);

            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);

            }

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
}
