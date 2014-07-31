using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Psistats
{
    class DotNetChecker
    {
        public static double[] getVersion()
        {
            RegistryKey installed_versions = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP");
            string[] version_names = installed_versions.GetSubKeyNames();
            //version names start with 'v', eg, 'v3.5' which needs to be trimmed off before conversion
            double Framework = Convert.ToDouble(version_names[version_names.Length - 1].Remove(0, 1), CultureInfo.InvariantCulture);
            double SP = Convert.ToDouble(installed_versions.OpenSubKey(version_names[version_names.Length - 1]).GetValue("SP", 0));
            double[] packet = new double[2];
            packet[0] = Framework;
            packet[1] = SP;
            return packet;
        }
    }
}
