using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace game.model.movement
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
        public double zpos {get; private set;}

        /// <summary>
        /// the current position of the entity on the Y axis
        /// </summary>
        public double ypos
        {
            get => yposValue;
            set
            {
                yposValue = value;
                posChanged();
            }
        }    //TODO remettre en privé

        /// <summary>
        /// the current position of the entity on the X axis
        /// </summary>
        public double xpos {
            get => xposValue;
            set
            {
                xposValue = value;
                posChanged();
            }
        }    //TODO remettre en privé

        /// <summary>
        /// The current acceleration of the Entity on the X axis (defines how much the Entity will be moved by the EntityMover next game tick)
        /// </summary>
        public double xVelocity { get; set; }

        /// <summary>
        /// The current acceleration of the Entity on the Y axis (defines how much the Entity will be moved by the EntityMover next game tick)
        /// </summary>
        private double yVelocity { get; set; }

    /// <summary>
    /// The current acceleration of the Entity on the Z axis (defines how much the Entity will be moved by the EntityMover next game tick)
    /// </summary>
    private double zVelocity { get; set; }

    /// <summary>
    /// Current rotation of the entity (on the XY plane)
    /// </summary>
    public double rotation { get; private set; }

        /// <summary>
        /// The current velocity at which the entity rotate each tick.
        /// </summary>
        private double rotationVelocity = 0;


        public void posChanged([CallerMemberName] String propertyName = "")
        {
        }
    }
}