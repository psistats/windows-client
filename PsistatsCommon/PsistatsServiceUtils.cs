using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace Psistats
{
    public static class PsistatsServiceUtils
    {
        public static string SERVICE_NAME = "Psistats";
        public static string SERVICE_EXE = "PsistatsService.exe";

        public static ServiceController GetServiceController()
        {
            return ServiceController.GetServices().FirstOrDefault(s => s.ServiceName == PsistatsServiceUtils.SERVICE_NAME);
        }

        public static bool IsInstalled()
        {
            ServiceController ctl = PsistatsServiceUtils.GetServiceController();
            
            if (ctl == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsRunning()
        {
            ServiceController ctl = PsistatsServiceUtils.GetServiceController();
            if (ctl == null)
            {
                return false;
            }
            else
            {
                if (ctl.Status == ServiceControllerStatus.Running)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static void InstallService()
        {
            if (!PsistatsServiceUtils.IsInstalled())
            {
                ManagedInstallerClass.InstallHelper(new string[] { PsistatsServiceUtils.SERVICE_EXE });
            }
        }

        public static void StartService()
        {
            if (!PsistatsServiceUtils.IsRunning())
            {
                ServiceController sc = PsistatsServiceUtils.GetServiceController();
                sc.Start();
            }
        }


        public static void InstallAndStart()
        {
            PsistatsServiceUtils.InstallService();
            PsistatsServiceUtils.StartService();
        }

        public static void UninstallService()
        {
            ManagedInstallerClass.InstallHelper(new string[] { "/u", PsistatsServiceUtils.SERVICE_EXE });
        }

        public static void StopService()
        {
            ServiceController service = PsistatsServiceUtils.GetServiceController();
            service.Stop();
        }

        public static void StopAndUninstall()
        {
            PsistatsServiceUtils.StopService();
            PsistatsServiceUtils.UninstallService();
        }
    }
}
