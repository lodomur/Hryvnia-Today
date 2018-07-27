using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace HryvniaToday.Model.ViewModels
{
    public class RateValueAndBankNameViewModel
    {
        public string BankName { get; set; }
        public float CurrencyRateSingle { get; set; }
    }
}