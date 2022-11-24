using UnityEngine;
using NjoyKidzCase.Broadcasting.ProjectileChannels;

namespace NjoyKidzCase.Entities.Projectile
{
    public class ProjectileSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject ballPref;
        [SerializeField] private Vector3[] spawnBounds;

        [Header("Listening To")]
        [SerializeField] private ProjectileSpawnRequestChannel projectileSpawnRequestChannel;

        private void OnEnable()
        {
            projectileSpawnRequestChannel.OnProjectileSpawnRequested += SpawnProjectile;
        }

        private void OnDisable()
        {
            projectileSpawnRequestChannel.OnProjectileSpawnRequested -= SpawnProjectile;
        }

        private void SpawnProjectile()
        {
            float randX = Random.Range(spawnBounds[0].x, spawnBounds[1].x);
            float randY = Random.Range(spawnBounds[0].y, spawnBounds[1].y);
            float randZ = Random.Range(spawnBounds[0].z, spawnBounds[1].z);

            Instantiate(ballPref, new Vector3(randX, randY, randZ), Quaternion.identity);
        }
    }
}