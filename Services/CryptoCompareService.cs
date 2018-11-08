using System.Net.Http;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Microsoft.EntityFrameworkCore;
using sqlitedbapp.Models;
using System;
using System.Threading;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace sqlitedbapp.Services
{
    public class CryptoCompareService: IDisposable
    {
        IServiceProvider serviceProvider;
        ILogger logger;
        HttpClient client;
        CancellationTokenSource tokenSource;
        public CryptoCompareService(IServiceProvider serviceProvider, ILogger<CryptoCompareService> logger){
            this.serviceProvider = serviceProvider;
            this.logger = logger;
            client = new HttpClient();
        }

        public void Dispose()
        {
            tokenSource?.Cancel();
            tokenSource.Dispose();
        }

        public void Process(string apiuri){
            tokenSource = new CancellationTokenSource();
            ProcessAsync(apiuri, tokenSource.Token);
        }

        private async void ProcessAsync(string apiuri, CancellationToken token){
            while(!token.IsCancellationRequested){
                var responseStream = client.GetStreamAsync(apiuri);
                var serializer = new DataContractJsonSerializer(typeof(Price));
                var price = serializer.ReadObject(await responseStream) as Price;
                var dbContext = serviceProvider.GetRequiredService<SqliteDbContext>();
                await dbContext.AddAsync(price);
                logger.LogInformation(price.ToString());
                await Task.Delay(15000);
            }

        }
    }
}