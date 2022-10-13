using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saphyre.Contact.Model
{
    public class Contact
    {

        public Guid id { get; set; }
        public string firstName { get; set; }

        public string lastName { get; set; } 

        public int age { get; set; }

        public string phone { get; set; }

        public string address { get; set; }    
        

    }
}
