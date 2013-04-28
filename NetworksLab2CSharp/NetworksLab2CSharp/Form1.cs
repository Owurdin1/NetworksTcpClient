using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace NetworksLab2CSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            ConnectClass cClass = new ConnectClass();

            string test = cClass.ConnectCreated();
            startLabel.Text = test;

            Socket sock = null;
            sock = cClass.ConnectToServer();
            cClass.ThreadBuilder(sock);
        }

        private void finishButton_Click(object sender, EventArgs e)
        {
            startLabel.Text = "";
        }

        //private unsafe void endianButton_Click(object sender, EventArgs e)
        //{
        //    int a = 0x12345678;
        //    char *c = (char*)(&a);
        //    if (*c == 0x78)
        //        startLabel.Text = "little-endian\n";
        //    else
        //        startLabel.Text = "big-endian\n";
        //}
    }
}
