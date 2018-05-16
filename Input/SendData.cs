using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Input
{
    class SendData
    {
        public void CreateUser(User user)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57224/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.PostAsJsonAsync("api/Users", user);
        }

        public void CreateComputer(Computer computer)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57224/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
   
            var response = client.PostAsJsonAsync("api/products", computer);
        }

        public void CreateMemory(Memory memory)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57224/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.PostAsJsonAsync("api/products", memory);
        }

        public void CreateGraphicCard(GraphicCard graphic)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57224/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.PostAsJsonAsync("api/products", graphic);
        }

        public void CreateHDD(DiskDrive diskDrive)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57224/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.PostAsJsonAsync("api/products", diskDrive);
        }
    }
}
