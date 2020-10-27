using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class ModuleHasProgram
    {
        public int ModuleIdmodule { get; set; }
        public int ProgramIdprogram { get; set; }

        public virtual Module ModuleIdmoduleNavigation { get; set; }
        public virtual Program ProgramIdprogramNavigation { get; set; }
    }
}
