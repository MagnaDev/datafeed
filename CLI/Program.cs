﻿using System;
using System.Collections.Generic;
using JLPMPDev.Datafeed.Core;

namespace JLPMPDev.Datafeed.CLI
{
    public class Program
    {
        static void Main(string[] Args)
        {
            Config config = Config.Deserialize();

            try
            {
                // read feed and build list
                Console.WriteLine("Attemping to read feed. Please wait...");
                List<Core.Attribute> list = Core.Attribute.BuildList(config.feedPath);

                if (list.Count < 1)
                {
                    Console.WriteLine("Feed is empty. Press any key to exit.");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("Attempting to send message. Please wait...");
                Mail.SendMail(list, config);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
    }
}