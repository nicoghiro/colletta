using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace colletta
{
    public class Valuta
    {
        string id;
        double valore;
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
        public Valuta(string i,double Val)
        {
            valore = Val;   
            id = i;
        }
        public override int GetHashCode()
        {
            return (id,valore).GetHashCode();
        }

    }
}
