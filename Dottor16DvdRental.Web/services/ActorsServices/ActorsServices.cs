using Dapper;
using Dottor16DvdRental.Web.models;
using Npgsql;

namespace Dottor16DvdRental.Web.services.ActorsServices;

public class ActorsServices : IActorsServices
{
    private readonly string _connectionString;

    public ActorsServices(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("db")!;
    }

    public async Task<IEnumerable<Actor>> GetActorsAsync()
    {
        using NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        string query = """
            SELECT
                actor_id as Id,
                first_name,
                last_name,
                last_update
            FROM public.actor
            ORDER BY actor_id desc;
            """;

        //confronta i campi richiesti della query con le proprietà di Actor e ritorna un Actor con le proprietà delle colonne
        return await connection.QueryAsync<Actor>(query);
    }

    public async Task<Actor> GetActorByIdAsync(int id)
    {
        using NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        string query = """
            SELECT
                actor_id as Id,
                first_name,
                last_name,
                last_update
            FROM public.actor
            WHERE 
                actor_id = @ActorId;
            """;

        return await connection.QueryFirstAsync<Actor>(query, new { ActorId = id});
    }

    public async Task<int> InsertActorAsync(Actor actor)
    {
        using NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        string query = """
            INSERT INTO public.actor
                (first_name, last_name)
            VALUES
                (@FirstName, @LastName);
            """;

        return await connection.ExecuteScalarAsync<int>(query, actor);
    }

    public async Task UpdateActorAsync(Actor actor)
    {
        using NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        string query = """
            UPDATE public.actor
            SET
                first_name = @FirstName,
                last_name = @LastName,
                last_update = NOW()
            WHERE
                actor_id = @ActorId;
            """;

        await connection.ExecuteAsync(query, actor);
    }

    public async Task DeleteActorAsync(int id)
    {
        using NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        string query = """
            DELETE FROM public.actor
            WHERE actor_id = @ActorId
            """;

        await connection.ExecuteAsync(query, new { ActorId = id });
    }
}
