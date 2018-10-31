using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.ServiceModel.Syndication;
using System.IO;


namespace Projekt
{
    public class Spellista
    {

        public int Count(SyndicationFeed syndicationFeed)
        {
            return syndicationFeed.Items.Count();
        }
        public string url(string url)
        {
            return url;
        }
        public SyndicationFeed feed(XmlReader xmlreader)
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
