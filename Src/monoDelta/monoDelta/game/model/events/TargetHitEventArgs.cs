
using game.model.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game.model.events{
    public class TargetHitEventArgs : EventArgs {

        public TargetHitEventArgs() {
        }

        public Target t;

    }
}