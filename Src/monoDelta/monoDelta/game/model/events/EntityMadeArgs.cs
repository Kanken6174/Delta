
using Game.Model.Entity;
using System;

namespace Game.Model.events
{
    public class EntityMadeArgs : EventArgs
    {

        public EntityMadeArgs()
        {
        }

        public GameEntity entity;

    }
}