using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HryvniaToday.Model.Class;

namespace HryvniaToday.Model.Adapters
{
    public class CurrencyAdapter : BaseAdapter<Currency>
    {
        public List<Currency> listData;
        public Context context;

        // Contrsuctor for adapter CryptoAdapter
        public CurrencyAdapter(Context context, List<Currency> listData)
        {
            this.context = context;
            this.listData = listData;
        }

        public override Currency this[int position]
        {
            get { return listData.ElementAt(position); }
        }


        public override int Count
        {
            get { return listData.Count; }
        }


        public override long GetItemId(int position)
        {

            return listData.ElementAt(position).RecordId;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            if (view == null)
                view = LayoutInflater.From(context).Inflate(Resource.Layout.CurrencyItem, null);


            TextView CurrencyName = view.FindViewById<TextView>(Resource.Id.CurrencyName);
            CurrencyName.Text = listData.ElementAt(position).Id;

            TextView CurrencyBuy = view.FindViewById<TextView>(Resource.Id.CurrencyBuy);
            CurrencyBuy.Text = "Купівля: " + listData.ElementAt(position).Buy;

            TextView CurrencySell = view.FindViewById<TextView>(Resource.Id.CurrencySell);
            CurrencySell.Text = "Продаж: " + listData.ElementAt(position).Sell;

            //ImageView BankLogoImageView = view.FindViewById<ImageView>(Resource.Id.BankLogoImageView);
            //BankLogoImageView.SetImageResource(listData[position].BankLogo);

            Typeface type = Typeface.CreateFromAsset(context.Assets, "Oswald-Regular.ttf");
            CurrencyName.SetTypeface(type, TypefaceStyle.Normal);
            CurrencyBuy.SetTypeface(type, TypefaceStyle.Normal);
            CurrencySell.SetTypeface(type, TypefaceStyle.Normal);
            return view;

           
        }
    }
}


