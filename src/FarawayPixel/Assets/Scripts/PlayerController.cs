using UnityEngine;

namespace Faraway.Pixel
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Animator))]
    public class PlayerController : MonoBehaviour
    {
        private const float GroundCheckRadius = 0.1f;
        
        [SerializeField]
        private float speed = 5f; 
        [SerializeField]
        private float jumpForce = 10f;
        [SerializeField]
        private Transform groundCheck; 
        [SerializeField]
        private LayerMask groundLayer;

        private Rigidbody2D playerRigidbody;
        private SpriteRenderer playerSpriteRenderer;
        private bool isGrounded;
        private float moveDirection;

        private readonly int runTrigger = Animator.StringToHash("Run");
        private readonly int idleTrigger = Animator.StringToHash("Idle");
        
        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody2D>();
            playerSpriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, GroundCheckRadius, groundLayer);
            playerSpriteRenderer.flipX = moveDirection < 0;

            if (!isGrounded)
            {
                return;
            }
            
            var moveInput = Input.GetAxis("Horizontal");
            if (Mathf.Abs(moveInput) > Mathf.Epsilon)
            {
                moveDirection = Mathf.Sign(moveInput);
            }

            playerRigidbody.velocity = new Vector2(moveDirection * speed, playerRigidbody.velocity.y);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpForce);
            }
        }
    }
}