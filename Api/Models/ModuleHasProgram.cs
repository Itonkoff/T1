using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class ModuleHasProgram
    {
        public int Module { get; set; }
        public int Program { get; set; }

        public virtual Module ModuleNavigation { get; set; }
        public virtual StudentProgram StudentProgramNavigation { get; set; }
    }
}
