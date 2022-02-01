using game.model.entity;
using game.model.observable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.model.game.model.movement
{
    public abstract class EntityMover : Subscriber
    {

        public EntityMover()
        {
        }

        protected Entity managedEntity;


        protected abstract void moveManagedEntity();

        public void doAction()
        {
            throw new NotImplementedException();
        }
    }
}
