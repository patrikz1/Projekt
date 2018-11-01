using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.ServiceModel.Syndication;
using System.IO;
using System.Text.RegularExpressions;

namespace Projekt
{
    public class Spellista : TitleInterface
    {
        public string Title { get; set; }

      
        public void HideSelection (ListView podcast, ListBox lbAvsnitt, ListView categories)
        {
            podcast.HideSelection = false;
            categories.HideSelection = false;
        }
        public void Description(string url, SyndicationFeed syndicationFeed, ListView podcast, ListBox lbAvsnitt, TextBox txtBoxDescription)
        {         
            url = podcast.SelectedItems[0].SubItems[4].Text;
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(url);
            XmlNodeList description = xmlDocument.SelectNodes("//rss/channel/item/description");
            
            var i = lbAvsnitt.SelectedIndex;
            txtBoxDescription.Clear();
            txtBoxDescription.Text = (Regex.Replace(description[i].InnerText, @"<.*?>",""));
            CreateXmlReader(url).Close();

        }

        public void BtnNewPod(string url,ComboBox comboFrekvens, ComboBox comboCategory,ListView podcast,ListBox lbAvsnitt,TextBox txtBoxURL )
        {
            lbAvsnitt.Items.Clear();
            var syndicationFeed = LoadFeed(CreateXmlReader(url));
            int i = Count(syndicationFeed);

            string[] row = { i.ToString(), syndicationFeed.Title.Text, comboFrekvens.SelectedItem.ToString(),
                      comboCategory.SelectedItem.ToString(), url };

            AddRow(podcast, AddContent(row));
            CreateXmlReader(url).Close();

            txtBoxURL.Clear();

        }

        public void BtnRemoveCategory(ListView categories, ComboBox comboCategory)
        {
            foreach(ListViewItem item in categories.Items)
            {
                if (item.Selected)
                {
                    string category = item.Text;
                    if (comboCategory.Items.Contains(category))
                    {
                        comboCategory.Items.Remove(category);
                    }
                    categories.Items.Remove(item);
                }
            }
        }

        public void BtnRemovePod(ListView podcasts, ListBox lbAvsnitt)
        {
            foreach(ListViewItem item in podcasts.Items)
            {
                if (item.Selected)
                {
                    podcasts.Items.Remove(item);
                    lbAvsnitt.Text ="";
                }
            }
        }


        public void IndexChangedPodcast(ListView podcasts,ListBox lbAvsnitt, string url, SyndicationFeed syndicationFeed)
        {
            var spellista = new Spellista();
                lbAvsnitt.Text ="";
                url = podcasts.SelectedItems[0].SubItems[4].Text;
                syndicationFeed = LoadFeed(CreateXmlReader(url));
                foreach (SyndicationItem item in syndicationFeed.Items)
                {
                    string title = item.Title.Text;
                    lbAvsnitt.Items.Add(title);

                }
                CreateXmlReader(url).Close();
            
        }

        public void SelectedIndex(ComboBox comboFrekvens, ComboBox comboCategory)
        {
            comboFrekvens.SelectedIndex = 0;
            comboCategory.SelectedIndex = 0;
        }

        public void AddCategories(ListView lvCategories, ComboBox comboCategory, string newCategory, TextBox txtBoxCategories)
        {
            lvCategories.Items.Add(newCategory);
            comboCategory.Items.Add(newCategory);
            txtBoxCategories.Clear();
        }

        public void FullRowSelect(ListView listView)
        {
            listView.FullRowSelect = true;
        }
        public void Categories(ListView listview, ComboBox cbox)
        {
            listview.Items.Add("All Categories");
            listview.Items.Add("Comedy");
            listview.Items.Add("Space");
            listview.Items.Add("Crime");
            listview.Items.Add("Romance");

            cbox.Items.Add("All Categories");
            cbox.Items.Add("Comedy");
            cbox.Items.Add("Space");
            cbox.Items.Add("Crime");
            cbox.Items.Add("Romance");
        }
        public int Count(SyndicationFeed syndicationFeed)
        {
            return syndicationFeed.Items.Count();
        }
        public string Url(string url)
        {
            return url;
        }
        public SyndicationFeed LoadFeed(XmlReader xmlreader)
        {
            return SyndicationFeed.Load(xmlreader);
        }
        public XmlReader CreateXmlReader(string url)
        {
            return XmlReader.Create(url);
        }
        public ListViewItem AddContent(string[] myRow)
        {    
              return new ListViewItem(myRow);            
        }
      
        public void AddRow(ListView listView ,ListViewItem listviewitem)
        {
                listView.Items.Add(listviewitem);
        }
        
      
    }
}
