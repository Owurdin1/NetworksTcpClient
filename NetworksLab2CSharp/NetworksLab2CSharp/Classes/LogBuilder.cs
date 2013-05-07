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
