using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MedicineService.Models;
using MedicineService.ViewModels;

namespace MedicineService.Controllers
{
    public class vw_ViewProductsController : ApiController
    {

        MedicineServiceContext db = new MedicineServiceContext();
        [HttpGet]
        public IQueryable<vw_ViewProduct> GetAllProductView()
        {
            var query = db.Purchases.Select(d => new vw_ViewProduct
            {
                PurchaseId = d.PurchaseId,
                PurchaseDate = d.PurchaseDate,
                PurchaseQuantity = d.PurchaseQuantity,
                ProductDescription = d.ProductDescription,
                BoxPrice=d.BoxPrice,
                StripOrVialPerBox = d.StripOrVialPerBox,
                PiecePerStrip = d.PiecePerStrip,
                UnitPrice = d.UnitPrice,
                Comission = d.Comission,
                SalePrice=d.SalePrice,
                ProductName = d.ProductName,
                ProductPhoto = d.ProductPhoto,
                MedicineUnit = d.MedicineUnit,
                CompanyId = d.CompanyId,
                GenericId = d.GenericId,
                DosageFormatId = d.DosageFormatId,
                CompanyName = d.Company.CompanyName,
                GenericName = d.Generic.GenericName,
                DosageFormatName = d.DosageFormat.DosageFormatName,
                ProductId = d.ProductId,
                ReorderLevel = d.ReorderLevel
            });
            return query.AsQueryable();
        }
    }
}

