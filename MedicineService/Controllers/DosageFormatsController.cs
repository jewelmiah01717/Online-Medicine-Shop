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
    builder.EntitySet<DosageFormat>("DosageFormats");
    builder.EntitySet<Purchase>("Purchases"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class DosageFormatsController : ODataController
    {
        private MedicineServiceContext db = new MedicineServiceContext();

        // GET: odata/DosageFormats
        [EnableQuery]
        public IQueryable<DosageFormat> GetDosageFormats()
        {
            return db.DosageFormats;
        }

        // GET: odata/DosageFormats(5)
        [EnableQuery]
        public SingleResult<DosageFormat> GetDosageFormat([FromODataUri] int key)
        {
            return SingleResult.Create(db.DosageFormats.Where(dosageFormat => dosageFormat.DosageFormatId == key));
        }

        // PUT: odata/DosageFormats(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<DosageFormat> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DosageFormat dosageFormat = db.DosageFormats.Find(key);
            if (dosageFormat == null)
            {
                return NotFound();
            }

            patch.Put(dosageFormat);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DosageFormatExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dosageFormat);
        }

        // POST: odata/DosageFormats
        public IHttpActionResult Post(DosageFormat dosageFormat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DosageFormats.Add(dosageFormat);
            db.SaveChanges();

            return Created(dosageFormat);
        }

        // PATCH: odata/DosageFormats(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<DosageFormat> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DosageFormat dosageFormat = db.DosageFormats.Find(key);
            if (dosageFormat == null)
            {
                return NotFound();
            }

            patch.Patch(dosageFormat);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DosageFormatExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dosageFormat);
        }

        // DELETE: odata/DosageFormats(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            DosageFormat dosageFormat = db.DosageFormats.Find(key);
            if (dosageFormat == null)
            {
                return NotFound();
            }

            db.DosageFormats.Remove(dosageFormat);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/DosageFormats(5)/Purchases
        [EnableQuery]
        public IQueryable<Purchase> GetPurchases([FromODataUri] int key)
        {
            return db.DosageFormats.Where(m => m.DosageFormatId == key).SelectMany(m => m.Purchases);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DosageFormatExists(int key)
        {
            return db.DosageFormats.Count(e => e.DosageFormatId == key) > 0;
        }
    }
}
