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
                try
                {
                    if (args[0] == "install")
                    {
                        if (!Utils.IsInstalled())
                        {
                            Utils.InstallService();
                        }
                        Utils.StartService();
                    }
                    else if (args[0] == "uninstall")
                    {
                        Utils.StopService();
#if DEBUG
                        Utils.UninstallService();
#endif
                    }
                }
                catch (Exception e)
                {
#if DEBUG
                    Console.WriteLine("I wasn't able to " + args[0] + " the service. I am sorry...");
                    Console.WriteLine(e.ToString());
                    if (e.InnerException != null)
                    {
                        Console.WriteLine(e.InnerException.ToString());
                    }
                    Console.WriteLine(" ");
                    Console.WriteLine("Press enter to continue, and again, sorry for that...");
                    string output = Console.ReadLine();
#endif
                    exitCode = 1;
                }

            }
            else
            {
                exitCode = 2;
            }

            return exitCode;
        }
    }
}
