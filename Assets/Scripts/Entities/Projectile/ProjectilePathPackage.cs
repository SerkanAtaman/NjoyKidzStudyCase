using UnityEngine;

namespace NjoyKidzCase.Entities.Projectile
{
    public class ProjectilePathPackage
    {
        public ILaunchable Projectile { get; private set; }
        public Vector3 Force { get; private set; }

        public void Set(ILaunchable projectile, Vector2 force)
        {
            Projectile = projectile;
            Force = new Vector3(force.x, force.y, 0);
        }
    }
}