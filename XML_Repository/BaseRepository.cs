using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XML_Repository.Models;

namespace XML_Repository
{
   public abstract class BaseRepository<TModel>
    {
        public string FileName { get; }

        public BaseRepository(string filename)
        {
            FileName = filename;
        }

        public IEnumerable<TModel> AsEnumerable()
        {
            var XDoc = new XmlDocument();
            XDoc.Load(FileName);
            var xRoot = XDoc.DocumentElement;

            foreach (XmlNode xnode in xRoot.ChildNodes)
            {
               yield return ToModel(xnode);
            }
        }

        protected abstract TModel ToModel(XmlNode xnode);
        
    }
}
