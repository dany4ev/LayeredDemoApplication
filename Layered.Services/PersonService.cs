using Layered.Core;
using Layered.EF;
using Layered.Extensions;
using Layered.Extensions.Attributes;
using Layered.Repository;
using Layered.ServiceModel;
using LayeredDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Layered.Services
{
    [Injectable]
    public class PersonService : BaseService<PersonVM>, IPersonService
    {
        private readonly PersonRepository _repository;

        public PersonService(IDbFactory dbFactory)
        {
            _repository = new PersonRepository(dbFactory);
        }

        public void CreateAsync(PersonVM personVM)
        {
            try
            {
                _repository.CreatePeople(personVM.ConvertTo());
            }
            catch (Exception ex)
            {
                // Log or return exception message service model from here 
                Debug.WriteLine(ex);
            }
        }

        public void Update(PersonVM personVM)
        {
            try
            {
                _repository.Update(personVM.ConvertTo());
            }
            catch (Exception ex)
            {
                // Log or return exception message service model from here 
                Debug.WriteLine(ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _repository.DeletePeople(new Person() { Id = id });
            }
            catch (Exception ex)
            {
                // Log or return exception message service model from here 
                Debug.WriteLine(ex);
            }
        }

        public Message<PersonVM> FindByEmail(string email)
        {
            var personVM = new PersonVM();

            try
            {
                personVM = _repository.Single(e => e.Email.Equals(email)).ConvertTo();
                return ReturnSuccess(personVM);
            }
            catch (Exception ex)
            {
                return ReturnException(personVM, ex);
            }
        }

        public Message<IEnumerable<PersonVM>> GetAll()
        {
            IEnumerable<PersonVM> personVMList = null;

            try
            {
                personVMList = _repository.GetList().Items.ConvertTo();

                return ReturnSuccess(personVMList);
            }
            catch (Exception ex)
            {
                return ReturnException(personVMList, ex);
            }
        }
    }
}
