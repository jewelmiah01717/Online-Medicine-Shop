namespace MedicineService.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vw_ViewProduct
    {
        public int PurchaseId { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public int? PurchaseQuantity { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int? StripOrVialPerBox { get; set; }
        public int? PiecePerStrip { get; set; }
        public decimal? BoxPrice { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? Comission { get; set; }
        public string ProductPhoto { get; set; }
        public string MedicineUnit { get; set; }
        public int? ReorderLevel { get; set; }
        public int? CompanyId { get; set; }
        public int? DosageFormatId { get; set; }
        public int? GenericId { get; set; }
        public string CompanyName { get; set; }
        public string DosageFormatName { get; set; }
        public string GenericName { get; set; }

        public int? StockQuantity { get; set; }

}
}
