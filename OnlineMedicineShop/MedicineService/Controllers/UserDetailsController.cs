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
    builder.EntitySet<UserDetail>("UserDetails");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class UserDetailsController : ODataController
    {
        private MedicineServiceContext db = new MedicineServiceContext();

        // GET: odata/UserDetails
        [EnableQuery]
        public IQueryable<UserDetail> GetUserDetails()
        {
            return db.UserDetails;
        }

        // GET: odata/UserDetails(5)
        [EnableQuery]
        public SingleResult<UserDetail> GetUserDetail([FromODataUri] string key)
        {
            return SingleResult.Create(db.UserDetails.Where(userDetail => userDetail.UserEmail == key));
        }

        // PUT: odata/UserDetails(5)
        public IHttpActionResult Put([FromODataUri] string key, Delta<UserDetail> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserDetail userDetail = db.UserDetails.Find(key);
            if (userDetail == null)
            {
                return NotFound();
            }

            patch.Put(userDetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDetailExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(userDetail);
        }

        // POST: odata/UserDetails
        public IHttpActionResult Post(UserDetail userDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserDetails.Add(userDetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UserDetailExists(userDetail.UserEmail))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(userDetail);
        }

        // PATCH: odata/UserDetails(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] string key, Delta<UserDetail> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserDetail userDetail = db.UserDetails.Find(key);
            if (userDetail == null)
            {
                return NotFound();
            }

            patch.Patch(userDetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDetailExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(userDetail);
        }

        // DELETE: odata/UserDetails(5)
        public IHttpActionResult Delete([FromODataUri] string key)
        {
            UserDetail userDetail = db.UserDetails.Find(key);
            if (userDetail == null)
            {
                return NotFound();
            }

            db.UserDetails.Remove(userDetail);
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

        private bool UserDetailExists(string key)
        {
            return db.UserDetails.Count(e => e.UserEmail == key) > 0;
        }
    }
}
