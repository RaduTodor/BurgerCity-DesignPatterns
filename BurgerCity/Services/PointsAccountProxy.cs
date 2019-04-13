using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using BurgerCity.Contracts;
using BurgerCity.Entities;
using Newtonsoft.Json;

namespace BurgerCity.Services
{
    public class PointsAccountProxy : IAccount
    {
        private readonly Dictionary<string, int> AccountBalances;

        public string CurrentAccountCode { get; set; }

        protected IAccount RealSubject { get; set; }

        private string _accountsPath = string.Format(ConfigurationManager.AppSettings["AccountsFilePath"],
            System.AppContext.BaseDirectory);

        public PointsAccountProxy()
        {
            Directory.CreateDirectory(_accountsPath);
            _accountsPath += "/accounts.txt";
            if (!File.Exists(_accountsPath))
            {
                File.CreateText(_accountsPath).Close();
            }

            AccountBalances = JsonConvert.DeserializeObject<Dictionary<string, int>>
                                  (File.ReadAllText(_accountsPath)) ?? new Dictionary<string, int>();
        }

        public IAccount ChangeAccount(string accountCode)
        {
            CurrentAccountCode = accountCode;
            SaveChanges();

            RealSubject = new PointsAccount();
            foreach (var account in AccountBalances)
            {
                if (account.Key == accountCode)
                {
                    RealSubject.AddPoints(account.Value);
                    return RealSubject;
                }
            }

            AccountBalances.Add(accountCode, 0);
            return RealSubject;
        }

        public void AddPoints(int pointsNumber)
        {
            RealSubject.AddPoints(pointsNumber);
        }

        public bool RemovePoints(int pointsNumber)
        {
            return RealSubject.RemovePoints(pointsNumber);
        }

        public int GetPointsAmount()
        {
            return RealSubject.GetPointsAmount();
        }

        public bool IsEnough(int neededPoints)
        {
            return RealSubject.IsEnough(neededPoints);
        }

        public void SaveChanges()
        {
            if (RealSubject != null)
            {
                AccountBalances[CurrentAccountCode] = RealSubject.GetPointsAmount();
            }

            string json = JsonConvert.SerializeObject(AccountBalances);
            File.WriteAllText(_accountsPath, json);
        }
    }
}