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
using Remoting;
using System.IO;

namespace RemotingClient
{
 
    public partial class FrmUpdateNews : DevExpress.XtraEditors.XtraForm
    {
        public static event UpdateGrid ReFillData;
        INewsManager Newsprox = (INewsManager)Activator
              .GetObject(typeof(INewsManager)
                   , "http://localhost:1234/NewsManager.soap");

        IAgencyManager Agencyprox = (IAgencyManager)Activator
            .GetObject(typeof(IAgencyManager)
                 , "http://localhost:1234/AgencyManager.soap");
        private string imagePath = "";
        bool ImageChanged = false;
        public FrmUpdateNews(News news)
        {
            InitializeComponent();
            var agencies = Agencyprox.GetAll();
            CbAgency.Properties.Items.AddRange(agencies.ToList());
            CbAgency.SelectedItem = agencies.SingleOrDefault(s => s.ID == news.AgencyID);
            TxtAbstrack.Text = news?.Abstract;
            TxtRating.Text = news?.Ranking.ToString();
            TxtText.Text = news?.Text;
            TxtTitle.Text = news?.Title;
            pictureBox1.Image = Image.FromFile(news?.ImagePath);
            imagePath = news?.ImagePath;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            if (op.ShowDialog() == DialogResult.OK)
            {
                imagePath = op.FileName;
                pictureBox1.Image = Image.FromFile(imagePath);
                ImageChanged = true;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            String file = null;
            string extention = null;
            if (ImageChanged)
            {
                if (!string.IsNullOrEmpty(imagePath))
                {
                    Byte[] bytes = File.ReadAllBytes(imagePath);
                    file = Convert.ToBase64String(bytes);
                    extention = Path.GetExtension(imagePath);
                }
            }


            var IsUpdated = Newsprox.Add(new News
            {
                Abstract = TxtAbstrack.Text,
                Image = file,
                Text = TxtText.Text,
                Title = TxtTitle.Text,
                AgencyID = ((Agency)CbAgency.SelectedItem).ID,
                ImageExtenttion = extention,
                Ranking = int.Parse(TxtRating.Text),
            //    ImageChanged = ImageChanged
            });
            if (!IsUpdated)
            {
                MessageBox.Show("please insert correct data");
            }
            else
            {
                ReFillData();
                this.Close();
            }
        }
    }
}