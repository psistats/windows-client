using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Psistats.App.Workers
{
    class Resizer : BasicFormWorker
    {
        public static int MAX_HEIGHT = 350;
        public static int MIN_HEIGHT = 140;

        public static bool DIR_UP = true;
        public static bool DIR_DOWN = false;

        private bool direction = false;

        private int speed = 2;

        private int height;

        public Resizer(MainScreen2 mainScreen2) : base(mainScreen2)
        {
        }

        public override void Start()
        {
            Debug.WriteLine("Form Height:" + this.form.Height.ToString());
            this.InitWorker();

            if (this.form.Height == Resizer.MIN_HEIGHT)
            {
                this.direction = Resizer.DIR_DOWN;
            }
            else
            {
                this.direction = Resizer.DIR_UP;
            }

            this.height = this.form.Height;
            
            this.form.SetNotificationText("Starting...");
            this.GetWorker().RunWorkerAsync();
        }

        
        public override void DoWork(object sender, DoWorkEventArgs e)
        {
            Debug.WriteLine("DoWork()!");
            
            while (true)
            {
                if (this.direction == Resizer.DIR_DOWN)
                {
                    Debug.WriteLine("going down");
                    if (this.height <= Resizer.MAX_HEIGHT)
                    {
                        this.height = this.height + 1;
                        this.form.SetWindowHeight(this.form, this.height);
                    } else {
                        this.direction = Resizer.DIR_UP;
                        break;
                    }
                }
                else
                {
                    if (this.form.Height > Resizer.MIN_HEIGHT)
                    {
                        this.height = this.height - 1;
                        this.form.SetWindowHeight(this.form, this.height);
                    } else {
                        this.direction = Resizer.DIR_DOWN;
                        break;
                        
                    }
                }
                System.Threading.Thread.Sleep(this.speed);
            }
        }

        public override void Completed(object sender, RunWorkerCompletedEventArgs e) {}
    }
}
