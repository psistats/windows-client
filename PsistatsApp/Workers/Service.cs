using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            if (PsistatsServiceUtils.IsRunning() == true)
            {
                this.form.SetServiceButton(true);
                this.form.SetTextContent(this.form.service_status_label, "Online");
            }
            else
            {
                this.form.SetServiceButton(false);
                this.form.SetTextContent(this.form.service_status_label, "Offline");
            }

            this.form.SetNotificationText(" ");
        }

        public override void Completed(object sender, RunWorkerCompletedEventArgs e)
        {
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
            this.form.SetNotificationText("Attempting to start service");
            System.Threading.Thread.Sleep(2000);
            this.form.SetNotificationText("Service started successfully");

            Resizer resizer = new Resizer(this.form);
            resizer.Start();
        }

        public override void Completed(object sender, RunWorkerCompletedEventArgs e)
        {
        }
    }
}
