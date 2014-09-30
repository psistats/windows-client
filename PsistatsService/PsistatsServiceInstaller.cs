using System.Configuration.Install;
using System.ServiceProcess;

namespace Psistats.Service
{
    class PsistatsServiceInstaller : Installer
    {
        public PsistatsServiceInstaller()
        {
            ServiceProcessInstaller spi = new ServiceProcessInstaller();
            ServiceInstaller si = new ServiceInstaller();

            spi.Account = ServiceAccount.LocalService;
            spi.Username = null;
            spi.Password = null;

            si.DisplayName = "PsistatsService";
            si.StartType = ServiceStartMode.Automatic;

            si.ServiceName = "PsistatsService";

            this.Installers.Add(spi);
            this.Installers.Add(si);
        }
    }
}
