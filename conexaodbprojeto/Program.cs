using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conexaodbprojeto
{
    class Program
    {
        static void Main(string[] args)
        {
            var usuarioDAO = new UsuarioDAO();
            var usuario = new Usuario();

            while (true)
            {
                //menu
                Menu();
                Console.WriteLine("O que deseja Fazer?");
                var CodMenu = Console.ReadLine();

                //cadastro
                if (CodMenu == "0")
                {
                    CampoNomeUsuario();
                    usuario.NomeUsu = Console.ReadLine();

                    CampoCargoUsuario();
                    usuario.Cargo = Console.ReadLine();

                    CampoDataNascUsuario();
                    usuario.DataNasc = DateTime.Parse(Console.ReadLine());

                    usuarioDAO.Insert(usuario);

                    //mostrando dados
                    var leitorCad = usuarioDAO.Lista();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    foreach (var usu in leitorCad)
                    {
                        Console.WriteLine("Id: {0}, Nome: {1}, Cargo: {2}, Nascimento: {3}",
                            usu.IdUsu, usu.NomeUsu, usu.Cargo, usu.DataNasc);
                    }

                    //if para sair ou voltar pro menu
                    SaiOuVolta();
                }


                //update
                else if (CodMenu == "1")
                {
                    CampoCodigoUsuario();
                    usuario.IdUsu = int.Parse(Console.ReadLine());

                    CampoNomeUsuario();
                    usuario.NomeUsu = Console.ReadLine();

                    CampoCargoUsuario();
                    usuario.Cargo = Console.ReadLine();

                    CampoDataNascUsuario();
                    usuario.DataNasc = DateTime.Parse(Console.ReadLine());

                    usuarioDAO.Atualiza(usuario);

                    //mostrando dados
                    var leitorUpdate = usuarioDAO.Lista();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    foreach (var usu in leitorUpdate)
                    {
                        Console.WriteLine("Id: {0}, Nome: {1}, Cargo: {2}, Nascimento: {3}",
                            usu.IdUsu, usu.NomeUsu, usu.Cargo, usu.DataNasc);
                    }

                    //if para sair ou voltar pro menu
                    SaiOuVolta();
                }


                //exluir
                else if (CodMenu == "2")
                {
                    CampoCodigoUsuario();
                    usuario.IdUsu = int.Parse(Console.ReadLine());

                    usuarioDAO.Excluir(usuario);

                    //mostrando dados
                    var leitorDelete = usuarioDAO.Lista();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    foreach (var usu in leitorDelete)
                    {
                        Console.WriteLine("Id: {0}, Nome: {1}, Cargo: {2}, Nascimento: {3}",
                            usu.IdUsu, usu.NomeUsu, usu.Cargo, usu.DataNasc);                     
                    }

                    //if para sair ou voltar pro menu
                    SaiOuVolta();
                }


                else if (CodMenu == "3")
                {
                    //select
                    var leitor = usuarioDAO.Lista();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    foreach (var usu in leitor)
                    {
                        Console.WriteLine("Id: {0}, Nome: {1}, Cargo: {2}, Nascimento: {3}",
                            usu.IdUsu, usu.NomeUsu, usu.Cargo, usu.DataNasc);                      
                    }
                    //if para sair ou voltar pro menu
                    SaiOuVolta();
                }

                //sair
                else if (CodMenu == "4")
                {
                    Environment.Exit(0);
                }

                //Escolha erdaa
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Numero Inavalido");
                    Console.WriteLine("Digite Uma das escolhas abaixo");                
                }
            }
        }

        private static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("__________________Usuario______________________");
            Console.WriteLine("|    Cadastro-0                               |");
            Console.WriteLine("|    Editar-1                                 |");
            Console.WriteLine("|    Excluir-2                                |");
            Console.WriteLine("|    Listar-3                                 |");
            Console.WriteLine("|    Sair-4                                   |");
            Console.WriteLine("|_____________________________________________|");
        }

        //Campo Codigo
        private static void CampoCodigoUsuario()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Codigo Do Usuário:");
            Console.ForegroundColor = ConsoleColor.Red;
        }

        //campo Nome de Usuario
        private static void CampoNomeUsuario()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Nome Do Usuário:");
            Console.ForegroundColor = ConsoleColor.Red;
        }

        //campo Cagro
        private static void CampoCargoUsuario()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Cargo Do Usuário:");
            Console.ForegroundColor = ConsoleColor.Red;
        }

        //Data de nascimento
        private static void CampoDataNascUsuario()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Data de Nascimento:");
            Console.ForegroundColor = ConsoleColor.Red;
        }

        //If para sair ou voltar para menu
        private static void SaiOuVolta()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("     1-Sair\n     2-Menu");
            if (Console.ReadLine() == "1")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
            }
        }


    }
}
