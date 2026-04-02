using Dapper;
using System.Runtime.CompilerServices;

namespace Dottor16DvdRental.Web.services.JoinTables
{
    public class FilmCategory
    {

        private readonly string _connectionString;

        public FilmCategory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("db");
        }

        public async Task InsertJoinRow(int FilmId, int CategoryId)
        {
            using var connection = new Npgsql.NpgsqlConnection(_connectionString);
            await connection.OpenAsync();

            string query = """
                INSERT INTO film_category
                    (film_id, category_id)
                VALUES
                    (@FilmId, @CategoryId);
                """;

            await connection.ExecuteAsync(query, new { FilmId, CategoryId});
        }

        public async Task DeleteJoinRow(int FilmId, int CategoryId)
        {
            using var connection = new Npgsql.NpgsqlConnection(_connectionString);
            await connection.OpenAsync();

            string query = """
                DELETE FROM film_category
                WHERE
                    film_id = @FilmId AND 
                    category_id = @CategoryId;
                """;

            await connection.ExecuteAsync(query, new { FilmId, CategoryId });
        }
    }
}


