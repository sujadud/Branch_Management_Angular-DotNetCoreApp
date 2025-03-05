using ExamCore.Shared.Mappings;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamCore.Model.Models
{
    public class Branch : IAuditableEntity, IDelatableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Please, provide the name.")]
        [StringLength(maximumLength: 30, MinimumLength = 2)]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Phone { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please, provide the city.")]
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public virtual City City { get; set; }
        public ICollection<BranchEmployee> BranchEmployees { get; set; }


        public string CreatedById { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string? UpdatedById { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTime { get; set; }
    }
}
