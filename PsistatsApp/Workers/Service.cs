using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Psistats.App.Workers
{
    class ServiceChecker : BasicFormWorker
    {
        public ServiceChecker(MainScreen2 form) : base(form) {}

        public override void DoWork(object sender, DoWorkEventArgs e)
        {
            this.form.SetNotificationText("Checking service status");
            if (Psistats.ServiceUtils.Utils.IsRunning() == true)
            {
                this.form.SetServiceButton(true);
                this.form.SetTextContent(this.form.service_status_label, "Online");
            }
            else
            {
                this.form.SetServiceButton(false);
                this.form.SetTextContent(this.form.service_status_label, "Offline");
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
                    arg = "uninstall";
                }
                else
                {
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
                this.SetCompletedMessage("Was not able to start service properly");
            }
        }
    }
}
