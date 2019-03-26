namespace MedicineService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Generic")]
    public partial class Generic
    {
        public Generic()
        {
            Purchases = new HashSet<Purchase>();
        }

        public int GenericId { get; set; }

        [Required]
        [StringLength(50)]
        public string GenericName { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
