using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Psistats.App.Workers
{
    class Service : BasicFormWorker
    {
        public Service(MainScreen2 form)
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
