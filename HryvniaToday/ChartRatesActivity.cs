
using Android.App;
using Android.OS;
using HryvniaToday.Model.Class;
using HryvniaToday.Model.Repository;
using HryvniaToday.Model.ViewModels;
using Microcharts;
using Microcharts.Droid;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HryvniaToday
{
    [Activity(Label = "ChartRatesActivity")]
    public class ChartRatesActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            // View confic - start
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ChartRatesView);

            // USD sell
            createChartByfor_USD_sell();
           
            // USD buy
            createChartByfor_USD_buy();
            




        }

        #region USD rates charts
        // Get USD chart on view

        // Methoda createChartByfor_USD_sell
        public void createChartByfor_USD_sell()
        {

            List<Entry> entryList_USD_sell = new List<Entry>();

            // Get Data by Currency USD
            List<CurrenciesRatesForBankViewModel> listData = BankRepository.GetBanksData().Select(x => new CurrenciesRatesForBankViewModel
            {
                BankName = x.Title,
                CurrenciesRates = x.Currencies.Where(z => z.Id == "USD").ToList()
            }).Where(y => y.CurrenciesRates.Count() > 0).ToList();

            int counter = 0;
            string color = "";
            // USD
            foreach (CurrenciesRatesForBankViewModel Bankitem in listData)
            {
                counter++;

                if (counter <= 5)
                {
                    color = "#266489";
                }
                if (counter > 5 && counter <= 10)
                {
                    color = "#68B9C0";
                }
                if (counter > 10)
                {
                    color = "#90D585";
                }

                entryList_USD_sell.Add(new Entry(float.Parse(Bankitem.CurrenciesRates.Select(x => x.Sell).FirstOrDefault()))
                {
                    Label = "",
                    ValueLabel = Bankitem.BankName + " (" + Bankitem.CurrenciesRates.Select(x => x.Sell).FirstOrDefault() + ")",
                    Color = SKColor.Parse(color)
                });
            }


            // USD chart config
            var chart_USD = new LineChart()
            {
                Entries = entryList_USD_sell,
                MaxValue = entryList_USD_sell.Select(x => x.Value).Max(),
                MinValue = entryList_USD_sell.Select(x => x.Value).Min()
            };
            chart_USD.BackgroundColor = SKColor.Parse("#FFFFFF");
            var chartView = FindViewById<ChartView>(Resource.Id.chartViewUSD_sell);
            chartView.Chart = chart_USD;

        }

        // Methoda createChartByfor_USD_buy
        public void createChartByfor_USD_buy()
        {

            List<Entry> entryList_USD_buy = new List<Entry>();

            // Get Data by Currency USD
            List<CurrenciesRatesForBankViewModel> listData = BankRepository.GetBanksData().Select(x => new CurrenciesRatesForBankViewModel
            {
                BankName = x.Title,
                CurrenciesRates = x.Currencies.Where(z => z.Id == "USD").ToList()
            }).Where(y => y.CurrenciesRates.Count() > 0).ToList();

            int counter = 0;
            string color = "";
            // USD
            foreach (CurrenciesRatesForBankViewModel Bankitem in listData)
            {
                counter++;

                if (counter <= 5)
                {
                    color = "#266489";
                }
                if (counter > 5 && counter <= 10)
                {
                    color = "#68B9C0";
                }
                if (counter > 10)
                {
                    color = "#90D585";
                }

                entryList_USD_buy.Add(new Entry(float.Parse(Bankitem.CurrenciesRates.Select(x => x.Buy).FirstOrDefault()))
                {
                    Label = "",
                    ValueLabel = Bankitem.BankName + " (" + Bankitem.CurrenciesRates.Select(x => x.Buy).FirstOrDefault() + ")",
                    Color = SKColor.Parse(color)
                });
            }


            // USD chart config
            var chart_USD = new LineChart()
            {
                Entries = entryList_USD_buy,
                MaxValue = entryList_USD_buy.Select(x => x.Value).Max(),
                MinValue = entryList_USD_buy.Select(x => x.Value).Min()
            };
            chart_USD.BackgroundColor = SKColor.Parse("#FFFFFF");
            var chartView = FindViewById<ChartView>(Resource.Id.chartViewUSD_buy);
            chartView.Chart = chart_USD;

        }
        #endregion

        #region EUR rates charts
        // Get EUR chart on view

        // Methoda createChartByfor_EUR_sell
        public void createChartByfor_EUR_sell()
        {

            List<Entry> entryList_EUR_sell = new List<Entry>();

            // Get Data by Currency EUR
            List<CurrenciesRatesForBankViewModel> listData = BankRepository.GetBanksData().Select(x => new CurrenciesRatesForBankViewModel
            {
                BankName = x.Title,
                CurrenciesRates = x.Currencies.Where(z => z.Id == "EUR").ToList()
            }).Where(y => y.CurrenciesRates.Count() > 0).ToList();

            int counter = 0;
            string color = "";
            // EUR
            foreach (CurrenciesRatesForBankViewModel Bankitem in listData)
            {
                counter++;

                if (counter <= 5)
                {
                    color = "#266489";
                }
                if (counter > 5 && counter <= 10)
                {
                    color = "#68B9C0";
                }
                if (counter > 10)
                {
                    color = "#90D585";
                }

                entryList_EUR_sell.Add(new Entry(float.Parse(Bankitem.CurrenciesRates.Select(x => x.Sell).FirstOrDefault()))
                {
                    Label = "",
                    ValueLabel = Bankitem.BankName + " (" + Bankitem.CurrenciesRates.Select(x => x.Sell).FirstOrDefault() + ")",
                    Color = SKColor.Parse(color)
                });
            }


            // USD chart config
            var chart_EUR = new LineChart()
            {
                Entries = entryList_EUR_sell,
                MaxValue = entryList_EUR_sell.Select(x => x.Value).Max(),
                MinValue = entryList_EUR_sell.Select(x => x.Value).Min()
            };
            chart_EUR.BackgroundColor = SKColor.Parse("#FFFFFF");
            var chartView = FindViewById<ChartView>(Resource.Id.chartViewEUR_sell);
            chartView.Chart = chart_EUR;

        }


        // Methoda createChartByfor_EUR_buy
        public void createChartByfor_EUR_buy()
        {

            List<Entry> entryList_EUR_buy = new List<Entry>();

            // Get Data by Currency EUR
            List<CurrenciesRatesForBankViewModel> listData = BankRepository.GetBanksData().Select(x => new CurrenciesRatesForBankViewModel
            {
                BankName = x.Title,
                CurrenciesRates = x.Currencies.Where(z => z.Id == "EUR").ToList()
            }).Where(y => y.CurrenciesRates.Count() > 0).ToList();

            int counter = 0;
            string color = "";
            // EUR
            foreach (CurrenciesRatesForBankViewModel Bankitem in listData)
            {
                counter++;

                if (counter <= 5)
                {
                    color = "#266489";
                }
                if (counter > 5 && counter <= 10)
                {
                    color = "#68B9C0";
                }
                if (counter > 10)
                {
                    color = "#90D585";
                }

                entryList_EUR_buy.Add(new Entry(float.Parse(Bankitem.CurrenciesRates.Select(x => x.Buy).FirstOrDefault()))
                {
                    Label = "",
                    ValueLabel = Bankitem.BankName + " (" + Bankitem.CurrenciesRates.Select(x => x.Buy).FirstOrDefault() + ")",
                    Color = SKColor.Parse(color)
                });
            }


            // USD chart config
            var chart_EUR = new LineChart()
            {
                Entries = entryList_EUR_buy,
                MaxValue = entryList_EUR_buy.Select(x => x.Value).Max(),
                MinValue = entryList_EUR_buy.Select(x => x.Value).Min()
            };
            chart_EUR.BackgroundColor = SKColor.Parse("#FFFFFF");
            var chartView = FindViewById<ChartView>(Resource.Id.chartViewEUR_buy);
            chartView.Chart = chart_EUR;

        }
        #endregion
    }
}


