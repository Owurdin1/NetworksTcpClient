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

            // Set scenario Number for ConnectClass
            cClass.ScenarioNo = Convert.ToInt32(scenarioListBox.SelectedItem);

            // Create Socket and ask ConnectClass to connect
            //Socket sock = null;
            //sock = cClass.ConnectToServer();

            // Call the thread building funciton to begin send/receive
            //cClass.ThreadBuilder(sock);
         }

        private void finishButton_Click(object sender, EventArgs e)
        {
            startLabel.Text = "";
            startButton.Enabled = false;
            scenarioListBox.ClearSelected();
        }

        private void scenarioListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (scenarioListBox.SelectedIndex != -1)
            {
                startButton.Enabled = true;
            }
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
