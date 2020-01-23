using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_Repository.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
   public class DateFormatAttribute : Attribute
    {
        public string Value { get; }
        public DateFormatAttribute(string value)
        {
            Value = value;
        }
        public DateFormatAttribute():this("dd/MM/yyyy")
        {

        }
    }
}
