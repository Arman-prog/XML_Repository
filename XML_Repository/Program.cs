using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XML_Repository.Models;

namespace XML_Repository
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentRepository studentrep = new StudentRepository(@"Data\Student.xml");
            List<Student> students = studentrep
                .AsEnumerable()
                .ToList();

            foreach (Student st in students)
            {
                Console.WriteLine(st);
            }

            XmlDocument document = new XmlDocument();
            studentrep.AddRange(students);

        }
    }
}
