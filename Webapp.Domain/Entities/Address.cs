using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webapp.Domain
{
    [Table("Address")]
    public class Address
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Address1 { get; set; } = null!;

        public string? Address2 { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        public string State {  get; set; }

        [Required]
        public string Zip {  get; set; }

        [ForeignKey(nameof(User))]
        public Guid PersonId { get; set; }

        public virtual User? User { get; set; }
    }
}
