using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Api.Models {
    public class User : IdentityUser<Guid> {
        public User()
        {
            BookHasStudent = new HashSet<BookHasStudent>();
            CanteenBalance = new HashSet<CanteenBalance>();
            Student = new HashSet<Student>();
        }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NationalId { get; set; }

        public string PhysicalAddress { get; set; }

        public virtual ICollection<BookHasStudent> BookHasStudent { get; set; }
        public virtual ICollection<CanteenBalance> CanteenBalance { get; set; }
        public virtual ICollection<Student> Student { get; set; }
    }
}

