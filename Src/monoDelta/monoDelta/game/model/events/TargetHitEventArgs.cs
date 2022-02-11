
using Game.Model.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Model.events{
    public class TargetHitEventArgs : EventArgs {

        public TargetHitEventArgs() {
        }

        public Target t;

    }
}