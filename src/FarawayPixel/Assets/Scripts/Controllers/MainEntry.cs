using Faraway.Pixel.Actors;
using Faraway.Pixel.Entities;
using Faraway.Pixel.Entities.Buffs;
using Faraway.Pixel.Entities.Interaction;
using Faraway.Pixel.Entities.Locomotion;
using UnityEngine;

namespace Faraway.Pixel.Controllers
{
    public class MainEntry : MonoBehaviour
    {
        [SerializeField]
        private InteractiveObjectsCollection interactiveObjects;

        [SerializeField]
        private PlayerActor playerActor;

        private BuffCollection buffCollection;
        private PlayerController playerController;
        
        private void Awake()
        {
            Initialize();
        }
        
        private void Update()
        {
            buffCollection.Update();
            playerController.Update();
        }

        private void Initialize()
        {
            var player = new Player();
            var locomotion = new DefaultLocomotionSystem(playerActor, player);
            player.SetLocomotion(locomotion);
            buffCollection = new BuffCollection(new TimeProvider());
            var buffFactory = new BuffFactory(player, playerActor);
            var interactiveObjectFactory = new InteractiveObjectFactory(buffCollection, buffFactory);
            _ = new InteractiveObjectsController(interactiveObjects.Objects, interactiveObjectFactory);
            playerController = new PlayerController(playerActor, player, new InputProvider());
        }
    }
}