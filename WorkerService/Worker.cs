using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Presentation;
using Domain;

namespace WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly IPersonRepository _repository;

        public Worker(IPersonRepository repository)
        {
            _repository = repository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");
            _repository.FirstRun();
            Controller.menu();
        }
    }
}
