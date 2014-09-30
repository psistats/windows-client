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

        private string completedMessage;

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
            worker.RunWorkerCompleted += Completed;
            worker.DoWork += DoWork;
        }

        protected void SetCompletedMessage(string msg)
        {
            this.completedMessage = msg;
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

        public void Completed(object sender, RunWorkerCompletedEventArgs e) {
            this.form.SetNotificationText(this.completedMessage);
        }
    }
}
