﻿using System;
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
        public ListViewItem AddContent(string[] myRow)
        {
            
              return new ListViewItem(myRow);
            
        }
      
        public void AddRow(ListView listView ,ListViewItem listviewitem)
        {
                listView.Items.Add(listviewitem);
        }
        //  PodcastPlayer podcastplayer = new PodcastPlayer();
        public void ReadXml()
        {            

            //Ska kanske flytta över btnNy's rss reader hit, då måste man använda det nedan på nåt sätt
            //TextBox url = Application.OpenForms["Form1"].Controls["txtBoxURL"] as TextBox;
            // XmlReader xmlReader = XmlReader.Create(url.Text);

        }
    }
}
