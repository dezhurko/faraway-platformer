using UnityEngine;

namespace Faraway.Pixel.Entities.Locomotion
{
    public interface ILocomotionActor
    {
        Vector3 Velocity { get; set; }
        bool IsGrounded();
    }
}