using UnityEngine;

namespace Faraway.Pixel.Actors
{
    public class CameraActor : MonoBehaviour
    {
        [SerializeField]
        private Transform targetTransform;
        [SerializeField]
        private float lerp = 0.7f;

        private float initialCameraZPos;

        private void Start()
        {
            initialCameraZPos = transform.position.z;
        }

        private void Update()
        {
            var target = targetTransform.position;
            transform.position = Vector3.Lerp(
                transform.position, 
                new Vector3(target.x, target.y, initialCameraZPos), 
                lerp * Time.deltaTime * 60f);
        }
    }
}
