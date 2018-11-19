using System.Net.Http;
using System.Threading.Tasks;
using sqlitedbapp.Models;
using System;
using System.Linq;
using System.Threading;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace sqlitedbapp.Services
{
    public class CryptoCompareService : IDisposable
    {
        Dictionary<Session, Task> activeSessions;
        IServiceProvider serviceProvider;
        ILogger logger;
        HttpClient client;
        CancellationTokenSource tokenSource;
        CancellationTokenSource TokenSource { get 
        {
            if(tokenSource!=null) return tokenSource;
            else 
            {
                tokenSource = new CancellationTokenSource();
                return tokenSource;
            } 
        } }

        string apiuri = "https://min-api.cryptocompare.com/data/price?fsym=BTC&tsyms=USD,RUB";
        public CryptoCompareService(IServiceProvider serviceProvider, ILogger<CryptoCompareService> logger)
        {
            this.serviceProvider = serviceProvider;
            this.logger = logger;
            activeSessions = new Dictionary<Session, Task>();
            client = new HttpClient();
        }

        

        public void Dispose()
        {
            TokenSource?.Cancel();
            TokenSource.Dispose();
        }

        public void Process(Session session)
        {
            session.Status = SessionStatus.Online;
            activeSessions[session] = ProcessAsync(session, TokenSource.Token);
        }

        public bool Stop(int id)
        {
            var session = activeSessions.Keys.Single(key => key.Id == id);
            if(session != null)
            {
                session.Status = SessionStatus.Offline;
                return true;
            }
            else return false;
            
        }

        private async Task ProcessAsync(Session session, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                //Остановка сессии по времени
                if(session.EndTime <= DateTimeOffset.UtcNow) break; 
                //Остановка сессии по запросу
                if(session.Status != SessionStatus.Online) break; 
                var response = client.GetStringAsync(apiuri);
                var price = JsonConvert.DeserializeObject<Price>(await response);
                price.Session = session;

                using (var _scope = serviceProvider.CreateScope())
                using (var dbContext = _scope.ServiceProvider.GetRequiredService<SqliteDbContext>())
                {
                    await dbContext.AddAsync(price);
                    await dbContext.SaveChangesAsync();
                }

                logger.LogInformation(price.ToString());
                await Task.Delay(15000);
            }

            session.Status = SessionStatus.Offline;
            session.EndTime = DateTimeOffset.Now.ToUniversalTime();
            using (var _scope = serviceProvider.CreateScope())
                using (var dbContext = _scope.ServiceProvider.GetRequiredService<SqliteDbContext>())
                {
                    dbContext.Update(session);
                    await dbContext.SaveChangesAsync();
                }

        }
    }
}