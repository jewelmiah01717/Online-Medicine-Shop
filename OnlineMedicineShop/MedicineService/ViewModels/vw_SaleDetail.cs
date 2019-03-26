using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MedicineService.ViewModels
{
    public class vw_SaleDetail
    {
        
        public int? OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? OrderDetailId { get; set; }
        public string ProductId { get; set; }
        public decimal? SalePrice { get; set; }
        public int? SaleQuantity { get; set; }
        public decimal? TotalSale { get; set; }
        public decimal? GrandTotal { get; set; }
        public int? GrandTotalItem { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }

    }
}