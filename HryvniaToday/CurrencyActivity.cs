using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HryvniaToday.Model.Adapters;
using HryvniaToday.Model.Class;
using HryvniaToday.Model.Repository;

namespace HryvniaToday
{
    [Activity(Label = "Курс валют в банку", Theme = "@style/MyTheme")]
    public class CurrencyActivity : Activity
    {
        ListView listViewCurrency;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            // OnCreate
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CurrencyListForBank);

            // Get data from another view
            string idSelected = Intent.GetStringExtra("BankId") ?? string.Empty;
            int BankId = Int32.Parse(idSelected);
            Bank selectedBank = BankRepository.GetBanksData().Where(x => x.Id == BankId).FirstOrDefault();

            // List view adapter
            List<Currency> bankcurrencyList = new List<Currency>();

            foreach (Currency itemCurrency in selectedBank.Currencies)
            {
                if (itemCurrency.Id == "USD")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.USD;
                }
                if (itemCurrency.Id == "EUR")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.EUR;
                }
                if (itemCurrency.Id == "RUB")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.RUB;
                }
                if (itemCurrency.Id == "PLN")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.PLN;
                }
                if (itemCurrency.Id == "GBP")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.GBP;
                }
                if (itemCurrency.Id == "CZK")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.CZK;
                }
                if (itemCurrency.Id == "CHF")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.CHF;
                }
                if (itemCurrency.Id == "JPY")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.JPY;
                }
                if (itemCurrency.Id == "BYN")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.BYN;
                }
                if (itemCurrency.Id == "CAD")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.CAD;
                }
                if (itemCurrency.Id == "BGN")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.BGN;
                }
                if (itemCurrency.Id == "CNY")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.CNY;
                }
                if (itemCurrency.Id == "AED")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.AED;
                }
                if (itemCurrency.Id == "AMD")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.AMD;
                }
                if (itemCurrency.Id == "GEL")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.GEL;
                }
                if (itemCurrency.Id == "HKD")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.HKD;
                }
                if (itemCurrency.Id == "HRK")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.HRK;
                }
                if (itemCurrency.Id == "AUD")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.AUD;
                }
                if (itemCurrency.Id == "AZN")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.AZN;
                }
                if (itemCurrency.Id == "BRL")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.BRL;
                }
                if (itemCurrency.Id == "CLP")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.CLP;
                }
                if (itemCurrency.Id == "DKK")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.DKK;
                }
                if (itemCurrency.Id == "EGP")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.EGP;
                }
                if (itemCurrency.Id == "KGS")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.KGS;
                }
                if (itemCurrency.CurrencyLogo == 0){
                    itemCurrency.CurrencyLogo = Resource.Drawable.UNKOWN;
                }
                if (itemCurrency.Id == "HUF")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.HUF;
                }
                if (itemCurrency.Id == "ILS")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.ILS;
                }
                if (itemCurrency.Id == "KRW")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.KWD;
                }
                if (itemCurrency.Id == "KZT")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.KZT;
                }
                if (itemCurrency.Id == "LBP")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.LBP;
                }
                if (itemCurrency.Id == "MDL")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.MDL;
                }
                if (itemCurrency.Id == "MXN")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.MXN;
                }
                if (itemCurrency.Id == "NOK")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.NOK;
                }
                if (itemCurrency.Id == "NZD")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.NZD;
                }
                if (itemCurrency.Id == "PKR")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.PKR;
                }
                if (itemCurrency.Id == "RON")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.RON;
                }
                if (itemCurrency.Id == "SAR")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.SAR;
                }
                if (itemCurrency.Id == "SEK")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.SEK;
                }
                if (itemCurrency.Id == "SGD")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.SGD;
                }
                if (itemCurrency.Id == "THB")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.THB;
                }
                if (itemCurrency.Id == "TJS")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.TJS;
                }
                if (itemCurrency.Id == "TRY")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.TRY_;
                }
                if (itemCurrency.Id == "INR")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.INR;
                }
                if (itemCurrency.Id == "KWD")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.KWD;
                }
                if (itemCurrency.Id == "TWD")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.TWD;
                }
                if (itemCurrency.Id == "VND")
                {
                    itemCurrency.CurrencyLogo = Resource.Drawable.VND;
                }
            }

            int id = 0;
            foreach (Currency itemCurrency in selectedBank.Currencies)
            {
                id++;
                itemCurrency.RecordId = id;
                bankcurrencyList.Add(itemCurrency);
            }

            listViewCurrency = FindViewById<ListView>(Resource.Id.listViewCurrencyFromBank);
            CurrencyAdapter adapter = new CurrencyAdapter(this, bankcurrencyList);
            listViewCurrency.Adapter = adapter;

            // Toolbar
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbarCurrencyList);
            SetActionBar(toolbar);
            ActionBar.Title = selectedBank.Title;


             

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menu_back_change, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {


            if (item.TitleFormatted.ToString() == "Back")
            {
                this.Finish();
            }

            if (item.TitleFormatted.ToString() == "Calculate")
            {
                var activity = new Intent(this, typeof(ConvertorCurrencyActivity));
                StartActivity(activity);
            }

            return base.OnOptionsItemSelected(item);
        }

    }
}