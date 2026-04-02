using Dapper;
using Dottor16DvdRental.Web.models;
using Npgsql;

namespace Dottor16DvdRental.Web.services.FilmsServices;

public class FilmsServices : IFilmsServices
{
    private readonly string _connectionString;

    public FilmsServices(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("db");
    }

    public async Task<IEnumerable<Film>> GetFilmsAsync()
    {
        using NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        string query = """
        SELECT
            film_id,
            title,
            description,
            release_year,
            language_id,
            rental_duration,
            rental_rate,
            length,
            replacement_cost,
            rating,
            last_update,
            special_features,
            fulltext
        FROM public.film;
        """;

        return await connection.QueryAsync<Film>(query);
    }

    public async Task<Film> GetFilmByIdAsync(int id)
    {
        using NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        string query = """
        SELECT
            film_id,
            title,
            description,
            release_year,
            language_id,
            rental_duration,
            rental_rate,
            length,
            replacement_cost,
            rating,
            last_update,
            special_features,
            fulltext
        FROM public.film;
        WHERE
            film_id = @FilmId
        """;

        return await connection.QueryFirstAsync<Film>(query, new { FilmId = id});
    }

    public async Task<int> InsertFilmAsync(Film film)
    {
        using NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        string query = """
        INSERT INTO public.film (
            title,
            description,
            release_year,
            language_id,
            rental_duration,
            rental_rate,
            length,
            replacement_cost,
            rating,
            last_update,
            special_features,
            fulltext
        )
        VALUES (
            @Title,
            @Description,
            @ReleaseYear,
            @LanguageId,
            @RentalDuration,
            @RentalRate,
            @Length,
            @ReplacementCost,
            @Rating,
            @LastUpdate,
            @SpecialFeatures,
            @Fulltext 
        );
        """;

        return await connection.ExecuteScalarAsync<int>(query, film);
    }

    public async Task UpdateFilmAsync(Film film)
    {
        using NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        string query = """
        UPDATE public.film SET
            title = @Title,
            description = @Description,
            release_year = @ReleaseYear,
            language_id = @LanguageId,
            rental_duration = @RentalDuration,
            rental_rate = @RentalRate,
            length = @Length,
            replacement_cost = @ReplacementCost,
            rating = @Rating,
            last_update = @LastUpdate,
            special_features = @SpecialFeatures,
            fulltext = @Fulltext
        WHERE
            film_id = @FilmId;
        """;

        await connection.ExecuteAsync(query, film);
    }

    public async Task DeleteFilmAsync(int id)
    {
        using NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        string query = """
        DELETE FROM public.film
        WHERE
            film_id = @FilmId;
        """;

        await connection.ExecuteAsync(query, new { FilmId = id });
    }
}
