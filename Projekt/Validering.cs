using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt
{
    public class Validering
    {
        public static bool txtBoxInteTomt(TextBox txtBoxURL)
        {

            if (txtBoxURL.Text == "")
            {

                MessageBox.Show("Det får inte saknas ett värde.");
                return false;

            }
            else
            {

                return true;
            }



        }
        public static bool ListBoxInteTom(ListBox box)
        {
            if (box.Text == "")
            {
                MessageBox.Show("Välj ett värde från listan.");
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool ComboTom(ComboBox cb)
        {
            if (cb.Text == "")
            {
                MessageBox.Show("Det saknas ett värde.");
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool taBort(ListView lvCategories)
        {
            if (lvCategories == null)
            {
                MessageBox.Show("Du måste välja något.");
                return false;
            }
            else
            {

                return true;
            }
        }

        public static bool taBort2(ListView lvPodcasts)
        {
            if (lvPodcasts == null)
            {
                MessageBox.Show("Du måste välja något.");
                return false;
            }
            else
            {

                return true;
            }
        }

        public static bool riktigURL(string url)
        {
            try
            {
                var xml = "";
                using (var client = new System.Net.WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    xml = client.DownloadString(url);
                    return true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Skriv in en giltig URL.");
                return false;
            }
        }
    }
}