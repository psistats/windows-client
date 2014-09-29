using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace Psistats.MessageQueue
{
    public class Message
    {
        double uptime;
        string hostname;
        List<String> ipaddr;
        double cpu;
        double cpu_temp;
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
            var serializer = new JavaScriptSerializer();
            string json = serializer.Serialize(msg);
            return json;
        }
    }
}
