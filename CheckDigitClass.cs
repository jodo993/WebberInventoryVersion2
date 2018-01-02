using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webber_Inventory_Search_2017_2018
{
    class CheckDigitClass
    {
        // Check entered string to make sure it is all digits
        public bool digitOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                        return false;
            }
            return true;
        }
    }
}
