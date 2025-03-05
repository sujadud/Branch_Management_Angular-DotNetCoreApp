using ExamCore.Shared.Mappings;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamCore.Model.Models
{
    public class Role : IAuditableEntity, IDelatableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        [Required(ErrorMessage = "Please, provide the name.")]
        [StringLength(maximumLength: 20, MinimumLength = 2)]
        public string Name { get; set; }
        public virtual ICollection<BranchEmployee> BranchEmployees { get; set; }

        public string CreatedById { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string? UpdatedById { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTime { get; set; }
    }
}
