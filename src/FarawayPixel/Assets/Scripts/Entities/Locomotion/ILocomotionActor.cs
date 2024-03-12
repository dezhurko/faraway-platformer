using UnityEngine;

namespace Faraway.Pixel.Entities.Locomotion
{
    /// <summary>
    /// Represents an actor that can move.
    /// </summary>
    public interface ILocomotionActor
    {
        /// <summary>
        /// Actor's velocity.
        /// </summary>
        Vector3 Velocity { get; set; }
        
        /// <summary>
        /// Checks if the actor is grounded.
        /// </summary>
        bool IsGrounded();
    }
}