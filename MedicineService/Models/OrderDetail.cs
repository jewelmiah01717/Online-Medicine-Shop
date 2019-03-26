namespace MedicineService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }

        [Column(TypeName = "money")]
        public decimal? SalePrice { get; set; }

        public int? SaleQuantity { get; set; }
        [Column(TypeName = "money")]
        public decimal? TotalSale { get; set; }
        public string ProductId { get; set; }
        public int? OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}
