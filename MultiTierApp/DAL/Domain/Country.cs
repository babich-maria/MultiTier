using System.ComponentModel.DataAnnotations;

namespace DAL.Domain
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        [Required]
        [MaxLength(2)]
        public string Iso { get; set; }
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }
        [MaxLength(3)]
        public string Iso3 { get; set; }
        
        public string NumCode { get; set; }
        public string PhoneCode { get; set; }
    }
}
