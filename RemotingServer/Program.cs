using ADP_HomeWork.Classes;
using ADP_HomeWork.DataBase;
using ADP_HomeWork.DataBase.Tables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Text;
using System.Threading.Tasks;

namespace RemotingServer
{
    class Program
    {
        static void Main(string[] args)
        {

            HttpChannel ch1 = new HttpChannel(1234);
            ChannelServices.RegisterChannel(ch1, false);
            Console.WriteLine("{0}:{1}:{2}:{3}", DateTime.Now.Hour.ToString(),
             DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString(),
             DateTime.Now.Millisecond.ToString());
            Console.WriteLine("Server.Main: Server is ready to be used at port 1234");
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(NewsManager),
                "NewsManager.soap", WellKnownObjectMode.SingleCall);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(AgencyManager),
                "AgencyManager.soap", WellKnownObjectMode.SingleCall);
            Console.WriteLine("{0}:{1}:{2}:{3}", DateTime.Now.Hour.ToString(),
              DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString(),
              DateTime.Now.Millisecond.ToString());
            Console.WriteLine("Server.Main: SingleCall Remoting is configured");

            //var _Context = new NewsDataContext();
            //foreach (var item in _Context.News)
            //{
            //    item.Ranking = new Collection<Rank>();
            //}
            //_Context.SaveChanges();
            Console.ReadKey();
        }
    }
}
