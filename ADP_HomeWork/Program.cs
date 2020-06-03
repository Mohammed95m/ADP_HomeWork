using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using ADP_HomeWork.Classes;

namespace ADP_HomeWork
{
    public class Program
    {
        public static void Main(string[] args)
        {
      
            HttpChannel ch1 = new HttpChannel(1234);
            ChannelServices.RegisterChannel(ch1, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(NewsManager),
                "NewsManager.soap", WellKnownObjectMode.SingleCall);

            CreateWebHostBuilder(args).Build().Run();

          
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
