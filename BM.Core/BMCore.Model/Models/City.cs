using BMCore.Shared.Mappings;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMCore.Model.Models
{
    public class City : IAuditableEntity, IDelatableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Please, provide the name.")]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please, provide the country.")]
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }

        public string CreatedById { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string? UpdatedById { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTime { get; set; }
    }
}
