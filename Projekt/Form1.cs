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
        List<ListViewItem> lvItemList = new List<ListViewItem>();
        public PodcastPlayer()
        {
            InitializeComponent();
        }

      
        private void Form1_Load(object sender, EventArgs e)
        {
            var spellista = new Spellista();
            var categories = new Categories();
            var updatefrequency = new UpdateFrequency();
            categories.Categoriess(lvCategories, comboKategori);

            updatefrequency.AddFrequency(comboFrekvens);
            updatefrequency.List(lvPodcasts);

            spellista.FullRowSelect(lvPodcasts);
            spellista.SelectedIndex(comboFrekvens, comboKategori);
            spellista.HideSelection(lvPodcasts, lvCategories);
        }

        private void btnSavePod_Click(object sender, EventArgs e)
        {

        }

        private void btnNewPod_Click(object sender, EventArgs e)
        {
            var feeds = new Feeds();
            feeds.BtnNewPod(txtBoxURL.Text, comboFrekvens, comboKategori, lvPodcasts,lbAvsnitt,txtBoxURL);                       
        }
      
        private void btnNewCategory_Click(object sender, EventArgs e)
        {
            var categories = new Categories();
            categories.AddCategories(lvCategories, comboKategori, txtBoxCategories.Text.ToString(),txtBoxCategories);         

        }

        private void listPodcasts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var feeds = new Feeds();
            if (lvPodcasts.SelectedItems.Count > 0)
            {
                feeds.IndexChangedPodcast(lvPodcasts, lbAvsnitt, lvPodcasts.SelectedItems[0].SubItems[4].Text,
                feeds.LoadFeed(feeds.CreateXmlReader(lvPodcasts.SelectedItems[0].SubItems[4].Text)));
            }
        }

        private void btnRemovePod_Click(object sender, EventArgs e)
        {
            var spellista = new Spellista();
            spellista.BtnRemovePod(lvPodcasts, lbAvsnitt);
        }

        private void btnRemoveCategory_Click(object sender, EventArgs e)
        {
            var categories = new Categories();
            categories.BtnRemoveCategory(lvCategories, comboKategori);
        }

        private void lbAvsnitt_SelectedIndexChanged(object sender, EventArgs e)
        {           
                var feeds = new Feeds();
                if (lbAvsnitt.SelectedItems.Count > 0)
                {
                    feeds.Description(lvPodcasts.SelectedItems[0].SubItems[4].Text, feeds.LoadFeed(feeds.CreateXmlReader(lvPodcasts.SelectedItems[0].SubItems[4].Text)),
                        lvPodcasts, lbAvsnitt, txtBoxDescription);
                }
        }
    }
}
