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
            listPodcasts.FullRowSelect = true;
            // ---- poppulera listCategories samt comboBoxen ---------


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

        private void btnSavePod_Click(object sender, EventArgs e)
        {

        }
        //Behöver flytta ut all kod till en annan klass och använda oss av get metoder, exempel på den under i spellista.cs
        //Så vi kan få tillgång på listorna/txtbox i annan klass
        public string TextBoxText { get { return txtBoxURL.Text; } }

        private void btnNewPod_Click(object sender, EventArgs e)
        {
            listAvsnitt.Clear();
            try
            {
                string url = "";
                url = txtBoxURL.Text;
                XmlReader xmlReader = XmlReader.Create(url);
                SyndicationFeed syndicationFeed = SyndicationFeed.Load(xmlReader);
                int i = 0;
                foreach (SyndicationItem item in syndicationFeed.Items)
                {
                    i++;                    
                }
                
                string[] row = { i.ToString(), syndicationFeed.Title.Text, comboFrekvens.SelectedItem.ToString(),
                    comboKategori.SelectedItem.ToString(), txtBoxURL.Text,  };
                var listViewItem = new ListViewItem(row);
                listPodcasts.Items.Add(listViewItem);

                xmlReader.Close();
            }
            catch
            {
                MessageBox.Show("Detta är felkoden, ge till programmeraren : " + e);
            }
            txtBoxURL.Clear();
            
        }
      
        private void btnNewCategory_Click(object sender, EventArgs e)
        {
            listCategories.Items.Add(txtBoxCategories.Text.ToString());
            comboKategori.Items.Add(txtBoxCategories.Text.ToString());
            txtBoxCategories.Clear();

        }
        //Item summary text till en textbox

        private void listPodcasts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listPodcasts.SelectedItems.Count > 0)
            {
                listAvsnitt.Clear();

                string url = listPodcasts.SelectedItems[0].SubItems[4].Text;

                XmlReader xmlReader = XmlReader.Create(url);
                SyndicationFeed syndicationFeed = SyndicationFeed.Load(xmlReader);
                foreach (SyndicationItem item in syndicationFeed.Items)
                {
                     String title = item.Title.Text;
                     listAvsnitt.Items.Add(title); 
                    
                }
                xmlReader.Close();
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
    }
}
