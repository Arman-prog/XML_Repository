using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XML_Repository.Models;

namespace XML_Repository
{
    public class UniversityRepository : BaseRepository<University>
    {
        public UniversityRepository(string filename) : base(filename)
        {

        }

        //protected override University ToModel(XmlNode xnode)
        //{
        //    University item = new University();
        //    foreach (XmlNode xchild in xnode.ChildNodes)
        //    {
        //        switch (xchild.Name)
        //        {
        //            case UniverKeywords.Name:
        //                item.Name = xchild.InnerText;
        //                break;

        //            case UniverKeywords.Address:
        //                item.Address = xchild.InnerText;
        //                break;   
        //        }
        //    }
        //    return item;
        //}


    }
}
