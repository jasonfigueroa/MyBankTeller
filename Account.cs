namespace MyBankTeller
{
    internal class Account
    {
        private int id;
        public int Id
        {
            get { return id;}
            set { id = value;}
        }

        private int balance;
        public int Balance
        {
            get { return balance;}
            set { balance = value;}
        }
        
        /****************/
        /* Constructors */
        /****************/
        public Account()
        {
            Id = 0;
            Balance = 0;
        }
        
        public Account(int id)
        {
            Id = id;
            Balance = 0;
        }

        public Account(int id, int balance)
        {
            Id = id;
            Balance = balance;
        }
        /********************/
        /* End Constructors */
        /********************/
    }
}