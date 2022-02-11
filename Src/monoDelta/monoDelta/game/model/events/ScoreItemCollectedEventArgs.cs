
using Game.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Model.events{
    public class ScoreItemCollectedEventArgs : EventArgs {

        public ScoreItemCollectedEventArgs() {
        }

        public ScoreItem collectedItem;

    }
}