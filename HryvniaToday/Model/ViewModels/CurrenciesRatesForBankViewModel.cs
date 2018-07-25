using HryvniaToday.Model.Class;
using System.Collections.Generic;
 

namespace HryvniaToday.Model.ViewModels
{
    public class CurrenciesRatesForBankViewModel
    {
        public string BankName { get; set; }
        public List<Currency> CurrenciesRates { get; set; }
    }
}