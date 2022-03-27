using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conexaodbprojeto
{
    public class UsuarioDAO
    {
        private Banco db;

        //insert
        public void Insert(Usuario usuario)
        {
            var strQuery = "";
            strQuery += "call insereusu";
            strQuery += string.Format("('{0}', '{1}', STR_TO_DATE('{2}', '%d/%m/%Y %T'))", usuario.NomeUsu, usuario.Cargo, usuario.DataNasc);

            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }
        }

        //update
        public void Atualiza(Usuario usuario)
        {
            var strQuery = "";
            strQuery += string.Format("UPDATE tb_USUARIO SET ");
            strQuery += string.Format("NomeUsu='{0}', ", usuario.NomeUsu);
            strQuery += string.Format("cargo='{0}', ", usuario.Cargo);
            strQuery += string.Format("DataNasc= STR_TO_DATE('{0}', '%d/%m/%Y %T')", usuario.DataNasc);
            strQuery += string.Format("WHERE idusu = {0} ", usuario.IdUsu);
            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }
        }

        //exclusao
        public void Excluir(Usuario usuario)
        {
            using(db=new Banco())
            {
                string strDeletaUso = string.Format("delete from tb_USUARIO WHERE idusu={0}",usuario.IdUsu);
                db.ExecutaComando(strDeletaUso);
            }
        }

        public List<Usuario> Lista()
        {
             using(db = new Banco())
            {
                var strSelecionaUsu = "Select * from tb_USUARIO";
                var retorno =db.RetornaComando(strSelecionaUsu);
                return ListaDeUsuario(retorno);
        
            }
        }

        public List<Usuario> ListaDeUsuario(MySqlDataReader retorno)
        {
            var usuario = new List<Usuario>();
            while (retorno.Read())
            {
                var TempUsuario = new Usuario()
                {
                    IdUsu = int.Parse(retorno["IdUsu"].ToString()),
                    NomeUsu = retorno["NomeUsu"].ToString(),
                    Cargo = retorno["Cargo"].ToString(),
                    DataNasc = DateTime.Parse(retorno["DataNasc"].ToString())
                };
                usuario.Add(TempUsuario);
            }
            retorno.Close();
            return usuario;
        }



//desisão se faz insert ou update
public void Salva(Usuario usuario)
        {

            if (usuario.IdUsu > 0)
            {
                Atualiza(usuario);
            }
            else
            {
                Insert(usuario);
            }
        }
    }

}
