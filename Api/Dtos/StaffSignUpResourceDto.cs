﻿using System.ComponentModel.DataAnnotations;

namespace Api.Dtos {
    public class StaffSignUpResourceDto {
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string Email { get; set; }
        
        [Required] public string PhoneNumber { get; set; }
        
        [Required] public string Password { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
    }
}