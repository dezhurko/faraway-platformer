using Faraway.Pixel.Entities;
using UnityEngine;

namespace Faraway.Pixel.Main
{
    public class TimeProvider : ITimeProvider
    {
        public float Now => Time.time;
    }
}