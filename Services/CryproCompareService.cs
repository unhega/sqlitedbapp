using System.Net.Http;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Microsoft.EntityFrameworkCore;
using sqlitedbapp.Models;
using System;
using System.Threading;

namespace sqlitedbapp.Services
{
    public class CryproCompareService: IDisposable
    {
        DbContext dbContext;
        HttpClient client;
        CancellationTokenSource tokenSource;
        public CryproCompareService(DbContext dbContext){
            this.dbContext = dbContext;
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
            }

        }
    }
}