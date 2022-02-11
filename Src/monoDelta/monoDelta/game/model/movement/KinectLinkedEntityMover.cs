
using game.model.entity;
using kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static game.model.movement.Position;

namespace game.model.movement{
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