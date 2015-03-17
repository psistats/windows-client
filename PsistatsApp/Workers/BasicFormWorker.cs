using Psistats.App;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace Psistats.App.Workers
{
    abstract class BasicFormWorker : IWorker
    {
        protected MainScreen2 form;
        protected BackgroundWorker worker;

        public BasicFormWorker(MainScreen2 form)
        {
            this.form = form;
        }

        public virtual void Start()
        {
            this.InitWorker();
            this.worker.RunWorkerAsync();
        }

        public void InitWorker()
        {
            var worker = this.GetWorker();
            worker.DoWork += DoWork;
        }

        public void log(String msg)
        {
            this.form.AddLog(msg);
        }

        public BackgroundWorker GetWorker()
        {
            if (this.worker == null)
            {
                this.worker = new BackgroundWorker();
            }
            return this.worker;
        }

        abstract public void DoWork(object sender, DoWorkEventArgs e);
    }
}
