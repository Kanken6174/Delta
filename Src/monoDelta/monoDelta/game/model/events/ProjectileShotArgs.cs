
using Game.Model.Entity.Projectiles;
using System;

namespace Game.Model.events
{
    public class ProjectileShotArgs : EventArgs
    {

        public ProjectileShotArgs()
        {
        }

        public Projectile p;

    }
}