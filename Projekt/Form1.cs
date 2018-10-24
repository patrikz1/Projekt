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
            
            
        }

        private void listBoxKategorier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSavePod_Click(object sender, EventArgs e)
        {

        }

      
        private void btnNewPod_Click(object sender, EventArgs e)
        {
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
            // test, behöver ta in info från rss filen sen
            string[] row = { i.ToString(), syndicationFeed.Title.Text, comboFrekvens.SelectedItem.ToString(), comboKategori.SelectedItem.ToString() };
            var listViewItem = new ListViewItem(row);
            listPodcasts.Items.Add(listViewItem);
        }
    }
}
