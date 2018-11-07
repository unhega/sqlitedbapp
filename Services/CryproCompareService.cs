using System.Net.Http;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Microsoft.EntityFrameworkCore;
using sqlitedbapp.Models;

namespace sqlitedbapp.Services
{
    public class CryproCompareService
    {
        DbContext dbContext;
        public CryproCompareService(DbContext dbContext){
            this.dbContext = dbContext;

        }

        public async void Process(string apiuri){
            using(HttpClient client = new HttpClient()){
                var responseMsg = await client.GetAsync(apiuri);
                var response = await responseMsg.Content.ReadAsStringAsync();
                var serializer = new DataContractJsonSerializer(typeof(Price));
            }
        }
    }
}