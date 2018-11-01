using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projekt
{
  
      /*  public class Serializer : Spellista
        {
            string filepath;


            public Serializer()
            {
                var folder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                filepath = System.IO.Path.Combine(folder, "Feeds");
            }

            public void SaveFile(List<Tillvårfeed> feed)
            {
                List<klassenSomTarEmotItems> Items = feed.Select(x => new SerializerItems(x)).ToList();
                var xml = new System.Xml.Serialization.XmlSerializer(typeof(List<SerializerItems>));
                using (var f = System.IO.File.Open(filepath, System.IO.FileMode.Create))
                {

                    xml.Serialize(f, Items);
                    f.Flush();
                    f.Close();
                }
            }

            public delegate void Del(SerializerItems returFeed);


            public void LoadFromFile(Del Callback)
            {
                if (System.IO.File.Exists(filepath))
                {
                    List<SerializerItems> returFeed;

                    var xml = new System.Xml.Serialization.XmlSerializer(typeof(List<SerializerItems>));
                    using (var s = System.IO.File.Open(filepath, System.IO.FileMode.Open))
                    {
                        returFeed = xml.Deserialize(s) as List<SerializerItems>;
                        s.Flush();
                        s.Close();
                    }

                    returFeed.ForEach(x => Callback(x));

                }
            }

        } */
    }


