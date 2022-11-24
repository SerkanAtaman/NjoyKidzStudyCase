using UnityEngine;

namespace NjoyKidzCase.Entities.Projectile
{
    public interface ILaunchable
    {
        public Rigidbody Rigid { get; set; }

        void Launch(Vector2 force);
    }
}