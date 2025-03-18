using AutoMapper;
using BMCore.Model.Models;
using BMCore.Shared.Mappings;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;

namespace BMCore.Application.ApplicationLogic.BranchLogic.Model
{
    public class BranchViewModel
    {
        public BranchCreateModel CreateModel { get; set; }
        public BranchUpdateModel UpdateModel { get; set; }
        public BranchGridModel GridModel { get; set; }
        public dynamic OptionsDataSources { get; set; } = new ExpandoObject();
    }

    public class BranchCreateModel : IMapFrom<Branch>
    {
        [Required(ErrorMessage = "Please, provide the name.")]
        [StringLength(maximumLength: 30, MinimumLength = 2)]
        public string Name { get; set; }
        public string Address { get; set; }

        [StringLength(maximumLength: 20, MinimumLength = 11)]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please, provide the city.")]
        public int CityId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Branch, BranchCreateModel>();
            profile.CreateMap<BranchCreateModel, Branch>();
        }
    }

    public class BranchUpdateModel : IMapFrom<Branch>
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Please, provide the name.")]
        [StringLength(maximumLength: 30, MinimumLength = 2)]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Address { get; set; }
        [StringLength(maximumLength: 20, MinimumLength = 11)]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please, provide the city.")]
        public int CityId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Branch, BranchUpdateModel>();
            profile.CreateMap<BranchUpdateModel, Branch>();
        }
    }

    public class BranchGridModel : IMapFrom<Branch>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CityName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Branch, BranchGridModel>();
            profile.CreateMap<BranchGridModel, Branch>();
        }
    }
}
