using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Psistats.MessageQueue
{
    [DataContract]
    public class Message
    {
        [DataMember(EmitDefaultValue = false)]
        double uptime;

        public double Uptime
        {
            get { return uptime; }
            set { uptime = value; }
        }

        [DataMember(EmitDefaultValue = false)]
        string hostname;

        public string Hostname
        {
            get { return hostname; }
            set { hostname = value; }
        }

        [DataMember(EmitDefaultValue = false)]
        List<String> ipaddr;

        public List<String> Ipaddr
        {
            get { return ipaddr; }
            set { ipaddr = value; }
        }

        [DataMember(EmitDefaultValue = false)]
        double cpu;

        public double Cpu
        {
            get { return cpu; }
            set { cpu = value; }
        }

        [DataMember(EmitDefaultValue = false)]
        double cputemp;

        public double CpuTemp
        {
            get { return cputemp; }
            set { cputemp = value; }
        }

        [DataMember(EmitDefaultValue = false)]
        double mem;

        public double Mem
        {
            get { return mem; }
            set { mem = value; }
        }

        public static Message FromStatObject(Stat stat)
        {
            Message msg = new Message();

            msg.Hostname = stat.Hostname;
            msg.Uptime = stat.Uptime;
            msg.Ipaddr = stat.Ipaddr;
            msg.Cpu = stat.Cpu;
            msg.CpuTemp = (double) stat.CpuTemp;
            msg.Mem = stat.Mem;

            return msg;
        }

        public static Message FromJson(string json)
        {
            var serializer = new DataContractJsonSerializer(typeof(Message));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));

            Message msg = (Message)serializer.ReadObject(stream);

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
