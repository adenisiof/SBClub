using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace SBClub.Layers.DAL
{
    class DALLocalClient
    {
        private SqlConnection connection;
        private DataTable dataTable = null;
        private SqlDataAdapter adapter = null;
        private SqlDataReader reader = null;
        private SqlCommand command = null;

        private string pathLocalConn = string.Empty;

        //create a connection

        public void openLocalConnectio()
        {
            if (connection != null)
            {
                connection.Close();
            }
            pathLocalConn = SBClub.Properties.Settings.Default["DBLocalConnectionString"].ToString();
            //pathLocalConn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SHD\source\repos\SBClub\SBClub\DBLocal.mdf;Integrated Security=True";


            try
            {
                connection = new SqlConnection(pathLocalConn);
                connection.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro para conectar no Bando de Dados local\nContacte o Administrador SBClub\nERRO : ", "Informação", MessageBoxButton.OK, MessageBoxImage.Information);
                
            }
         }

        //Commands Sql
        public void ExecuteCommandSqlLocal(string sql)
        {
            command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        //return string
        public string RetCommandExecuted(string sql)
        {
            string ret;
            SqlCommand SqlCommand = new SqlCommand(sql, connection);

            if (SqlCommand.ExecuteScalar() != null)
            {
                ret = SqlCommand.ExecuteScalar().ToString();
                connection.Close();
                return ret;
            }
            else
            {
                connection.Close();
                return "null";
            }
            
        }

        //commads to retrun intrucions fo database
        public DataTable RetDataTable(string sql)
        {
            dataTable = new DataTable();
            adapter = new SqlDataAdapter(sql, connection);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            dataTable.TableName = "tabela";
            adapter.Fill(dataTable);
            connection.Close();

            return dataTable;
        }
           
    }

 }




        

    

