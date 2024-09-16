namespace ParkSpot.Models
{
    public class User : Auditable
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public DateOnly BirthDate { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
