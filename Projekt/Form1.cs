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
            var spellista = new Spellista();
            spellista.FullRowSelect(lvPodcasts);
            spellista.Categories(lvCategories, comboKategori);
            spellista.SelectedIndex(comboFrekvens, comboKategori);
            spellista.HideSelection(lvPodcasts, lvAvsnitt, lvCategories);
        }

        private void btnSavePod_Click(object sender, EventArgs e)
        {

        }

        private void btnNewPod_Click(object sender, EventArgs e)
        {           
            var spellista = new Spellista();
            spellista.BtnNewPod(txtBoxURL.Text, comboFrekvens, comboKategori, lvPodcasts,lvAvsnitt,txtBoxURL);                       
        }
      
        private void btnNewCategory_Click(object sender, EventArgs e)
        {
            var spellista = new Spellista();
            spellista.AddCategories(lvCategories, comboKategori, txtBoxCategories.Text.ToString(),txtBoxCategories);         

        }

        private void listPodcasts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var spellista = new Spellista();
            if (lvPodcasts.SelectedItems.Count > 0)
            {
                spellista.IndexChangedPodcast(lvPodcasts, lvAvsnitt, lvPodcasts.SelectedItems[0].SubItems[4].Text,
                spellista.LoadFeed(spellista.CreateXmlReader(lvPodcasts.SelectedItems[0].SubItems[4].Text)));
            }
        }




private void listAvsnitt_SelectedIndexChanged(object sender, EventArgs e)
        {
            var spellista = new Spellista();
            if(lvPodcasts.SelectedItems.Count > 0){
                
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
        }

        private void btnRemovePod_Click(object sender, EventArgs e)
        {
            var spellista = new Spellista();
            spellista.BtnRemovePod(lvPodcasts, lvAvsnitt);
        }

        private void btnRemoveCategory_Click(object sender, EventArgs e)
        {
            var spellista = new Spellista();
            spellista.BtnRemoveCategory(lvCategories, comboKategori);
        }

    }
}
