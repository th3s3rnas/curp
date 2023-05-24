using System;
using System.Collections.Generic;
using System.IO;
using Abp.Domain.Values;
using static AutoMapper.Internal.ExpressionFactory;

namespace QualisTechnologiesCurpSolution.Curp.ValueObjects
{
    public class Person : ValueObject
    {
        public string Curp { get; }
        public string Nombres { get; }
        public string ApellidoPaterno { get; }
        public string ApellidoMaterno { get; }
        public string FechaNacimiento { get; }
        public bool EsMexicano { get; }

        public Person(string curp, string nombres, string aPaterno, string aMaterno, string fecha
            , bool esMexicano)
        {
            Curp = curp;
            Nombres = nombres;
            ApellidoPaterno = aPaterno;
            ApellidoMaterno = aMaterno;
            FechaNacimiento = fecha;
            EsMexicano = esMexicano;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Curp;
            yield return Nombres;
            yield return ApellidoPaterno;
            yield return ApellidoMaterno;
            yield return FechaNacimiento;
            yield return EsMexicano;
        }
    }
}

