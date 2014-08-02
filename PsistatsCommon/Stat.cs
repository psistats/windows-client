using System;
using System.Management;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace Psistats
{
    public class Stat
    {
        private string _ipaddr = null;
        private string _hostname = null;

        private PerformanceCounter cpuCounter;
        private PerformanceCounter uptimeCounter;

        private ManagementObjectSearcher searcher;

        public double uptime
        {
            get
            {
                if (uptimeCounter == null)
                {
                    uptimeCounter = new PerformanceCounter("System", "System Up Time");
                }
                return System.Convert.ToDouble(uptimeCounter.NextValue());
            }
        }

        public string hostname
        {
            get
            {
                if (this._hostname == null)
                {
                    this._hostname = System.Environment.GetEnvironmentVariable("COMPUTERNAME").ToLower();
                }

                return this._hostname;
            }
        }

        public string ipaddr
        {
            get
            {
                if (this._ipaddr == null)
                {
                    this._ipaddr = this.localIPAddress();
                }
                return this._ipaddr;
            }
        }

        
        public double cpu {
            get {
                return this.getCpuPercent();
            }
        }

        public double mem
        {
            get
            {
                if (searcher == null)
                {
                    searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
                }

                string sFreeMem = null;
                string sTotalMem = null;

                double freeMem;
                double totalMem;

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    sFreeMem = queryObj["FreeVirtualMemory"].ToString();
                    sTotalMem = queryObj["TotalVirtualMemorySize"].ToString();
                }

                if (sFreeMem != null)
                {

                    freeMem = double.Parse(sFreeMem);
                    totalMem = double.Parse(sTotalMem);

                    return Math.Round((freeMem / totalMem) * 100, 2);
                }
                else
                {
                    return 0.0;
                }
            }
        }

        private double getCpuPercent()
        {
            if (this.cpuCounter == null)
            {
                this.cpuCounter = new PerformanceCounter();
                this.cpuCounter.CategoryName = "Processor";
                this.cpuCounter.CounterName = "% Processor Time";
                this.cpuCounter.InstanceName = "_Total";
            }
            return Math.Round(Convert.ToDouble(this.cpuCounter.NextValue()), 2);
        }

        private string localIPAddress()
        {
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    if (ni.Name == "Local Area Connection")
                    {
                        foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            {
                                return ip.Address.ToString();
                            }
                        }
                    }
                }
            }
            return "";
        }
    }
}
