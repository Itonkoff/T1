namespace Api.Dtos {
    public class SignUpDto {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NationalId { get; set; }

        public string PhysicalAddress { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        //TODO validate passowrd confirm
        public string PasswordConfirm { get; set; }
    }
}