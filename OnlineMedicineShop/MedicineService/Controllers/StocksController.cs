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
    builder.EntitySet<Stock>("Stocks");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class StocksController : ODataController
    {
        private MedicineServiceContext db = new MedicineServiceContext();

        // GET: odata/Stocks
        [EnableQuery]
        public IQueryable<Stock> GetStocks()
        {
            return db.Stocks;
        }

        // GET: odata/Stocks(5)
        [EnableQuery]
        public SingleResult<Stock> GetStock([FromODataUri] string key)
        {
            return SingleResult.Create(db.Stocks.Where(stock => stock.ProductId == key));
        }

        // PUT: odata/Stocks(5)
        public IHttpActionResult Put([FromODataUri] string key, Delta<Stock> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Stock stock = db.Stocks.Find(key);
            if (stock == null)
            {
                return NotFound();
            }

            patch.Put(stock);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(stock);
        }

        // POST: odata/Stocks
        public IHttpActionResult Post(Stock stock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Stocks.Add(stock);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (StockExists(stock.ProductId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(stock);
        }

        // PATCH: odata/Stocks(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] string key, Delta<Stock> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Stock stock = db.Stocks.Find(key);
            if (stock == null)
            {
                return NotFound();
            }

            patch.Patch(stock);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(stock);
        }

        // DELETE: odata/Stocks(5)
        public IHttpActionResult Delete([FromODataUri] string key)
        {
            Stock stock = db.Stocks.Find(key);
            if (stock == null)
            {
                return NotFound();
            }

            db.Stocks.Remove(stock);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StockExists(string key)
        {
            return db.Stocks.Count(e => e.ProductId == key) > 0;
        }
    }
}
