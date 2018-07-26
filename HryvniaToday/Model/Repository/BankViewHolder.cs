using System;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace HryvniaToday.Model.Repository
{
    public class BankViewHolder : RecyclerView.ViewHolder
    {
        public ImageView Image { get; set; }
        public TextView BankName { get; set; }
        public BankViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            Image = itemview.FindViewById<ImageView>(Resource.Id.BankLogoImageView);
            BankName = itemview.FindViewById<TextView>(Resource.Id.BankNameTextView);
            itemview.Click += (sender, e) => listener(base.Position);
        }
    }


}