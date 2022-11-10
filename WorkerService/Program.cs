using Domain;
using Infra;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var configRepositorio = hostContext.Configuration.GetValue<string>("AppSettings:configRepositorio");
                    services.AddSingleton<IPersonRepository>(provider => DefinirRepoInstancia(configRepositorio));
                    services.AddHostedService<Worker>();
                });
        private static IPersonRepository DefinirRepoInstancia(string configRepositorio)
        {
            if (configRepositorio == "LinkedList")
                return new PersonsRepository();
            else
                throw new NotImplementedException("Não existe implementação de repositório para configuração existente.");
        }
    }
}
