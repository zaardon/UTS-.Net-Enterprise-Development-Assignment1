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

        /*
         * Checks to see if an input field contains any characters that are of punctuation
         */
        public bool HasPunctuationCharacters(string checkString)
        {
            foreach (Char c in checkString)
            {
                if (Char.IsPunctuation(c))
                    return true;
            }
            return false;
        }
    }


}
