using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using HryvniaToday;
using HryvniaToday.Model.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using Android.Views;

namespace CurrencyApplication.Adapters
{
    public class BankAdapter : BaseAdapter<Bank>
    {
        public List<Bank> listData;
        public Context context;

        // Contrsuctor for adapter CryptoAdapter
        public BankAdapter(Context context, List<Bank> listData)
        {
            this.context = context;
            this.listData = listData;
        }

        public override Bank this[int position]
        {
            get { return listData.ElementAt(position); }
        }


        public override int Count
        {
            get { return listData.Count; }
        }


        public override long GetItemId(int position)
        {  
            
            return (long)Convert.ToDouble(listData.ElementAt(position).Id);
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            if (view == null)
                view = LayoutInflater.From(context).Inflate(Resource.Layout.BankItem, null);


            TextView BankNameListView = view.FindViewById<TextView>(Resource.Id.BankNameTextView);
            BankNameListView.Text = listData.ElementAt(position).Title;

            ImageView BankLogoImageView = view.FindViewById<ImageView>(Resource.Id.BankLogoImageView);
            BankLogoImageView.SetImageResource(listData[position].BankLogo);

            Typeface type = Typeface.CreateFromAsset(context.Assets, "Oswald-Regular.ttf");
            BankNameListView.SetTypeface(type,TypefaceStyle.Normal);
            return view;
        }
    }
}