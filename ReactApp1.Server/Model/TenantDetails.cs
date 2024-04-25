using System.ComponentModel.DataAnnotations;

namespace ReactApp1.Server.Model
{

    public class TenantDetails
    {
        [Key]
        public int UserId { get; set; }
        public string Host { get; set; }
        public bool IsActive { get; set; }
        public string ThemeName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Favicon { get; set; }
        public string Image { get; set; }
    }
}
