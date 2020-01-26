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

        public static bool IsIgnodred(this PropertyInfo p)
        {
            return p.GetCustomAttribute<IgnoreAttribute>() != null;
        }

        public static T ToModel<T>(this XmlNode xnode)where T:new()
        {
            Type type = typeof(T);
            if (type.Name.ToUpper()!=xnode.Name.ToUpper())
            {
                throw new ArgumentException("Different model type");
            }

            var source = new T();
            var members = type
                .GetProperties()
                .Where(p=>!p.IsIgnodred())
                .ToDictionary(p => p.Name.ToUpper(), p => p);
            foreach (XmlNode xchild in xnode.ChildNodes)
            {
                if (members.TryGetValue(xchild.Name.ToUpper(),out PropertyInfo member))
                {
                    if (member.GetCustomAttribute<DateFormatAttribute>()!=null)
                    {
                        if (DateTime.TryParse(xchild.InnerText, out DateTime date))
                        {
                            member.SetValue(source, DateTime.Parse(xchild.InnerText));
                        }
                    }
                    else if(member.GetCustomAttribute<IdAttribute>()!=null)
                    {
                        member.SetValue(source, int.Parse( xchild.InnerText));
                    }
                    else
                    {
                        member.SetValue(source, xchild.InnerText);
                    }

                }
            }
            return source;
        }
    }
}
