using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabbitMQ.Client;

namespace Psistats.MessageQueue
{
    public class Server
    {
        private Config conf;

        private IConnection conn;
        private IModel channel;

        private QueueingBasicConsumer consumer;

        private string queue_name;

        public Server(Config config)
        {
            if (config == null)
            {
                throw new ArgumentNullException("config can't be null");
            }
            this.conf = config;
        }

        public bool IsConnected()
        {
            if (this.conn.IsOpen)
            {
                return true;
            }
            return false;
        }

        public void Connect()
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.uri = new Uri(conf.ServerUrl);
            
            this.conn = factory.CreateConnection();
            this.channel = this.conn.CreateModel();
        }

        public void Bind(string hostname)
        {
            var queue_opts = new Dictionary<string, object>();
            queue_opts["x-message-ttl"] = conf.QueueTTL;

            this.queue_name = this.conf.QueuePrefix + "." + hostname;

            this.channel.ExchangeDeclare(this.conf.ExchangeName, this.conf.ExchangeType.ToLower(), this.conf.ExchangeDurable, this.conf.ExchangeAutodelete, null);
            this.channel.QueueDeclare(this.queue_name, this.conf.QueueDurable, this.conf.QueueExclusive, this.conf.QueueAutodelete, queue_opts);
            this.channel.QueueBind(this.queue_name, this.conf.ExchangeName, this.queue_name);
        }

        public Message NextMessage()
        {
            if (this.consumer == null)
            {
                this.consumer = new QueueingBasicConsumer(this.channel);
                this.channel.BasicConsume(this.queue_name, true, this.consumer);
            }

            BasicGetResult result = channel.BasicGet(this.queue_name, true);
            if (result != null)
            {
                this.channel.BasicAck(result.DeliveryTag, false);

                string json = Encoding.UTF8.GetString(result.Body, 0, result.Body.Length);

                return Message.FromJson(json);
            }

            return null;
        }

        public void DeleteQueue()
        {
            this.channel.QueueDelete(this.queue_name);
        }

        public void Send(string msg)
        {
            IBasicProperties p = this.channel.CreateBasicProperties();
            p.DeliveryMode = 2;
            p.ContentType = "application/json";
            p.ContentEncoding = "UTF-8";

            byte[] bytes = Encoding.Default.GetBytes(msg);
            this.channel.BasicPublish(conf.ExchangeName, queue_name, p, bytes);
        }

        public void Send(Message msg)
        {
            this.Send(Message.ToJson(msg));
        }

        public void Close()
        {
            this.channel.Close();
            this.channel.Dispose();

            this.conn.Close();
            this.conn.Dispose();
        }
    }
}
