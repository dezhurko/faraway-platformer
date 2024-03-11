using Faraway.Pixel.Entities.Locomotion;

namespace Faraway.Pixel.Controllers
{
    public interface IInputProvider
    {
        UserInput GetInput();
    }
}