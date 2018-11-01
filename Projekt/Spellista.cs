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
    public class Spellista
    {      
       
        public void HideSelection (ListView podcast, ListView categories)
        {
            podcast.HideSelection = false;
            categories.HideSelection = false;
        }
       
        public void BtnRemovePod(ListView podcasts, ListBox lbAvsnitt)
        {
            foreach(ListViewItem item in podcasts.Items)
            {
                if (item.Selected)
                {
                    podcasts.Items.Remove(item);
                    lbAvsnitt.Items.Clear();
                }
            }
        }

        public void SelectedIndex(ComboBox comboFrekvens, ComboBox comboCategory)
        {
            comboFrekvens.SelectedIndex = 0;
            comboCategory.SelectedIndex = 0;
        }       

        public void FullRowSelect(ListView listView)
        {
            listView.FullRowSelect = true;
        }

        
      
    }
}
