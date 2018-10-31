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

            List<string> categories = new List<string>();
            lvPodcasts.FullRowSelect = true;
            // ---- poppulera listCategories samt comboBoxen ---------


            lvCategories.Items.Add("Comedy");
            lvCategories.Items.Add("Space");
            lvCategories.Items.Add("Crime");
            lvCategories.Items.Add("Romance");

            comboKategori.Items.Add("Comedy");
            comboKategori.Items.Add("Space");
            comboKategori.Items.Add("Crime");
            comboKategori.Items.Add("Romance");

            //Så första i comboBox inte är en tom ruta
            comboFrekvens.SelectedIndex = 0;
            comboKategori.SelectedIndex = 0;
            //---------------------------------------------------------------------
        }

        private void btnSavePod_Click(object sender, EventArgs e)
        {

        }

        private void btnNewPod_Click(object sender, EventArgs e)
        {
            lvAvsnitt.Clear();
            try
            {
                var spellista = new Spellista();
                
                var url = txtBoxURL.Text;
                var syndicationFeed = spellista.feed(spellista.CreateXmlReader(url));
                int i = spellista.Count(syndicationFeed);

                string[] row = { i.ToString(), syndicationFeed.Title.Text, comboFrekvens.SelectedItem.ToString(),
                    comboKategori.SelectedItem.ToString(), url };

                spellista.AddRow(lvPodcasts, spellista.AddContent(row));
                spellista.CreateXmlReader(url).Close();
            }
            catch
            {
                MessageBox.Show("Detta är felkoden, ge till programmeraren : " + e);
            }
            txtBoxURL.Clear();
            
        }
      
        private void btnNewCategory_Click(object sender, EventArgs e)
        {
            lvCategories.Items.Add(txtBoxCategories.Text.ToString());
            comboKategori.Items.Add(txtBoxCategories.Text.ToString());
            txtBoxCategories.Clear();

        }
        //Item summary text till en textbox

        private void listPodcasts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPodcasts.SelectedItems.Count > 0)
            {
                var spellista = new Spellista();

                lvAvsnitt.Clear();

                string url = lvPodcasts.SelectedItems[0].SubItems[4].Text;

                var syndicationFeed = spellista.feed(spellista.CreateXmlReader(url));
                foreach (SyndicationItem item in syndicationFeed.Items)
                {
                     String title = item.Title.Text;
                     lvAvsnitt.Items.Add(title); 
                    
                }
                spellista.CreateXmlReader(url).Close();
            }

        }

        private void listAvsnitt_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            foreach (ListViewItem item in lvPodcasts.Items)
            {
                if (item.Selected)
                {
                    lvPodcasts.Items.Remove(item);
                    lvAvsnitt.Clear();
                }
            }
        }

        private void btnRemoveCategory_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvCategories.Items)
            {
                if (item.Selected)
                {                   
                    string category = item.Text;
                    if (comboKategori.Items.Contains(category))
                    {
                        comboKategori.Items.Remove(category);
                    }
                    lvCategories.Items.Remove(item);

                }
            }
        }
    }
}
