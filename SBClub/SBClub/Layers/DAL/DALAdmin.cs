using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SBClub;

namespace SBClub.Layers.DAL
{
    class DALAdmin
    {
        //create connection 
        private MySqlConnection connection;        
        private DataTable dataTable;
        private MySqlDataAdapter mySqlDataAdapter;
        private MySqlDataReader mySqlDataReader;
        private MySqlCommandBuilder mySqlCommandBuilder;


        private string pathConn = string.Empty;
        string strSql = string.Empty;

        private string server = "108.167.168.51"; 
        private string user = "sbclub";
        private string database = "sbclub_app";
        private string password = "marceloCEL17";
      
       /* private string server = "127.0.0.1";
        private string user = "root";
        private string database = "sbclubd";
        private string password = "@formiga";
        */
        //to connect datatable
        public void ConnectAdmin()
        {
            if(connection != null)
            {
                connection.Close();
            }

            pathConn = string.Format("server = {0}; user id = {1}; database = {2}; password = {3}", server, user, database, password);
            

            try
            {
                connection = new MySqlConnection(pathConn);
                connection.Open();
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro ao conectar ao Banco de Dados\nContacte seu administrado SBClub\nERRO : ", ex);
            }
        }
        
        //comand sql 
        public void ExecutCommandSql(string sql)
        {
            MySqlCommand mySqlCommand = new MySqlCommand(sql, connection);
            mySqlCommand.ExecuteNonQuery();
            connection.Close();
        }

        public string RetCommandExecuted(string sql)
        {
            string ret;
            MySqlCommand mySqlCommand = new MySqlCommand(sql, connection);

            if(mySqlCommand.ExecuteScalar() != null)
            {
                ret = mySqlCommand.ExecuteScalar().ToString();
                connection.Close();
                return ret;
            }
            else
            {
                connection.Close();
                return null;
            }            
        }
        //create a copy of admin table into the system
        public DataTable RetDataTable(string sql)
        {
            dataTable = new DataTable();
            mySqlDataAdapter = new MySqlDataAdapter(sql, connection);
            mySqlCommandBuilder = new MySqlCommandBuilder(mySqlDataAdapter);
            mySqlDataAdapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }       
    }
}
