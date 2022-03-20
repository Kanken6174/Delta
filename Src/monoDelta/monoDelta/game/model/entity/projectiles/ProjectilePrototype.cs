namespace Game.Model.Entity.Projectiles
{ 
    /// <summary>
    /// This interface describes what a projectile should be like, specifically the fact that it can be cloned.
    /// </summary>
    public interface IProjectilePrototype
    {
        Projectile Clone();

    }
}