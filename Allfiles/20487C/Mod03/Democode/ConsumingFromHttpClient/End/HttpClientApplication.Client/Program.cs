﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace HttpClientApplication.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await CallServerAsync();
            Console.ReadKey();
        }

        static async Task CallServerAsync()
        {
            using (var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:12534/")
            })
            {

                HttpResponseMessage message = await client.GetAsync("api/Destinations");
                var res = await message.Content.ReadAsStringAsync();
                Console.WriteLine(res);

                var destinations = await message.Content.ReadAsAsync<List<Destination>>();
                Console.WriteLine(destinations.Count);
            }
        }
    }
}