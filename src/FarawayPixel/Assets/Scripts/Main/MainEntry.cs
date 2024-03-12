using Faraway.Pixel.Actors;
using Faraway.Pixel.Controllers;
using Faraway.Pixel.Entities;
using Faraway.Pixel.Entities.Buffs;
using Faraway.Pixel.Entities.Interaction;
using Faraway.Pixel.Entities.Locomotion;
using UnityEngine;

namespace Faraway.Pixel.Main
{
    public class MainEntry : MonoBehaviour
    {
        [SerializeField]
        private InteractiveObjectsCollection interactiveObjects;

        [SerializeField]
        private PlayerActor playerActor;
        
        [SerializeField]
        private HUDView hudView;

        [SerializeField]
        private FloatingJoystick joystick;

        [SerializeField]
        private TouchAreaControl touchAreaControl;

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
            var locomotion = new DefaultLocomotionSystem(playerActor, player.LocomotionParameters);
            player.SetLocomotion(locomotion);
            buffCollection = new BuffCollection(new TimeProvider());
            var buffFactory = new BuffFactory(player, playerActor);
            var interactiveObjectFactory = new InteractiveObjectFactory(buffCollection, buffFactory, player);
            _ = new InteractiveObjectsController(interactiveObjects.Objects, interactiveObjectFactory);
            var input = CreateInputProvider();
            playerController = new PlayerController(playerActor, playerActor, input, player);
            _ = new HUDController(hudView, player);
        }

        private IInputProvider CreateInputProvider()
        {
            if (Input.touchSupported)
            {
                return new MobileInputProvider(joystick, touchAreaControl);
            }

            touchAreaControl.gameObject.SetActive(false);
            joystick.gameObject.SetActive(false);
            
            return new DesktopInputProvider();
        }
    }
}