using Android.Views;
using HryvniaToday;
using HryvniaToday.Model.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using Android.Support.V7.Widget;
using HryvniaToday.Model.Repository;
using Android.Widget;
using Android.Content;

namespace CurrencyApplication.Adapters
{
    public class BankAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public List<Bank> mPhotoAlbum;
        public List<Bank> list, reslist;

        public BankAdapter(List<Bank> photoAlbum)
        {
            mPhotoAlbum = photoAlbum;
        }
        public override int ItemCount
        {
            get { return mPhotoAlbum.Count(); }
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            BankViewHolder vh = holder as BankViewHolder;

            reslist = BankRepository.GetBanksData();
          

            vh.Image.SetImageResource(reslist.ElementAt(position).BankLogo);
            vh.BankName.Text = reslist.ElementAt(position).Title;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.BankItem, parent, false);
            BankViewHolder vh = new BankViewHolder(itemView, OnClick);
            return vh;
        }
        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);
        }

        
    }
}