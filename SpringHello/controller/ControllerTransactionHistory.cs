using System;
using System.Collections.Generic;
using SpringHello.model;

namespace SpringHello.controller
{
    public class ControllerTransactionHistory
    {
        static YYTransactionModel _transactionModel = new YYTransactionModel();

        public void ListTransactionToAccountNumber()
        {
            List<YYTransaction> _list = new List<YYTransaction>();
            Console.WriteLine("Please enter the acountNumber to find");
            var accountNumber = Console.ReadLine();
            _list = _transactionModel.GetTransactionByAccountNumber(accountNumber);
            if (_list.Count == 0)
            {
                Console.WriteLine(" No transaction history information");
                return;
            }

            Console.WriteLine("{0, -40} {1, -10} {2, -15} {3, -40} {4, -40} {5, -10} {6, -10}", "Id", "Amount",
                "Content", "SenderAccountNumber",
                "ReceiverAccountNumber", "Type", "Status");
            var addlist = _transactionModel.GetListTransaction();

            Console.WriteLine("------------------------------------------------------------------------------------" +
                              "------------------------------------------------------------------------------ .");
            foreach (var transaction in _list)
            {
                Console.WriteLine("{0, -40} {1, -10} {2, -15} {3, -40} {4, -40} {5, -10} {6, -10}",
                    transaction.Id,
                    transaction.Amount, transaction.Content,
                    transaction.SenderAccountNumber, transaction.ReceiverAccountNumber, transaction.Type,
                    transaction.Status
                );
            }
        }

        public void GetListTransactionHistory()
        {
            Console.WriteLine("Transaction history: ");
            Console.WriteLine("{0, -40} {1, -10} {2, -15} {3, -40} {4, -40} {5, -10} {6, -10}", "Id", "Amount",
                "Content", "SenderAccountNumber",
                "ReceiverAccountNumber", "Type", "Status");
            var addlist = _transactionModel.GetListTransaction();
            if (addlist.Count == 0)
            {
                Console.WriteLine(" No transaction history information");
                return;
            }

            Console.WriteLine("------------------------------------------------------------------------------------" +
                              "------------------------------------------------------------------------------ .");
            foreach (var transaction in addlist)
            {
                Console.WriteLine("{0, -40} {1, -10} {2, -15} {3, -40} {4, -40} {5, -10} {6, -10}",
                    transaction.Id,
                    transaction.Amount, transaction.Content,
                    transaction.SenderAccountNumber, transaction.ReceiverAccountNumber, transaction.Type,
                    transaction.Status
                );
            }
        }
    }
}