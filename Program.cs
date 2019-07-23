using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Timers;

namespace AkkaTest
{


    class Program
    {
        static void Main(string[] args)
        {
            var userStateSystem = ActorSystem.Create("userState");
            var routerActor = userStateSystem.ActorOf(TrackerRouterActor.Props(), "router");


            var createTimer = new Timer();
            var sendTimer = new Timer();
            createTimer.Start();
            for (int i = 0; i < 10000; i++)
            {
                routerActor.Tell("tkid:"+i.ToString());
            }
            createTimer.Stop();
            sendTimer.Start();
            for (int i = 0; i < 10000; i++)
            {
                routerActor.Tell("tkid:" + i.ToString());
            }
            sendTimer.Stop();

            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n");
            Console.WriteLine($"Async: { createTimer.Interval}");

            while (true)
            {
                Console.WriteLine("Send msg:");
                routerActor.Tell(Console.ReadLine());
            }

        }

    }
}
