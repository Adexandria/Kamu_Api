namespace KAMU.API.Domain.DTOs
{
    public class LoginDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public Guid OrganisationId { get; set; }
    }
}
