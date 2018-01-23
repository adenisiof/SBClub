using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBClub.Layers.DTO;
using SBClub.Layers.DAL;
using System.Data;
using System.Windows;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;


namespace SBClub.Layers.DLL
{
    class ClientBLL
    {
        DALAdmin admin = new DALAdmin();
        //DALLocalClient local = new DALLocalClient();
        DALLocalClient dbLocal = new DALLocalClient();
        public string data_acesso;       


        public bool InsertDbLocal(DTOClientLocal dto, bool e)
        {
            
            try
            {
                dbLocal.openLocalConnectio();
                string strSqlLogin = string.Format("SELECT ultimo_acesso FROM login WHERE id_parceiro = '{0}'", dto.Login);
                string loginLocal =  dbLocal.RetCommandExecuted(strSqlLogin);   
                
                if(loginLocal != "null")
                {
                    e = LoginLocal(dto);
                    return e;                    
                }            
                else
                {
                     e = LoginAdmin(dto);
                     return e;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro na verificação de login\nContacte o Administrador SBClub\nERRO : ");
            }

            return false;
        }

        //access admin db
        public bool LoginAdmin(DTOClientLocal dto)
            {

                try
                {
                    admin.ConnectAdmin();
                    string strSqlLogin = string.Format("SELECT id_login FROM parceiro WHERE id_login = '{0}' AND senha = '{1}'", dto.Login, dto.Senha);
                    string strSqlSenha = string.Format("SELECT senha FROM parceiro WHERE id_login = '{0}' AND senha = '{1}'", dto.Login, dto.Senha);
                    int login;

                    if(int.TryParse(admin.RetCommandExecuted(strSqlLogin),out login) == false)
                    {
                    MessageBox.Show("Usuario não cadastrado\nContacte o Administrador SBClub", "SBClub", MessageBoxButton.OK, MessageBoxImage.Warning);
                         return false;
                    }                         

                    admin.ConnectAdmin();
                    string senha = admin.RetCommandExecuted(strSqlSenha);

                    if (login == dto.Login && senha == dto.Senha)
                    {
                        dbLocal.openLocalConnectio();
                        string insertDataDblocal = string.Format("INSERT INTO login(id_parceiro, senha) VALUES('{0}','{1}')", dto.Login, dto.Senha);
                        dbLocal.ExecuteCommandSqlLocal(insertDataDblocal);
                        MessageBox.Show("Usuario logado com Sucesso", "Informação", MessageBoxButton.OK, MessageBoxImage.Information);


                    //insert today date in admin
                    string today = DateTime.Today.ToString().Substring(0,10);
                    string insertData = string.Format("UPDATE `parceiro` SET `ultimo_acesso` = '{0}' WHERE `parceiro`.`id_login` = '{1}'", today, dto.Login);
                 
                    admin.ConnectAdmin();
                    admin.ExecutCommandSql(insertData);
                    DataAcesso(dto, insertData);
                    return true;
                    }
                    else
                    {
                        MessageBox.Show("Usuario não cadastrado","SBClub", MessageBoxButton.OK, MessageBoxImage.Information);
                        return false;
                    }

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Erro na verificação de login\nContacte o Administrador SBClub ","SBClub", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            //dbLocal.openLocalConnectio();
        }

        //access local db
        public bool LoginLocal(DTOClientLocal dto)
        {
             data_acesso = DateTime.Today.ToString().Substring(0,10);          

            try
            {
                string userData = string.Format("SELECT ultimo_acesso FROM login WHERE id_parceiro = '{0}' AND senha = '{1}'", dto.Login, dto.Senha);
                string userLogin = string.Format("SELECT id_parceiro FROM login WHERE id_parceiro = '{0}' AND  senha = '{1}'", dto.Login, dto.Senha);
                string userSenha = string.Format("SELECT senha FROM login WHERE id_parceiro = '{0}' AND senha = '{1}'", dto.Login, dto.Senha);
                dbLocal.openLocalConnectio();
                string login = dbLocal.RetCommandExecuted(userLogin);
                dbLocal.openLocalConnectio();
                string senha = dbLocal.RetCommandExecuted(userSenha);
                dbLocal.openLocalConnectio();
                userData = userData = dbLocal.RetCommandExecuted(userData);

                
                if (login == dto.Login.ToString() && senha == dto.Senha)
                {
                    DataAcesso(dto, userData);
                    MessageBox.Show("Logado banco de dados local", "Informação", MessageBoxButton.OK, MessageBoxImage.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Erro na verificação de login\nContacte o Administrador SBClub", "Informação", MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro na verificação de login\nContacte o Administrador SBClub", "Informação", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }           

        }

        //control data access 
        public void DataAcesso(DTOClientLocal dto, string userData)
        {
            string today = DateTime.Today.ToString().Substring(0, 10);
            if (userData != today)
            {
                admin.ConnectAdmin();
                userData = string.Format("UPDATE `parceiro` SET `ultimo_acesso` = '{0}' WHERE `parceiro`.`id_login` = '{1}'", today, dto.Login);
                admin.ExecutCommandSql(userData);

                dbLocal.openLocalConnectio();
                userData = string.Format("UPDATE login SET ultimo_acesso = '{0}' WHERE login.id_parceiro = '{1}'", today, dto.Login);
                dbLocal.ExecuteCommandSqlLocal(userData);

            }
            else
            {
                dbLocal.openLocalConnectio();
                userData = string.Format("UPDATE login SET ultimo_acesso = '{0}' WHERE login.id_parceiro= '{1}'", today, dto.Login);
                dbLocal.ExecuteCommandSqlLocal(userData);
            }
        }


        //control associate 
        public string FindAssociates(DTOClientLocal dto, bool cpforip)
        {
            string nome = "";
            int login_associado;
            string cpf_associado;
            string nome_associado;
            int pontos;
            try
            {
                admin.ConnectAdmin();
                //select data of associate's when make a bought
                string strSqlCpf = string.Format("SELECT cpf FROM associado WHERE id_login = '{0}' OR cpf = '{1}'", dto.Login, dto.Cpf);
                cpf_associado = admin.RetCommandExecuted(strSqlCpf);

                if (cpf_associado != null)
                {
                    admin.ConnectAdmin();
                    string strSqlLogin = string.Format("SELECT id_login FROM associado WHERE id_login = '{0}' OR cpf = '{1}'", dto.Login, dto.Cpf);
                    login_associado = int.Parse(admin.RetCommandExecuted(strSqlLogin));

                    admin.ConnectAdmin();
                    string strSqlNome = string.Format("SELECT nome FROM associado WHERE id_login = '{0}' OR cpf = '{1}'", dto.Login, dto.Cpf);
                    nome_associado = admin.RetCommandExecuted(strSqlNome);

                    admin.ConnectAdmin();
                    string strSqlPontos = string.Format("SELECT pontos FROM associado WHERE id_login = '{0}' OR cpf = '{1}'", dto.Login, dto.Cpf);
                    int.TryParse(admin.RetCommandExecuted(strSqlPontos), out pontos);

                    dbLocal.openLocalConnectio();
                    string strSqlloginLojista = string.Format("SELECT id_parceiro FROM login");
                    int id_lojista = int.Parse(dbLocal.RetCommandExecuted(strSqlloginLojista));

                    dto.Login = login_associado;
                    dto.Cpf = cpf_associado;
                    dto.Nome = nome_associado;
                    dto.Pontos = pontos;
                    dto.id_lojista = id_lojista;           

                    return nome;
                }
                else
                {
                    MessageBox.Show("Associado não encontrado\nContacte o Administrado SBClub","SBClub", MessageBoxButton.OK, MessageBoxImage.None);
                    return "Não Cadastrado";
                }

            }
            catch (MySqlException e)
            {
                MessageBox.Show ("Erro ao acessar o banco de dados\nCheque sua conexão com a internet ou contacte o Administrado SBClub\n","Informação", MessageBoxButton.OK, MessageBoxImage.Error);
                return "Nome Associado";
            }
        }

        //insert new data in local database and admin database bougth of client
        public bool LancaPontoAssociado(DTOClientLocal dto)
        {          
            try
            {
                admin.ConnectAdmin();
               
                    string strSql = $"INSERT INTO `movimentacao_associado` (`id_login_associado`, `valor_compra`, `forma_pagamento`, `pontos`, `data_compra`, `id_lojista`) VALUES ({dto.Login}, '{dto.ValorGasto}', '{dto.Pagamento}', {dto.Pontos}, '{DateTime.Now.ToString()}', {dto.id_lojista}); ";
                    admin.ExecutCommandSql(strSql);
                
                    dbLocal.openLocalConnectio();
                    string insertDataDblocal = $"INSERT INTO  associado ( id_login_associado, cpf, nome, forma_pagamento, pontos, data_compra, valor_compra, id_parceiro) VALUES ({dto.Login},'{dto.Cpf}','{dto.Nome}', '{dto.Pagamento}', {dto.Pontos}, '{DateTime.Now.ToString()}','{dto.ValorGasto}', {dto.id_lojista})";
                    dbLocal.ExecuteCommandSqlLocal(insertDataDblocal);

                return true;
             }
            catch
            {
                MessageBox.Show("Erro ao inserir pontuação no servidor\nContacte o Administrador SBClub", "SBClub", MessageBoxButton.OK,MessageBoxImage.Error);
                return false;
            }
        }

       

        //load gridview with 20 last clients that bought 
        public DataTable RetResumo()
        {
            DataTable dataTable = new DataTable();
            dbLocal.openLocalConnectio();            
            dataTable = dbLocal.RetDataTable("SELECT cpf, pontos, data_compra, valor_compra FROM associado");

            return dataTable;
        }

        //load plan
        public DataTable LoadPlanos()
        {
            DataTable data = new DataTable();
            int id_lojista;
            try
            {
                string strSql = $"SELECT id_parceiro FROM login";
                dbLocal.openLocalConnectio();
                if (int.TryParse(dbLocal.RetCommandExecuted(strSql), out id_lojista))
                {
                    strSql = $"SELECT plano1, descricao1, plano2, descricao2, plano3, descricao3, plano4, descricao4 FROM planos WHERE  id_lojista = '{id_lojista}';";
                    admin.ConnectAdmin();
                    data = admin.RetDataTable(strSql);
                }

            }
            catch
            {
                MessageBox.Show("Erro ao conectar com Servidor\nContacte Administrado SBClub","SBClub", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return data;
        }
        
    }   
}
