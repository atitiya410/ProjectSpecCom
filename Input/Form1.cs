using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleApp1.Models;
using Newtonsoft.Json;

namespace Input
{
    public partial class Input : Form
    {
        public Input()
        {
            InitializeComponent();
        }

        private void Input_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Put your name in the textbox Name and pressing the button OK");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user = new User();
            SendData sendData = new SendData();
            user.UserName = textBox1.Text;
            sendData.CreateUser(user);
            MessageBox.Show("Success");
            this.Close();
        }
    }
}
