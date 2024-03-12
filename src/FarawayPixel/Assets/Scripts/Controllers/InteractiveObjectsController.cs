using Faraway.Pixel.Actor.Contracts;
using Faraway.Pixel.Entities.Interaction;

namespace Faraway.Pixel.Controllers
{
    /// <summary>
    /// The InteractiveObjectsController is responsible for managing the interactions of interactive objects in the game.
    /// </summary>
    public class InteractiveObjectsController
    {
        private readonly InteractiveObjectFactory interactiveObjectFactory;
        
        /// <summary>
        /// Constructor for the InteractiveObjectsController.
        /// </summary>
        /// <param name="interactiveObjects">A collection of interactive objects</param>
        /// <param name="interactiveObjectFactory">Interactive objects factory.</param>
        public InteractiveObjectsController(
            IInteractiveObjectsCollection interactiveObjects, 
            InteractiveObjectFactory interactiveObjectFactory)
        {
            this.interactiveObjectFactory = interactiveObjectFactory;
            
            foreach (var actor in interactiveObjects.Objects)
            {
                actor.Interact += InteractiveObjectOnInteract;
            }
        }
        
        private void InteractiveObjectOnInteract(InteractiveObjectData data)
        {
            var interactiveObject = interactiveObjectFactory.CreateInteractiveObject(data);
            interactiveObject.Interact();
        }
    }
}