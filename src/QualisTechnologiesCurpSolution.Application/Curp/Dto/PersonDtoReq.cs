using System;
namespace QualisTechnologiesCurpSolution.Curp.Dto
{
    public class PersonDtoReq
    {
        public string Curp { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string FechaNacimiento { get; set; }
        public bool EsMexicano { get; set; }
    }
}

