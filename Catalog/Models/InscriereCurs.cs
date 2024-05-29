using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Models
{
    public class InscriereCurs
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Student")]
        public int StudentID { get; set; }
        public Student Student { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Curs")]
        public int CursID { get; set; }
        public Curs Curs { get; set; }

        public decimal Nota { get; set; }
    }
}
