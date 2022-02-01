
using game.model.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game.model.events{
    public class PlayerHitEventArgs : EventArgs {

        public PlayerHitEventArgs() {
        }

        public Target hitBy;

    }
}