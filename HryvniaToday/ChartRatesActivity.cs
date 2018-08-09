
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
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
    [Activity(Label = "Банки за сьогодні", Theme = "@style/MyTheme")]
    public class ChartRatesActivity : Activity
    {

        public PointChart pc = new PointChart();


        protected override void OnCreate(Bundle savedInstanceState)
        {
            pc.LabelOrientation = Microcharts.Orientation.Vertical;
            pc.ValueLabelOrientation = Microcharts.Orientation.Vertical;

            // View config
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ChartRatesView);

            // USD sell
            createChartByfor_USD_sell("USD");

            // USD buy
            createChartByfor_USD_buy("USD");

            // EUR sell
            createChartByfor_EUR_sell("EUR");

            // EUR buy
            createChartByfor_EUR_buy("EUR");

            // PLN sell
            createChartByfor_PLN_sell("PLN");

            // PLN buy
            createChartByfor_PLN_buy("PLN");

            // RUB sell
            createChartByfor_RUB_sell("RUB");

            // RUB buy
            createChartByfor_RUB_buy("RUB");

            // Toolbar
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbarCurrencyList);
            SetActionBar(toolbar);
            ActionBar.Title = "Візуалізація курсів";

            //Typeface type = Typeface.CreateFromAsset(this.Assets, "Oswald-Regular.ttf");

            //var USDRateTextView_sell = FindViewById<TextView>(Resource.Id.USDRateTextView_sell);
            //USDRateTextView_sell.SetTypeface(type, TypefaceStyle.Normal);

            //var USDRateTextView_buy = FindViewById<TextView>(Resource.Id.USDRateTextView_buy);
            //USDRateTextView_buy.SetTypeface(type, TypefaceStyle.Normal);

            //var EURRateTextView_buy = FindViewById<TextView>(Resource.Id.EURRateTextView_buy);
            //EURRateTextView_buy.SetTypeface(type, TypefaceStyle.Normal);

            //var EURRateTextView_sell = FindViewById<TextView>(Resource.Id.EURRateTextView_sell);
            //EURRateTextView_sell.SetTypeface(type, TypefaceStyle.Normal);

            //var RUBRateTextView_buy = FindViewById<TextView>(Resource.Id.RUBRateTextView_buy);
            //RUBRateTextView_buy.SetTypeface(type, TypefaceStyle.Normal);

            //var RUBRateTextView_sell = FindViewById<TextView>(Resource.Id.RUBRateTextView_sell);
            //RUBRateTextView_sell.SetTypeface(type, TypefaceStyle.Normal);

            //var PLNRateTextView_buy = FindViewById<TextView>(Resource.Id.PLNRateTextView_buy);
            //PLNRateTextView_buy.SetTypeface(type, TypefaceStyle.Normal);

            //var PLNRateTextView_sell = FindViewById<TextView>(Resource.Id.PLNRateTextView_sell);
            //PLNRateTextView_sell.SetTypeface(type, TypefaceStyle.Normal);


        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menu_back, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {


            if (item.TitleFormatted.ToString() == "Back")
            {
                this.Finish();
            }

            return base.OnOptionsItemSelected(item);
        }

        #region USD rates charts
        // Get USD chart on view

        // Methoda createChartByfor_USD_sell
        public void createChartByfor_USD_sell(string currencyName)
        {

            List<Entry> entryList = new List<Entry>();
            List<CurrenciesRatesForBankViewModel> listData = BankRepository.GetBanksData().Select(x => new CurrenciesRatesForBankViewModel
            {
                BankName = x.Title,
                CurrenciesRates = x.Currencies.Where(z => z.Id == currencyName).ToList()
            }).Where(y => y.CurrenciesRates.Count() > 0).ToList();

            // Type rate
            List<RateValueAndBankNameViewModel> sourceTable = listData.Select(x => new RateValueAndBankNameViewModel
            {
                BankName = x.BankName,
                CurrencyRateSingle = float.Parse(x.CurrenciesRates.Select(f => f.Sell).FirstOrDefault())
            }).OrderBy(x => x.CurrencyRateSingle).ToList();

            int counter = 0;
            string color = "";


            int start_1 = (int)sourceTable.Count() / 3;
            int start_2 = start_1 * 2;


            foreach (RateValueAndBankNameViewModel Bankitem in sourceTable)
            {
                counter++;

                if (counter <= start_1)
                {
                    color = "#266489";
                }
                if (counter > start_1 && counter <= start_2)
                {
                    color = "#68B9C0";
                }
                if (counter > start_2)
                {
                    color = "#90D585";
                }

                if (Bankitem.BankName.Equals("Райффайзен Банк Аваль"))
                {
                    Bankitem.BankName = "Райффайзен Б. А.";
                }

                if (Bankitem.BankName.Equals("Креді Агріколь Банк"))
                {
                    Bankitem.BankName = "Креді Агріколь Б.";
                }

                entryList.Add(new Entry(Bankitem.CurrencyRateSingle)
                {
                    Label = Bankitem.BankName,
                    ValueLabel = string.Format("{0:F3}", Bankitem.CurrencyRateSingle),
                    Color = SKColor.Parse(color),
                    TextColor = SKColor.Parse(color),
                });
            }

            var chart = new LineChart()
            {
                Entries = entryList,
                MaxValue = entryList.Select(x => x.Value).Max(),
                MinValue = entryList.Select(x => x.Value).Min(),
                ValueLabelOrientation = pc.ValueLabelOrientation,
                LabelOrientation = pc.LabelOrientation,
                LabelTextSize = 18,
            };

            chart.BackgroundColor = SKColor.Parse("#FFFFFF");

            var chartView = FindViewById<ChartView>(Resource.Id.chartViewUSD_sell);
            chartView.Chart = chart;

        }

        // Methoda createChartByfor_USD_buy
        public void createChartByfor_USD_buy(string currencyName)
        {

            List<Entry> entryList = new List<Entry>();
            List<CurrenciesRatesForBankViewModel> listData = BankRepository.GetBanksData().Select(x => new CurrenciesRatesForBankViewModel
            {
                BankName = x.Title,
                CurrenciesRates = x.Currencies.Where(z => z.Id == currencyName).ToList()
            }).Where(y => y.CurrenciesRates.Count() > 0).ToList();

            // Type rate
            List<RateValueAndBankNameViewModel> sourceTable = listData.Select(x => new RateValueAndBankNameViewModel
            {
                BankName = x.BankName,
                CurrencyRateSingle = float.Parse(x.CurrenciesRates.Select(f => f.Buy).FirstOrDefault())
            }).OrderBy(x => x.CurrencyRateSingle).ToList();

            int counter = 0;
            string color = "";

            int start_1 = (int)sourceTable.Count() / 3;
            int start_2 = start_1 * 2;

            foreach (RateValueAndBankNameViewModel Bankitem in sourceTable)
            {
                counter++;

                if (counter <= start_1)
                {
                    color = "#90D585";
                }
                if (counter > start_1 && counter <= start_2)
                {
                    color = "#68B9C0";
                }
                if (counter > start_2)
                {
                    color = "#266489";
                }

                if (Bankitem.BankName.Equals("Райффайзен Банк Аваль"))
                {
                    Bankitem.BankName = "Райффайзен Б. А.";
                }

                if (Bankitem.BankName.Equals("Креді Агріколь Банк"))
                {
                    Bankitem.BankName = "Креді Агріколь Б.";
                }

                entryList.Add(new Entry(Bankitem.CurrencyRateSingle)
                {
                    Label = Bankitem.BankName,
                    ValueLabel = string.Format("{0:F3}", Bankitem.CurrencyRateSingle),
                    Color = SKColor.Parse(color),
                    TextColor = SKColor.Parse(color),
                });
            }

            var chart = new LineChart()
            {
                Entries = entryList,
                MaxValue = entryList.Select(x => x.Value).Max(),
                MinValue = entryList.Select(x => x.Value).Min(),
                ValueLabelOrientation = pc.ValueLabelOrientation,
                LabelOrientation = pc.LabelOrientation,
                LabelTextSize = 18,
            };

            chart.BackgroundColor = SKColor.Parse("#FFFFFF");

            var chartView = FindViewById<ChartView>(Resource.Id.chartViewUSD_buy);
            chartView.Chart = chart;

        }
        #endregion

        #region EUR rates charts
        // Get EUR chart on view

        // Methoda createChartByfor_EUR_sell
        public void createChartByfor_EUR_sell(string currencyName)
        {

            List<Entry> entryList = new List<Entry>();
            List<CurrenciesRatesForBankViewModel> listData = BankRepository.GetBanksData().Select(x => new CurrenciesRatesForBankViewModel
            {
                BankName = x.Title,
                CurrenciesRates = x.Currencies.Where(z => z.Id == currencyName).ToList()
            }).Where(y => y.CurrenciesRates.Count() > 0).ToList();

            // Type rate
            List<RateValueAndBankNameViewModel> sourceTable = listData.Select(x => new RateValueAndBankNameViewModel
            {
                BankName = x.BankName,
                CurrencyRateSingle = float.Parse(x.CurrenciesRates.Select(f => f.Sell).FirstOrDefault())
            }).OrderBy(x => x.CurrencyRateSingle).ToList();

            int counter = 0;
            string color = "";


            int start_1 = (int)sourceTable.Count() / 3;
            int start_2 = start_1 * 2;


            foreach (RateValueAndBankNameViewModel Bankitem in sourceTable)
            {
                counter++;

                if (counter <= start_1)
                {
                    color = "#266489";
                }
                if (counter > start_1 && counter <= start_2)
                {
                    color = "#68B9C0";
                }
                if (counter > start_2)
                {
                    color = "#90D585";
                }

                if (Bankitem.BankName.Equals("Райффайзен Банк Аваль"))
                {
                    Bankitem.BankName = "Райффайзен Б. А.";
                }

                if (Bankitem.BankName.Equals("Креді Агріколь Банк"))
                {
                    Bankitem.BankName = "Креді Агріколь Б.";
                }

                entryList.Add(new Entry(Bankitem.CurrencyRateSingle)
                {
                    Label = Bankitem.BankName,
                    ValueLabel = string.Format("{0:F3}", Bankitem.CurrencyRateSingle),
                    Color = SKColor.Parse(color),
                    TextColor = SKColor.Parse(color),
                });
            }

            var chart = new LineChart()
            {
                Entries = entryList,
                MaxValue = entryList.Select(x => x.Value).Max(),
                MinValue = entryList.Select(x => x.Value).Min(),
                ValueLabelOrientation = pc.ValueLabelOrientation,
                LabelOrientation = pc.LabelOrientation,
                LabelTextSize = 18,
            };

            chart.BackgroundColor = SKColor.Parse("#FFFFFF");

            var chartView = FindViewById<ChartView>(Resource.Id.chartViewEUR_sell);
            chartView.Chart = chart;

        }


        // Methoda createChartByfor_EUR_buy
        public void createChartByfor_EUR_buy(string currencyName)
        {
            List<Entry> entryList = new List<Entry>();
            List<CurrenciesRatesForBankViewModel> listData = BankRepository.GetBanksData().Select(x => new CurrenciesRatesForBankViewModel
            {
                BankName = x.Title,
                CurrenciesRates = x.Currencies.Where(z => z.Id == currencyName).ToList()
            }).Where(y => y.CurrenciesRates.Count() > 0).ToList();

            // Type rate
            List<RateValueAndBankNameViewModel> sourceTable = listData.Select(x => new RateValueAndBankNameViewModel
            {
                BankName = x.BankName,
                CurrencyRateSingle = float.Parse(x.CurrenciesRates.Select(f => f.Buy).FirstOrDefault())
            }).OrderBy(x => x.CurrencyRateSingle).ToList();

            int counter = 0;
            string color = "";

            int start_1 = (int)sourceTable.Count() / 3;
            int start_2 = start_1 * 2;

            foreach (RateValueAndBankNameViewModel Bankitem in sourceTable)
            {
                counter++;

                if (counter <= start_1)
                {
                    color = "#90D585";
                }
                if (counter > start_1 && counter <= start_2)
                {
                    color = "#68B9C0";
                }
                if (counter > start_2)
                {
                    color = "#266489";
                }

                if (Bankitem.BankName.Equals("Райффайзен Банк Аваль"))
                {
                    Bankitem.BankName = "Райффайзен Б. А.";
                }

                if (Bankitem.BankName.Equals("Креді Агріколь Банк"))
                {
                    Bankitem.BankName = "Креді Агріколь Б.";
                }

                entryList.Add(new Entry(Bankitem.CurrencyRateSingle)
                {
                    Label = Bankitem.BankName,
                    ValueLabel = string.Format("{0:F3}", Bankitem.CurrencyRateSingle),
                    Color = SKColor.Parse(color),
                    TextColor = SKColor.Parse(color),
                });
            }

            var chart = new LineChart()
            {
                Entries = entryList,
                MaxValue = entryList.Select(x => x.Value).Max(),
                MinValue = entryList.Select(x => x.Value).Min(),
                ValueLabelOrientation = pc.ValueLabelOrientation,
                LabelOrientation = pc.LabelOrientation,
                LabelTextSize = 18,
            };

            chart.BackgroundColor = SKColor.Parse("#FFFFFF");

            var chartView = FindViewById<ChartView>(Resource.Id.chartViewEUR_buy);
            chartView.Chart = chart;
        }
        #endregion

        #region PLN rates charts
        // Get PLN chart on view

        // Methoda createChartByfor_PLN_sell
        public void createChartByfor_PLN_sell(string currencyName)
        {

            List<Entry> entryList = new List<Entry>();
            List<CurrenciesRatesForBankViewModel> listData = BankRepository.GetBanksData().Select(x => new CurrenciesRatesForBankViewModel
            {
                BankName = x.Title,
                CurrenciesRates = x.Currencies.Where(z => z.Id == currencyName).ToList()
            }).Where(y => y.CurrenciesRates.Count() > 0).ToList();

            // Type rate
            List<RateValueAndBankNameViewModel> sourceTable = listData.Select(x => new RateValueAndBankNameViewModel
            {
                BankName = x.BankName,
                CurrencyRateSingle = float.Parse(x.CurrenciesRates.Select(f => f.Sell).FirstOrDefault())
            }).OrderBy(x => x.CurrencyRateSingle).ToList();

            int counter = 0;
            string color = "";


            int start_1 = (int)sourceTable.Count() / 3;
            int start_2 = start_1 * 2;


            foreach (RateValueAndBankNameViewModel Bankitem in sourceTable)
            {
                counter++;

                if (counter <= start_1)
                {
                    color = "#266489";
                }
                if (counter > start_1 && counter <= start_2)
                {
                    color = "#68B9C0";
                }
                if (counter > start_2)
                {
                    color = "#90D585";
                }

                if (Bankitem.BankName.Equals("Райффайзен Банк Аваль"))
                {
                    Bankitem.BankName = "Райффайзен Б. А.";
                }

                if (Bankitem.BankName.Equals("Креді Агріколь Банк"))
                {
                    Bankitem.BankName = "Креді Агріколь Б.";
                }

                entryList.Add(new Entry(Bankitem.CurrencyRateSingle)
                {
                    Label = Bankitem.BankName,
                    ValueLabel = string.Format("{0:F3}", Bankitem.CurrencyRateSingle),
                    Color = SKColor.Parse(color),
                    TextColor = SKColor.Parse(color),
                });
            }

            var chart = new LineChart()
            {
                Entries = entryList,
                MaxValue = entryList.Select(x => x.Value).Max(),
                MinValue = entryList.Select(x => x.Value).Min(),
                ValueLabelOrientation = pc.ValueLabelOrientation,
                LabelOrientation = pc.LabelOrientation,
                LabelTextSize = 18,
            };

            chart.BackgroundColor = SKColor.Parse("#FFFFFF");

            var chartView = FindViewById<ChartView>(Resource.Id.chartViewPLN_sell);
            chartView.Chart = chart;

        }


        // Methoda createChartByfor_PLN_buy
        public void createChartByfor_PLN_buy(string currencyName)
        {

            List<Entry> entryList = new List<Entry>();
            List<CurrenciesRatesForBankViewModel> listData = BankRepository.GetBanksData().Select(x => new CurrenciesRatesForBankViewModel
            {
                BankName = x.Title,
                CurrenciesRates = x.Currencies.Where(z => z.Id == currencyName).ToList()
            }).Where(y => y.CurrenciesRates.Count() > 0).ToList();

            // Type rate
            List<RateValueAndBankNameViewModel> sourceTable = listData.Select(x => new RateValueAndBankNameViewModel
            {
                BankName = x.BankName,
                CurrencyRateSingle = float.Parse(x.CurrenciesRates.Select(f => f.Buy).FirstOrDefault())
            }).OrderBy(x => x.CurrencyRateSingle).ToList();

            int counter = 0;
            string color = "";

            int start_1 = (int)sourceTable.Count() / 3;
            int start_2 = start_1 * 2;

            foreach (RateValueAndBankNameViewModel Bankitem in sourceTable)
            {
                counter++;

                if (counter <= start_1)
                {
                    color = "#90D585";
                }
                if (counter > start_1 && counter <= start_2)
                {
                    color = "#68B9C0";
                }
                if (counter > start_2)
                {
                    color = "#266489";
                }

                if (Bankitem.BankName.Equals("Райффайзен Банк Аваль"))
                {
                    Bankitem.BankName = "Райффайзен Б. А.";
                }

                if (Bankitem.BankName.Equals("Креді Агріколь Банк"))
                {
                    Bankitem.BankName = "Креді Агріколь Б.";
                }

                entryList.Add(new Entry(Bankitem.CurrencyRateSingle)
                {
                    Label = Bankitem.BankName,
                    ValueLabel = string.Format("{0:F3}", Bankitem.CurrencyRateSingle),
                    Color = SKColor.Parse(color),
                    TextColor = SKColor.Parse(color),
                });
            }

            var chart = new LineChart()
            {
                Entries = entryList,
                MaxValue = entryList.Select(x => x.Value).Max(),
                MinValue = entryList.Select(x => x.Value).Min(),
                ValueLabelOrientation = pc.ValueLabelOrientation,
                LabelOrientation = pc.LabelOrientation,
                LabelTextSize = 18,
            };

            chart.BackgroundColor = SKColor.Parse("#FFFFFF");

            var chartView = FindViewById<ChartView>(Resource.Id.chartViewPLN_buy);
            chartView.Chart = chart;
        }
        #endregion

        #region RUB rates charts
        // Get RUB chart on view

        // Methoda createChartByfor_RUB_sell
        public void createChartByfor_RUB_sell(string currencyName)
        {

            List<Entry> entryList = new List<Entry>();
            List<CurrenciesRatesForBankViewModel> listData = BankRepository.GetBanksData().Select(x => new CurrenciesRatesForBankViewModel
            {
                BankName = x.Title,
                CurrenciesRates = x.Currencies.Where(z => z.Id == currencyName).ToList()
            }).Where(y => y.CurrenciesRates.Count() > 0).ToList();

            // Type rate
            List<RateValueAndBankNameViewModel> sourceTable = listData.Select(x => new RateValueAndBankNameViewModel
            {
                BankName = x.BankName,
                CurrencyRateSingle = float.Parse(x.CurrenciesRates.Select(f => f.Sell).FirstOrDefault())
            }).OrderBy(x => x.CurrencyRateSingle).ToList();

            int counter = 0;
            string color = "";


            int start_1 = (int)sourceTable.Count() / 3;
            int start_2 = start_1 * 2;


            foreach (RateValueAndBankNameViewModel Bankitem in sourceTable)
            {
                counter++;

                if (counter <= start_1)
                {
                    color = "#266489";
                }
                if (counter > start_1 && counter <= start_2)
                {
                    color = "#68B9C0";
                }
                if (counter > start_2)
                {
                    color = "#90D585";
                }

                if (Bankitem.BankName.Equals("Райффайзен Банк Аваль"))
                {
                    Bankitem.BankName = "Райффайзен Б. А.";
                }

                if (Bankitem.BankName.Equals("Креді Агріколь Банк"))
                {
                    Bankitem.BankName = "Креді Агріколь Б.";
                }

                entryList.Add(new Entry(Bankitem.CurrencyRateSingle)
                {
                    Label = Bankitem.BankName,
                    ValueLabel = string.Format("{0:F3}", Bankitem.CurrencyRateSingle),
                    Color = SKColor.Parse(color),
                    TextColor = SKColor.Parse(color),
                });
            }

            if (entryList.Count > 0)
            {
                var chart = new LineChart()
                {
                    Entries = entryList,
                    MaxValue = entryList.Select(x => x.Value).Max(),
                    MinValue = entryList.Select(x => x.Value).Min(),
                    ValueLabelOrientation = pc.ValueLabelOrientation,
                    LabelOrientation = pc.LabelOrientation,
                    LabelTextSize = 18,
                };

                chart.BackgroundColor = SKColor.Parse("#FFFFFF");

                var chartView = FindViewById<ChartView>(Resource.Id.chartViewRUB_sell);
                chartView.Chart = chart;

            }
        }


        // Methoda createChartByfor_RUB_buy
        public void createChartByfor_RUB_buy(string currencyName)
        {

            List<Entry> entryList = new List<Entry>();
            List<CurrenciesRatesForBankViewModel> listData = BankRepository.GetBanksData().Select(x => new CurrenciesRatesForBankViewModel
            {
                BankName = x.Title,
                CurrenciesRates = x.Currencies.Where(z => z.Id == currencyName).ToList()
            }).Where(y => y.CurrenciesRates.Count() > 0).ToList();

            // Type rate
            List<RateValueAndBankNameViewModel> sourceTable = listData.Select(x => new RateValueAndBankNameViewModel
            {
                BankName = x.BankName,
                CurrencyRateSingle = float.Parse(x.CurrenciesRates.Select(f => f.Buy).FirstOrDefault())
            }).OrderBy(x => x.CurrencyRateSingle).ToList();

            int counter = 0;
            string color = "";

            int start_1 = (int)sourceTable.Count() / 3;
            int start_2 = start_1 * 2;

            foreach (RateValueAndBankNameViewModel Bankitem in sourceTable)
            {
                counter++;

                if (counter <= start_1)
                {
                    color = "#90D585";
                }
                if (counter > start_1 && counter <= start_2)
                {
                    color = "#68B9C0";
                }
                if (counter > start_2)
                {
                    color = "#266489";
                }

                if (Bankitem.BankName.Equals("Райффайзен Банк Аваль"))
                {
                    Bankitem.BankName = "Райффайзен Б. А.";
                }

                if (Bankitem.BankName.Equals("Креді Агріколь Банк"))
                {
                    Bankitem.BankName = "Креді Агріколь Б.";
                }

                entryList.Add(new Entry(Bankitem.CurrencyRateSingle)
                {
                    Label = Bankitem.BankName,
                    ValueLabel = string.Format("{0:F3}", Bankitem.CurrencyRateSingle),
                    Color = SKColor.Parse(color),
                    TextColor = SKColor.Parse(color),
                });
            }


            if (entryList.Count > 0)
            {
                var chart = new LineChart()
                {
                    Entries = entryList,
                    MaxValue = entryList.Select(x => x.Value).Max(),
                    MinValue = entryList.Select(x => x.Value).Min(),
                    ValueLabelOrientation = pc.ValueLabelOrientation,
                    LabelOrientation = pc.LabelOrientation,
                    LabelTextSize = 18,
                };

                chart.BackgroundColor = SKColor.Parse("#FFFFFF");

                var chartView = FindViewById<ChartView>(Resource.Id.chartViewRUB_buy);
                chartView.Chart = chart;
            }

        }
        #endregion
    }
}


