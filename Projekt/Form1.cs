using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            //test, behöver ta in info från rss filen sen
            string[] row = { "2", txtBoxURL.Text, comboFrekvens.SelectedItem.ToString(), comboKategori.SelectedItem.ToString() };
            var listViewItem = new ListViewItem(row);
            listPodcasts.Items.Add(listViewItem);
        }
    }
}
