namespace MedicineService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Purchase")]
    public partial class Purchase
    {[Key]
        public int PurchaseId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PurchaseDate { get; set; }

        public int? PurchaseQuantity { get; set; }

        [StringLength(40)]
        public string ProductName { get; set; }


        public string ProductDescription { get; set; }

        public int? StripOrVialPerBox { get; set; }
        [Column(TypeName = "money")]
        public decimal? BoxPrice { get; set; }
        public int? PiecePerStrip { get; set; }

        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal? Comission { get; set; }
        public decimal? SalePrice { get; set; }
        

        public string ProductPhoto { get; set; }


        [StringLength(50)]
        public string MedicineUnit { get; set; }
        public int? ReorderLevel { get; set; }

        public int? GenericId { get; set; }

        public int? CompanyId { get; set; }

        public int? DosageFormatId { get; set; }
        [StringLength(10)]
        public string ProductId { get; set; }
        public virtual Company Company { get; set; }

        public virtual Generic Generic { get; set; }
        public virtual DosageFormat DosageFormat { get; set; }
        
    }
}
