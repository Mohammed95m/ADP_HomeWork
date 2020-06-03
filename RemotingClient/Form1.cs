using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using Remoting;
using System.IO;

namespace RemotingClient
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        INewsManager prox = (INewsManager)Activator
            .GetObject(typeof(INewsManager)
                 , "http://localhost:1234/NewsManager.soap");
        public Form1()
        {
            InitializeComponent();
            HttpChannel chnl = new HttpChannel();
            ChannelServices.RegisterChannel(chnl, false);
          
            var news = prox.GetAll();
            GcNews.DataSource = news;
       /*     Byte[] bytes = File.ReadAllBytes("Logo.png");
            String file = Convert.ToBase64String(bytes);
            prox.Add(new News
            {
                Abstract = "add",
                Image = file,
                Text = "add add",
                Title = "add add add",
                AgencyID = 4,
                ImageExtenttion =Path.GetExtension("Logo.png")

            }); */
        }
    }
}
