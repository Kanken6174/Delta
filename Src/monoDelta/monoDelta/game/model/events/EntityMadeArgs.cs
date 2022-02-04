
using game.model.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game.model.events{
    public class EntityMadeArgs : EventArgs {

        public EntityMadeArgs() {
        }

        public GameEntity entity;

    }
}