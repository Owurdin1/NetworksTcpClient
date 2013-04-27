using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            string hope = cClass.ConnectCreated();

            //ReceiverClass rClass = new ReceiverClass();
            //string hope = rClass.ReceiverCreated();

            //SenderClass sClass = new SenderClass();
            //string hope = sClass.SenderCreated();

            //LogBuilder lClass = new LogBuilder();
            //string hope = lClass.LogBuilderCreated();

            startLabel.Text = hope;
        }

        private void finishButton_Click(object sender, EventArgs e)
        {
            startLabel.Text = "";
        }
    }
}
