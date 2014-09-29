using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Psistats.MessageQueue
{
    public class Server
    {
        private Config conf;

        private IConnection conn;
        private IModel channel;

        private QueueingBasicConsumer consumer;

        private string queue_name;

        public Server(Config conf)
        {
            this.conf = conf;
        }

        public bool IsConnected()
        {
            if (conn != null)
            {
                if (conn.IsOpen)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public void Connect()
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = conf.server_hostname;
            factory.Port = conf.server_port;
            factory.UserName = conf.server_username;
            factory.Password = conf.server_password;
            factory.VirtualHost = conf.server_vhost;

            this.conn = factory.CreateConnection();
            this.channel = this.conn.CreateModel();
        }

        public string GetQueueName()
        {
            return queue_name;
        }


        public void Bind(string hostname)
        {
            var queue_opts = new Dictionary<string, int>();
            queue_opts["x-message-ttl"] = conf.queue_ttl;

            queue_name = conf.queue_prefix + "." + hostname;

            channel.ExchangeDeclare(conf.exchange_name, conf.exchange_type.ToLower(), conf.exchange_durable, conf.exchange_autodelete, null);
            channel.QueueDeclare(queue_name, conf.queue_durable, conf.queue_exclusive, conf.queue_autodelete, queue_opts);
            channel.QueueBind(queue_name, conf.exchange_name, queue_name);
        }

        public Message getNextMessage()
        {
            if (consumer == null)
            {
                consumer = new QueueingBasicConsumer(channel);
                channel.BasicConsume(queue_name, true, consumer);
            }

            BasicGetResult result = channel.BasicGet(queue_name, true);
            if (result != null)
            {
                channel.BasicAck(result.DeliveryTag, false);

                string json = Encoding.UTF8.GetString(result.Body, 0, result.Body.Length);

                return Message.FromJson(json);
            }

            return null;
        }

        public void DeleteQueue()
        {
            channel.QueueDelete(queue_name);
        }

        public void SendJson(string msg)
        {
            IBasicProperties p = channel.CreateBasicProperties();
            p.DeliveryMode = 2;
            p.ContentType = "application/json";
            p.ContentEncoding = "UTF-8";

            byte[] bytes = Encoding.Default.GetBytes(msg);
            channel.BasicPublish(conf.exchange_name, queue_name, p, bytes);
        }

        public void Close()
        {
            channel.Close();
            channel.Dispose();

            conn.Close();
            conn.Dispose();
        }
    }
}
