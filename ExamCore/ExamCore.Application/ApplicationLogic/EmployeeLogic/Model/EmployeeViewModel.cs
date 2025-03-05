
using AutoMapper;
using ExamCore.Model.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;

namespace ExamCore.Application.ApplicationLogic.EmployeeLogic.Model
{
    public class EmployeeViewModel
    {
        public EmployeeCreateModel EmployeeCreate { get; set; }
        public EmployeeUpdateModel EmployeeUpdate { get; set; }
        public EmployeeGridModel EmployeeGrid { get; set; }
        public dynamic OptionsDataSources { get; set; } = new ExpandoObject();
    }

    public class EmployeeCreateModel
    {
        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Please, provide name.")]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please, provide the branch.")]
        public int BranchId { get; set; }
        [Required(ErrorMessage = "Please, provide the role.")]
        public int RoleId { get; set; }

        public virtual void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeCreateModel>();
            profile.CreateMap<EmployeeCreateModel, Employee>();
        }
    }

    public class EmployeeUpdateModel
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Please, provide name.")]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please, provide the branch.")]
        public int BranchId { get; set; }
        [Required(ErrorMessage = "Please, provide the role.")]
        public int RoleId { get; set; }
        public virtual void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeUpdateModel>();
            profile.CreateMap<EmployeeUpdateModel, Employee>();
        }
    }

    public class EmployeeGridModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BranchName { get; set; }
        public string RoleName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeGridModel>();
            profile.CreateMap<EmployeeGridModel, Employee>();
        }
    }
}
