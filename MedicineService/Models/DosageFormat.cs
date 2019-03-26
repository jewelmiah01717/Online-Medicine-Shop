namespace MedicineService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DosageFormat")]
    public partial class DosageFormat
    {
        public DosageFormat()
        {
            Purchases = new HashSet<Purchase>();
        }

        public int DosageFormatId { get; set; }

        [Required]
        [StringLength(50)]
        public string DosageFormatName { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
