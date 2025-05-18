using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HealthCheckApp.Server.Models
{
    [Table("Countries")]
    [Index(nameof(Name))]
    [Index(nameof(ISO2))]
    [Index(nameof(ISO3))]
    public class Country
    {
        #region Properties
        // The unique id and primary key for this Country
        [Key]
        [Required]
        public int Id { get; set; }
        // Country name (in UTF8 format)
        public required string Name { get; set; }
        // Country code (in ISO 3166-1 ALPHA-2 format)
        [JsonPropertyName("iso2")]
        public required string ISO2 { get; set; }
        // Country code (in ISO 3166-1 ALPHA-3 format)
        [JsonPropertyName("iso3")]
        public required string ISO3 { get; set; }
        public ICollection<City>? Cities { get; set; }
        #endregion
    }
}
