using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MedicineService.Models
{
    public class MedicineServiceContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public MedicineServiceContext()
            : base("name=MedicineServiceContext")
        {
        }

        public System.Data.Entity.DbSet<MedicineService.Models.UserDetail> UserDetails { get; set; }

        public System.Data.Entity.DbSet<MedicineService.Models.Company> Companies { get; set; }

        public System.Data.Entity.DbSet<MedicineService.Models.Generic> Generics { get; set; }

        public System.Data.Entity.DbSet<MedicineService.Models.DosageFormat> DosageFormats { get; set; }

        public System.Data.Entity.DbSet<MedicineService.Models.Stock> Stocks { get; set; }

        public System.Data.Entity.DbSet<MedicineService.Models.Purchase> Purchases { get; set; }

        public System.Data.Entity.DbSet<MedicineService.Models.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<MedicineService.Models.OrderDetail> OrderDetails { get; set; }


    }
}
