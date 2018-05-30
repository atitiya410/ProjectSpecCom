using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using SpeccomDB.Models;

namespace Input
{
    class SendData
    {
        string url = "https://webapispeccom20180518043834.azurewebsites.net/";
        //"http://localhost:57224/";




        public async Task<User> CreateUser(User user)
        {            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.PostAsJsonAsync("api/Users", user);
            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<User>();
            }
            return user;
        }

        public async Task<string> CreateComputer(Computer computer)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response =await client.PostAsJsonAsync("api/Computers", computer);
            string result = null;

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<string>();
            }
            return result;
        }

        public async Task CreateMemory(Memory memory)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.PostAsJsonAsync("api/Memories", memory);
        }

        public async Task CreateGraphicCard(GraphicCard graphic)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.PostAsJsonAsync("api/GraphicCards", graphic);
        }

        public async Task CreateHDD(DiskDrive diskDrive)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.PostAsJsonAsync("api/DiskDrives", diskDrive);
        }

        //public void CreateComUser(ComputerUser computerUser)
        //{
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri(url);
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //    var response =  client.PostAsJsonAsync("api/ComputerUsers", computerUser);
        //}
    }
}
