using Layered.Core;
using Layered.ServiceModel;
using LayeredDemo.ViewModels;
using System.Collections.Generic;
using System.Web.Http;

namespace Layered.AspnetWebApi.Controllers
{
    [Route("api/Person")]
    public class PersonController : ApiController
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public Message<IEnumerable<PersonVM>> Get()
        {
            return _personService.GetAll();
        }

        [HttpGet]
        public Message<PersonVM> Get(string email)
        {
            return _personService.FindByEmail(email);
        }

        [HttpPost]
        public void Post(PersonVM personVM)
        {
            _personService.CreateAsync(personVM);
        }

        [HttpPut]
        public void Put(PersonVM personVM)
        {
            _personService.Update(personVM);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _personService.Delete(id);
        }
    }
}
