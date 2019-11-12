using Domain.Entities;
using Domain.Interfaces;
using Domain.Services.Interfaces;

namespace Domain.Services
{
    public partial class PersonService : BaseService<Person>, IPersonService
    {
        IPersonRepository _repository;
        public PersonService(IPersonRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

    }
}
