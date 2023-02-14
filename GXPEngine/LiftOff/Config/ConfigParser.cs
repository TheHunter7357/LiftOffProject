using System.IO;
using System;
using System.Xml;
using System.Xml.Serialization;

namespace GXPEngine
{
    public class ConfigParser
    {
        static XmlSerializer serial = new XmlSerializer(typeof(Config));

        public static Config ReadConfig(string fileName)
        {
            TextReader reader = new StreamReader(fileName);
            Config config = serial.Deserialize(reader) as Config;
            reader.Close();
            //if (config.stats == null)
            //{
            //    throw new Exception("No stats found in config file");
            //}
            return config;
        }

    }

    [XmlRoot("config")]
    public class Config
    {
        [XmlAttribute("name")]
        public string Name;

        [XmlElement("character")]
        public CharacterStats[] characters;
    }

    [XmlRoot("character")]
    public class CharacterStats
    {
        
    }


}