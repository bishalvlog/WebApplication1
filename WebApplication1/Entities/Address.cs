using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model
{
    [Table("Address")]
    public class Address
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State {  get; set; }

        public string Zip {  get; set; }

        [ForeignKey(nameof(User))]
        public Guid PersonId { get; set; }

        public virtual User? User { get; set; }
    }
}
