namespace MedicineService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Company")]
    public partial class Company
    {
        public Company()
        {
            Purchases = new HashSet<Purchase>();
        }

        public int CompanyId { get; set; }

        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
