using ProjetoAula04.Entities;
using ProjetoAula04.Enums;
using ProjetoAula04.Repositories;
using ProjetoAula04.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ProjetoAula04.Controllers
{
    /// <summary>
    /// Classe de Controle para realizar os fluxos de ações de funcionário
    /// </summary>
    
    public class FuncionarioController
    {

        /// <summary>
        /// Método para realizar o cadastro do funcionário
        /// </summary>

        public void CadastrarFuncionario()
        {
            Console.WriteLine("\n*** CADASTRO DE FUNCIONÁRIO:***\n ");

            //Criando um Objeto da classe de funcionário.

            var funcionario = new Funcionario();

            Console.Write("INFORME O NOME DO FUNCIONÁRIO......:");
            funcionario.Nome = Console.ReadLine();

            Console.Write("INFORME O CPF DO FUNCIONÁRIO.......:");
            funcionario.Cpf = Console.ReadLine();

            Console.Write("INFORME O SÁLARIO DO FUNCIONÁRIO....:");
            funcionario.Salario = decimal.Parse(Console.ReadLine());


            Console.WriteLine("\t(1) ESTÁGIO");
            Console.WriteLine("\t(2) CLT");
            Console.WriteLine("\t(3) TERCEIRIZADO");
            Console.Write("INFORME O TIPO (1, 2 OU 3)............:");
            funcionario.Tipo = (TipoContratacao)int.Parse(Console.ReadLine());


            #region Validação dos dados do funcionário 


            //Instanciando a classe de validação do funcionario.

            var funcionarioValidator = new FuncionarioValidator();

            //Aplicando as regras de validação no objeto 'funcionario'.

            var result = funcionarioValidator.Validate(funcionario);

            //Verificar se o funcionario passou na verificação

            if(result.IsValid)
            {
                //Instanciando a classe de repositório JSON

                var funcionarioRepositoryJson = new FuncionarioRepositoryJson();
                funcionarioRepositoryJson.ExportarDados(funcionario);
                Console.WriteLine("\nFUNCIONÁRIO CADASTRADO COM SUCESSO EM ARQUIVO JSON!");

                //Instanciando a classe de repositório SQL
                var funcionarioRepositorySql = new FuncionarioRepositorySlq();
                funcionarioRepositorySql.ExportarDados(funcionario);
                Console.WriteLine("\nFUNCIONÁRIO CADASTRADO COM SUCESSO EM AQUIVO SQL!");


            }
            else

            {

                Console.WriteLine("\nOCORRERAM ERROS DE VALIDAÇÃO");

                //Percorrendo todos os erros de validação encontrados

                foreach (var item in result.Errors) 


                {
                    //Imprimindo cada mensagem de erro de validação obtida.
                    Console.WriteLine(item.ErrorMessage);


                } 

            }





            #endregion






        }



    }
}
