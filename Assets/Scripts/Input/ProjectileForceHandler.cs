using UnityEngine;
using UnityEngine.EventSystems;
using NjoyKidzCase.Entities.Projectile;
using NjoyKidzCase.Broadcasting.InputChannels;
using NjoyKidzCase.Broadcasting.ProjectileChannels;

namespace NjoyKidzCase.Input
{
    public class ProjectileForceHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [Header("Listening To")]
        [SerializeField] private ProjectileDetectedChannel projectileDetectedChannel;
        
        [Header("Broadcasting On")]
        [SerializeField] private ProjectilePathChangedChannel projectilePathChangedChannel;
        [SerializeField] private ProjectileLaunchedChannel projectileLaunchedChannel;

        private ILaunchable _launchable;
        private ProjectilePathPackage _pathPackage;

        private Vector2 _dragStartPos;
        private Vector2 _dragVect;

        private void OnEnable()
        {
            _pathPackage = new ProjectilePathPackage();
            _launchable = null;

            projectileDetectedChannel.OnProjectileDetected += OnProjectileDetected;
        }

        private void OnDisable()
        {
            projectileDetectedChannel.OnProjectileDetected -= OnProjectileDetected;
        }

        private void OnProjectileDetected(ILaunchable launchable)
        {
            _launchable = launchable;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _dragStartPos = eventData.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_launchable == null) return;

            _dragVect = _dragStartPos - eventData.position;

            _pathPackage.Set(_launchable, _dragVect);
            projectilePathChangedChannel.OnPathChanged.Invoke(_pathPackage);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (_launchable == null) return;

            _launchable.Launch(_dragVect);
            projectileLaunchedChannel.OnProjectileLaunched.Invoke();

            _launchable = null;
            _dragVect = Vector2.zero;
        }
    }
}