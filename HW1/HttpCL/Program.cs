using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.IO;
using System.Text;

namespace HttpCL
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static readonly string baseURL = "https://jsonplaceholder.typicode.com/todos/";
        static readonly string fileName = "result.txt";
        static async Task Main(string[] args)
        {
            client.BaseAddress = new Uri(baseURL);
            for (int i = 4; i < 14; i++)
            {                
                Post post = await client.GetFromJsonAsync<Post>(i.ToString());
                StringBuilder stringBuilder = new StringBuilder(post.userId.ToString()+"\n");
                stringBuilder.Append(post.id.ToString() + "\n");
                stringBuilder.Append(post.title + "\n"+String.Empty+"\n");
                File.AppendAllText(fileName, stringBuilder.ToString());
            }
            
        }
    }
}
