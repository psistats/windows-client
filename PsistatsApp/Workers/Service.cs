using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Psistats.App.Workers
{
    class ServiceChecker : BasicFormWorker
    {
        public ServiceChecker(MainScreen2 form) : base(form) {}

        public override void DoWork(object sender, DoWorkEventArgs e)
        {
            this.log("Checking service...");
            if (Psistats.ServiceUtils.Utils.IsRunning() == true)
            {
                this.form.SetServiceButton(true);
                this.log("Service Started");
            }
            else
            {
                this.form.SetServiceButton(false);
                this.log("Service Stopped");
            }
        }
    }

    class ServiceStarter : BasicFormWorker
    {
        public ServiceStarter(MainScreen2 form)
            : base(form)
        {
        }

        public override void DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {

                string arg;

                if (Psistats.ServiceUtils.Utils.IsRunning() == true)
                {
                    this.log("Stopping service");
                    arg = "uninstall";
                }
                else
                {
                    this.log("Starting service");
                    arg = "install";
                }


                Process process = null;
                ProcessStartInfo processStartInfo = new ProcessStartInfo();

                processStartInfo.FileName = "PsistatsServiceCLI.EXE";

                processStartInfo.Verb = "runas";
                processStartInfo.WindowStyle = ProcessWindowStyle.Normal;
                processStartInfo.UseShellExecute = true;
                processStartInfo.Arguments = arg;

                process = Process.Start(processStartInfo);
                process.WaitForExit();

                var nextWorker = new ServiceChecker(this.form);
                nextWorker.Start();

            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.ToString());
                Debug.WriteLine(exc.Message);
                Debug.WriteLine(exc.StackTrace);
                this.form.AddLog(exc.ToString());
            }
        }
    }
}
