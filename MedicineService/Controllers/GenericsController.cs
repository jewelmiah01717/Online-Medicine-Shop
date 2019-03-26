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
    builder.EntitySet<Generic>("Generics");
    builder.EntitySet<Purchase>("Purchases"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class GenericsController : ODataController
    {
        private MedicineServiceContext db = new MedicineServiceContext();

        // GET: odata/Generics
        [EnableQuery]
        public IQueryable<Generic> GetGenerics()
        {
            return db.Generics;
        }

        // GET: odata/Generics(5)
        [EnableQuery]
        public SingleResult<Generic> GetGeneric([FromODataUri] int key)
        {
            return SingleResult.Create(db.Generics.Where(generic => generic.GenericId == key));
        }

        // PUT: odata/Generics(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Generic> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Generic generic = db.Generics.Find(key);
            if (generic == null)
            {
                return NotFound();
            }

            patch.Put(generic);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenericExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(generic);
        }

        // POST: odata/Generics
        public IHttpActionResult Post(Generic generic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Generics.Add(generic);
            db.SaveChanges();

            return Created(generic);
        }

        // PATCH: odata/Generics(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Generic> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Generic generic = db.Generics.Find(key);
            if (generic == null)
            {
                return NotFound();
            }

            patch.Patch(generic);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenericExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(generic);
        }

        // DELETE: odata/Generics(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Generic generic = db.Generics.Find(key);
            if (generic == null)
            {
                return NotFound();
            }

            db.Generics.Remove(generic);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Generics(5)/Purchases
        [EnableQuery]
        public IQueryable<Purchase> GetPurchases([FromODataUri] int key)
        {
            return db.Generics.Where(m => m.GenericId == key).SelectMany(m => m.Purchases);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GenericExists(int key)
        {
            return db.Generics.Count(e => e.GenericId == key) > 0;
        }
    }
}
