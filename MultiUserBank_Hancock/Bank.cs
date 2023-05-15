namespace MultiUserBank_Hancock
{
    internal class Bank
    {
        private decimal _bankBalance;
        private string[] _username = new string[4];
        private string[] _userPassword = new string[4];
        private decimal[] _userBalance = new decimal[4];

        private int _userIndex;

        public Bank(decimal bankBalance, string[] username, string[] password, decimal[] userBalance)
        {
            _bankBalance = bankBalance;
            for (int i = 0; i < username.Length; i++)
            {
                _username[i] = username[i];
                _userPassword[i] = password[i];
                _userBalance[i] = userBalance[i];
            }
        }

        public int CheckUsername(string entry)
        {
            _userIndex = -1;
            for (int i = 0; i < _username.Length; i++)
            {
                if (entry == _username[i])
                {
                    _userIndex = i;
                }
            }
            return _userIndex;
        }

        public string CheckUserPassword(string password)
        {
            if (password == _userPassword[_userIndex])
            {
                return "true";
            }
            return "false";
        }

        public void Withdrawal(decimal withdrawal)
        {
            if (withdrawal > 500)
            {
                withdrawal = 500;
            }

            if ((_userBalance[_userIndex] - withdrawal) < 0)
            {
                withdrawal += (_userBalance[_userIndex] - withdrawal);
            }

            _userBalance[_userIndex] -= withdrawal;
            _bankBalance -= withdrawal;
        }

        public void Deposit(decimal deposit)
        {
            _userBalance[_userIndex] += deposit;
            _bankBalance += deposit;
        }

        public string GetUsername
        {
            get
            {
                return _username[_userIndex];
            }
        }

        public decimal GetUserBalance
        {
            get
            {
                return _userBalance[_userIndex];
            }
        }

        public decimal GetBankBalance
        {
            get
            {
                return _bankBalance;
            }
        }
    }
}