using System;
using Faraway.Pixel.Actors;
using Faraway.Pixel.Entities;
using Faraway.Pixel.Entities.Locomotion;
using UnityEngine;

namespace Faraway.Pixel.Controllers
{
    public class PlayerController
    {
        private readonly PlayerActor playerActor;
        private readonly Player player;
        private readonly IInputProvider inputProvider;

        private AnimationState previousAnimationState;

        public PlayerController(PlayerActor playerActor, Player player, IInputProvider inputProvider)
        {
            this.playerActor = playerActor;
            this.player = player;
            this.inputProvider = inputProvider;
        }

        public void Update()
        {
            var input = inputProvider.GetInput();
            player.Locomotion.Update(input);
            var isFlying = player.Locomotion is FlyingLocomotionSystem;
            UpdateFlipState(isFlying);
            UpdateAnimation(isFlying);
        }

        private void UpdateFlipState(bool isFlying)
        {
            if (Mathf.Abs(playerActor.Velocity.x) > Mathf.Epsilon)
            {
                playerActor.FlipHorizontal(isFlying ? playerActor.Velocity.x > 0 : playerActor.Velocity.x < 0);
            }
        }

        private void UpdateAnimation(bool isFlying)
        {
            var currentAnimationState = isFlying
                ? AnimationState.Fly
                : Mathf.Abs(playerActor.Velocity.x) > Mathf.Epsilon ? AnimationState.Run : AnimationState.Idle;

            if (previousAnimationState == currentAnimationState)
            {
                return;
            }
            
            switch (currentAnimationState)
            {
                case AnimationState.Idle:
                    playerActor.PlayIdleAnimation();
                    break;
                case AnimationState.Run:
                    playerActor.PlayRunAnimation();
                    break;
                case AnimationState.Fly:
                    playerActor.PlayFlyAnimation();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            previousAnimationState = currentAnimationState;
        }

        private enum AnimationState
        {
            Idle,
            Run,
            Fly,
        }
    }
}