using System;
using System.Collections;
using System.Collections.Generic;
using QualisTechnologiesCurpSolution.Curp.ValueObjects;

namespace QualisTechnologiesCurpSolution.Curp
{
    public interface ICurpDomainService
    {
        IEnumerable<string> Validar(Person person);
    }
}

