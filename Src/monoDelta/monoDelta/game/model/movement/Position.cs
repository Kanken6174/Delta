using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Game.Model.movement
{
    public class Position {

        public Position() {
        }

        private double xposValue = 0;
        private double yposValue = 0;
        private double zposValue = 0;

        /// <summary>
        /// the current position of the entity on the Z axis (scale)
        /// </summary>
        public double Zpos
        {
            get => zposValue;

            set
            {
                zposValue = value;
            }
        }    //TODO remettre en privé

        /// <summary>
        /// the current position of the entity on the Y axis
        /// </summary>
        public double Ypos
        {
            get => yposValue;
            set
            {
                yposValue = value;
            }
        }    //TODO remettre en privé

        /// <summary>
        /// the current position of the entity on the X axis
        /// </summary>
        public double Xpos {
            get => xposValue;
            set
            {
                xposValue = value;
            }
        }    //TODO remettre en privé

        /// <summary>
        /// The current acceleration of the Entity on the X axis (defines how much the Entity will be moved by the EntityMover next game tick)
        /// </summary>
        public double XVelocity { get; set; }

        /// <summary>
        /// The current acceleration of the Entity on the Y axis (defines how much the Entity will be moved by the EntityMover next game tick)
        /// </summary>
        public double YVelocity { get; set; }

        /// <summary>
        /// The current acceleration of the Entity on the Z axis (defines how much the Entity will be moved by the EntityMover next game tick)
        /// </summary>
        public double ZVelocity { get; set; }

        /// <summary>
        /// Current rotation of the entity (on the XY plane)
        /// </summary>
        public double Rotation { get; set; }

        /// <summary>
        /// The current velocity at which the entity rotate each tick.
        /// </summary>
        public double RotationVelocity { get; set; }

    }
}