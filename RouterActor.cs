using Akka.Actor;
using Akka.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AkkaTest
{
    public class TrackerRouterActor : UntypedActor
    {
        public TrackerRouterActor() { }

        protected override void OnReceive(object message)
        {

            if ((string)message == "void") return;

            var msgTrackerId = message.ToString().Split(":")[1];

            var receiver = Context.Child(msgTrackerId);
            if(receiver != ActorRefs.Nobody)
            {
                receiver.Tell(message);
            }
            else
            {
                IActorRef child = Context.ActorOf(TrackerWriterActor.Props(int.Parse(msgTrackerId)));
                child.Tell(msgTrackerId);
            }
        }

        public static Props Props()
        {
            return Akka.Actor.Props.Create(() => new TrackerRouterActor());
        }

    }


}
