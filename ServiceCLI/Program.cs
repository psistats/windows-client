using System;
using System.Collections.Generic;
using System.Text;
using Psistats.ServiceUtils;

namespace Psistats.ServiceCLI
{
    class Program
    {
        static int Main(string[] args)
        {
            int exitCode = 0;
            if (args.Length > 0)
            {

                Console.WriteLine("Trying my luck at " + args[0] + "ing this Psistats service thing...");

                try
                {
                    if (args[0] == "install")
                    {
                        Utils.InstallAndStart();
                        Console.WriteLine("Service installed!");
                    }
                    else if (args[0] == "uninstall")
                    {
                        Utils.StopAndUninstall();
                        Console.WriteLine("Service uninstalled");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("I wasn't able to " + args[0] + " the service. I am sorry...");
                    Console.WriteLine(e.ToString());
                    if (e.InnerException != null)
                    {
                        Console.WriteLine(e.InnerException.ToString());
                    }
                    Console.WriteLine(" ");
                    Console.WriteLine("Press any key to continue, and again, sorry for that...");
                    Console.Read();
                    exitCode = 1;
                }

            }
            else
            {
                Console.WriteLine("What was it I was supposed to do again?");
                exitCode = 2;
            }

            return exitCode;
        }
    }
}
