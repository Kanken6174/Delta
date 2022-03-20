
using Game.Model.movement;

namespace Game.Model.Collisions.Hitboxes
{
    /// <summary>
    /// This type of hitbox represnts a sphere on the 3d plane, with a changing radius
    /// </summary>
    public class HitboxSphere
    {

        public double Radius { get; set; }

        /// <summary>
        /// this method is used to calculate what radius the hitbox should have relative to the position of the entity and the original radius
        /// (to make sense in a fake 3d plane)
        /// </summary>
        /// <param name="pos"></param>
        public void Grow(Position pos)
        {
            int togrow = (int)(1 / pos.Xpos);
            if (togrow == 0)
                togrow = 1;
            Radius = togrow; //
        }
    }
}