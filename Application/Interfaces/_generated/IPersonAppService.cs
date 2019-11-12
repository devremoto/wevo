using Application.ViewModels;
using Domain.Entities;
using System;

namespace Application.Interfaces
{
    public partial interface IPersonAppService : IBaseAppService<Person>
    {
		Person Save(Person viewModel, bool edit = false);
    }
}

