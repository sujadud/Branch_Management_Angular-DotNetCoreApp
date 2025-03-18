using AutoMapper;
using BMCore.Model.Models;
using BMCore.Shared.Mappings;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;

namespace BMCore.Application.ApplicationLogic.EmployeeLogic.Model
{
    public class EmployeeViewModel
    {
        public EmployeeCreateModel EmployeeCreate { get; set; }
        public EmployeeUpdateModel EmployeeUpdate { get; set; }
        public EmployeeGridModel EmployeeGrid { get; set; }
        public dynamic OptionsDataSources { get; set; } = new ExpandoObject();
    }

    public class EmployeeCreateModel : IMapFrom<Employee>
    {
        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Please, provide name.")]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        [Required(ErrorMessage = "Please, provide code.")]
        [StringLength(maximumLength: 10, MinimumLength = 4)]
        public string Code { get; set; }
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

    public class EmployeeUpdateModel : IMapFrom<Employee>
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Please, provide name.")]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        [Required(ErrorMessage = "Please, provide code.")]
        [StringLength(maximumLength: 10, MinimumLength = 4)]
        public string Code { get; set; }
        [Required(ErrorMessage = "Please, provide the branch.")]
        public int BranchId { get; set; }
        [Required(ErrorMessage = "Please, provide the role.")]
        public int RoleId { get; set; }
        public virtual void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeUpdateModel>()
                .ForMember(b => b.BranchId, opt => opt.MapFrom(be => be.BranchEmployees.FirstOrDefault().BranchId))
                .ForMember(r => r.RoleId, opt => opt.MapFrom(be => be.BranchEmployees.FirstOrDefault().RoleId));
        }
    }

    public class EmployeeGridModel : IMapFrom<Employee>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string BranchName { get; set; }
        public string RoleName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeGridModel>()
                .ForMember(b => b.BranchName, opt => opt.MapFrom(be => be.BranchEmployees.FirstOrDefault().Branch.Name))
                .ForMember(r => r.RoleName, opt => opt.MapFrom(be => be.BranchEmployees.FirstOrDefault().Role.Name));
        }
    }
}
