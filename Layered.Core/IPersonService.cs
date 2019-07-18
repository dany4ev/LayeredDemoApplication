using Layered.ServiceModel;
using LayeredDemo.ViewModels;
using System.Collections.Generic;

namespace Layered.Core
{
    public interface IPersonService
    {
        void CreateAsync(PersonVM person);

        void Update(PersonVM person);

        void Delete(int id);

        Message<IEnumerable<PersonVM>> GetAll();

        Message<PersonVM> FindByEmail(string email);
    }
}
