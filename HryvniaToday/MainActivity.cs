using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using HryvniaToday.Model.Class;
using CurrencyApplication.Adapters;
using HryvniaToday.Model.Repository;
using Android.Views;

namespace HryvniaToday
{
    [Activity(Label = "Гривня Today", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@style/MyTheme")]
    public class MainActivity : Activity
    {

        ListView listViewBanks;
        public List<Bank> list, reslist;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            //RequestWindowFeature(WindowFeatures.CustomTitle); // Hide title bar

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            list = new List<Bank>();
            reslist = new List<Bank>();

            list.AddRange(BankRepository.GetBanksData());

            int counterId = 0;
            foreach (Bank bankItem in list)
            {
                switch (bankItem.Title)
                {
                    case "ПриватБанк":
                        counterId++;
                        bankItem.Id = counterId;
                        bankItem.BankLogo = Resource.Drawable.PrivatBank;
                        reslist.Add(bankItem);
                        break;
                    case "Європошта":
                        counterId++;
                        bankItem.Id = counterId;
                        bankItem.BankLogo = Resource.Drawable.ukrpost;
                        reslist.Add(bankItem);
                        break;
                    case "Ідея Банк":
                        counterId++;
                        bankItem.Id = counterId;
                        bankItem.BankLogo = Resource.Drawable.idea_bank;
                        reslist.Add(bankItem);
                        break;
                    case "Альфа-Банк":
                        counterId++;
                        bankItem.Id = counterId;
                        bankItem.BankLogo = Resource.Drawable.alfa_Bank;
                        reslist.Add(bankItem);
                        break;
                    case "Кредобанк":
                        counterId++;
                        bankItem.Id = counterId;
                        bankItem.BankLogo = Resource.Drawable.kredobankpl;
                        reslist.Add(bankItem);
                        break;
                    case "Креді Агріколь Банк":
                        counterId++;
                        bankItem.Id = counterId;
                        bankItem.BankLogo = Resource.Drawable.creditagricol;
                        reslist.Add(bankItem);
                        break;
                    case "Мiсто Банк":
                        counterId++;
                        bankItem.Id = counterId;
                        bankItem.BankLogo = Resource.Drawable.misto_bank;
                        reslist.Add(bankItem);
                        break;
                    case "ОТП Банк":
                        counterId++;
                        bankItem.Id = counterId;
                        bankItem.BankLogo = Resource.Drawable.otp_bank;
                        reslist.Add(bankItem);
                        break;
                    case "Ощадбанк":
                        counterId++;
                        bankItem.Id = counterId;
                        bankItem.BankLogo = Resource.Drawable.oshchadbank;
                        reslist.Add(bankItem);
                        break;
                    case "ПУМБ":
                        counterId++;
                        bankItem.Id = counterId;
                        bankItem.BankLogo = Resource.Drawable.pumb;
                        reslist.Add(bankItem);
                        break;
                    case "Райффайзен Банк Аваль":
                        counterId++;
                        bankItem.Id = counterId;
                        bankItem.BankLogo = Resource.Drawable.rfba;
                        reslist.Add(bankItem); reslist.Add(bankItem);
                        break;
                    case "Сбербанк":
                        counterId++;
                        bankItem.Id = counterId;
                        bankItem.BankLogo = Resource.Drawable.sberbank;
                        reslist.Add(bankItem);
                        break;
                    case "Укргазбанк":
                        counterId++;
                        bankItem.Id = counterId;
                        bankItem.BankLogo = Resource.Drawable.ukrgaz;
                        reslist.Add(bankItem);
                        break;
                    case "Укрсиббанк":
                        counterId++;
                        bankItem.Id = counterId;
                        bankItem.BankLogo = Resource.Drawable.ukrsibbank;
                        reslist.Add(bankItem);
                        break;
                    case "Укрсоцбанк":
                        counterId++;
                        bankItem.Id = counterId;
                        bankItem.BankLogo = Resource.Drawable.ukrsoc;
                        reslist.Add(bankItem);
                        break;
                    case "Юнекс Банк":
                        counterId++;
                        bankItem.Id = counterId;
                        bankItem.BankLogo = Resource.Drawable.unex;
                        reslist.Add(bankItem);
                        break;
                    default:
                        // reslist.Add(bankItem);
                        break;
                }
            }

            listViewBanks = FindViewById<ListView>(Resource.Id.listViewBanks);
            reslist.Reverse();
            reslist.RemoveAt(4); // RFB duplicate
            BankAdapter adapter = new BankAdapter(this, reslist);
            listViewBanks.Adapter = adapter;

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "Гривня сьогодні";


        }
    }
}

