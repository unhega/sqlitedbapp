using System.Net.Http;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Microsoft.EntityFrameworkCore;
using sqlitedbapp.Models;
using System;
using System.Threading;
using Microsoft.Extensions.Logging;

namespace sqlitedbapp.Services
{
    public class CryptoCompareService: IDisposable
    {
        DbContext dbContext;
        ILogger logger;
        HttpClient client;
        CancellationTokenSource tokenSource;
        public CryptoCompareService(SqliteDbContext dbContext, ILogger<CryptoCompareService> logger){
            this.dbContext = dbContext;
            this.logger = logger;
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
                await dbContext.AddAsync(price);
                logger.LogInformation(price.ToString());
                await Task.Delay(15000);
            }

        }
    }
}