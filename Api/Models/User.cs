using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Api.Models {
    public class User : IdentityUser<Guid> {
        public User()
        {
            Student = new HashSet<Student>();
        } 
        public virtual ICollection<Student> Student { get; set; }
        public virtual ICollection<Staff> Staff { get; set; }
    }
}

