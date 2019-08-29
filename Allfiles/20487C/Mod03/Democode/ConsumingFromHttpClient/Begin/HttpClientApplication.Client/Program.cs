using System;
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
            await CallServer();
            Console.ReadKey();
        }

        static async Task CallServer()
        {
            //Create a new httpClient on http://localhost:12534/

            //Execute GetAsync on 'api/Destinations'

            //Read response content as string

            //Read response content as List of destination
        }
    }
}