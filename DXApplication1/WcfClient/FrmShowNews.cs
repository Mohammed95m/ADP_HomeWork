using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using System.IO;
using WcfClient.NewsService1;

namespace RemotingClient
{
 
    public partial class FrmShowNews : DevExpress.XtraEditors.XtraForm
    {
 
        bool ImageChanged = false;
        public FrmShowNews(News news)
        {
            InitializeComponent();
            TxtAbstrack.Text = news?.Abstract;
            TxtRating.Text = ((news?.Ranking.Select(a => a.Number).DefaultIfEmpty().Average()) ?? 0).ToString();
            TxtText.Text = news?.Text;
            TxtTitle.Text = news?.Title;
            try
            {
                if (news?.ImagePath != null)
                {
                    pictureBox1.Image = Image.FromFile(news?.ImagePath);
                }
            }
            catch (Exception ex)
            {

             
            }
           
            
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //OpenFileDialog op = new OpenFileDialog();
            //op.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            //if (op.ShowDialog() == DialogResult.OK)
            //{
            //    imagePath = op.FileName;
            //    pictureBox1.Image = Image.FromFile(imagePath);
            //    ImageChanged = true;
            //}
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           
        }
    }
}