using UnityEngine;

namespace NjoyKidzCase.Utilities.Physic
{
    public static class PhysicUtilities
    {
        private static Ray _tempRay;
        private static RaycastHit _tempRaycastHit;

        public static T GetInteractableOnRayPoint<T>(Vector3 position, LayerMask layerMask)
        {
            _tempRay = Camera.main.ScreenPointToRay(position);
            if (Physics.Raycast(_tempRay, out _tempRaycastHit, float.MaxValue, layerMask))
                return _tempRaycastHit.collider.gameObject.GetComponent<T>();
            else return default;
        }

        public static T GetInteractableOnRayPoint<T>(Vector3 position)
        {
            _tempRay = Camera.main.ScreenPointToRay(position);
            if (Physics.Raycast(_tempRay, out _tempRaycastHit, float.MaxValue))
                return _tempRaycastHit.collider.gameObject.GetComponent<T>();
            else return default;
        }

        public static bool TryGetInteractableOnRayPoint<T>(Vector3 position, out T result)
        {
            _tempRay = Camera.main.ScreenPointToRay(position);
            if (Physics.Raycast(_tempRay, out _tempRaycastHit, float.MaxValue))
            {
                result = _tempRaycastHit.collider.gameObject.GetComponent<T>();
                return true;
            }

            result = default;
            return false;
        }
    }
}