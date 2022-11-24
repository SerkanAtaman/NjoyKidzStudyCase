using System;
using UnityEngine;
using NjoyKidzCase.Entities.Projectile;

namespace NjoyKidzCase.Broadcasting.ProjectileChannels
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BroadcastChannels/Projectile/ProjectilePathChangedChannel")]
    public class ProjectilePathChangedChannel : ScriptableObject
    {
        public Action<ProjectilePathPackage> OnPathChanged;
    }
}