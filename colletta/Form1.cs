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
            if(totale <= raggiunto)
            {
                MessageBox.Show("obiettivo gia raggiunto");
            }
            if (totale <= 0) {
                MessageBox.Show("selezionarre un obiettivo");
            }
            Persona temp2 = new Persona(Convert.ToString(id), textBox1.Text);
            if (parteci.ContainsKey(temp2))
            {
                MessageBox.Show("questa persona sta gia facendo parte della colletta");
            }
            if (totale > 0 && raggiunto <= totale && !parteci.ContainsKey(temp2)) 
            {
                Persona temp = new Persona(Convert.ToString(id), textBox1.Text);
                Valuta temp1 = new Valuta(Convert.ToString(id), Convert.ToDouble(textBox2.Text));
                parteci.Add(temp, temp1);
                raggiunto += parteci[temp].Valore;
                comboBox1.Items.Add(temp);
                
                label8.Text = Convert.ToString(raggiunto);
                if (totale <= raggiunto)
                {
                    MessageBox.Show("obiettivo raggiunto");
                }
                id++;
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           if(textBox3.Text.All(char.IsDigit)) { 
            if (double.Parse(textBox3.Text)>0 ) { 
            totale = double.Parse(textBox3.Text);
            label5.Text= totale.ToString();
            }
                else
                {
                    MessageBox.Show("inserisci valore > 0");
                }
            }
            else
            {
                MessageBox.Show("inserisci valore valido");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(KeyValuePair<Persona,Valuta> pippo in parteci){
                if(pippo.Key.Name == comboBox1.Text)
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
                    if (pippo.Key.Name == comboBox1.Text)
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
        
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox1.Text))
            {
                Persona temp=(Persona)comboBox1.SelectedItem;
                if (parteci.ContainsKey(temp))
                {


                    raggiunto -= parteci[temp].Valore;
                    comboBox1.Items.Remove(temp);
                    parteci.Remove(temp);
                    label8.Text = Convert.ToString(raggiunto);
                    comboBox1.Text = "";
                  
                }
                else
                {
                    MessageBox.Show("elemento non esistente");
                }
            }
            else
            {
                MessageBox.Show("seleziona  un partecipante");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
