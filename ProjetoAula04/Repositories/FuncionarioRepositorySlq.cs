using Dapper;
using ProjetoAula04.Entities;
using ProjetoAula04.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula04.Repositories
{
    /// <summary>
    /// Implementação de repositório de funcionário
    /// para gravação em banco de dados do SqlsServer 
    /// </summary>
    
    public class FuncionarioRepositorySlq : IFuncionarioReposytory

    {
        public void ExportarDados(Funcionario funcionario)
        {
            //Abrindo conexão com o banco de dados

            using (var connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDProjetoAula004;Integrated Security=True;"))
            {
                //Executando um comando SQL para inserir
                //um funcionário na tabela do banco (INSERT)

                connection.Execute("INSERT INTO FUNCIONARIO (ID, NOME, CPF, SALARIO, TIPO) VALUES (@ID,@NOME,@CPF, @SALARIO,@TIPO )",
                        new
                        {
                            @ID = funcionario.Id,
                            @NOME = funcionario.Nome,
                            @CPF = funcionario.Cpf,
                            @SALARIO = funcionario.Salario,
                            @TIPO = (int)funcionario.Tipo
                        });

            }
        }
    }
}
