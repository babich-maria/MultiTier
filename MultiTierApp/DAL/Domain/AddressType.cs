using System.ComponentModel.DataAnnotations;

namespace DAL.Domain
{
    public class AddressType
    {
        [Key]
        public int AddressTypeId { get; set; }
        [Required]
        [MaxLength(1)]
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
