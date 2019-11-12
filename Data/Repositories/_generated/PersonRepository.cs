using Data.EF;
using Domain.Entities;
using Domain.Interfaces;

namespace Data.Repositories
{
    public partial class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(AppDbContext db)
            : base(db)
        {
            
        }		
    }
}

