using Layered.EF;
using Layered.Extensions.Attributes;
using System.Collections.Generic;

namespace Layered.Repository
{
    [Injectable]
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public void CreatePeople(Person person)
        {
           Add(person);           
        }

        public void DeletePeople(Person person)
        {
            Delete(person);
        }

        public IEnumerable<Person> GetAllPeople()
        {
            return GetList().Items;
        }

        public Person GetPeopleById(int personId)
        {
            return Single(person => person.Id == personId);
        }

        public void UpdatePeople(Person person)
        {
            Update(person);
        }
    }  
}