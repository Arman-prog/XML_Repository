using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XML_Repository.Models;

namespace XML_Repository
{
    public class StudentRepository : BaseRepository<Student>
    {
        public StudentRepository(string filename):base(filename)
        {

        }

        protected override Student ToModel(XmlNode xnode)
        {                    
                Student item = new Student();
            foreach (XmlNode xchild in xnode.ChildNodes)
            {
                switch (xchild.Name)
                {
                    case Keywords.FirstName:
                        item.FirstName = xchild.InnerText;
                        break;

                    case Keywords.LastName:
                        item.Lastname = xchild.InnerText;
                        break;

                    case Keywords.BirthDate:
                        if (DateTime.TryParse(xchild.InnerText, out DateTime date))
                        {
                            item.BirthDate = DateTime.Parse(xchild.InnerText);
                        }
                        break;
                }
            }    
                return item;
            
        }

    }
}
