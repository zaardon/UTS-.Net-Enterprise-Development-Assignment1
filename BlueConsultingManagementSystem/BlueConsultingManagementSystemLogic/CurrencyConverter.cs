using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueConsultingManagementSystemLogic
{
    public class CurrencyConverter
    {
        private double EUR = 1.49, CNY = 0.172175, AUD = 1.00;

        public double ConvertCurrencyToAUD(String ConvertType, double money)
        {
            double conversion = 0.0;

            if (ConvertType == "EUR")
                conversion = money * EUR;
            else if (ConvertType == "CNY")
                conversion = money * CNY;
            else if (ConvertType == "AUD")
                conversion = money * AUD;

            return conversion;
        }
    }
}
