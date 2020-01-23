using System;
using XML_Repository.Attributes;

namespace XML_Repository.Models
{
   public class Teacher
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        [Ignore]
        public string FullName => $"{FirstName} {Lastname}";
        [DateFormat]
        public DateTime BirthDate { get; set; }
        public int Age
        {
            get
            {
                TimeSpan age = DateTime.Now - BirthDate;
                return age.Days / 365;
            }
        }

        public override string ToString()
        {
            return $"{FirstName}\t{Lastname}\t{Age}";
        }
    }
}
