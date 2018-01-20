using System;

namespace MyBankTeller
{
    class Program
    {
        static void Main(string[] args)
        {
            int customerOption = 0;
            Controller controller = new Controller();

            while(customerOption >= 0 && customerOption <= 4)
            {
                
                customerOption = Menu.Show();

                if(customerOption == 0)
                {
                    Console.WriteLine("\nInvalid input, please try again.\n");   
                }
                else if(customerOption > 0 && customerOption <= 4)
                {
                    // interface with system and db
                    Console.WriteLine("\ninterfacing with backend system and database\n");
                    controller.Process(customerOption);
                }
            }

            Console.WriteLine("\nThank for choosing NASHVILLE SAFE & SOUND BANK for your banking needs.");
        }
    }
}
