using System;

namespace MyBankTeller
{
    internal class Menu
    {
        public static int Show()
        {
            ConsoleKeyInfo userInput;
            int userOption;

            Console.WriteLine("WELCOME TO NASHVILLE SAFE & SOUND BANK");
            Console.WriteLine("**************************************");
            Console.WriteLine("1. Create customer account");
            Console.WriteLine("2. Deposit money");
            Console.WriteLine("3. Withdraw money");
            Console.WriteLine("4. Show account balance");
            Console.WriteLine("5. Exit");

            // temp off
            userInput = Console.ReadKey();

            // userInput = 1;

            if(char.IsDigit(userInput.KeyChar))
            {
                userOption = int.Parse(userInput.KeyChar.ToString());
                
                if(userOption < 1 || userOption > 5)
                {
                    userOption = 0;
                }
            }
            else
            {
                userOption = 0;
            }

            return userOption;
        }
    }
}