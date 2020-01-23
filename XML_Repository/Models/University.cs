using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_Repository.Models
{
   public class University
    {
        public string Name { get; set; }
        public string Address { get; set; }        

        public override string ToString()
        {
            return $"{Name}\t{Address}";
        }
    }
}
