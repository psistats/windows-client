﻿using RabbitMQ.Client;
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
            if (conn.IsOpen)
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

        public string GetQueueName()
        {
            return queue_name;
        }


        public void Bind(string hostname)
        {
            var queue_opts = new Dictionary<string, object>();
            queue_opts["x-message-ttl"] = conf.QueueTTL;

            queue_name = conf.QueuePrefix + "." + hostname;

            channel.ExchangeDeclare(conf.ExchangeName, conf.ExchangeType.ToLower(), conf.ExchangeDurable, conf.ExchangeAutodelete, null);
            channel.QueueDeclare(queue_name, conf.QueueDurable, conf.QueueExclusive, conf.QueueAutodelete, queue_opts);
            channel.QueueBind(queue_name, conf.ExchangeName, queue_name);
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

        public void Send(string msg)
        {
            IBasicProperties p = channel.CreateBasicProperties();
            p.DeliveryMode = 2;
            p.ContentType = "application/json";
            p.ContentEncoding = "UTF-8";

            byte[] bytes = Encoding.Default.GetBytes(msg);
            channel.BasicPublish(conf.ExchangeName, queue_name, p, bytes);
        }

        public void Send(Message msg)
        {
            this.Send(Message.ToJson(msg));
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
