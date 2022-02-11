
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Model.Entity.Projectiles{
    public interface IProjectilePrototype {

        /// <summary>
        /// @return
        /// </summary>
        IProjectilePrototype Clone();

    }
}