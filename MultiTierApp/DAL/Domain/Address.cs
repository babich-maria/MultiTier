using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Domain
{
    public class Address
    {
        [ForeignKey("CustomerId")]
        [Column(TypeName = "varchar(5)")]
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("CustomerId")]
        public int AddressTypeId { get; set; }
        public AddressType AddressType { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Street { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string ZIP { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string City { get; set; }

        [ForeignKey("CountryId")]
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
