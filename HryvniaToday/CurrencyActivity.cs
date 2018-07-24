﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HryvniaToday.Model.Adapters;
using HryvniaToday.Model.Class;
using HryvniaToday.Model.Repository;

namespace HryvniaToday
{
    [Activity(Label = "Курс валют в банку")]
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
            //var toolbar = FindViewById<Toolbar>(Resource.Id.toolbarCurrencyList);
            //SetActionBar(toolbar);
            //ActionBar.Title = selectedBank.Title;

        }
    }
}