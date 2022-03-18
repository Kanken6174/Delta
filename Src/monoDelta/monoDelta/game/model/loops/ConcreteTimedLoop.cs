
using System;
using System.Threading;

namespace Game.Model.loops
{
    public class ConcreteTimedLoop : TimedLoop
    {

        public ConcreteTimedLoop()
        {
        }

        private Thread localthread;

        public override void Start()
        {
            throw new NotImplementedException();
        }

        public override void Stop()
        {
            throw new NotImplementedException();
        }
    }
}