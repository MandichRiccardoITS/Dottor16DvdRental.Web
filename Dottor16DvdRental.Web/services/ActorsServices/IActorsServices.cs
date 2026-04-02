using Dottor16DvdRental.Web.models;

namespace Dottor16DvdRental.Web.services.ActorsServices;

public interface IActorsServices
{
    Task<IEnumerable<Actor>> GetActorsAsync();
    Task<Actor> GetActorByIdAsync(int id);
    Task<int> InsertActorAsync(Actor actor);
    Task UpdateActorAsync(Actor actor);
    Task DeleteActorAsync(int id);
}
