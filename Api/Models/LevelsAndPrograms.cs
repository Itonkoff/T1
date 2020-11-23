using System.Collections.Generic;

namespace Api.Models {
    public class LevelsAndPrograms {
        public List<double> Levels { get; set; }
        public List<ProgramSummary> ProgramSummaries { get; set; }
    }
}