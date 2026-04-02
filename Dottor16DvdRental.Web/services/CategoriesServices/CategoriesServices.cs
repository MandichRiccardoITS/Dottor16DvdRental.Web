using Dapper;
using Dottor16DvdRental.Web.models;

namespace Dottor16DvdRental.Web.services.CategoriesServices;

public class CategoriesServices : ICategoriesServices
{
    private readonly string _connectionString;

    public CategoriesServices(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("db");
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        var connection = new Npgsql.NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        string query = """
            SELECT
                category_id,
                name,
                last_update
            FROM public.category;
            """;

        return await connection.QueryAsync<Category>(query);
    }

    public async Task<Category> GetCategoryByIdAsync(int id)
    {
        var connection = new Npgsql.NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        string query = $"""
            SELECT
                category_id,
                name,
                last_update
            FROM public.category
            WHERE
                category_id = @CategoryId;
            """;

        return await connection.QueryFirstAsync<Category>(query, new { CategoryId = id });
    }

    public async Task<int> InsertCategoryAsync(Category category)
    {
        var connection = new Npgsql.NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        string query = """
            INSERT INTO public.category
                (name)
            VALUES
                (@Name);
            """;

        return await connection.ExecuteScalarAsync<int>(query, category);
    }

    public async Task UpdateCategoryAsync(Category category)
    {
        var connection = new Npgsql.NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        string query = """
            UPDATE public.category
            SET
                name = @Name,
                last_update = NOW();
            """;

        await connection.ExecuteAsync(query, category);
    }

    public async Task DeleteCategoryAsync(int id)
    {
        var connection = new Npgsql.NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        string query = """
            DELETE FROM public.category
            WHERE
                category_id = @CategoryId
            """;

        await connection.ExecuteAsync(query, new { CategoryId = id});
    }
}
