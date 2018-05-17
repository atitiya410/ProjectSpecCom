using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Management;

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
   
            var response = client.PostAsJsonAsync("api/Computers", computer);
        }

        public void CreateMemory(Memory memory)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57224/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.PostAsJsonAsync("api/Memories", memory);
        }

        public void CreateGraphicCard(GraphicCard graphic)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57224/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.PostAsJsonAsync("api/GraphicCards", graphic);
        }

        public void CreateHDD(DiskDrive diskDrive)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57224/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.PostAsJsonAsync("api/DiskDrives", diskDrive);
        }

        public void CreateComUser(ComputerUser computerUser)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57224/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.PostAsJsonAsync("api/ComputerUsers", computerUser);
        }
    }
}
