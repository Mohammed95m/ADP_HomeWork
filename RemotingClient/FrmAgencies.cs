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

namespace RemotingClient
{
    public partial class FrmAgencies : DevExpress.XtraEditors.XtraForm
    {
        IAgencyManager Agencyprox = (IAgencyManager)Activator
       .GetObject(typeof(IAgencyManager)
            , "http://localhost:1234/AgencyManager.soap");
        int? SelectedID = null;
        public FrmAgencies()
        {
            InitializeComponent();
            CbLanguage.Properties.Items.AddRange(Agencyprox.GetLanguages().ToList());
            CbCity.Properties.Items.AddRange(Agencyprox.GetCities().ToList());
            Refresh();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsAdded = Agencyprox.Add(new Agency
                {
                    CityID = ((DataEntriy)CbCity.SelectedItem).ID,
                    LanguageID = ((DataEntriy)CbCity.SelectedItem).ID,
                    Name = TxtName.Text
                });
                if (!IsAdded) MessageBox.Show("pleas check your data");
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("pleas check your data");

            }
           
        }

        private void GvAgency_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                var Agency = GvAgency.GetRow(e.RowHandle) as Agency;
                SelectedID = Agency.ID;
                var city= Agencyprox.GetCities().SingleOrDefault(s => s.ID == Agency.CityID);
                var Language = Agencyprox.GetCities().SingleOrDefault(s => s.ID == Agency.CityID);
                foreach (var item in CbCity.Properties.Items)
                {
                    if (((DataEntriy)item).ID == city.ID) CbCity.SelectedItem = item;
                }
                foreach (var item in CbLanguage.Properties.Items)
                {
                    if (((DataEntriy)item).ID == Language.ID) CbLanguage.SelectedItem = item;
                }
                CbLanguage.SelectedItem = Agencyprox.GetLanguages().SingleOrDefault(s => s.ID == Agency.LanguageID);
                TxtName.Text = Agency.Name;
          
            }
            catch (Exception ex)
            {

              
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsUpdated = Agencyprox.Update(new Agency
                {
                    ID =SelectedID??0,
                    CityID = ((DataEntriy)CbCity.SelectedItem).ID,
                    LanguageID = ((DataEntriy)CbCity.SelectedItem).ID,
                    Name = TxtName.Text
                });
                if (!IsUpdated) MessageBox.Show("pleas check your data");
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("pleas check your data");

            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            SelectedID = null;
            TxtName.Text = null;
            CbLanguage.SelectedIndex = -1;
            CbCity.SelectedIndex = -1;
            GcAgency.DataSource = Agencyprox.GetAll();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsUpdated = Agencyprox.Remove(SelectedID??0);
                if (!IsUpdated) MessageBox.Show("cant be deleted");
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("cant be deleted");

            }
            Refresh();
        }
    }
}