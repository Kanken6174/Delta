
using Game.Model.movement;

namespace Game.Model.Collisions.Hitboxes
{
    public class HitboxSphere
    {

        public int Radius { get; set; }

        public void grow(Position pos)
        {
            int togrow = (int)(1 / pos.Xpos);
            if (togrow == 0)
                togrow = 1;
            Radius = togrow; //
        }
    }
}