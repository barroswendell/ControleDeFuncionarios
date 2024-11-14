using FluentValidation;
using ProjetoAula04.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula04.Validations
{
    /// <summary>
    /// Classe para validação dos dados do funcionário.
    /// </summary>
    
    public class FuncionarioValidator : AbstractValidator <Funcionario>
    {

        /// <summary>
        /// Método construtor para implementar as validações do funcionario 
        /// </summary>
        
        public FuncionarioValidator()
        {
            // Validações do campo ID

            RuleFor(f => f.Id)
                .NotEmpty().WithMessage("Por favor, informe o ID do funcionário,");

            //Validações do campo'Nome'.

            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("Por favor, informe o nome do funcionário.")
                .Length(8, 150).WithMessage("Por favor, informe o nome do funcionário de 8 a 150 caracteres.");

            //Validações do campo 'CPF'

            RuleFor(f => f.Cpf)
                .NotEmpty().WithMessage("Por favor, informe o cpf do funcionário")
                .Matches(@"^\d{11}$").WithMessage("Por favor, informe o cpf com exatamente 11 números.");

                // Validações do campo 'Salario'

                RuleFor(f => f.Salario)
                .GreaterThan(0).WithMessage("Por favor, informe o salário maior do que zero");

            //Validações do campo 'Tipo' (enum)

            RuleFor(f => f.Tipo)
                .IsInEnum().WithMessage("Por Favor, informe um tipo de contratação vãolido(1, 2 ou 3).");


            
        }
    }
}
