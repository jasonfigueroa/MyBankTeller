using System;

namespace MyBankTeller
{
    internal class Controller
    {
        private string fullname;
        private int accountId;
        private Customer customer;
        private Model model;

        public Controller()
        {
            model = new Model();
        }
        public void Process(int option)
        {
            Model model = new Model(); 
            switch (option)
            {
                case 1:
                    /***************************/
                    /* Create Customer Account */
                    /***************************/
                    Console.WriteLine("What is your full name?");
                    this.fullname = Console.ReadLine();

                    customer = new Customer(this.fullname);

                    // CreateCustomer will return last id inserted into db
                    customer.Id = model.CreateCustomer(this.fullname);

                    Console.WriteLine($"new customer name: {customer.Fullname}");
                    Console.WriteLine($"new customer id: {customer.Id}");

                    // TODO create new account for new user and store it in Account 
                    // table in db
                    this.accountId = model.CreateAccount(customer.Id);
                    Account account = new Account(this.accountId);
                    
                    customer.Accounts.Add(account);

                    // Console.WriteLine();
                    
                    break;
                case 2:
                    /***********/
                    /* Deposit */
                    /***********/

                    // prompt user for their name
                    Console.WriteLine("What is your full name?");
                    this.fullname = Console.ReadLine();
                    
                    // prompt user for the account id number of the account they 
                    // would like to make a deposit to
                    Console.WriteLine("What is the id of the account you wish to make the deposit to?");
                    this.accountId = int.Parse(Console.ReadLine());

                    // prompt user for amount they wish to deposit
                    Console.WriteLine("How much would you like to deposit?");
                    double depositAmount = double.Parse(Console.ReadLine());

                    // make the deposit
                    model.Deposit(fullname, this.accountId, depositAmount);

                    break;
                case 3:
                    /************/
                    /* Withdraw */
                    /************/
                    
                    // code here

                    break;
                case 4:
                    /****************/
                    /* Show Balance */
                    /****************/
                    
                    // code here

                    break;
                // default:
                //     // code here
                //     break;
            }
        }
    }
}