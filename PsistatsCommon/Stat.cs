﻿using System;
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
using OpenHardwareMonitor.Hardware;

namespace Psistats
{
    public class Stat
    {
        private List<String> ipaddr = null;
        private string hostname = null;

        private PerformanceCounter cpuCounter;
        private PerformanceCounter uptimeCounter;

        private ManagementObjectSearcher searcher;

        private ISensor cpu_temp_sensor;

        private IHardware cpu_hardware;

        private Computer computer;

        public double Uptime
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

        public string Hostname
        {
            get
            {
                if (this.hostname == null)
                {
                    this.hostname = System.Environment.GetEnvironmentVariable("COMPUTERNAME").ToLower();
                }

                return this.hostname;
            }
        }

        public List<String> Ipaddr
        {
            get
            {
                if (this.ipaddr == null)
                {
                    this.ipaddr = new List<string>();
                } else if (this.ipaddr.Count() == 0) {
                    this.ipaddr.Add(this.localIPAddress());
                }

                return this.ipaddr;
            }
        }

        
        public double Cpu {
            get {
                return this.getCpuPercent();
            }
        }

        public Computer GetComputer()
        {
            if (computer == null)
            {
                computer = new Computer();
                computer.CPUEnabled = true;
                computer.Open();
            }
            return computer;
        }

        public IHardware GetCpuHardware()
        {
            if (this.cpu_hardware == null)
            {
                Computer comp = GetComputer();
                foreach (IHardware hardware in comp.Hardware)
                {
                    if (hardware.HardwareType == HardwareType.CPU)
                    {
                        this.cpu_hardware = hardware;
                    }
                }
            }
            return this.cpu_hardware;
        }

        public ISensor GetCpuSensor()
        {
            if (this.cpu_temp_sensor == null)
            {
                IHardware cpu = GetCpuHardware();
                foreach (ISensor sensor in cpu.Sensors)
                {
                    if (sensor.SensorType == SensorType.Temperature)
                    {
                        if (sensor.Name == "CPU Package")
                        {
                            this.cpu_temp_sensor = sensor;
                            return this.cpu_temp_sensor;
                        }
                        else if (sensor.Name == "CPU Core #1")
                        {
                            this.cpu_temp_sensor = sensor;
                            return this.cpu_temp_sensor;
                        }
                    }
                }
                return null;
            }
            else
            {
                return this.cpu_temp_sensor;
            }
        }

        public double? CpuTemp
        {
            get
            {
                var hardware = GetCpuHardware();
                if (hardware == null)
                {
                    return null;
                }
                hardware.Update();

                var sensor = GetCpuSensor();
                if (sensor == null)
                {
                    return null;
                    
                }
                return System.Convert.ToDouble(sensor.Value);
            }
        }

        public double Mem
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
