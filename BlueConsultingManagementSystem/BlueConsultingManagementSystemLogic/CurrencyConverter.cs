namespace BlueConsultingManagementSystemLogic
{
    public static class CurrencyConverter
    {
        const double EUR = 0.680265;
        const double CNY = 1.03215;
        const double USD = 0.94;
        const double AUD = 1.00;

        public static double ConvertCurrencyToAUD(string currency, double amount)
        {
            switch (currency)
            {
                case "EUR":
                    return amount * EUR;
                case "CNY":
                    return amount * CNY;
                case "USD":
                    return amount * USD;
                case "AUD":
                    return amount;
                default:
                    return -1.0;
            }
        }
    }
}
