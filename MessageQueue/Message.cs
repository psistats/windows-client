using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Script.Serialization;

namespace Psistats.MessageQueue
{
    [DataContract]
    public class Message
    {
        [DataMember]
        double uptime;

        [DataMember]
        string hostname;

        [DataMember]
        List<String> ipaddr;

        [DataMember]
        double cpu;

        [DataMember]
        double cpu_temp;

        [DataMember]
        double mem;

        public static Message FromStatObject(Stat stat)
        {
            Message msg = new Message();

            msg.uptime = stat.uptime;
            msg.hostname = stat.hostname;
            msg.ipaddr = stat.ipaddr;
            msg.cpu = stat.cpu;
            msg.cpu_temp = stat.cpu_temp;
            msg.mem = stat.mem;

            return msg;
        }

        public static Message FromJson(string json)
        {
            var serializer = new JavaScriptSerializer();

            Message msg = serializer.Deserialize<Message>(json);

            return msg;
        }

        public static String ToJson(Message msg)
        {
            var serializer = new DataContractJsonSerializer(typeof(Message));

            MemoryStream stream = new MemoryStream();

            serializer.WriteObject(stream, msg);
            stream.Position = 0;

            var sr = new StreamReader(stream);
            string json = sr.ReadToEnd();

            return json;
        }
    }
}
