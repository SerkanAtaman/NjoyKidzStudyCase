using UnityEngine;
using NjoyKidzCase.Broadcasting.ProjectileChannels;
using NjoyKidzCase.Settings.Projectile;

namespace NjoyKidzCase.Entities.Projectile
{
    [RequireComponent(typeof(LineRenderer))]
    public class ProjectilePathDrawer : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private int _lineSegmentCount = 20;
        [SerializeField] private float _pathSimulationTime = 2f;

        [SerializeField] private ProjectileSettings projectileSettings;

        [Header("Listening To")]
        [SerializeField] private ProjectilePathChangedChannel projectilePathChangedChannel;
        [SerializeField] private ProjectileLaunchedChannel projectileLaunchedChannel;

        private LineRenderer _lineRenderer;

        private Vector3[] _linePositions;

        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();

            _lineRenderer.positionCount = 0;
            _lineRenderer.enabled = false;
            _linePositions = new Vector3[_lineSegmentCount];
        }

        private void OnEnable()
        {
            projectilePathChangedChannel.OnPathChanged += DrawProjectilePath;
            projectileLaunchedChannel.OnProjectileLaunched += DisablePath;
        }

        private void OnDisable()
        {
            projectilePathChangedChannel.OnPathChanged -= DrawProjectilePath;
            projectileLaunchedChannel.OnProjectileLaunched -= DisablePath;
        }

        private void DrawProjectilePath(ProjectilePathPackage package)
        {
            if(!_lineRenderer.enabled) _lineRenderer.enabled = true;

            Vector3 startPosition = package.Projectile.Rigid.position;
            Vector3 initialVelocity = package.Force * projectileSettings.ProjectileLaunchForce;
            Vector3 velocityXZ = new Vector3(initialVelocity.x, 0, initialVelocity.z);
            
            _lineRenderer.positionCount = 0;

            for(int i = 0; i < _lineSegmentCount; i++)
            {
                float time = (i / (float)_lineSegmentCount) * _pathSimulationTime;

                Vector3 movement = velocityXZ * time;
                float h = initialVelocity.y * time + ((Physics.gravity.y * Mathf.Pow(time, 2)) / 2f);
                movement.y = h;
                _linePositions[i] = startPosition + movement;
            }

            _lineRenderer.positionCount = _lineSegmentCount;
            _lineRenderer.SetPositions(_linePositions);
        }

        private void DisablePath()
        {
            _lineRenderer.positionCount = 0;
            _lineRenderer.enabled = false;
        }
    }
}