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
    class LogBuilder
    {
        public List<string> sentMsgs = new List<string>();

        public void BuildLog(ReceiverClass rc)
        {
            string logMessage = rc.sb.ToString();

            // Open log file and print string
            string path = @"c:\Logs\Lab2.Scenario2.WurdingerO.WORKING_SERVER.txt";
            StreamWriter logWrite = File.AppendText(path);

            logWrite.Write(logMessage);
            logWrite.Close();
            //System.Windows.Forms.MessageBox.Show(logMessage);
        }

        public void BuildSentLog()
        {
            string path = @"c:\Logs\20130530_LabOutput.txt";

            StreamWriter sentWrite = File.AppendText(path);

            //foreach (string b in sentMsgs)
            //{
            //    //string value = System.Text.Encoding.ASCII.GetString(b);
            //    sentWrite.Write(b);
            //}

            for (int i = 0; i < sentMsgs.Count; i++)
            {
                //sentWrite.Write(sentMsgs[i]);
                //sentWrite.Write("test/r/n");
            }

                sentWrite.Close();
        }

        #region removeable
        //// Private Global Variables
        //private Classes.ResponseClass responseClass;

        ///// <summary>
        ///// Response Class property
        ///// </summary>
        //public Classes.ResponseClass ResponseClass
        //{
        //    get
        //    {
        //        return responseClass;
        //    }
        //    set
        //    {
        //        responseClass = value;
        //    }
        //}

        ///// <summary>
        ///// Default constructor
        ///// </summary>
        //public LogBuilder()
        //{
        //}

        ///// <summary>
        ///// non-default constructor
        ///// Takes a ResponseClass object to
        ///// be parsed for creating logs
        ///// </summary>
        ///// <param name="rc"></param>
        //public LogBuilder(Classes.ResponseClass rc)
        //{
        //    responseClass = rc;
        //}

        //public void LogWriter(int receivedBytes, byte[] receiveMsg, Socket sock)
        //{
        //    // Prepare file for IO operations
        //    string path = @"c:\Logs\Lab2.Scenario2.WurdingerO.txt";
        //    StreamWriter logWrite = File.AppendText(path);

        //    byte[] printMsg = new byte[receivedBytes];
        //    Array.Copy(receiveMsg, printMsg, receivedBytes);

        //    logWrite.Write("<CR><LF>");
        //    logWrite.Write(System.Text.Encoding.ASCII.GetString(printMsg));
        //    logWrite.Write("\r");
        //    //System.Windows.Forms.MessageBox.Show(System.Text.Encoding.ASCII.GetString(printMsg));

        //    logWrite.Close();
        //}

        //public void LogClose(Socket sock)
        //{
        //    // Prepare file for IO operations
        //    string path = @"c:\Logs\Lab2.Scenario2.WurdingerO.txt";
        //    StreamWriter logWrite = File.AppendText(path);

        //    // Socket shutdown
        //    sock.Shutdown(SocketShutdown.Receive);
        //    sock.Shutdown(SocketShutdown.Send);

        //    string date = System.DateTime.Now.ToString("MMddyyyy");
        //    string time = System.DateTime.Now.ToString("HHmmss");

        //    logWrite.Write(date + "|" + time + "|0|0|");

        //    // Close log file
        //    logWrite.Close();
        //    System.Windows.Forms.MessageBox.Show("Finished");
        //}
        #endregion
    }
}
