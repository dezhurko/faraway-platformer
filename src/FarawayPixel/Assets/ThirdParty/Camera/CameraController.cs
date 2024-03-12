using UnityEngine;

namespace ThirdParty.Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private Transform targetTransform;

        [SerializeField]
        private float damping = 1.5f;

        [SerializeField]
        private Vector2 offset = Vector2.zero;

        [SerializeField]
        private bool faceLeft;

        private int lastX;

        private void Update()
        {
            var targetPos = targetTransform.position;
            var currentX = Mathf.RoundToInt(targetPos.x);
            if (currentX > lastX)
            {
                faceLeft = false;
            }
            else if (currentX < lastX)
            {
                faceLeft = true;
            }
            
            lastX = Mathf.RoundToInt(targetTransform.position.x);
            Vector3 target;
          
            if (faceLeft)
            {
                target = new Vector3(targetPos.x - offset.x, targetPos.y + offset.y, transform.position.z);
            }
            else
            {
                target = new Vector3(targetPos.x + offset.x, targetPos.y + offset.y, transform.position.z);
            }

            var currentPosition = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);
            transform.position = currentPosition;
        }
    }
}