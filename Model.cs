using System;
using Microsoft.Data.Sqlite;

namespace MyBankTeller
{
    internal class Model
    {
        private string connectionString;
        private SqliteConnection sqlite_conn;
        private SqliteCommand sqlite_command;

        /****************/
        /* Constructors */
        /****************/
        public Model()
        {
            this.connectionString = "Data Source=database.sqlite;";
            this.sqlite_conn = new SqliteConnection(this.connectionString);
            this.sqlite_command = this.sqlite_conn.CreateCommand();
        }
        /********************/
        /* End Constructors */
        /********************/
        public int CreateCustomer(string fullname)
        {
            int customerId = 0;
            // string connectionString = "Data Source=database.sqlite;";
            // SqliteConnection sqlite_conn = new SqliteConnection(connectionString);

            this.sqlite_conn.Open();

            // SqliteCommand sqlite_command = sqlite_conn.CreateCommand();

            this.sqlite_command.CommandText = @"CREATE TABLE IF NOT EXISTS 
                Customer (
                    id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
                    fullname TEXT NOT NULL)";

            this.sqlite_command.ExecuteNonQuery();

            this.sqlite_command.CommandText = $"INSERT INTO Customer (fullname) VALUES ('{fullname}')";

            this.sqlite_command.ExecuteNonQuery();

            this.sqlite_command.CommandText = "SELECT LAST_INSERT_ROWID() as id";

            SqliteDataReader dataReader = this.sqlite_command.ExecuteReader();

            while(dataReader.Read())
            {
                // long id = (long) dataReader["id"];
                // object id = dataReader["id"];
                customerId = int.Parse(dataReader["id"].ToString());
            }

            this.sqlite_conn.Close();

            return customerId;
        }
        // mayber this method should return the newly created Account Id
        public int CreateAccount(int customerId)
        {
            int accountId = 0;

            // string connectionString = "Data Source=database.sqlite;";
            // SqliteConnection sqlite_conn = new SqliteConnection(connectionString);

            this.sqlite_conn.Open();

            // SqliteCommand sqlite_command = sqlite_conn.CreateCommand();

            /*
            CREATE TABLE IF NOT EXISTS 
                Account (
                    id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                    customer_id INTEGER NOT NULL,
                    balance REAL NOT NULL DEFAULT 0,
					FOREIGN KEY (customer_id) REFERENCES Customer(id));
					
            insert into Account (customer_id, balance) values (1, 5.00);
            */

            this.sqlite_command.CommandText = @"CREATE TABLE IF NOT EXISTS 
                Account (
                    id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                    customer_id INTEGER NOT NULL,
                    balance REAL NOT NULL DEFAULT 0,
                    FOREIGN KEY (customer_id) REFERENCES Customer(id))"; 

            this.sqlite_command.ExecuteNonQuery();

            double initialBalance = 0;
            this.sqlite_command.CommandText = $"INSERT INTO Account (customer_id, balance) VALUES ({customerId}, {initialBalance})";

            this.sqlite_command.ExecuteNonQuery();

            this.sqlite_command.CommandText = "SELECT LAST_INSERT_ROWID() as account_id";

            SqliteDataReader dataReader = this.sqlite_command.ExecuteReader();

            while(dataReader.Read())
            {
                // long id = (long) dataReader["id"];
                // object id = dataReader["id"];
                accountId = int.Parse(dataReader["account_id"].ToString());
            }

            this.sqlite_conn.Close();

            return accountId;
        }

		internal void Deposit(string fullname, int accountId, double depositAmount)
		{
            int userId = 0;
            double currentBalance = 0;
            double newBalance;
            this.sqlite_conn.Open();

            // get customer id from db
            sqlite_command.CommandText = $"SELECT id from Customer WHERE fullname = {fullname}";
            SqliteDataReader dataReader = sqlite_command.ExecuteReader();
            while(dataReader.Read())
            {
                userId = int.Parse(dataReader["id"].ToString());
            }

            // get current balance from db
            sqlite_command.CommandText = $"SELECT balance FROM ACCOUNT WHERE id = {accountId} AND customer_id = {userId}";
            dataReader = sqlite_command.ExecuteReader();
            while(dataReader.Read())
            {
                currentBalance = double.Parse(dataReader["balance"].ToString());
            }

            // update customer account balance in db
            newBalance = currentBalance + depositAmount;

            sqlite_command.CommandText = $"UPDATE Account SET balance = {newBalance} WHERE customer_id = {userId}";

            sqlite_command.ExecuteNonQuery();

            this.sqlite_conn.Close();			
		}
	}
}