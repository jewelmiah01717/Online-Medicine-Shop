namespace MedicineService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Stock")]
    public partial class Stock
    {
        //public Stock()
        //{
        //    OrderDetails = new HashSet<OrderDetail>();
        //}

        [Key]
        [StringLength(10)]
        public string ProductId { get; set; }

        public int? StockQuantity { get; set; }

        public int? ReorderLevel { get; set; }

        [Column(TypeName = "money")]
        public decimal? SalePrice { get; set; }

        //public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
