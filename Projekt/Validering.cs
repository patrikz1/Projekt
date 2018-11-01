using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt
{
    class Validering
    {
        public static bool tfInteTomt(TextBox falt, string label)
        {

            if (falt.Text == "")
            {

                MessageBox.Show(label + " får inte sakna ett värde.");
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
                MessageBox.Show("Listan får inte vara tom.");
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool TaBort(ListBox list)
        {
            if (list.Text == "")
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