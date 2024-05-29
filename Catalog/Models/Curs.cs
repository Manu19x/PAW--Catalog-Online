using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Models
{
    public class Curs
    {
        [Key]
        public int CursID { get; set; }
        public string NumeCurs { get; set; }
        public string Descriere { get; set; }
        [ForeignKey("Profesor")]
        public int ProfesorID { get; set; }
        public Profesor Profesor { get; set; }

        public int AnUniversitar { get; set; }
        public ICollection<InscriereCurs> InscrieriCursuri { get; set; }
    }
}
