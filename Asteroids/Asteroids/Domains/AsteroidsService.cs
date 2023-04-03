using Asteroids.Domains.Interface;
using Asteroids.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Asteroids.Domains
{
    public class AsteroidsService : IAsteroidsService
    {
        IAsteroidsRepository _repository;

        public AsteroidsService(IAsteroidsRepository repository)
        {
            this._repository = repository;
        }
        public ActionResult ReturnAsteroids(int number)
        {
            var startDate = DateTime.Now;
            var endDate = startDate.AddDays(number);

            return _repository.getAsteroids(startDate, endDate);
        }
    }
}
