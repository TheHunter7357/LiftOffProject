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
        [XmlElement("characterstats")]
        public GeneralCharacterStats generalStats;

        [XmlElement("character")]
        public CharacterStats characterStats;
    }

    [XmlRoot("character")]
    public class CharacterStats
    {
        [XmlElement("rootsstats")]
        public RootsStats rootStats;

        [XmlElement("firestats")]
        public FireStats fireStats;

        [XmlElement("fatstats")]
        public FatStats fatStats;
    }

    [XmlRoot("rootsstats")]
    public class RootsStats
    {
        [XmlAttribute("ultdamage")]
        public int ultDamage;

        [XmlAttribute("ultspeed")]
        public int ultSpeed;
    }

    [XmlRoot("firestats")]
    public class FireStats
    {
        [XmlAttribute("laserdamagepertick")]
        public int laserTickDamage;

        [XmlAttribute("laserticks")]
        public int laserTicks;


    }

    [XmlRoot("fatstats")]
    public class FatStats
    {
        [XmlAttribute("damageresistance")]
        public float damageResistance;

        [XmlAttribute("flatdamage")]
        public float flatDamage;
    }

    [XmlRoot("generalstats")]
    public class GeneralCharacterStats
    {
        [XmlAttribute("gravity")]
        public float gravity;

        [XmlAttribute("jumpgravitymulti")]
        public float jumpGravityMultiplier;

        [XmlAttribute("jumpforce")]
        public float jumpForce;

        [XmlAttribute("punchdamage")]
        public float punchDamage;

        [XmlAttribute("kickdamage")]
        public float kickDamage;

        [XmlAttribute("hitknockback")]
        public float hitKnockback;

        [XmlAttribute("blockdamagereduction")]
        public float blockDamageReduction;

        [XmlAttribute("speed")]
        public float speed;

        [XmlAttribute("animationdelay")]
        public int animationDelay;

        [XmlAttribute("idlebegin")]
        public int idelBegin;

        [XmlAttribute("idleend")]
        public int idleEnd;

        [XmlAttribute("walkbegin")]
        public int walkBegin;

        [XmlAttribute("walkend")]
        public int walkEnd;

        [XmlAttribute("punchbegin")]
        public int punchBegin;

        [XmlAttribute("punchend")]
        public int punchEnd;

        [XmlAttribute("kickbegin")]
        public int kickBegin;

        [XmlAttribute("kickend")]
        public int kickEnd;

        [XmlAttribute("hitbegin")]
        public int hitBegin;

        [XmlAttribute("hitEnd")]
        public int hitEnd;

        [XmlAttribute("blockbegin")]
        public int blockBegin;

        [XmlAttribute("blockend")]
        public int blockEnd;

        [XmlAttribute("diebegin")]
        public int dieBegin;

        [XmlAttribute("dieend")]
        public int dieEnd;

        [XmlAttribute("jumpbegin")]
        public int jumpBegin;

        [XmlAttribute("jumpend")]
        public int jumpEnd;

    }


}