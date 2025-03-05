using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using ExamCore.Model.Models;
using System.Dynamic;

namespace ExamCore.Application.ApplicationLogic.RoleLogic.Model
{
    public class RoleViewModel
    {
        public RoleCreateModel CreateModel { get; set; }
        public RoleUpdateModel UpdateModel { get; set; }
        public RoleGridModel GridModel { get; set; }
        public dynamic OptionsDataSources { get; set; } = new ExpandoObject();
    }

    public class RoleCreateModel
    {
        [Column(TypeName = "nvarchar(20)")]
        [Required(ErrorMessage = "Please, provide the name.")]
        [StringLength(maximumLength: 20, MinimumLength = 2)]
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Role, RoleCreateModel>();
            profile.CreateMap<RoleCreateModel, Role>();
        }
    }

    public class RoleUpdateModel
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        [Required(ErrorMessage = "Please, provide the name.")]
        [StringLength(maximumLength: 20, MinimumLength = 2)]
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Role, RoleUpdateModel>();
            profile.CreateMap<RoleUpdateModel, Role>();
        }
    }

    public class RoleGridModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Role, RoleGridModel>();
            profile.CreateMap<RoleGridModel, Role>();
        }
    }
}
