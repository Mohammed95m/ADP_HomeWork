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
    public delegate void UpdateGrid ();
    public partial class FrmAddNews : DevExpress.XtraEditors.XtraForm
    {
        public static event UpdateGrid ReFillData;
        INewsManager Newsprox = (INewsManager)Activator
              .GetObject(typeof(INewsManager)
                   , "http://localhost:1234/NewsManager.soap");
        IAgencyManager Agencyprox = (IAgencyManager)Activator
            .GetObject(typeof(IAgencyManager)
                 , "http://localhost:1234/AgencyManager.soap");
        private string imagePath = "";
        public FrmAddNews()
        {
            InitializeComponent();
            var agencies = Agencyprox.GetAll();
            CbAgency.Properties.Items.AddRange(agencies.ToList());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            if (op.ShowDialog() == DialogResult.OK)
            {
                imagePath = op.FileName;
                pictureBox1.Image = Image.FromFile(imagePath);
            }
        
           
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            String file = null;
            string extention = null;
            if (!string.IsNullOrEmpty(imagePath))
            {
                Byte[] bytes = File.ReadAllBytes(imagePath);
                 file = Convert.ToBase64String(bytes);
                extention = Path.GetExtension(imagePath);
            }

         var IsAdded=   Newsprox.Add(new News
            {
                Abstract = TxtAbstrack.Text,
                Image = file,
                Text = TxtText.Text,
                Title = TxtTitle.Text,
                AgencyID = ((Agency)CbAgency.SelectedItem).ID,
                ImageExtenttion = extention,
                Ranking = int.Parse(TxtRating.Text)
            });
            if (!IsAdded)
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