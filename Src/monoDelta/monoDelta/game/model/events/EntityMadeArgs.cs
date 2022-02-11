
using Game.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Model.events{
    public class EntityMadeArgs : EventArgs {

        public EntityMadeArgs() {
        }

        public GameEntity entity;

    }
}