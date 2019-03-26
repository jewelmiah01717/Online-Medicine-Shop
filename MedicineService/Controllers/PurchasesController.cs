using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using MedicineService.Models;

namespace MedicineService.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using MedicineService.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Purchase>("Purchases");
    builder.EntitySet<Company>("Companies"); 
    builder.EntitySet<DosageFormat>("DosageFormats"); 
    builder.EntitySet<Generic>("Generics"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class PurchasesController : ODataController
    {
        private MedicineServiceContext db = new MedicineServiceContext();

        // GET: odata/Purchases
        [EnableQuery]
        public IQueryable<Purchase> GetPurchases()
        {
            return db.Purchases;
        }

        // GET: odata/Purchases(5)
        [EnableQuery]
        public Purchase GetPurchase([FromODataUri] string  key)
        {
            return db.Purchases.Where(purchase => purchase.ProductId == key).FirstOrDefault();
        }

        // PUT: odata/Purchases(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Purchase> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Purchase purchase = db.Purchases.Find(key);
            if (purchase == null)
            {
                return NotFound();
            }

            patch.Put(purchase);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(purchase);
        }

        // POST: odata/Purchases
        public IHttpActionResult Post(Purchase purchase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Purchases.Add(purchase);
            db.SaveChanges();

            return Created(purchase);
        }

        // PATCH: odata/Purchases(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Purchase> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Purchase purchase = db.Purchases.Find(key);
            if (purchase == null)
            {
                return NotFound();
            }

            patch.Patch(purchase);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(purchase);
        }

        // DELETE: odata/Purchases(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Purchase purchase = db.Purchases.Find(key);
            if (purchase == null)
            {
                return NotFound();
            }

            db.Purchases.Remove(purchase);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Purchases(5)/Company
        [EnableQuery]
        public SingleResult<Company> GetCompany([FromODataUri] int key)
        {
            return SingleResult.Create(db.Purchases.Where(m => m.PurchaseId == key).Select(m => m.Company));
        }

        // GET: odata/Purchases(5)/DosageFormat
        [EnableQuery]
        public SingleResult<DosageFormat> GetDosageFormat([FromODataUri] int key)
        {
            return SingleResult.Create(db.Purchases.Where(m => m.PurchaseId == key).Select(m => m.DosageFormat));
        }

        // GET: odata/Purchases(5)/Generic
        [EnableQuery]
        public SingleResult<Generic> GetGeneric([FromODataUri] int key)
        {
            return SingleResult.Create(db.Purchases.Where(m => m.PurchaseId == key).Select(m => m.Generic));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PurchaseExists(int key)
        {
            return db.Purchases.Count(e => e.PurchaseId == key) > 0;
        }
    }
}
