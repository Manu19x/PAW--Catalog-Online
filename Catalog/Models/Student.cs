using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        [ForeignKey("UserAccount")]
        public int UserID { get; set; }
        public UserAccount UserAccount { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }

        public ICollection<InscriereCurs> InscrieriCursuri { get; set; }
    }
}
