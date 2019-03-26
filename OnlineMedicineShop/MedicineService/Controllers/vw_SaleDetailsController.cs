using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MedicineService.Models;
using MedicineService.ViewModels;
using System.Web.Http.Description;

namespace MedicineService.Controllers
{
    public class vw_SaleDetailsController : ApiController
    {
        MedicineServiceContext db = new MedicineServiceContext();
        [HttpGet]
        public IQueryable<vw_SaleDetail> GetAllSalesDetail()
        {
            var query = db.OrderDetails.Select(d => new vw_SaleDetail
            {
                OrderId=d.OrderId,
                OrderDetailId=d.OrderDetailId,
                SalePrice=d.SalePrice,
                SaleQuantity=d.SaleQuantity,
                TotalSale=d.TotalSale,
                ProductId=d.ProductId,
                OrderDate=d.Order.OrderDate,
                GrandTotal=d.Order.GrandTotal,
                GrandTotalItem=d.Order.GrandTotalItem,
                CustomerName=d.Order.CustomerName,
                CustomerAddress=d.Order.CustomerAddress,
                CustomerEmail=d.Order.CustomerEmail,
                CustomerPhone=d.Order.CustomerPhone            
            });
            return query.AsQueryable();
        }

        // GET: api/vw_SaleDetail1/5
        [ResponseType(typeof(vw_SaleDetail))]
        public IQueryable<vw_SaleDetail> Getvw_SaleDetail(int id)
        {
            // vw_SaleDetail vw_SaleDetail = db.vw_SaleDetail.Find(id);
            var query = db.OrderDetails.Select(d => new vw_SaleDetail
            {
                OrderId = d.OrderId,
                OrderDetailId = d.OrderDetailId,
                SalePrice = d.SalePrice,
                SaleQuantity = d.SaleQuantity,
                TotalSale = d.TotalSale,
                ProductId = d.ProductId,
                OrderDate = d.Order.OrderDate,
                GrandTotal = d.Order.GrandTotal,
                GrandTotalItem = d.Order.GrandTotalItem,
                CustomerName = d.Order.CustomerName,
                CustomerAddress = d.Order.CustomerAddress,
                CustomerEmail = d.Order.CustomerEmail,
                CustomerPhone = d.Order.CustomerPhone
            }).Where(d => d.OrderId == id);
            return query.AsQueryable();

            //return Ok(vw_SaleDetail);
        }
        //[HttpGet]
        //public IQueryable<vw_SaleDetail> GetSalesDetail(int oid)
        //{
        //    var query = db.OrderDetails.Select(d => new vw_SaleDetail
        //    {
        //        OrderId = d.OrderId,
        //        OrderDetailId = d.OrderDetailId,
        //        SalePrice = d.SalePrice,
        //        SaleQuantity = d.SaleQuantity,
        //        TotalSale = d.TotalSale,
        //        ProductId = d.ProductId,
        //        OrderDate = d.Order.OrderDate,
        //        GrandTotal = d.Order.GrandTotal,
        //        GrandTotalItem = d.Order.GrandTotalItem,
        //        CustomerName = d.Order.CustomerName,
        //        CustomerAddress = d.Order.CustomerAddress,
        //        CustomerEmail = d.Order.CustomerEmail,
        //        CustomerPhone = d.Order.CustomerPhone
        //    }).Where(d=> d.OrderId==oid);
        //    return query.AsQueryable();
        //}
    }
}
