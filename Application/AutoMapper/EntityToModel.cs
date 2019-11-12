using AutoMapper;
using Application.ViewModels;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.AutoMapper
{
    public class EntityToModel : Profile
    {
        public EntityToModel()
        {
			CreateMap<Contact, ContactViewModel>();
			CreateMap<Language, LanguageViewModel>();
			CreateMap<Person, PersonViewModel>();
        }
    }
}
