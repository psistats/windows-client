Psistats Windows Client
=======================

.NET client that sends some computer statistics to a RabbitMQ server.

* Github: https://github.com/psistats/windows-client
* Builds: http://hq.psikon.net:20020/jenkins/
* Sonar: http://hq.psikon.net:20010/dashboard/index/11

Message Format
--------------
```
{
    "hostname": "my-computer",
    "uptime": 130583.1,
    "cpu": 24.1,
    "mem": 34.1,
    "ipaddr": ['192.168.1.101','192.168.1.102']
    "cpu_temp": 72.4
}
```

Uptime is in seconds.

Uptime and IP Addresses are sent at a longer rate than cpu and memory however that rate is configurable.

CPU Temperature is enabled by default, but may not work on all systems. It is dependent on your motherboard making this information available over WMI and is not always accurate. Some work will need to be done to better expose CPU temperatures across Intel/AMD chips.

Installation
------------

- Stable Version: http://repo.psikon.org/psistats/clients/windows/releases
- Snapshot Builds: http://repo.psikon.org/psistats/clients/windows/snapshots

1. Download and install Psistats
2. Launch the Psistats application
3. Click settings and configure Psistats (details below)
4. Save settings, and click on Start Service

Configuration
-------------

####Server Settings
* **Hostname / IP:** Address of the RabbitMQ server
* **Port:** Port number of the RabbitMQ server
* **Path:** Virtual host path
* **Username:** RabbitMQ Username
* **Password:** RabbitMQ Password

####Service Setings
* **Main Timer:** The main timer broadcasts the cpu and memory usage, hostname, and cpu temperature. Defaults to 1 second.
* **Secondary Timer:** The secondary timer broadcastst the hostname, ip addresses, and uptime. Defaults to 5 seconds.
* **Debug:** If checked, lots of information will be sent to the Event Log. Could potentially reveal passwords.

####Queue Settings
* **Name:** The queue prefix to use. The full queue name will be [prefix].[hostname]. Defaults to "psistats"
* **Message TTL:** How long messages should stay in the queue, in milliseconds. Defaults to 10000
* **Exclusive:** Whether or not any other client can access the queue. Defaults to checked
* **Durable:** Whether or not the queue will be recreated automatically upon server restart
* **Autodelete:** Whether or not the queue will be removed when there are no more clients using it

####Exchange Settings
* **Name:** The exchange name to use. Defaults to "psistats"
* **Type:** What kind of exchange it should be. Defaults to "topic"
* **Durable:** Whether or not the exchange will be recreated automatically upon server restart
* **Autodelete:** Whether or not the exchange will be removed when there are no more clients using it 

The exchange settings for all client installations must be the same.

Fault Tolerance
---------------

Psistats is fault tolerant. If the queue or exchange get deleted, they will be recreated. If the server goes down, the service will continue trying to reconnect.

Troubleshooting
---------------

Psistats will log exceptions and other messages to the event log.
