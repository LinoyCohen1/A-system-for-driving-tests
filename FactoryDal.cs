using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FactoryDal
    {
       // private static Dal_XML_imp instance1 = null;
      private static Dal_imp instance = null;
        //public static Idal getDal()
        //{
        //    // return new Dal_imp();
        //    return new DAL_XML_imp();
        //}
        //private FactoryDal()
        //{
        //    t++;
        //}
        public static IDAL getDal
        {
            get
            {
                if (instance == null)
               // if (instance1 == null)
                {
                    Console.WriteLine("first time initializing");
                   //instance1 = new Dal_XML_imp();
                    instance = new Dal_imp();

                }

               //eturn instance1;
               return instance;

            }
        }
    }
}