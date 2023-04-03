using Microsoft.AspNetCore.Mvc;

namespace Asteroids.Repositories.Interface
{
    public interface IAsteroidsRepository
    {
        ActionResult getAsteroids(DateTime startDate, DateTime endDate);
    }
}
