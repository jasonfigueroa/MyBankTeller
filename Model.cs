using Microsoft.Data.Sqlite;

namespace MyBankTeller
{
    internal class Model
    {
        // private string connectionString;
        // private SqliteConnection sqlite_conn;

        /****************/
        /* Constructors */
        /****************/
        // public Model()
        // {
        //     connectionString = "Data Source=database.sqlite;";
        // }
        /********************/
        /* End Constructors */
        /********************/
        public int CreateCustomer(string fullname)
        {
            int customerId = 0;
            string connectionString = "Data Source=database.sqlite;";
            SqliteConnection sqlite_conn = new SqliteConnection(connectionString);

            sqlite_conn.Open();

            SqliteCommand sqlite_command = sqlite_conn.CreateCommand();

            sqlite_command.CommandText = @"CREATE TABLE IF NOT EXISTS 
                Customer (
                    id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
                    fullname TEXT NOT NULL)";

            sqlite_command.ExecuteNonQuery();

            sqlite_command.CommandText = $"INSERT INTO Customer (fullname) VALUES ('{fullname}')";

            sqlite_command.ExecuteNonQuery();

            sqlite_command.CommandText = "SELECT LAST_INSERT_ROWID() as id";

            SqliteDataReader dataReader = sqlite_command.ExecuteReader();

            while(dataReader.Read())
            {
                // long id = (long) dataReader["id"];
                // object id = dataReader["id"];
                customerId = int.Parse(dataReader["id"].ToString());
            }

            sqlite_conn.Close();

            return customerId;
        }
        // mayber this method should return the newly created Account Id
        public int CreateAccount(int customerId)
        {
            int accountId = 0;

            string connectionString = "Data Source=database.sqlite;";
            SqliteConnection sqlite_conn = new SqliteConnection(connectionString);

            sqlite_conn.Open();

            SqliteCommand sqlite_command = sqlite_conn.CreateCommand();

            /*
            CREATE TABLE IF NOT EXISTS 
                Account (
                    id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                    customer_id INTEGER NOT NULL,
                    balance REAL NOT NULL DEFAULT 0,
					FOREIGN KEY (customer_id) REFERENCES Customer(id));
					
            insert into Account (customer_id, balance) values (1, 5.00);
            */

            sqlite_command.CommandText = @"CREATE TABLE IF NOT EXISTS 
                Account (
                    id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                    customer_id INTEGER NOT NULL,
                    balance REAL NOT NULL DEFAULT 0,
                    FOREIGN KEY (customer_id) REFERENCES Customer(id))"; 

            sqlite_command.ExecuteNonQuery();

            double initialBalance = 0;
            sqlite_command.CommandText = $"INSERT INTO Account (customer_id, balance) VALUES ({customerId}, {initialBalance})";

            sqlite_command.ExecuteNonQuery();

            sqlite_command.CommandText = "SELECT LAST_INSERT_ROWID() as account_id";

            SqliteDataReader dataReader = sqlite_command.ExecuteReader();

            while(dataReader.Read())
            {
                // long id = (long) dataReader["id"];
                // object id = dataReader["id"];
                accountId = int.Parse(dataReader["account_id"].ToString());
            }

            sqlite_conn.Close();

            return accountId;
        }
    }
}