using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueConsultingManagementSystemLogic
{
    public class InputChecker
    {

        public InputChecker()
        { }


        public bool HasNonAlphaNumCharacters(string checkString)
        {
             if(!checkString.All(Char.IsLetterOrDigit))
                 return true;
             else
                 return false;
        }
    }


}
