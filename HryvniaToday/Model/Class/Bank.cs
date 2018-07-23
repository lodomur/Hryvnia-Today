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

namespace HryvniaToday.Model.Class
{
    public class Bank
    {
        public int Id { get; set; }
        public string OrganizationType { get; set; }
        public string Title { get; set; }
        public int BankLogo { get; set; }
        public List<Currency> Currencies { get; set; }
    }
}