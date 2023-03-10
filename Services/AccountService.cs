using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Webshop.Services
{
    public class AccountService
    {
        public List<AccountData> Accounts { get; set; } = new List<AccountData>();

        public void AccountCreation(string phonenumber, string customerName)
        {
            bool CreateNewAccount = DoesAccountExist(phonenumber);
            if (CreateNewAccount)
            {
                CreateAccount(phonenumber, customerName);
            }
        }

        private void CreateAccount(string phonenumber, string customerName)
        {
            AccountData newAccount = new AccountData();

            newAccount.CustomerName = customerName;
            newAccount.Phonenumber = phonenumber;
            Accounts.Add(newAccount);
        }

        public bool DoesAccountExist(string phonenumber)
        {
            if (Accounts.Count == 0)
            {
                return false;
            }

            foreach (AccountData account in Accounts)
            {
                if (phonenumber == account.Phonenumber)
                {
                    return true;
                }
            }

            return false;
        }

        public class AccountData
        {
            public string Phonenumber { get; set; }
            public string CustomerName { get; set; }
        }

    }
}
