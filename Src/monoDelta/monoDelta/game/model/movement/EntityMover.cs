using game.model.entity;
using game.model.observable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game.model.movement
{
    public abstract class EntityMover : Subscriber
    {

        public EntityMover(GameEntity entity)
        {
            this.managedEntity = entity;
        }

        protected GameEntity managedEntity;

        protected abstract void MoveManagedEntity();

        void Subscriber.doAction() => MoveManagedEntity();
    }
}
