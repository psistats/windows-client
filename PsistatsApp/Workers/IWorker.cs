using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Psistats.App.Workers
{
    public interface IWorker
    {
        void Start();
        void DoWork(object sender, DoWorkEventArgs e);
        void Completed(object sender, RunWorkerCompletedEventArgs e);
        BackgroundWorker GetWorker();
    }
}
