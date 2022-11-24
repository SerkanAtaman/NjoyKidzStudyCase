using UnityEngine;
using NjoyKidzCase.Broadcasting.ProjectileChannels;

namespace NjoyKidzCase.UI.Projectile
{
    public class ProjectileSpawnerButton : MonoBehaviour
    {
        [Header("Broadcasting On")]
        [SerializeField] private ProjectileSpawnRequestChannel projectileSpawnRequestChannel;

        public void SpawnBallButton()
        {
            projectileSpawnRequestChannel.OnProjectileSpawnRequested?.Invoke();
        }
    }
}