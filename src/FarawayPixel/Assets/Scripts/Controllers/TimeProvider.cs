using Faraway.Pixel.Entities;
using UnityEngine;

namespace Faraway.Pixel.Controllers
{
    public class TimeProvider : ITimeProvider
    {
        public float Now => Time.time;
    }
}