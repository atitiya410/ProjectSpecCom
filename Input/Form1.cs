using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Put your name in the textbox Name and pressing the button OK");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
  
            button1.Enabled = true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {



            if (String.IsNullOrEmpty(textBox1.Text) || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter your name!!!");
                return;
            }
            else
            {
                MessageBox.Show("Success");

            }
            User user = new User();
            SendData sendData = new SendData();
            user.UserName = textBox1.Text;
            await sendData.CreateUser(user);

            GetData getData = new GetData();
            await getData.getComputer();
            await getData.getMemory();
            await getData.getGraphicCard();
            await getData.getHDD();
            ComputerUser computerUser = new ComputerUser();
            await sendData.CreateComUser(computerUser);

            this.Close();
        }

        
    }
}
