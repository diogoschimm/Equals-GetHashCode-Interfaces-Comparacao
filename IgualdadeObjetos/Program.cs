using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IgualdadeObjetos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var funcionario1 = new Funcionario { Id = 1, CPF = "123", Nome = "Jose" };
            var funcionario2 = new Funcionario { Id = 2, CPF = "123", Nome = "Jose da Silva" };

            var listaFuncionarios = new List<Funcionario>
            {
                funcionario1,
                funcionario2
            };

            var igual = funcionario1.Equals( funcionario2);

            // Podemos usar a regra de igualdade para encontrar o objeto
            var exists = listaFuncionarios.Contains(funcionario1, new FuncionarioIdEqual());

            // Vai usar o metodo padrão compareTo
            listaFuncionarios.Sort();

            // Vai usar a regra que estamos usando 
            listaFuncionarios.Sort(new FunctionarioIdComparer());


            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
