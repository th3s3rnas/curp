using System;
using System.Collections;
using System.Collections.Generic;
using Abp.Application.Services;
using QualisTechnologiesCurpSolution.Curp.Dto;

namespace QualisTechnologiesCurpSolution.Curp
{
    public interface ICurpAppService : IApplicationService
    {
        PersonValidateDtoRes Validate(PersonDtoReq person);
    }
}

