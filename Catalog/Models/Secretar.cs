using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Models
{
    public class Secretar
    {
        [Key]
        public int SecretarID { get; set; }
        [ForeignKey("UserAccount")]
        public int UserID { get; set; }
        public UserAccount UserAccount { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
    }
}
