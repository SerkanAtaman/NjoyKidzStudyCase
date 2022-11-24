using UnityEngine;

namespace NjoyKidzCase.Settings.Projectile
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Settings/Projectile")]
    public class ProjectileSettings : ScriptableObject
    {
        [field:SerializeField] public float ProjectileLaunchForce { get; private set; }
    }
}