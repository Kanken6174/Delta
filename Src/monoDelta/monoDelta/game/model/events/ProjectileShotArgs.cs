
using Game.Model.entity.projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Model.events{
    public class ProjectileShotArgs : EventArgs {

        public ProjectileShotArgs() {
        }

        public Projectile p;

    }
}