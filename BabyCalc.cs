using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCalculator
{
    public partial class Form1 : Form
    {
        int num1 = 0;
        bool prev = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (prev) { textBox1.Text = ""; }
            textBox1.Text = textBox1.Text + 1.ToString();
            if (prev) { prev = false; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int num2 = Convert.ToInt32(textBox1.Text);
            int result = num1 + num2;
            textBox1.Text = result.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (prev) { textBox1.Text = ""; }
            textBox1.Text += 5.ToString();
            if (prev) { prev = false; }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            prev = true;
            num1 = Convert.ToInt32(textBox1.Text);
        }
    }
}
