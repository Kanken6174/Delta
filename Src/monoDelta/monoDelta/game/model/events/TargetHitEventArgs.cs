
using Game.Model.Entity;
using System;

namespace Game.Model.events
{
    public class TargetHitEventArgs : EventArgs
    {

        public TargetHitEventArgs()
        {
        }

        public Target t;

    }
}