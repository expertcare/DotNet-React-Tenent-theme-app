using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ReactApp1.Server.Model
{
    public class LoginInputModel
    {
       public string UserName { get; set; }
        public string Password { get; set; }
    }
}
