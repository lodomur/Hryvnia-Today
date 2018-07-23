using HryvniaToday.Model.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace HryvniaToday.Model.Repository
{
    public class BankRepository
    {

        public static List<Bank> GetBanksData()
        {
            List<Bank> bankList = new List<Bank>();
            int d;
            XDocument xdoc = XDocument.Load("http://resources.finance.ua/ua/public/currency-cash.xml");
            bankList = xdoc.Descendants("organizations").Elements("organization").Select(f => new Bank
            {
                Id = Int32.Parse(f.Attribute("oldid").Value),
                OrganizationType = f.Attribute("org_type").Value.ToString(),
                Title = f.Element("title").Attribute("value").Value,
                Currencies = f.Element("currencies").Elements("c").Select(x => new Currency
                {
                    Id = x.Attribute("id").Value,
                    Buy = x.Attribute("br").Value,
                    Sell = x.Attribute("ar").Value
                }).ToList()
            }).ToList();


            return bankList;
        }

    }
}