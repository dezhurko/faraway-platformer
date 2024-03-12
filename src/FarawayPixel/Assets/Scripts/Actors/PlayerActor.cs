using Faraway.Pixel.Actor.Contracts;
using Faraway.Pixel.Entities.Locomotion;
using UnityEngine;

namespace Faraway.Pixel.Actors
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Animator))]
    public class PlayerActor : MonoBehaviour, ILocomotionActor, IPlayerAnimator
    {
        private const float GroundCheckRadius = 0.1f;
        
        [SerializeField]
        private Transform groundCheck; 
        [SerializeField]
        private LayerMask groundLayer;

        private Animator playerAnimator;
        private Rigidbody2D playerRigidbody;
        private SpriteRenderer playerSpriteRenderer;

        private readonly int runTrigger = Animator.StringToHash("Run");
        private readonly int idleTrigger = Animator.StringToHash("Idle");
        private readonly int flyTrigger = Animator.StringToHash("Fly");

        public Vector3 Velocity 
        {
            get => playerRigidbody.velocity;
            set => playerRigidbody.velocity = value;
        }
        
        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody2D>();
            playerSpriteRenderer = GetComponent<SpriteRenderer>();
            playerAnimator = GetComponent<Animator>();
        }

        public bool IsGrounded() =>
            Physics2D.OverlapCircle(groundCheck.position, GroundCheckRadius, groundLayer);

        public void PlayRunAnimation() => playerAnimator.SetTrigger(runTrigger);
        
        public void PlayIdleAnimation() => playerAnimator.SetTrigger(idleTrigger);
        
        public void PlayFlyAnimation() => playerAnimator.SetTrigger(flyTrigger);
        
        public void FlipHorizontal(bool flip) => playerSpriteRenderer.flipX = flip;
    }
}