using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace colletta
{
    public class Valuta:IComparable<Valuta>
    {
        string id;
        double valore;
        string tipo { get; set; }
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public double Valore
        {
            get { return valore; }
            set { valore = value; }
        }
        public Valuta(string i,double Val,string tipo)
        {
            if(tipo == "€") 
            valore = Val;
            if (tipo == "$")
            valore = Val * 0.93;
            if (tipo == "£")
            valore = Val * 1.13;
            id = i;
            this.tipo = tipo;
        }
        public override int GetHashCode()
        {
            return (id).GetHashCode();
        }
        public double getEuro()
        {
            return valore;
        }
        public double getDollaro()
        {
            return valore * 1.07;
        }
        public double getSterlina()
        {
            return valore *0.88 ;
        }
        public void setEuro(double Val)
        {
            valore = Val;
        }
        public void setSterlina(double Val)
        {
            valore = Val * 1.13;
        }
        public void setDollaro(double Val)
        {
            valore = Val * 0.93;
        }
        public int CompareTo(Valuta val)
        {
            return valore.CompareTo(valore);
        }
    }
}
