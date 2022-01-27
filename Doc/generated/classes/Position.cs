
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Position {

    public Position() {
    }

    /// <summary>
    /// the current position of the entity on the Z axis (scale)
    /// </summary>
    private double zpos = 0;

    /// <summary>
    /// the current position of the entity on the Y axis
    /// </summary>
    private double ypos = 0;

    /// <summary>
    /// the current position of the entity on the X axis
    /// </summary>
    private double xpos = 0;

    /// <summary>
    /// The current acceleration of the Entity on the X axis (defines how much the Entity will be moved by the Deplaceur next game tick)
    /// </summary>
    private double xVelocity = 0;

    /// <summary>
    /// The current acceleration of the Entity on the Y axis (defines how much the Entity will be moved by the Deplaceur next game tick)
    /// </summary>
    private double yVelocity = 0;

    /// <summary>
    /// The current acceleration of the Entity on the Z axis (defines how much the Entity will be moved by the Deplaceur next game tick)
    /// </summary>
    private double zVelocity = 0;

    /// <summary>
    /// Current rotation of the entity (on the XY plane)
    /// </summary>
    private double rotation = 0;

    /// <summary>
    /// The current velocity at which the entity rotate each tick.
    /// </summary>
    private double rotationVelocity = 0;

    public void Operation1() {
        // TODO implement here
    }

}