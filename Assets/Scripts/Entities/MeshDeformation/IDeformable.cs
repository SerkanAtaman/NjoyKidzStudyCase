using UnityEngine;

namespace NjoyKidzCase.Entities.MeshDeformation
{
    public interface IDeformable
    {
        void Deform(Collision collision);
    }
}