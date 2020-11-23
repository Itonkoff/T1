using System;

namespace Api.Dtos {
    public class AttendanceDto {
        public Guid Student { get; set; }
        public int Module { get; set; }        
    }
}