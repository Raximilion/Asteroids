using Microsoft.AspNetCore.Mvc;

namespace Asteroids.Domains.Interface
{
    public interface IAsteroidsService
    {
        ActionResult ReturnAsteroids(int number);
    }
}
