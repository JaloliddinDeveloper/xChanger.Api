using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using xChanger.Core.POC.Models.Orchestrations.PersonPets;
using xChanger.Core.POC.Services.Coordinations;
using xChanger.Core.POC.Services.Foundations.Persons;

namespace xChanger.Core.POC.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PersonsController : RESTFulController
    {
        private readonly IExternalPersonWithPetsCoordinationService externalPersonWithPetsCoordinationService;
        private readonly IPersonService personService;

        public PersonsController(
            IExternalPersonWithPetsCoordinationService externalPersonWithPetsCoordinationService,
            IPersonService personService)
        {
            this.externalPersonWithPetsCoordinationService = externalPersonWithPetsCoordinationService;
            this.personService = personService;
        }

        [HttpGet("Get XML")]
        public async ValueTask<ActionResult<List<PersonPet>>> GetStoredPersons()
        {
            var personPets = await this.externalPersonWithPetsCoordinationService
                .CoordinateExternalPersons();
            string xmlString = externalPersonWithPetsCoordinationService.SerializeToXml(personPets);
            return File(Encoding.UTF8.GetBytes(xmlString), "application/xml", "personpets/xml");
        }

        [HttpGet]
        public ActionResult<IQueryable<PersonPet>> GetAllPersonsWithPets() =>
            Ok(this.personService.RetrieveAllPersonsWithPets());
    }
}
