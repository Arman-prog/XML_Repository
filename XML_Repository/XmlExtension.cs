using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XML_Repository.Attributes;

namespace XML_Repository
{
   public static class XmlExtension
    {
        public static XmlNode ToXml<TModel>(this XmlDocument xdoc, TModel model)
        {
            Type type = model.GetType();

            XmlNode node = xdoc.CreateNode(XmlNodeType.Element, type.Name.ToLower(), null);

            var members = type
                .GetProperties()
                .Where(p => p.GetCustomAttribute<IgnoreAttribute>() == null);

            foreach (PropertyInfo member in members)
            {
                XmlNode nodemember = xdoc.CreateElement(member.Name);
                var value = member.GetValue(model);

                var dateformat = member.GetCustomAttribute<DateFormatAttribute>();
                if (dateformat!=null)
                {
                    if (DateTime.TryParse(value.ToString(), out DateTime date))
                    {
                        nodemember.InnerText = date.ToString(dateformat.Value);
                    }
                }
                else
                {
                    nodemember.InnerText = value?.ToString();
                }
                node.AppendChild(nodemember);
            }
            return node;
                
        }
    }
}
