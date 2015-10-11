using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PMDbDataAccess
{
    public class DbDataAccess
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public DbDataAccess()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "127.0.0.1";
            database = "pmdb";
            uid = "shashank";
            password = "shas1412";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        private bool OpenConn()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot connect to database. Caught exception with message : " + ex.Message);
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Failed to close database connection. Exception message : " + ex.Message);
                return false;
            }
        }

        public List<string>[] GetUserTypesFromDb()
        {
            // Query Setup
            List<string> cols = new List<string>();
            cols.Add(DbTableUserType.UserTypeIdCol);
            cols.Add(DbTableUserType.UserTypeNameCol);

            string query = "SELECT ";
            foreach(string col in cols)
            {
                query += col + ",";
            }
            query = query.TrimEnd(',');
            query += " FROM " + DbTableUserType.TableName + ";";

            //Create a list to store the result
            List<string>[] res = new List<string>[cols.Count];
            for(int i=0; i<cols.Count; ++i)
            {
                res[i] = new List<string>();
            }

            //Open connection
            if (OpenConn())
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    for (int i = 0; i < cols.Count; ++i)
                    {
                        res[i].Add(dataReader[cols[i]] + "");
                    }
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();
            }
            return res;
        }
    }
}
