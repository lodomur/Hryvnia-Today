
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
using System.Collections.Generic;
using System.Linq;

namespace HryvniaToday
{
    [Activity(Label = "Візуалізація курсів", Theme = "@style/MyTheme")]
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
            createChartByfor_USD_sell();
           
            // USD buy
            createChartByfor_USD_buy();

            // EUR sell
            createChartByfor_EUR_sell();

            // EUR buy
            createChartByfor_EUR_buy();

            // PLN sell
            createChartByfor_PLN_sell();

            // PLN buy
            createChartByfor_PLN_buy();

            // RUB sell
            createChartByfor_RUB_sell();

            // RUB buy
            createChartByfor_RUB_buy();

            // Toolbar
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbarCurrencyList);
            SetActionBar(toolbar);
            ActionBar.Title = "Візуалізація курсів";

            Typeface type = Typeface.CreateFromAsset(this.Assets, "Oswald-Regular.ttf");

            var USDRateTextView_sell = FindViewById<TextView>(Resource.Id.USDRateTextView_sell);
            USDRateTextView_sell.SetTypeface(type, TypefaceStyle.Normal);

            var USDRateTextView_buy = FindViewById<TextView>(Resource.Id.USDRateTextView_buy);
            USDRateTextView_buy.SetTypeface(type, TypefaceStyle.Normal);

            var EURRateTextView_buy = FindViewById<TextView>(Resource.Id.EURRateTextView_buy);
            EURRateTextView_buy.SetTypeface(type, TypefaceStyle.Normal);

            var EURRateTextView_sell = FindViewById<TextView>(Resource.Id.EURRateTextView_sell);
            EURRateTextView_sell.SetTypeface(type, TypefaceStyle.Normal);

            var RUBRateTextView_buy = FindViewById<TextView>(Resource.Id.RUBRateTextView_buy);
            RUBRateTextView_buy.SetTypeface(type, TypefaceStyle.Normal);

            var RUBRateTextView_sell = FindViewById<TextView>(Resource.Id.RUBRateTextView_sell);
            RUBRateTextView_sell.SetTypeface(type, TypefaceStyle.Normal);

            var PLNRateTextView_buy = FindViewById<TextView>(Resource.Id.PLNRateTextView_buy);
            PLNRateTextView_buy.SetTypeface(type, TypefaceStyle.Normal);

            var PLNRateTextView_sell = FindViewById<TextView>(Resource.Id.PLNRateTextView_sell);
            PLNRateTextView_sell.SetTypeface(type, TypefaceStyle.Normal);


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

                if (Bankitem.BankName.Equals("Райффайзен Банк Аваль"))
                {
                    Bankitem.BankName = "Райффайзен Б. А.";
                }

                if (Bankitem.BankName.Equals("Креді Агріколь Банк"))
                {
                    Bankitem.BankName = "Креді Агріколь Б.";
                }

                entryList_USD_sell.Add(new Entry(float.Parse(Bankitem.CurrenciesRates.Select(x => x.Sell).FirstOrDefault()))
                {
                    Label = Bankitem.BankName,
                    ValueLabel = Bankitem.CurrenciesRates.Select(x => x.Sell).FirstOrDefault().Substring(0, 6),
                    Color = SKColor.Parse(color),
                    TextColor = SKColor.Parse(color),
                });
            }

            // USD chart config
            var chart_USD = new BarChart()
            {
                Entries = entryList_USD_sell,
                MaxValue = entryList_USD_sell.Select(x => x.Value).Max(),
                MinValue = entryList_USD_sell.Select(x => x.Value).Min(),
                ValueLabelOrientation = pc.ValueLabelOrientation,
                LabelOrientation = pc.LabelOrientation,
                LabelTextSize = 17
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

                if (Bankitem.BankName.Equals("Райффайзен Банк Аваль"))
                {
                    Bankitem.BankName = "Райффайзен Б. А.";
                }

                if (Bankitem.BankName.Equals("Креді Агріколь Банк"))
                {
                    Bankitem.BankName = "Креді Агріколь Б.";
                }

                entryList_USD_buy.Add(new Entry(float.Parse(Bankitem.CurrenciesRates.Select(x => x.Buy).FirstOrDefault()))
                {
                    Label = Bankitem.BankName,
                    ValueLabel = Bankitem.CurrenciesRates.Select(x => x.Buy).FirstOrDefault().Substring(0, 6),
                    Color = SKColor.Parse(color),
                    TextColor = SKColor.Parse(color),
                });
            }


            // USD chart config
            var chart_USD = new LineChart()
            {
                Entries = entryList_USD_buy,
                MaxValue = entryList_USD_buy.Select(x => x.Value).Max(),
                MinValue = entryList_USD_buy.Select(x => x.Value).Min(),
                ValueLabelOrientation = pc.ValueLabelOrientation,
                LabelOrientation = pc.LabelOrientation,
                LabelTextSize = 17
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

                if (Bankitem.BankName.Equals("Райффайзен Банк Аваль"))
                {
                    Bankitem.BankName = "Райффайзен Б. А.";
                }

                if (Bankitem.BankName.Equals("Креді Агріколь Банк"))
                {
                    Bankitem.BankName = "Креді Агріколь Б.";
                }

                entryList_EUR_sell.Add(new Entry(float.Parse(Bankitem.CurrenciesRates.Select(x => x.Sell).FirstOrDefault()))
                {
                    Label = Bankitem.BankName,
                    ValueLabel = Bankitem.CurrenciesRates.Select(x => x.Sell).FirstOrDefault().Substring(0, 6),
                    Color = SKColor.Parse(color),
                    TextColor = SKColor.Parse(color),
                });
            }


            // EUR chart config
            var chart_EUR = new LineChart()
            {
                Entries = entryList_EUR_sell,
                MaxValue = entryList_EUR_sell.Select(x => x.Value).Max(),
                MinValue = entryList_EUR_sell.Select(x => x.Value).Min(),
                ValueLabelOrientation = pc.ValueLabelOrientation,
                LabelOrientation = pc.LabelOrientation,
                LabelTextSize = 17
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

                if (Bankitem.BankName.Equals("Райффайзен Банк Аваль"))
                {
                    Bankitem.BankName = "Райффайзен Б. А.";
                }

                if (Bankitem.BankName.Equals("Креді Агріколь Банк"))
                {
                    Bankitem.BankName = "Креді Агріколь Б.";
                }

                entryList_EUR_buy.Add(new Entry(float.Parse(Bankitem.CurrenciesRates.Select(x => x.Buy).FirstOrDefault()))
                {
                    Label = Bankitem.BankName,
                    ValueLabel = Bankitem.CurrenciesRates.Select(x => x.Buy).FirstOrDefault().Substring(0, 6),
                    Color = SKColor.Parse(color),
                    TextColor = SKColor.Parse(color),
                });
            }


            // EUR chart config
            var chart_EUR = new LineChart()
            {
                Entries = entryList_EUR_buy,
                MaxValue = entryList_EUR_buy.Select(x => x.Value).Max(),
                MinValue = entryList_EUR_buy.Select(x => x.Value).Min(),
                ValueLabelOrientation = pc.ValueLabelOrientation,
                LabelOrientation = pc.LabelOrientation,
                LabelTextSize = 17
            };
            chart_EUR.BackgroundColor = SKColor.Parse("#FFFFFF");
            var chartView = FindViewById<ChartView>(Resource.Id.chartViewEUR_buy);
            chartView.Chart = chart_EUR;

        }
        #endregion

        #region PLN rates charts
        // Get PLN chart on view

        // Methoda createChartByfor_PLN_sell
        public void createChartByfor_PLN_sell()
        {

            List<Entry> entryList_PLN_sell = new List<Entry>();

            // Get Data by Currency PLN
            List<CurrenciesRatesForBankViewModel> listData = BankRepository.GetBanksData().Select(x => new CurrenciesRatesForBankViewModel
            {
                BankName = x.Title,
                CurrenciesRates = x.Currencies.Where(z => z.Id == "PLN").ToList()
            }).Where(y => y.CurrenciesRates.Count() > 0).ToList();

            int counter = 0;
            string color = "";
            // PLN
            foreach (CurrenciesRatesForBankViewModel Bankitem in listData)
            {
                counter++;

                if (counter == 1)
                {
                    color = "#266489";
                }
                if (counter == 2)
                {
                    color = "#68B9C0";
                }
                if ( counter >= 3)
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

                entryList_PLN_sell.Add(new Entry(float.Parse(Bankitem.CurrenciesRates.Select(x => x.Sell).FirstOrDefault()))
                {
                    Label = Bankitem.BankName,
                    ValueLabel = Bankitem.CurrenciesRates.Select(x => x.Sell).FirstOrDefault().Substring(0, 6),
                    Color = SKColor.Parse(color),
                    TextColor = SKColor.Parse(color),
                });
            }


            // PLN chart config
            var chart_PLN = new LineChart()
            {
                Entries = entryList_PLN_sell,
                MaxValue = entryList_PLN_sell.Select(x => x.Value).Max(),
                MinValue = entryList_PLN_sell.Select(x => x.Value).Min(),
                ValueLabelOrientation = pc.ValueLabelOrientation,
                LabelOrientation = pc.LabelOrientation,
                LabelTextSize = 17
            };
            chart_PLN.BackgroundColor = SKColor.Parse("#FFFFFF");
            var chartView = FindViewById<ChartView>(Resource.Id.chartViewPLN_sell);
            chartView.Chart = chart_PLN;

        }


        // Methoda createChartByfor_PLN_buy
        public void createChartByfor_PLN_buy()
        {

            List<Entry> entryList_PLN_buy = new List<Entry>();

            // Get Data by Currency PLN
            List<CurrenciesRatesForBankViewModel> listData = BankRepository.GetBanksData().Select(x => new CurrenciesRatesForBankViewModel
            {
                BankName = x.Title,
                CurrenciesRates = x.Currencies.Where(z => z.Id == "PLN").ToList()
            }).Where(y => y.CurrenciesRates.Count() > 0).ToList();

            int counter = 0;
            string color = "";
            // PLN
            foreach (CurrenciesRatesForBankViewModel Bankitem in listData)
            {
                counter++;

                if (counter == 1)
                {
                    color = "#266489";
                }
                if (counter == 2)
                {
                    color = "#68B9C0";
                }
                if (counter >= 3)
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

                entryList_PLN_buy.Add(new Entry(float.Parse(Bankitem.CurrenciesRates.Select(x => x.Buy).FirstOrDefault()))
                {
                    Label = Bankitem.BankName,
                    ValueLabel = Bankitem.CurrenciesRates.Select(x => x.Buy).FirstOrDefault().Substring(0, 6),
                    Color = SKColor.Parse(color),
                    TextColor = SKColor.Parse(color),
                });
            }


            // PLN chart config
            var chart_PLN = new LineChart()
            {
                Entries = entryList_PLN_buy,
                MaxValue = entryList_PLN_buy.Select(x => x.Value).Max(),
                MinValue = entryList_PLN_buy.Select(x => x.Value).Min(),
                ValueLabelOrientation = pc.ValueLabelOrientation,
                LabelOrientation = pc.LabelOrientation,
                LabelTextSize = 17
            };
            chart_PLN.BackgroundColor = SKColor.Parse("#FFFFFF");
            var chartView = FindViewById<ChartView>(Resource.Id.chartViewPLN_buy);
            chartView.Chart = chart_PLN;

        }
        #endregion

        #region RUB rates charts
        // Get RUB chart on view

        // Methoda createChartByfor_RUB_sell
        public void createChartByfor_RUB_sell()
        {

            List<Entry> entryList_RUB_sell = new List<Entry>();

            // Get Data by Currency RUB
            List<CurrenciesRatesForBankViewModel> listData = BankRepository.GetBanksData().Select(x => new CurrenciesRatesForBankViewModel
            {
                BankName = x.Title,
                CurrenciesRates = x.Currencies.Where(z => z.Id == "RUB").ToList()
            }).Where(y => y.CurrenciesRates.Count() > 0).ToList();

            int counter = 0;
            string color = "";
            // RUB
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

                if (Bankitem.BankName.Equals("Райффайзен Банк Аваль"))
                {
                    Bankitem.BankName = "Райффайзен Б. А.";
                }

                if (Bankitem.BankName.Equals("Креді Агріколь Банк"))
                {
                    Bankitem.BankName = "Креді Агріколь Б.";
                }

                entryList_RUB_sell.Add(new Entry(float.Parse(Bankitem.CurrenciesRates.Select(x => x.Sell).FirstOrDefault()))
                {
                    Label = Bankitem.BankName,
                    ValueLabel = Bankitem.CurrenciesRates.Select(x => x.Sell).FirstOrDefault().Substring(0, 6),
                    Color = SKColor.Parse(color),
                    TextColor = SKColor.Parse(color),
                });
            }


            // RUB chart config
            var chart_RUB = new LineChart()
            {
                Entries = entryList_RUB_sell,
                MaxValue = entryList_RUB_sell.Select(x => x.Value).Max(),
                MinValue = entryList_RUB_sell.Select(x => x.Value).Min(),
                ValueLabelOrientation = pc.ValueLabelOrientation,
                LabelOrientation = pc.LabelOrientation,
                LabelTextSize = 17
            };
            chart_RUB.BackgroundColor = SKColor.Parse("#FFFFFF");
            var chartView = FindViewById<ChartView>(Resource.Id.chartViewRUB_sell);
            chartView.Chart = chart_RUB;

        }


        // Methoda createChartByfor_RUB_buy
        public void createChartByfor_RUB_buy()
        {

            List<Entry> entryList_RUB_buy = new List<Entry>();

            // Get Data by Currency RUB
            List<CurrenciesRatesForBankViewModel> listData = BankRepository.GetBanksData().Select(x => new CurrenciesRatesForBankViewModel
            {
                BankName = x.Title,
                CurrenciesRates = x.Currencies.Where(z => z.Id == "RUB").ToList()
            }).Where(y => y.CurrenciesRates.Count() > 0).ToList();

            int counter = 0;
            string color = "";
            // RUB
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

                if (Bankitem.BankName.Equals("Райффайзен Банк Аваль"))
                {
                    Bankitem.BankName = "Райффайзен Б. А.";
                }

                if (Bankitem.BankName.Equals("Креді Агріколь Банк"))
                {
                    Bankitem.BankName = "Креді Агріколь Б.";
                }

                entryList_RUB_buy.Add(new Entry(float.Parse(Bankitem.CurrenciesRates.Select(x => x.Buy).FirstOrDefault()))
                {
                    Label = Bankitem.BankName,
                    ValueLabel = Bankitem.CurrenciesRates.Select(x => x.Buy).FirstOrDefault().Substring(0, 6),
                    Color = SKColor.Parse(color),
                    TextColor = SKColor.Parse(color),
                });
            }


            // RUB chart config
            var chart_RUB = new LineChart()
            {
                Entries = entryList_RUB_buy,
                MaxValue = entryList_RUB_buy.Select(x => x.Value).Max(),
                MinValue = entryList_RUB_buy.Select(x => x.Value).Min(),
                ValueLabelOrientation = pc.ValueLabelOrientation,
                LabelOrientation = pc.LabelOrientation,
                LabelTextSize = 17

            };
            chart_RUB.BackgroundColor = SKColor.Parse("#FFFFFF");
            var chartView = FindViewById<ChartView>(Resource.Id.chartViewRUB_buy);
            chartView.Chart = chart_RUB;

        }
        #endregion
    }
}


