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
        public string server_hostname;
        public int server_port;
        public string server_username;
        public string server_password;
        public string server_vhost;

        public string exchange_name;
        public string exchange_type;
        public bool exchange_durable;
        public bool exchange_autodelete;

        public string queue_prefix;
        public bool queue_exclusive;
        public bool queue_durable;
        public bool queue_autodelete;
        public int queue_ttl;

        public int app_timer;
        public int metadata_timer;
        public int retry_timer;

        public Config() { }

        public static string GetConfigFilePath()
        {
            string root = "HKEY_LOCAL_MACHINE";
            string path = "SOFTWARE\\Wow6432Node\\Psikon\\Psistats";
            string key = "config";

            string keyname = root + "\\" + path;

            string default_conf = Environment.SpecialFolder.CommonApplicationData + "\\psistats.conf";

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
