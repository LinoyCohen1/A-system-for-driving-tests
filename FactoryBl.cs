using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class FactoryBl
    {
       private static Bl_imp bl = null;

        public static IBL GetBL()
        {
            if(bl==null)
                  bl = new Bl_imp();

            return bl;
        }
    }
}
