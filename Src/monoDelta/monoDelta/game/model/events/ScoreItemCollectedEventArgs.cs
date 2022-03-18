
using Game.Model.Entity;
using System;

namespace Game.Model.events
{
    public class ScoreItemCollectedEventArgs : EventArgs
    {

        public ScoreItemCollectedEventArgs()
        {
        }

        public ScoreItem collectedItem;

    }
}