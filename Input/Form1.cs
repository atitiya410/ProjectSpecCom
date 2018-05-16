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
      
        private void button1_Click(object sender, EventArgs e)
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


            this.Close();
        }

        
    }
}
