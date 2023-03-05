using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace colletta
{
    public partial class Form1 : Form
    {
       double totale = 0;
        double raggiunto = 0;
        Dictionary<string, double> parteci =new Dictionary<string, double>();
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(totale > 0 && raggiunto<=totale)
            {
                parteci.Add(textBox1.Text, double.Parse(textBox2.Text));
                raggiunto += parteci[textBox1.Text];
                comboBox1.Items.Add(textBox1.Text);
                label8.Text = Convert.ToString(raggiunto);
                if (totale <= raggiunto)
                {
                    MessageBox.Show("obiettivo raggiunto");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            totale = double.Parse(textBox3.Text);
            label5.Text= totale.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox4.Text = Convert.ToString(parteci[comboBox1.Text]);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox1.Text))
            {
                double temp = parteci[comboBox1.Text];
                parteci[comboBox1.Text] = double.Parse(textBox4.Text);
                temp = parteci[comboBox1.Text] - temp;
                raggiunto += temp;
                label8.Text = Convert.ToString(raggiunto);
                if (totale <= raggiunto)
                {
                    MessageBox.Show("obiettivo raggiunto");
                }
            }
            else
            {
                MessageBox.Show("seleziona  un partecipante");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox1.Text))
            {
                raggiunto -= parteci[comboBox1.Text];
                comboBox1.Items.Remove(comboBox1.Text);
                parteci.Remove(comboBox1.Text);
                label8.Text = Convert.ToString(raggiunto);
                comboBox1.Text = "";
            }
            else
            {
                MessageBox.Show("seleziona  un partecipante");
            }
        }
    }
}
