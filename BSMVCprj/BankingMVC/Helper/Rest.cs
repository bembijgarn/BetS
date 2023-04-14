using BankingMVC.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

namespace BankingMVC.Helper
{
    public class Rest : Irst
    {
        public async Task Restex(Bankingmodel request, string url)
        {
            var client = new RestClient(url);

            var requestt = new RestRequest();
            requestt.Method = Method.Post;
            requestt.AddHeader("Content-Type", "application/json");
            var body = JsonConvert.SerializeObject(request);
            requestt.AddParameter("application/json", body, ParameterType.RequestBody);
            await client.ExecuteAsync(requestt);
        }
    }


    public interface Irst
    {
        Task Restex(Bankingmodel model, string url);
    }
}
