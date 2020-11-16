using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class NewBookResourceDto
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string Author { get; set; }
        public int Count { get; set; } = 1;
        public int DaysAllowable { get; set; } = 1;
        public int PenaltyRate { get; set; } = 1;
    }
}
