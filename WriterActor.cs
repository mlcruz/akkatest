using Akka.Actor;
using Akka.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace AkkaTest
{
    public class TrackerWriterActor : UntypedActor
    {
        private readonly int _trackerId;
        private double myNum { get; set; }


        public TrackerWriterActor(int trackerId)
        {
            _trackerId = trackerId;
            myNum = 0;
        }

        protected override void OnReceive(object message)
        {
            if (int.Parse(message.ToString()) % 10 == 0 && myNum == 0)
            {
                var doStuff = Math.Pow(Double.Parse(message.ToString()), 5);
                Console.WriteLine(doStuff.ToString());
                myNum = doStuff;
            }
            else
            {
                if (myNum != 0)
                {
                    Console.WriteLine("My num: " + myNum.ToString());
                }
            }

        }

        public static Props Props(int trackerId)
        {
            return Akka.Actor.Props.Create(() => new TrackerWriterActor(trackerId));
        }
    }
}
