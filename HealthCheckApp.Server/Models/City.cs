using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace HealthCheckApp.Server.Models
{
    [Table("Cities")]
    [Index(nameof(Name))]
    [Index(nameof(Lat))]
    [Index(nameof(Lon))]
    public class City
    {
        #region Properties
        // The unique id and primary key for this City
        [Key]
        [Required]
        public int Id { get; set; }
        // City name (in UTF8 format)
        public required string Name { get; set; }
        // City latitude
        [Column(TypeName = "decimal(7,4)")]
        public decimal Lat { get; set; }
        // City longitude
        [Column(TypeName = "decimal(7,4)")]
        public decimal Lon { get; set; }
        // Country Id (foreign key)
        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }
        public Country? Country { get; set; }
        #endregion
    }
}
