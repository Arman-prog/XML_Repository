using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_Repository
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentRepository strep = new StudentRepository(@"Data\Student.xml");
            var stlist = strep.AsEnumerable().ToList();
            Console.WriteLine("students\n");
            foreach (var st in stlist)
            {
                Console.WriteLine(st);
            }
            Console.WriteLine();
            //TeacherRepository tcrep = new TeacherRepository(@"Data\Teacher.xml");

            //var tclist = tcrep.AsEnumerable().ToList();

            //Console.WriteLine("Teachers\n");
            //foreach (var tc in tclist)
            //{
            //    Console.WriteLine(tc);
            //}
            //Console.WriteLine();
            //UniversityRepository unrep = new UniversityRepository(@"Data\University.xml");
            //var unlist = unrep.AsEnumerable().ToList();
            //Console.WriteLine("Universities\n");
            //foreach (var univer in unrep.AsEnumerable())
            //{
            //    Console.WriteLine(univer);
            //}

            strep.Add(new Models.Student { BirthDate = DateTime.Now.AddYears(-20), FirstName = "Vaxinak", Lastname = "Sardaryan" });
           

           
        }
    }
}
