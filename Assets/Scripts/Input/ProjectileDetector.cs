using UnityEngine;
using UnityEngine.EventSystems;
using NjoyKidzCase.Entities.Projectile;
using NjoyKidzCase.Utilities.Physic;
using NjoyKidzCase.Broadcasting.InputChannels;

namespace NjoyKidzCase.Input
{
    public class ProjectileDetector : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private ProjectileDetectedChannel projectileDetectedChannel;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (PhysicUtilities.TryGetInteractableOnRayPoint(eventData.position, out ILaunchable result))
            {
                projectileDetectedChannel.OnProjectileDetected.Invoke(result);
            }
        }
    }
}