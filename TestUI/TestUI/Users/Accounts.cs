using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUI.Users
{
    public class Accounts
    {
        private List<Account> accounts = new List<Account>();
        public bool Login(string name,string password)
        {
            int passwordH = password.GetHashCode();
            foreach (Account ac in accounts)
            {
                if (ac.passwordH == passwordH) return true;
            }
            return false;
        }
    }
}
