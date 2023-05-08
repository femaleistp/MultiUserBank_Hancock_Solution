using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiUserBank_Hancock
{
    internal class Bank
    {
        private decimal _bankBalance;
        private string[] _username = { "jlennon", "pmccartney", "gharrison", "rstarr" };
        private string[] _userPassword = { "johnny", "pauly", "georgy", "ringoy" };
        private decimal[] _userBalance = { 1250, 2500, 3000, 1000 };

        public Bank(decimal bankBalance)
        {
            _bankBalance = bankBalance;
        }

        public void Withdrawal(int i, decimal withdrawal)
        {
            if (withdrawal > 500)
            {
                withdrawal = 500;
            }

            if ((_bankBalance - withdrawal) < 0)
            {
                withdrawal = withdrawal + (_bankBalance - withdrawal);
            }

            if ((_userBalance[i] - withdrawal) < 0)
            {
                withdrawal = withdrawal + (_userBalance[i] - withdrawal);
            }

            _userBalance[i] -= withdrawal;
            _bankBalance -= withdrawal;
        }

        public void Deposit(int index, decimal deposit)
        {
            _userBalance[index] += deposit;
            _bankBalance += deposit;
        }

        public string CheckUsername(string entry)
        {
            for (int i = 0; i < _username.Length; i++)
            {
                if (entry == _username[i])
                {
                    return _username[i];
                }
            }
            return "account does not exist";
        }

        public int UserPassword(string password, string username)
        {

            int index = -1;
            for (int i = 0; i < _userPassword.Length; i++)
            {
                if (password == _userPassword[i])
                    return i;
            }
            return index;
        }

        public string GetUsername(int index)
        {
            return _username[index];
        }

        public decimal UserBalance(int index)
        {

            return _userBalance[index];
        }

        public decimal BankBalance
        {
            get
            {
                return _bankBalance;
            }
        }
    }
}
