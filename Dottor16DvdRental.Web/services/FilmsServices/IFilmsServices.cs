using Dottor16DvdRental.Web.models;

namespace Dottor16DvdRental.Web.services.FilmsServices;

public interface IFilmsServices
{
    Task<IEnumerable<Film>> GetFilmsAsync();
    Task<Film> GetFilmByIdAsync(int id);
    Task<int> InsertFilmAsync(Film film);
    Task UpdateFilmAsync(Film film);
    Task DeleteFilmAsync(int id);
}
