﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoadAndInput
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

        private void Inputname_TextChanged(object sender, EventArgs e)
        {

            button1.Enabled = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Name : " + Inputname.Text);
        }

        
    }
}
