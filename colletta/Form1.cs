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
        int id = 0;
       double totale = 0;
        double raggiunto = 0;
        Dictionary<Persona, Valuta> parteci =new Dictionary<Persona, Valuta>();
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(totale > 0 && raggiunto<=totale && totale!=null)
            {
                Persona temp = new Persona(Convert.ToString(id), "pa");
                Valuta temp1 = new Valuta(Convert.ToString(id), Convert.ToDouble(textBox2.Text));
                parteci.Add(temp, temp1);
                raggiunto += parteci[temp].Valore;
                comboBox1.Items.Add(new {Text=temp, Value=temp.Name});
                label8.Text = Convert.ToString(raggiunto);
                if (totale <= raggiunto)
                {
                    MessageBox.Show("obiettivo raggiunto");
                }
                id++;
            }
            if(totale <= raggiunto)
            {
                MessageBox.Show("obiettivo gia raggiunto");
            }
            if (totale <= 0 && totale != null) {
                MessageBox.Show("selezionarre un obiettivo");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            totale = double.Parse(textBox3.Text);
            label5.Text= totale.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(KeyValuePair<Persona,Valuta> pippo in parteci){
                if(pippo.Key.Id == comboBox1.Text)
                {
                    textBox4.Text = Convert.ToString(pippo.Value.Valore);
                }

            }
          
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox1.Text))
            {
                foreach (KeyValuePair<Persona, Valuta> pippo in parteci)
                {
                    if (pippo.Key.Id == comboBox1.Text)
                    { double temp = pippo.Value.Valore;
                    pippo.Value.Valore= double.Parse(textBox4.Text);
                    temp = pippo.Value.Valore - temp;
                    raggiunto += temp;
                    label8.Text = Convert.ToString(raggiunto);
                    }
                   
                }
                
            }
            if (totale <= raggiunto)
            {
                MessageBox.Show("obiettivo raggiunto");
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
                foreach(KeyValuePair<Persona, Valuta> pippo in parteci)
                {
                    if (pippo.Key.Equals(comboBox1.SelectedItem)){
                        raggiunto -= pippo.Value.Valore; 
                        comboBox1.Items.Remove(comboBox1.SelectedItem);
                        parteci.Remove(pippo.Key);
                        label8.Text = Convert.ToString(raggiunto); 
                        comboBox1.Text = "";
                    }
                }
                
               
                
                
               
            }
            else
            {
                MessageBox.Show("seleziona  un partecipante");
            }
        }
    }
}
