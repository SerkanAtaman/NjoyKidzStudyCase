using UnityEngine;

namespace NjoyKidzCase.Entities.MeshDeformation
{
    [RequireComponent(typeof(Collider))]
    public class DeformerDetector : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.impulse.sqrMagnitude < 20) return;

            if(collision.transform.TryGetComponent(out IDeformable deformable))
            {
                Vector3 impactPoint = collision.contacts[0].point;

                deformable.Deform(collision);
            }
        }
    }
}