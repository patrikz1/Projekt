using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Projekt
{
    public partial class PodcastPlayer : Form
    {
        public PodcastPlayer()
        {
            InitializeComponent();
        }   
        
        private void Form1_Load(object sender, EventArgs e)
        {         

            // ---- poppulera listCategories samt comboBoxen ---------
            List<string> categories = new List<string>();

            listCategories.Items.Add("Comedy");
            listCategories.Items.Add("Space");
            listCategories.Items.Add("Crime");
            listCategories.Items.Add("Romance");
            
            comboKategori.Items.Add("Comedy");
            comboKategori.Items.Add("Space");
            comboKategori.Items.Add("Crime");
            comboKategori.Items.Add("Romance");

            //Så första i comboBox inte är en tom ruta
            comboFrekvens.SelectedIndex = 0;
            comboKategori.SelectedIndex = 0;
            //---------------------------------------------------------------------
        }

        private void listBoxKategorier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSavePod_Click(object sender, EventArgs e)
        {

        }

      
        private void btnNewPod_Click(object sender, EventArgs e)
        {
            listAvsnitt.Clear();
            string url = txtBoxURL.Text;
            XmlReader xmlReader = XmlReader.Create(url);
            SyndicationFeed syndicationFeed = SyndicationFeed.Load(xmlReader);
            int i = 0;
            foreach (SyndicationItem item in syndicationFeed.Items)
            {
                String title = item.Title.Text;
                i++;
                listAvsnitt.Items.Add(title); //måste fixa så den bara visar detta on selected item i listan
            }
            xmlReader.Close();

            string[] row = { i.ToString(), syndicationFeed.Title.Text, comboFrekvens.SelectedItem.ToString(), comboKategori.SelectedItem.ToString() };
            var listViewItem = new ListViewItem(row);
            listPodcasts.Items.Add(listViewItem);
            txtBoxURL.Clear();
        }

        private void btnNewCategory_Click(object sender, EventArgs e)
        {
            listCategories.Items.Add(txtBoxCategories.Text.ToString());
            comboKategori.Items.Add(txtBoxCategories.Text.ToString());
            txtBoxCategories.Clear();

        }
    }
}
