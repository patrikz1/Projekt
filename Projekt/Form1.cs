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
            updatefrequency.Updates(updatefrequency.List(lvPodcasts));
            
            //behövs overload med frequency
            //updatefrequency.Frequency(updatefrequency.Updates(updatefrequency.List(lvPodcasts)), lvPodcasts);

            spellista.FullRowSelect(lvPodcasts);
            spellista.SelectedIndex(comboFrekvens, comboKategori);
            spellista.HideSelection(lvPodcasts, lvCategories);
        }

        private void btnSavePod_Click(object sender, EventArgs e)
        {

        }

<<<<<<< HEAD
        private void btnNewPod_Click(object sender, EventArgs e)
        {
            try
            {

                if (Validering.txtBoxInteTomt(txtBoxURL))
                {

                    var spellista = new Spellista();
                    spellista.BtnNewPod(txtBoxURL.Text, comboFrekvens, comboKategori, lvPodcasts, lvAvsnitt, txtBoxURL);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
=======
        private async void btnNewPod_Click(object sender, EventArgs e)
        {
            var feeds = new Feeds();
            await feeds.BtnNewPod(txtBoxURL.Text, comboFrekvens, comboKategori, lvPodcasts, lbAvsnitt, txtBoxURL);                     
>>>>>>> d0333d7a475405d5de4650ec13766609b677f8df
        }

        private void btnNewCategory_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            var spellista = new Spellista();
            spellista.AddCategories(lvCategories, comboKategori, txtBoxCategories.Text.ToString(), txtBoxCategories);
=======
            var categories = new Categories();
            categories.AddCategories(lvCategories, comboKategori, txtBoxCategories.Text.ToString(),txtBoxCategories);
>>>>>>> d0333d7a475405d5de4650ec13766609b677f8df

        }

        private void listPodcasts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var feeds = new Feeds();
            if (lvPodcasts.SelectedItems.Count > 0)
            {
<<<<<<< HEAD
                spellista.IndexChangedPodcast(lvPodcasts, lvAvsnitt, lvPodcasts.SelectedItems[0].SubItems[4].Text,
                spellista.LoadFeed(spellista.CreateXmlReader(lvPodcasts.SelectedItems[0].SubItems[4].Text)));
            }
        }




        private void listAvsnitt_SelectedIndexChanged(object sender, EventArgs e)
        {
            var spellista = new Spellista();
            if (lvPodcasts.SelectedItems.Count > 0)
            {

            }
            /* lblDescription.Text = "";
             if (listAvsnitt.SelectedItems.Count > 0)
             {

                 string url = listPodcasts.SelectedItems[0].SubItems[4].Text;

                 XmlReader xmlReader = XmlReader.Create(url);
                 SyndicationFeed syndicationFeed = SyndicationFeed.Load(xmlReader);
                 foreach (SyndicationItem item in syndicationFeed.Items)
                 {
                     String description = item.Summary.Text;

                 }
                 lblDescription.Text = syndicationFeed.Description.Text;
                 xmlReader.Close();
             }
             */
=======
                feeds.IndexChangedPodcast(lvPodcasts, lbAvsnitt, lvPodcasts.SelectedItems[0].SubItems[4].Text,
                feeds.LoadFeed(feeds.CreateXmlReader(lvPodcasts.SelectedItems[0].SubItems[4].Text)));
            }
>>>>>>> d0333d7a475405d5de4650ec13766609b677f8df
        }

        private void btnRemovePod_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            try
            {
                if (Validering.taBort2(lvPodcasts))
                {
                    var bekrafta = MessageBox.Show("Är du säker på att du vill radera den här podcasten?", "Radera pocast", MessageBoxButtons.YesNo);

                    if (bekrafta == DialogResult.Yes)
                    {

                        var spellista = new Spellista();
                        spellista.BtnRemovePod(lvPodcasts, lvAvsnitt);
                        MessageBox.Show("Podcast Borttagen");
                    }
                }
            }
            
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
=======
            var spellista = new Spellista();
            spellista.BtnRemovePod(lvPodcasts, lbAvsnitt);
>>>>>>> d0333d7a475405d5de4650ec13766609b677f8df
        }
    

        private void btnRemoveCategory_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            try
            {
                if (Validering.taBort(lvCategories))
                {
                    var bekrafta = MessageBox.Show("Är du säker på att du vill radera den här kategorin?", "Radera kategori", MessageBoxButtons.YesNo);

                    if (bekrafta == DialogResult.Yes)
                    {

                        var spellista = new Spellista();
                        spellista.BtnRemoveCategory(lvCategories, comboKategori);
                        MessageBox.Show("Kategori Borttagen");
                    }

                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
=======
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
>>>>>>> d0333d7a475405d5de4650ec13766609b677f8df
        }
    }
}
