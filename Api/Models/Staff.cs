using System;

namespace Api.Models {
    public class Staff {
        public int Id { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public Guid UserId { get; set; }
        
        public virtual User User { get; set; }
    }
}