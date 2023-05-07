using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaProject
{
    public class RequestsClient
    {
        public static readonly HttpClient httpClient;

        public static string Username;

        public static string authToken;

        public static readonly string Server;

        static RequestsClient()
        {
            httpClient = new HttpClient();
            Server = "http://traptrixden.ddns.net:8080";
        }
    }
}
