using System;
using UnityEngine;

namespace NjoyKidzCase.Broadcasting.ProjectileChannels
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BroadcastChannels/Projectile/ProjectileSpawnRequestChannel")]
    public class ProjectileSpawnRequestChannel : ScriptableObject
    {
        public Action OnProjectileSpawnRequested;
    }
}