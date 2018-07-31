using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace rpc_http
{
  class Program
  {
    static void Main(string[] args)
    {
      	GetVersion().Wait();
        GetAccounts().Wait();
    }
    
    static async Task GetVersion()
    {
      HttpClient httpClient = new HttpClient();

      string url = "http://localhost:8545";
      string payload = "{\"jsonrpc\":\"2.0\",\"method\":\"web3_clientVersion\",\"params\":[],\"id\":7878}";
      Console.WriteLine("<= " + payload);
      StringContent content = new StringContent(payload,Encoding.UTF8,"application/json");
      HttpResponseMessage rsp = await httpClient.PostAsync(url,content);
      string ret = await rsp.Content.ReadAsStringAsync();
      Console.WriteLine("=> " + ret);      
    }
    
    static async Task GetAccounts()
    {
      HttpClient httpClient = new HttpClient();

      string url = "http://localhost:8545";
      string payload = "{\"jsonrpc\":\"2.0\",\"method\":\"eth_accounts\",\"params\":[],\"id\":7878}";
      Console.WriteLine("<= " + payload);
      StringContent content = new StringContent(payload,Encoding.UTF8,"application/json");
      HttpResponseMessage rsp = await httpClient.PostAsync(url,content);
      string ret = await rsp.Content.ReadAsStringAsync();
      Console.WriteLine("=> " + ret);      
    }
    
  }
}
