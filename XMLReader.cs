using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MixMusicFile
{
    class XMLReader
    {
        private List<string> musicExtention;

        public List<string> MusicExtention
        {
            get => musicExtention;
        }

        private XmlElement xRoot;

        public XMLReader()
        {
            musicExtention = new List<string>();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("settings.xml");
            xRoot = xDoc.DocumentElement;
            getFileExtensions();
        }

        private void getFileExtensions()
        {
             XmlNodeListToString(xRoot.SelectNodes("extension"));             
        }


        private void XmlNodeListToString(XmlNodeList nodelist)
        {
            string extension = "";
            foreach (XmlNode node in nodelist)
            {
                if (Boolean.Parse(node.SelectSingleNode(@"isUse").InnerText))
                {
                    extension = node.SelectSingleNode(@"pattern").InnerText;
                    musicExtention.Add(extension);
                }
            }
        }

    }
}

