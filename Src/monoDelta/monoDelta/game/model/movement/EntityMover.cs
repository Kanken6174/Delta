using Game.Model.Entity;
using Game.Model.Observable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Model.movement
{
    public abstract class EntityMover : ISubscriber
    {

        public EntityMover(GameEntity entity)
        {
            this.managedEntity = entity;
        }

        protected GameEntity managedEntity;

        protected abstract void MoveManagedEntity();

        void ISubscriber.DoAction() => MoveManagedEntity();
    }
}
