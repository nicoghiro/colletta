using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace colletta
{
    public class Persona
    {
        string id;
        string name;
        public Persona(string id, string name)
        {
            Id = id;
            Name = name;
          
        }

        public string Id
        {
            get { return id; }
            private set { id = value; }
        }
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }
        public override int GetHashCode()
        {
            return (id,name).GetHashCode();
        }
        public override string ToString()
        {
            return "{" + id + "}" + "{name}";
        }
        public bool equals(Persona other)
        {
            if(other == null)
            {
                return false;
            }
            if(this == other)
            {
                return true;
            }
            return(this.id == other.id);
        }
    }
}
