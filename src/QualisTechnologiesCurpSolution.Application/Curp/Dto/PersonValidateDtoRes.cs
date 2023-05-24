using System;
using System.Collections.Generic;

namespace QualisTechnologiesCurpSolution.Curp.Dto
{
    public class PersonValidateDtoRes
    {
        public List<string> Errors { get; set; }
        public bool IsOk { get; set; }
    }
}

