using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.SelfHost;
using WebApi.Common;

namespace WebApiConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpSelfHostConfiguration config = new HttpSelfHostConfiguration("http://localhost:8080");
            WebApiConfig.Configure(config);

            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("Press ENTER to exit");
                Console.ReadLine();
            }
        }
    }
}
