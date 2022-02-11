
using Game.Model.entity;
using Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Game.Model.movement.Position;

namespace Game.Model.movement{
    public class KinectLinkedEntityMover : EntityMover {

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