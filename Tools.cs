using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Reflection;
using System.IO;

namespace BE
{
    static public class Tools
    {
        public static string toStringProperty<T>(this T t)
        {
            string str = "";
            foreach (PropertyInfo item in t.GetType().GetProperties())
            {
                str += "\n" + item.Name + ": " + item.GetValue(t, null);
            }
            return str;
        }
        static public List<T> GetNewList<T>(this List<T> oldList)
        {
            T[] arr = new T[oldList.Count];
            oldList.CopyTo(arr);
            return arr.ToList();
        }

        //public static T LoadFromXML<T>(string path)
        //{
        //    T elem;
        //    XmlSerializer x = new XmlSerializer(typeof(T));
        //    FileStream XPath = new FileStream(path, FileMode.Open);
        //    elem = (T)x.Deserialize(XPath);
        //    return elem;
        //}
        //public static void SaveToXML<T>(T elem, string path)
        //{
        //    XmlSerializer x = new XmlSerializer(typeof(T));
        //    FileStream XPath = new FileStream(path, FileMode.Create);
        //    x.Serialize(XPath, elem);
        //}

    }
}