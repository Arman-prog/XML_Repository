using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XML_Repository.Models;

namespace XML_Repository
{
   public abstract class BaseRepository<TModel> where TModel:new()
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
               yield return xnode.ToModel<TModel>();
            }
        }

        public void Add(TModel model)
        {
            var xdoc = new XmlDocument();
            xdoc.Load(FileName);

            XmlNode xnode = xdoc.ToXml(model);
            xdoc.DocumentElement.AppendChild(xnode);
            xdoc.Save(FileName);
        }

        public void AddRange(IEnumerable<TModel> models)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(FileName);

            foreach (var model in models)
            {
                XmlNode xnode = xdoc.ToXml(model);
                xdoc.DocumentElement.AppendChild(xnode);
            }
            xdoc.Save(FileName);
        }
        //protected abstract TModel ToModel(XmlNode xnode);
        
    }
}
