using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using SpringHello.controller;
using SpringHello.model;
using SpringHello.utillty;

namespace SpringHello.view
{
    public class MainThread
    {
        private static CotrollerSpring cotrollerSpring = new CotrollerSpring();
        private static ControllerTransactionHistory transactionHistory = new ControllerTransactionHistory();


        public void GenerateMenu()
        {
            while (true)
            {
                if (Program.currentLoggedInYyAccount != null)
                {
                    GenerateCustumerMennu();
                }
                else
                {
                    GenerateDefaulMenu();
                }
            }
        }

        public void GenerateDefaulMenu()
        {
            while (true)
            {
                Console.WriteLine("============WELCOME TO SPRING HELLO BANK===========");
                Console.WriteLine("1.Register for free.");
                Console.WriteLine("2.Login.");
                Console.WriteLine("3. Exit.");
                Console.WriteLine("===================================================");
                Console.WriteLine("Please enter you choose (1|2|3)");
                var choose = Utillty.GetInt32Number();
                switch (choose)
                {
                    case 1:
                        Console.WriteLine(cotrollerSpring.Register()
                            ? "Register success!"
                            : "Register fails. Please try again later.");
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine(cotrollerSpring.LoginAccount()
                            ? "Login success! Welcome back!"
                            : "Login fails. Please try again later.");
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        break;
                    case 3:
                        Environment.Exit(1);
                        break;
                }

                if (Program.currentLoggedInYyAccount != null)
                {
                    break;
                }
            }
        }

        public void GenerateCustumerMennu()
        {
            while (true)
            {
                Console.WriteLine("============SPRING HELLO BANK CUSTUMER MAENU===========");
                Console.WriteLine("Welcome back " + Program.currentLoggedInYyAccount.Name + "!");
                Console.WriteLine("1. Check information.");
                Console.WriteLine("2. Withdraw.");
                Console.WriteLine("3. Deposit.");
                Console.WriteLine("4. Transfer.");
                Console.WriteLine("5. Transaction history.");
                Console.WriteLine("6. Logout.");
                Console.WriteLine("=======================================================");
                Console.WriteLine("Please enter you choose (1|2|3|4|5|6)");
                var choose = Utillty.GetInt32Number();
                switch (choose)
                {
                    case 1:
                        cotrollerSpring.ShowAccountInformation();
                        break;
                    case 2:
                        cotrollerSpring.Withdraw();
                        break;
                    case 3:
                        cotrollerSpring.Deposit();
                        break;
                    case 4:
                        cotrollerSpring.Transfer();
                        break;
                    case 5:
                        GenerateTransactionMennu();
                        break;
                    case 6:
                        Program.currentLoggedInYyAccount = null;
                        Console.WriteLine("Logout success");
                        break;
                }

                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                if (Program.currentLoggedInYyAccount == null)
                {
                    break;
                }
            }
        }

        private void GenerateTransactionMennu()
        {
            Console.WriteLine("Transaction history query");
            Console.WriteLine("Please select a transaction history view");
            Console.WriteLine("1. Retrieve all transaction history.");
            Console.WriteLine("2. Query transaction history according to AccountNumber.");
            Console.WriteLine("Please enter you choose (1|2)");
            var choose = Utillty.GetInt32Number();
            switch (choose)
            {
                case 1:
                    transactionHistory.GetListTransactionHistory();
                    break;
                case 2:
                    transactionHistory.ListTransactionToAccountNumber();
                    break;
            }
        }
    }
}