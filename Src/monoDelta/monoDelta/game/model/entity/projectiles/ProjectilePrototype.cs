
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Model.entity.projectiles{
    public interface ProjectilePrototype {

        /// <summary>
        /// @return
        /// </summary>
        ProjectilePrototype clone();

    }
}