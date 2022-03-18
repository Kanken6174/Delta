
using Game.Model.Entity;
using System;

namespace Game.Model.events
{
    public class PlayerHitEventArgs : EventArgs
    {

        public PlayerHitEventArgs()
        {
        }

        public Target hitBy;

    }
}