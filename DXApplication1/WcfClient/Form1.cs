using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using RemotingClient;

namespace WcfClient
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        NewsService1.NewsServiceClient prox = new NewsService1.NewsServiceClient();
     
        public Form1()
        {
            InitializeComponent();
          gridControl1.DataSource = prox.GetLast10();
        }

        private void BtnAddRank_Click(object sender, EventArgs e)
        {
               
              var result = XtraInputBox.Show("Enter a Rank as number", "Ranking", "0");
        }

        private void BtnNPostive_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = prox.GetBestPositive(string.IsNullOrEmpty(TxtN.Text) ? 0 : int.Parse(TxtN.Text));
        }

        private void BtnNNegative_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = prox.GetBestNegative(string.IsNullOrEmpty(TxtN.Text) ? 0 : int.Parse(TxtN.Text));
        }

        private void BtnGetSimilar_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtAbstract.Text)&& !string.IsNullOrEmpty(TxtTitle.Text))
            {
                var data = prox.GetSimilar(title: TxtTitle.Text, Abstract: txtAbstract.Text);
                FrmShowNews frm = new FrmShowNews(data);
                frm.ShowDialog();
            }
            else
            {
                if (!string.IsNullOrEmpty(txtAbstract.Text))
                {
                    var data = prox.GetSimilar(title: null, Abstract: txtAbstract.Text);
                    FrmShowNews frm = new FrmShowNews(data);
                    frm.ShowDialog();

                }
                if (!string.IsNullOrEmpty(TxtTitle.Text))
                {
                    var data = prox.GetSimilar(title: TxtTitle.Text, Abstract: null);
                    FrmShowNews frm = new FrmShowNews(data);
                    frm.ShowDialog();
                 
                }

            }
        }

        private void BtnLast10_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = prox.GetLast10();
        }
    }
}
