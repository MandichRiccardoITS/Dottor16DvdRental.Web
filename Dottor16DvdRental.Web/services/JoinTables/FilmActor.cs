using Dapper;

namespace Dottor16DvdRental.Web.services.JoinTables;

public class FilmActor
{
    private readonly string _connectionString;

    public FilmActor(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("db");
    }

    public async Task InsertJoinRow(int FilmId, int ActorId)
    {
        using var connection = new Npgsql.NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        string query = """
                INSERT INTO film_actor
                    (film_id, Actor_id)
                VALUES
                    (@FilmId, @ActorId);
                """;

        await connection.ExecuteAsync(query, new { FilmId, ActorId });
    }

    public async Task DeleteJoinRow(int FilmId, int ActorId)
    {
        using var connection = new Npgsql.NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        string query = """
                DELETE FROM film_actor
                WHERE
                    film_id = @FilmId AND 
                    Actor_id = @ActorId;
                """;

        await connection.ExecuteAsync(query, new { FilmId, ActorId });
    }
}
