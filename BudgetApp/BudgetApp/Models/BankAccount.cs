using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Models
{
    [Serializable]
    public class BankAccount
    {
        public double Balance { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string Nickname { get; set; }


        public BankAccount() : this(0, "-", "-", "My Account") { }

        public BankAccount(double iBalance, string account, string bank, string nickname)
        {

            Balance = iBalance;
            AccountNumber = account;
            BankName = bank;
            Nickname = nickname;
        }
        public override string ToString()
        {
            return base.ToString();
        }


    }

    
}
