using System;
using Application.Interfaces;
using Application.ViewModels;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Services.Interfaces;

namespace Application.Services
{
    public partial class PersonAppService : BaseAppService<Person>, IPersonAppService
    {
		IPersonService _service;
        public PersonAppService(IPersonService service, IUnitOfWork uow)
		: base(service, uow)
        {
			_uow = uow;
            _service = service;
        }

		public Person Save(Person model, bool edit = false)
        {
			var result = new Person();

			if (!edit || model.Id == default)
				result = _service.Add(model);
			else
				result = _service.Update(model);			
			_uow.Commit();
			//SaveJson();
            return result;
        }
	}        
}