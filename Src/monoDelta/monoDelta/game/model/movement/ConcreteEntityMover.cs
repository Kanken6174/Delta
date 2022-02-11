
using game.model.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static game.model.movement.Position;

namespace game.model.movement{
    public class ConcreteEntityMover : EntityMover {

        public ConcreteEntityMover(GameEntity entity) : base(entity) {
       
        }

        protected override void MoveManagedEntity()
        {
            managedEntity.position.xpos += managedEntity.position.xVelocity;
            managedEntity.position.ypos += managedEntity.position.yVelocity;
            //managedEntity.position.zpos += managedEntity.position.zVelocity;
        }
    }
}