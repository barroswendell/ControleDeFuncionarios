using Newtonsoft.Json;
using ProjetoAula04.Entities;
using ProjetoAula04.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula04.Repositories
{
    /// <summary>
    /// Implementação de repositório de funcionário
    /// para gravação em arquivoJSON.    
    /// </summary>
    
    public class FuncionarioRepositoryJson : IFuncionarioReposytory

    {
        public void ExportarDados(Funcionario funcionario)

        {
            // Converter os dados do funcionário em JSON.

            var json = JsonConvert.SerializeObject(funcionario, Formatting.Indented);

            //Abrindo um arquivo para gravação.

            var streamWriter = new StreamWriter("c:\\temp\\funcionarios.json", true);

            //Gravar os dados no arquivo.

            streamWriter.WriteLine(json);

            //Fechando o arquivo.

            streamWriter.Close();
        }
    }
}
