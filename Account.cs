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

        private double balance;
        public double Balance
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

        public Account(int id, double balance)
        {
            Id = id;
            Balance = balance;
        }
        /********************/
        /* End Constructors */
        /********************/
    }
}