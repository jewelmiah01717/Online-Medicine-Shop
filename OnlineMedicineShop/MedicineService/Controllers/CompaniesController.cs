﻿using System;
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
    builder.EntitySet<Company>("Companies");
    builder.EntitySet<Purchase>("Purchases"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class CompaniesController : ODataController
    {
        private MedicineServiceContext db = new MedicineServiceContext();

        // GET: odata/Companies
        [EnableQuery]
        public IQueryable<Company> GetCompanies()
        {
            return db.Companies;
        }

        // GET: odata/Companies(5)
        [EnableQuery]
        public SingleResult<Company> GetCompany([FromODataUri] int key)
        {
            return SingleResult.Create(db.Companies.Where(company => company.CompanyId == key));
        }

        // PUT: odata/Companies(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Company> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Company company = db.Companies.Find(key);
            if (company == null)
            {
                return NotFound();
            }

            patch.Put(company);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(company);
        }

        // POST: odata/Companies
        public IHttpActionResult Post(Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Companies.Add(company);
            db.SaveChanges();

            return Created(company);
        }

        // PATCH: odata/Companies(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Company> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Company company = db.Companies.Find(key);
            if (company == null)
            {
                return NotFound();
            }

            patch.Patch(company);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(company);
        }

        // DELETE: odata/Companies(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Company company = db.Companies.Find(key);
            if (company == null)
            {
                return NotFound();
            }

            db.Companies.Remove(company);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Companies(5)/Purchases
        [EnableQuery]
        public IQueryable<Purchase> GetPurchases([FromODataUri] int key)
        {
            return db.Companies.Where(m => m.CompanyId == key).SelectMany(m => m.Purchases);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyExists(int key)
        {
            return db.Companies.Count(e => e.CompanyId == key) > 0;
        }
    }
}
