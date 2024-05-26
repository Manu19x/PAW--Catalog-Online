using Microsoft.AspNetCore.Identity;

namespace Catalog_online.Models;

public class UserModel : IdentityUser
{
    public string Name { get; set; }
    public string UserType { get; set; } // This field can be used to store the type of user (Student, Profesor, etc.)
}
