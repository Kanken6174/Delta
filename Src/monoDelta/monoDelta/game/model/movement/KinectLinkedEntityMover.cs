
using Game.Model.Entity;
using Kinect;
using System;

namespace Game.Model.movement
{
    public class KinectLinkedEntityMover : EntityMover
    {

        public KinectManager dataSource;

        public KinectLinkedEntityMover(GameEntity entity) : base(entity)
        {
        }

        protected override void MoveManagedEntity()
        {
            throw new NotImplementedException();
        }
    }
}