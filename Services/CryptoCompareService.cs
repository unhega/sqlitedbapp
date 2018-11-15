using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sqlitedbapp.Models;
using System;
using System.Threading;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.IO;

namespace sqlitedbapp.Services
{
    public class CryptoCompareService : IDisposable
    {
        IServiceProvider serviceProvider;
        ILogger logger;
        HttpClient client;
        CancellationTokenSource tokenSource;
        public CryptoCompareService(IServiceProvider serviceProvider, ILogger<CryptoCompareService> logger)
        {
            this.serviceProvider = serviceProvider;
            this.logger = logger;
            client = new HttpClient();
        }

        public void Dispose()
        {
            tokenSource?.Cancel();
            tokenSource.Dispose();
        }

        public void Process(string apiuri)
        {
            tokenSource = new CancellationTokenSource();
            ProcessAsync(apiuri, tokenSource.Token);
        }

        private async void ProcessAsync(string apiuri, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                var response = client.GetStringAsync(apiuri);
                var price = JsonConvert.DeserializeObject<Price>(await response) as Price;

                using (var _scope = serviceProvider.CreateScope())
                using (var dbContext = _scope.ServiceProvider.GetRequiredService<SqliteDbContext>())
                {
                    await dbContext.AddAsync(price);
                    await dbContext.SaveChangesAsync();
                }

                logger.LogInformation(price.ToString());
                await Task.Delay(15000);
            }

        }
    }
}