using Layered.EF;
using System.Collections.Generic;

namespace Layered.Repository
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAllPeople();
        Person GetPeopleById(int personId);
        void CreatePeople(Person person);
        void UpdatePeople(Person dbPerson);
        void DeletePeople(Person person);
    }
}
