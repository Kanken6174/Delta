
using Game.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Model.events{
    public class PlayerHitEventArgs : EventArgs {

        public PlayerHitEventArgs() {
        }

        public Target hitBy;

    }
}