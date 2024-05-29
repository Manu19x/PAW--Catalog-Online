using Microsoft.AspNetCore.DataProtection;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Models
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public string Role { get; set; }  // Adăugat câmpul Role

        public ICollection<Student> Students { get; set; }
        public ICollection<Profesor> Profesori { get; set; }
        public ICollection<Secretar> Secretari { get; set; }
        public ICollection<Moderator> Moderatori { get; set; }
    }
}
