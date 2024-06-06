using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Models
{
    public class Profesor
    {
        [Key]
        public int ProfesorID { get; set; }
        [ForeignKey("UserAccount")]
        public int UserID { get; set; }
        public UserAccount UserAccount { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }

        public ICollection<Curs> Cursuri { get; set; }
    }
}
