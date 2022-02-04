
using game.model.entity;
using game.model.observable;
using System;

namespace game.model.movement
{
        public abstract class EntityMover : Subscriber {

            public EntityMover() {
            }

            private GameEntity managedEntity;


            private void moveManagedEntity() {
                // TODO implement here
            }

            public void doAction()
            {
                throw new NotImplementedException();
            }
        }
}