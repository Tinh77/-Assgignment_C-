using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace SpringHello.model
{
    public class YYTransactionModel
    {
        public List<YYTransaction> GetTransactionByAccountNumber(string accountnumber)
        {
            List<YYTransaction> list = new List<YYTransaction>();
            DbConnection.Instance().OpenConnection();
            string queryString =
                "select * from `transactions` where senderAccountNumber = @accountnumber or receiverAccountNumber = @accountnumber";
            MySqlCommand command = new MySqlCommand(queryString, DbConnection.Instance().Connection);
            command.Parameters.AddWithValue("@accountnumber", accountnumber);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                YYTransaction transaction = new YYTransaction()
                {
                    Id = reader.GetString("id"),
                    Amount = reader.GetDecimal("amount"),
                    Content = reader.GetString("content"),
                    Type = (YYTransaction.TransactionType) reader.GetInt64("type"),
                    ReceiverAccountNumber = reader.GetString("receiverAccountNumber"),
                    SenderAccountNumber = reader.GetString("senderAccountNumber"),
                    Status = (YYTransaction.ActiveStatus) reader.GetInt64("status")
                };
                list.Add(transaction);
            }

            DbConnection.Instance().CloseConnection();
            return list;
        }

        public List<YYTransaction> GetListTransaction()
        {
            List<YYTransaction> list = new List<YYTransaction>();
            DbConnection.Instance().OpenConnection();
            string queryString =
                "select * from `transactions`";
            MySqlCommand command = new MySqlCommand(queryString, DbConnection.Instance().Connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var transaction = new YYTransaction()
                {
                    Id = reader.GetString("id"),
                    Amount = reader.GetDecimal("amount"),
                    Content = reader.GetString("content"),
                    Type = (YYTransaction.TransactionType) reader.GetInt64("type"),
                    ReceiverAccountNumber = reader.GetString("receiverAccountNumber"),
                    SenderAccountNumber = reader.GetString("senderAccountNumber"),
                    Status = (YYTransaction.ActiveStatus) reader.GetInt64("status")
                };
                list.Add(transaction);
            }

            DbConnection.Instance().CloseConnection();
            return list;
        }
    }
}