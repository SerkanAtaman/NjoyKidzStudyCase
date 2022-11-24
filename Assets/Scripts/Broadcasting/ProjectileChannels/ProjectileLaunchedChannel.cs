using System;
using UnityEngine;

namespace NjoyKidzCase.Broadcasting.ProjectileChannels
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BroadcastChannels/Projectile/ProjectileLaunchedChannel")]
    public class ProjectileLaunchedChannel : ScriptableObject
    {
        public Action OnProjectileLaunched;
    }
}