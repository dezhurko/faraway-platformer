using System.Collections.Generic;
using Faraway.Pixel.Actor.Contracts;
using Faraway.Pixel.Entities.Interaction;

namespace Faraway.Pixel.Controllers
{
    public class InteractiveObjectsController
    {
        private readonly InteractiveObjectFactory interactiveObjectFactory;
        
        public InteractiveObjectsController(
            IEnumerable<IInteractiveObject> interactiveObjects, 
            InteractiveObjectFactory interactiveObjectFactory)
        {
            this.interactiveObjectFactory = interactiveObjectFactory;
            
            foreach (var actor in interactiveObjects)
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