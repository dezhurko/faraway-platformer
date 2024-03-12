using Faraway.Pixel.Entities;
using UnityEngine;

namespace Faraway.Pixel.Main
{
    /// <summary>
    /// Represents a time provider.
    /// </summary>
    public class TimeProvider : ITimeProvider
    {
        /// <inheritdoc/>
        public float Now => Time.time;
    }
}