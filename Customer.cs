using System.Collections.Generic;

namespace MyBankTeller
{
    internal class Customer
    {
        private string fullname;
        public string Fullname
        {
            get { return fullname;}
            set { fullname = value;}
        }        

        private int id;
        public int Id
        {
            get { return id;}
            set { id = value;}
        }

        private List<Account> accounts;
        public List<Account> Accounts
        {
            get { return accounts;}
            set { accounts = value;}
        }
        
                

        /*****************/
        /* Contstructors */
        /*****************/
        public Customer()
        {
            Accounts = new List<Account>();
        }

        public Customer(string fullname)
        {
            Accounts = new List<Account>();
            Fullname = fullname;
        }

        public Customer(string fullname, int id)
        {
            Accounts = new List<Account>();
            Fullname = fullname;
            Id = id;
        }
        /********************/
        /* End Constructors */
        /********************/
    }
}