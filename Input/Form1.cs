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
using Newtonsoft.Json;
using SpeccomDB.Models;

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
            
            User user = new User(); 
            SendData sendData = new SendData();
            user.UserName = textBox1.Text;
            user = await sendData.CreateUser(user);
           
            //get user by name
            Services services = new Services();
            Computer com = new Computer();
            com = services.GetComputer();
            com.Memory = services.GetMemory();
            com.GraphicCard = services.getGraphicCard();
            com.DiskDrive = services.GetDiskDrive();
            com.UserId = user.UserId;
           
            string result = await sendData.CreateComputer(com);
            MessageBox.Show(result);
            }
            this.Close();
        }

        
    }
}
