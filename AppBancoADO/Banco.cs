using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conexaodbprojeto
{
    public class Banco: IDisposable
    {
        private readonly MySqlConnection conexao;

        //conexao
        public Banco()
        {
            conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
            conexao.Open();
            
        }  

        //executa comandos
        public void ExecutaComando(string StrQuery)
        {
            var vComando = new MySqlCommand
            {
                CommandText = StrQuery,
                CommandType =CommandType.Text,
                Connection = conexao
            };
            vComando.ExecuteNonQuery();
        }


        //mostra os comandos
        public MySqlDataReader RetornaComando(string StrQuery)
        {
            var comando = new MySqlCommand(StrQuery, conexao);
            return comando.ExecuteReader();
        }


        //fecha o banco
        public void Dispose()
        {
            //se conexao aberta então feche
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
            
        }

    }
}
