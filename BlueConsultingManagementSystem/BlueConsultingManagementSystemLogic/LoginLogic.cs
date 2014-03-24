using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueConsultingManagementSystemLogic
{
   public class LoginLogic
    {
        string username = "user", password = "pass";

        public LoginLogic()
        {

        }

        public bool correctDetails(string user, string pass)
        {
            if (user == username && pass == password)
                return true;
            else
            return false;
        }

 

    }
}
