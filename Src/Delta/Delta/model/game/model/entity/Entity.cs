
using game.model.collisions.hitboxes;
using game.model.movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game.model.entity{
    public abstract class Entity {

        public Entity() {
        }

        public int Lifetime;

        public Position position;

        public HitboxSphere hitbox;




    }
}