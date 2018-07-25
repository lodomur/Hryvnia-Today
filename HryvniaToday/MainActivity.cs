using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using HryvniaToday.Model.Class;
using CurrencyApplication.Adapters;
using HryvniaToday.Model.Repository;
using Android.Views;
using Android.Graphics;
using Android.Content;
using Android.Support.V7.Widget;
using System;
using Android.Graphics.Drawables;

namespace HryvniaToday
{
    [Activity(Label = "Гривня Today", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@style/MyTheme")]
    public class MainActivity : Activity
    {
        RecyclerView mRecycleView;
        RecyclerView.LayoutManager mLayoutManager;
        List<Bank> mPhotoAlbum;
        BankAdapter mAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            //RequestWindowFeature(WindowFeatures.CustomTitle); // Hide title bar

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            mPhotoAlbum = new List<Bank>();
            // Set our view from the "main" layout resource  
            
            mRecycleView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            mLayoutManager = new LinearLayoutManager(this);
            mRecycleView.SetLayoutManager(mLayoutManager);

            mPhotoAlbum = BankRepository.GetBanksData();

            mAdapter = new BankAdapter(mPhotoAlbum);
            mAdapter.ItemClick += MAdapter_ItemClick;
            mRecycleView.SetAdapter(mAdapter);

            var toolbar = FindViewById<Android.Widget.Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "Гривня сьогодні";
            CardView cardViewBankItem = FindViewById<CardView>(Resource.Id.BankImageCardView);
           
        }

        private void MAdapter_ItemClick(object sender, int e)
        {
            string id ="" + (e + 1);
            var activity = new Intent(this, typeof(CurrencyActivity));
            activity.PutExtra("BankId", id);
            StartActivity(activity);
            //Toast.MakeText(this, "Bank: " + photoNum, ToastLength.Short).Show();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {

            if (item.TitleFormatted.ToString() == "ChartsRates")
            {
                var activity = new Intent(this, typeof(ChartRatesActivity)); 
                StartActivity(activity);

           

    }

            return base.OnOptionsItemSelected(item);
        }

        
    }
}

