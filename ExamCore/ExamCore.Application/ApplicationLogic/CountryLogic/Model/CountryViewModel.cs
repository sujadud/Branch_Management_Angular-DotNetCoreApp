using AutoMapper;
using ExamCore.Model.Models;
using ExamCore.Shared.Mappings;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;

namespace ExamCore.Application.ApplicationLogic.CountryLogic.Model
{
    public class CountryViewModel
    {
        public CountryCreateModel CreateModel { get; set; }
        public CountryUpdateModel UpdateModel { get; set; }
        public CountryGridModel GridModel { get; set; }
        public dynamic OptionsDataSources { get; set; } = new ExpandoObject();
    }

    public class CountryCreateModel : IMapFrom<Country>
    {
        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Please, provide name.")]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Country, CountryCreateModel>();
            profile.CreateMap<CountryCreateModel, Country>();
        }
    }

    public class CountryUpdateModel : IMapFrom<Country>
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Please, provide name.")]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Country, CountryUpdateModel>();
            profile.CreateMap<CountryUpdateModel, Country>();
        }
    }

    public class CountryGridModel : IMapFrom<Country>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Country, CountryGridModel>();
            profile.CreateMap<CountryGridModel, Country>();
        }
    }
}