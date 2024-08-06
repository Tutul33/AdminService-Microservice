namespace Shared
{
    public class User:AuditableEntity<long>
    {
        public string FullName { get; set; } = "";
        public string UserName { get; set; } = "";
        public string Email { get; set; } = "";

        public short? Age { get; set; }

        public DateOnly? BirthDate { get; set; }

        public string BirthTime { get; set; } = "";

        public string? Address { get; set; } = "";

        public string? Country { get; set; } = "";

        public bool? IsActive { get; set; }

        
    }

}
