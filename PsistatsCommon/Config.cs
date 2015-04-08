using System;
using System.Collections;
using System.Runtime.Serialization;
using System.Xml;
using System.Linq;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Microsoft.Win32;
using System.Diagnostics;

namespace Psistats
{
    public class Config
    {
        public string ServerUrl
        {
            get;
            set;
        }

        public string ExchangeName { get; set; }
        public string ExchangeType { get; set; }
        public bool ExchangeDurable { get; set; }
        public bool ExchangeAutodelete { get; set; }

        public string QueuePrefix { get; set; }
        public bool QueueExclusive { get; set; }
        public bool QueueDurable { get; set; }
        public bool QueueAutodelete { get; set; }
        public int QueueTTL { get; set; }

        public int PrimaryTimer { get; set; }
        public int SecondaryTimer { get; set; }
        public int RetryTimer { get; set; }
        public bool DebugEnabled { get; set; }

        public bool EnableCpu { get; set; }
        public bool EnableMem { get; set; }
        public bool EnableCpuTemp { get; set; }
        public bool EnableUptime { get; set; }
        public bool EnableHostname { get; set; }

        public Config() {

            this.ServerUrl = "amqp://guest:guest@localhost:5672";

            this.ExchangeName = "psistats";
            this.ExchangeType = "Topic";
            this.ExchangeDurable = false;
            this.ExchangeAutodelete = false;

            this.QueuePrefix = "psistats";
            this.QueueExclusive = true;
            this.QueueDurable = false;
            this.QueueAutodelete = true;
            this.QueueTTL = 10000;

            this.PrimaryTimer = 1;
            this.SecondaryTimer = 5;
            this.RetryTimer = 5;
            this.DebugEnabled = false;

            this.EnableCpu = true;
            this.EnableMem = true;
            this.EnableCpuTemp = true;
            this.EnableUptime = true;
            this.EnableHostname = true;

        
        }

        public static string GetConfigFilePath()
        {
            string root = "HKEY_LOCAL_MACHINE";
            string path = "SOFTWARE\\Wow6432Node\\Psikon\\Psistats";
            string key = "config";

            string keyname = root + "\\" + path;

            Uri fileUri = new Uri(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            string default_conf = System.IO.Path.GetDirectoryName(fileUri.AbsolutePath) + "\\psistats.conf";

            string conf_file = (string)Registry.GetValue(keyname, key, default_conf);

            if (conf_file == null)
            {
                conf_file = default_conf;
            }

            return conf_file;
        }

        public static bool Exists()
        {
            string conf = Config.GetConfigFilePath();
            return File.Exists(conf);
        }

        private static void CreateConfigFolder() {

            string conf_folder = Path.GetDirectoryName(Config.GetConfigFilePath());

            if (!Directory.Exists(conf_folder))
            {
                System.IO.Directory.CreateDirectory(conf_folder);
            }
        }

        static public void WriteConf(Config conf)
        {
            string conf_file = Config.GetConfigFilePath();
            Debug.WriteLine("Config file: ");
            Debug.WriteLine(conf_file);

            CreateConfigFolder();
            XmlSerializer ser = new XmlSerializer(typeof(Config));
            TextWriter writer = new StreamWriter(conf_file);

            ser.Serialize(writer, conf);
            writer.Close();
        }

        static public Config LoadConf()
        {
            if (!Config.Exists())
            {
                return new Config();
            }

            XmlSerializer ser = new XmlSerializer(typeof(Config));

            FileStream fs = new FileStream(Config.GetConfigFilePath(), FileMode.Open);

            Config conf;

            conf = (Config)ser.Deserialize(fs);

            fs.Close();

            return conf;
        }
    }
}
