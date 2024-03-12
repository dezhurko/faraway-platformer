using System;
using Faraway.Pixel.Actor.Contracts;
using Faraway.Pixel.Entities;
using Faraway.Pixel.Entities.Locomotion;
using UnityEngine;

namespace Faraway.Pixel.Controllers
{
    /// <summary>
    /// Represents the controller for the player character.
    /// </summary>
    public class PlayerController
    {
        private readonly IPlayerAnimator playerAnimator;
        private readonly ILocomotionActor playerLocomotionActor;
        private readonly Player player;
        private readonly IInputProvider inputProvider;

        private LocomotionActorState previousLocomotionActorState;

        /// <summary>
        /// Constructor for the PlayerController.
        /// </summary>
        /// <param name="playerAnimator">Player animator implementation.</param>
        /// <param name="playerLocomotionActor">Player locomotion implementation.</param>
        /// <param name="inputProvider">User input provide.</param>
        /// <param name="player">Player entity instance.</param>
        public PlayerController(
            IPlayerAnimator playerAnimator, 
            ILocomotionActor playerLocomotionActor, 
            IInputProvider inputProvider, 
            Player player)
        {
            this.playerAnimator = playerAnimator;
            this.playerLocomotionActor = playerLocomotionActor;
            this.player = player;
            this.inputProvider = inputProvider;
        }

        /// <summary>
        /// Update the controller. Must be executed in the game loop.
        /// </summary>
        public void Update()
        {
            var input = inputProvider.GetInput();
            player.Locomotion.Update(input);
            UpdateFlipState();
            UpdateAnimation();
        }

        private void UpdateFlipState()
        {
            if (Mathf.Abs(playerLocomotionActor.Velocity.x) > Mathf.Epsilon)
            {
                playerAnimator.FlipHorizontal(playerLocomotionActor.Velocity.x < 0);
            }
        }

        private void UpdateAnimation()
        {
            var currentLocomotionActorState = player.Locomotion.ActorState;
            if (previousLocomotionActorState == currentLocomotionActorState)
            {
                return;
            }
            
            switch (currentLocomotionActorState)
            {
                case LocomotionActorState.Idle:
                    playerAnimator.PlayIdleAnimation();
                    break;
                case LocomotionActorState.Run:
                    playerAnimator.PlayRunAnimation();
                    break;
                case LocomotionActorState.Fly:
                    playerAnimator.PlayFlyAnimation();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            previousLocomotionActorState = currentLocomotionActorState;
        }
    }
}