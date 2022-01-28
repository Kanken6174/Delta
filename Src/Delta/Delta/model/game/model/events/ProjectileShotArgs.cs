
using game.model.entity.projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game.model.events{
    public class ProjectileShotArgs : EventArgs {

        public ProjectileShotArgs() {
        }

        public Projectile p;

    }
}