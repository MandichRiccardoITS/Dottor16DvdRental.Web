using NpgsqlTypes;

namespace Dottor16DvdRental.Web.models;

public class Film
{
    public int FilmId { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public int? ReleaseYear { get; set; }
    public short LanguageId { get; set; }
    public short RentalDuration { get; set; } = 3;
    public decimal RentalRate { get; set; } = 4.99M; //M sta per indicare decimal
    public short? Length { get; set; }
    public decimal ReplacementCost { get; set; } = 19.99M;
    public string? Rating { get; set; } = "G";
    public DateTime LastUpdate { get; set; } //NOW() da impostare nel database
    public string[]? SpecialFeatures { get; set; }
    public NpgsqlTsVector Fulltext { get; set; }
}
