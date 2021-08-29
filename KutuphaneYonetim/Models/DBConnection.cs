using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace KutuphaneYonetim.Models
{
    public class DBConnection
    {
        private DBConnection()
        {

        }
        private static string connString = String.Format("Server={0};Port={1};" +
        "User Id={2};Password={3};Database={4};", "ec2-54-228-139-34.eu-west-1.compute.amazonaws.com", 5432, "pmcxffwcovbraz", "şifre", "d4e0mf1mi5g7b4");
        private readonly NpgsqlConnection conn = new NpgsqlConnection(connString);

        private static DBConnection instance = null;
        public static DBConnection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DBConnection();
                }
                return instance;
            }
        }
        public NpgsqlConnection GetDBConnection()
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
            }
            catch (Exception)
            {
            }
            finally
            {
            }

            return conn;
        }




    }
}
