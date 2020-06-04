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
using DevExpress.XtraEditors;

namespace RemotingClient
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        INewsManager prox = (INewsManager)Activator
            .GetObject(typeof(INewsManager)
                 , "http://localhost:1234/NewsManager.soap");

        IAgencyManager Agencyprox = (IAgencyManager)Activator
        .GetObject(typeof(IAgencyManager)
             , "http://localhost:1234/AgencyManager.soap");
        public Form1()
        {
            InitializeComponent();
            HttpChannel chnl = new HttpChannel();
            ChannelServices.RegisterChannel(chnl, false);
            GcNews.DataSource = prox.GetAll();
            #region Events 
            FrmAddNews.ReFillData += () =>
            {
                GcNews.DataSource = prox.GetAll();
            };
            #endregion
            var agencies = Agencyprox.GetAll();
            CbGetByAgency.Items.Add(new Agency { ID = -1, Name = "All" });
            CbGetByAgency.Items.AddRange(agencies.ToList());
            CbGetByAgency.SelectedIndexChanged += (o, e) =>
            {
                ComboBoxEdit cbe = (ComboBoxEdit)o;
                if (((Agency)cbe.SelectedItem).ID == -1)
                {
                    GcNews.DataSource = prox.GetAll();
                }
                else
                {
                    GcNews.DataSource = prox.GetByAgency(((Agency)cbe.SelectedItem).ID);

                }
            };
        }

     

        private void BtnNewNews_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmAddNews frm = new FrmAddNews();
            frm.ShowDialog();
        }

        private void BtnDeleteNews_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
              var news = GvNews.GetFocusedRow() as News;
             var IsRemoved=   prox.Remove(news.ID);
                if (IsRemoved) MessageBox.Show("removed");
                GcNews.DataSource = prox.GetAll();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Please select the row");
            }
         
        }

        private void BtnUpdateImage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int newsID = new int();
            try
            {
                var news = GvNews.GetFocusedRow() as News;
                newsID = news.ID;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select the row");
                return;
            }
            OpenFileDialog op = new OpenFileDialog();
            if (DialogResult.OK == op.ShowDialog())
            {
                String file = null;
                string extention = null;
                if (!string.IsNullOrEmpty(op.FileName))
                {
                    Byte[] bytes = File.ReadAllBytes(op.FileName);
                    file = Convert.ToBase64String(bytes);
                    extention = Path.GetExtension(op.FileName);
                    bool IsUpdated = prox.UpdatePhoto(newsID, file, extention);
                    if (IsUpdated) MessageBox.Show("Updated");
                }
               
            }
        }

        private void GvNews_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            MessageBox.Show("clicked");
            try
            {
                var news = GvNews.GetRow(e.RowHandle) as News;
                FrmShowNews frm = new FrmShowNews(news);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }

        private void BtnShowAgencies_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmAgencies frm = new FrmAgencies();
            frm.ShowDialog();
        }
    }
}
