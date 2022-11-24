using System;
using UnityEngine;

namespace NjoyKidzCase.Entities.MeshDeformation
{
    public static class MeshDeformer
    {
        static Vector3[] _displacedVertices;

        static int _step;

        const float FORCE_MULTIPLIER = 0.001f;
        const float MAX_IMPULSE = 1000f;

        static Vector3 _pointToVertex, _vertexWorldPos, _impactPoint;
        static float _attenuatedForce, _impulse;

        public static void DeformMesh(Transform meshTransform, Mesh meshToDeform, Collision collision, Action onDeformCompleted = null)
        {
            _displacedVertices = meshToDeform.vertices;
            _step = _displacedVertices.Length;
            _impactPoint = collision.contacts[0].point + collision.contacts[0].normal * 0.3f;
            _impulse = collision.impulse.sqrMagnitude;
            _impulse = Mathf.Clamp(_impulse, 0f, MAX_IMPULSE);

            for (int i = 0; i < _step; i++)
            {
                AddForceToVertex(i, meshTransform, _impactPoint, _impulse * FORCE_MULTIPLIER);
            }

            UpdateMesh(meshToDeform);

            onDeformCompleted?.Invoke();
        }

        private static void AddForceToVertex(int i, Transform meshTranform, Vector3 point, float force)
        {
            _vertexWorldPos = meshTranform.position + _displacedVertices[i];
            _pointToVertex = _vertexWorldPos - point;
            _attenuatedForce = force / (1f + _pointToVertex.sqrMagnitude);
            _displacedVertices[i] += _pointToVertex.normalized * _attenuatedForce;
        }

        private static void UpdateMesh(Mesh meshToUpdate)
        {
            meshToUpdate.vertices = _displacedVertices;
            meshToUpdate.RecalculateNormals();
        }
    }
}