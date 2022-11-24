using System;
using UnityEngine;
using NjoyKidzCase.Entities.Projectile;

namespace NjoyKidzCase.Broadcasting.InputChannels
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BroadcastChannels/Input/ProjectileDetectedChannel")]
    public class ProjectileDetectedChannel : ScriptableObject
    {
        public  Action<ILaunchable> OnProjectileDetected;
    }
}