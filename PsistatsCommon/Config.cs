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
        public string server_hostname = "localhost";
        public int server_port = 5672;
        public string server_username = "guest";
        public string server_password = "guest";
        public string server_vhost = "/";

        public string exchange_name = "psistats";
        public string exchange_type = "Topic";
        public bool exchange_durable = false;
        public bool exchange_autodelete = false;

        public string queue_prefix = "psistats";
        public bool queue_exclusive = true;
        public bool queue_durable = false;
        public bool queue_autodelete = true;
        public int queue_ttl = 10000;

        public int primary_timer = 1;
        public int secondary_timer = 5;
        public int retry_timer = 5;
        public bool app_cputemp = true;

        public Config() { }

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
