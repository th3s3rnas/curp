using System;
using System.Collections.Generic;
using System.Linq;
using QualisTechnologiesCurpSolution.Curp.Dto;
using QualisTechnologiesCurpSolution.Curp.ValueObjects;

namespace QualisTechnologiesCurpSolution.Curp
{
    public class CurpAppService : ICurpAppService
    {
        private readonly ICurpDomainService CurpDomainService;

        public CurpAppService(ICurpDomainService domainservice)
        {
            CurpDomainService = domainservice;
        }

        public PersonValidateDtoRes Validate(PersonDtoReq person)
        {
            var result = new PersonValidateDtoRes();
            result.Errors = new List<string>();
            var personObj = new Person(person.Curp, person.Nombres, person.ApellidoPaterno, person.ApellidoMaterno, person.FechaNacimiento, person.EsMexicano);

            result.Errors = CurpDomainService.Validar(personObj).ToList();

            result.IsOk = result.Errors.Count() == 0;


            return result;
        }
    }
}

