
using Game.Model.Entity;

namespace Game.Model.movement
{
    public class ConcreteEntityMover : EntityMover
    {

        public ConcreteEntityMover(GameEntity entity) : base(entity)
        {

        }

        protected override void MoveManagedEntity()
        {
            managedEntity.position.Xpos += managedEntity.position.XVelocity;
            managedEntity.position.Ypos += managedEntity.position.YVelocity;
            //managedEntity.position.zpos += managedEntity.position.zVelocity;
        }
    }
}