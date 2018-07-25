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
            
            List<Bank> reslist = new List<Bank>();

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

            int counterId = 0;
            foreach (Bank bankItem in bankList)
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
                    case "ПОВ №45":
                        counterId++;
                        bankItem.Id = counterId;
                        bankItem.Title = "Обмінні пункти";
                        bankItem.BankLogo = Resource.Drawable.kantor;
                        reslist.Add(bankItem);
                        break;
                    default:
                        break;
                }
            }


            var rfbDuplicate = reslist.Where(x => x.Title == "Райффайзен Банк Аваль").ToList();

            if (rfbDuplicate.Count() == 2)
            {
                reslist.Remove(rfbDuplicate.ElementAt(0));
            }

            return reslist;
        }

    }
}