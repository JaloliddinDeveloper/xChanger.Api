﻿using System.Collections.Generic;
using System.Threading.Tasks;
using xChanger.Core.POC.Models.Orchestrations.PersonPets;

namespace xChanger.Core.POC.Services.Coordinations
{
    public interface IExternalPersonWithPetsCoordinationService
    {
        ValueTask<List<PersonPet>> CoordinateExternalPersons();

        string SerializeToXml(List<PersonPet> talabalar);
    }
}
