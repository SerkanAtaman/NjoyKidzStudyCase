using UnityEngine;

namespace NjoyKidzCase.Entities.MeshDeformation
{
    [RequireComponent(typeof(MeshFilter))]
    public class SimpleDeformableObject : MonoBehaviour, IDeformable
    {
        private Mesh _mesh;
        private MeshCollider _meshCollider;

        private void Awake()
        {
            _meshCollider = GetComponent<MeshCollider>();
            _mesh = GetComponent<MeshFilter>().mesh;
        }

        public void Deform(Collision collision)
        {
            MeshDeformer.DeformMesh(transform, _mesh, collision, OnDeformationEnded);
        }

        private void OnDeformationEnded()
        {
            _meshCollider.sharedMesh = _mesh;
        }
    }
}