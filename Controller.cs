using System;

namespace MyBankTeller
{
    internal class Controller
    {
        // private Account account;
        private Customer customer;
        // private int accountNumber;
        private Model model;
        // private void promptUserForAccountNumber()
        // {
        //     this.accountNumber = 0;
        //     while(accountNumber == 0)
        //     {
        //         Console.WriteLine("What is your account number?");
        //         accountNumber = int.Parse(Console.ReadLine());
        //     }
        // }

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
                    Console.WriteLine("What is your full name?");
                    string fullname = Console.ReadLine();

                    customer = new Customer(fullname);

                    // CreateCustomer will return last id inserted into db
                    customer.Id = model.CreateCustomer(fullname);

                    Console.WriteLine($"new customer name: {customer.Fullname}");
                    Console.WriteLine($"new customer id: {customer.Id}");

                    // TODO create new account for new user and store it in Account 
                    // table in db 
                    
                    break;
                case 2:
                    Console.WriteLine("Case 2");
                    // this.promptUserForAccountNumber();
                    break;
                case 3:
                    Console.WriteLine("Case 2");
                    // this.promptUserForAccountNumber();
                    break;
                case 4:
                    Console.WriteLine("Case 2");
                    // this.promptUserForAccountNumber();
                    break;
                // default:
                //     Console.WriteLine("Default case");
                //     break;
            }
        }
    }
}