using AutoMapper;
using Application.ViewModels;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.AutoMapper
{
    public class ModelToEntity : Profile
    {
        public ModelToEntity()
        {
			CreateMap<ContactViewModel, Contact>();
			CreateMap<LanguageViewModel, Language>();
			CreateMap<PersonViewModel, Person>();
        }
    }
}
