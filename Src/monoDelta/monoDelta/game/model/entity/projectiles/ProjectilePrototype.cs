namespace Game.Model.Entity.Projectiles
{
    public interface IProjectilePrototype
    {

        /// <summary>
        /// @return
        /// </summary>
        Projectile Clone();

    }
}