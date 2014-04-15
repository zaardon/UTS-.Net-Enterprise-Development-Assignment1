using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueConsultingManagementSystemLogic
{
    public class CurrencyConverter
    {
        private double EUR = 0.680265, CND = 1.03215;
        public double ConvertDollars(String ConverType,double money )
        {
            double coney = 0.0;
            if (ConverType == "EUR")
            {
                coney = money * EUR;

            }
            else if (ConverType == "CND")
            {
                coney = money * CND;
            }
            else
            {
                //for now this is the deafualt somethings broken value
                coney = -1.0;
            }
            return coney;
        }
    }
}
