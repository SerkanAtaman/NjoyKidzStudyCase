using UnityEngine;
using NjoyKidzCase.Settings.Projectile;

namespace NjoyKidzCase.Entities.Projectile
{
    public class DefaultProjectile : BaseProjectile, ILaunchable
{
        [SerializeField] private ProjectileSettings projectileSettings;

        public Rigidbody Rigid { get; set; }

        protected override void Awake()
        {
            Rigid = GetComponent<Rigidbody>();
        }

        public void Launch(Vector2 force)
        {
            GetComponent<Rigidbody>().velocity = projectileSettings.ProjectileLaunchForce * new Vector3(force.x, force.y, 0);
        }
    }
}