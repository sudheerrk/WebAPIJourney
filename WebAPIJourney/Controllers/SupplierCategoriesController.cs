using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPIJourney.Models.Database;

namespace WebAPIJourney.Controllers
{
    public class SupplierCategoriesController : ApiController
    {
        private WideWorldImportersEntities2 db = new WideWorldImportersEntities2();

        /// <summary>
        /// This API return all Supplier Categories 
        /// </summary>
        /// <returns>IQueryable of SupplierCategory </returns>
        // GET: api/SupplierCategories
        public IQueryable<SupplierCategory> GetSupplierCategories()
        {
            return db.SupplierCategories;
        }

        // GET: api/SupplierCategories/5
        [ResponseType(typeof(SupplierCategory))]
        public IHttpActionResult GetSupplierCategory(int id)
        {
            SupplierCategory supplierCategory = db.SupplierCategories.Find(id);
            if (supplierCategory == null)
            {
                return NotFound();
            }

            return Ok(supplierCategory);
        }

        // PUT: api/SupplierCategories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSupplierCategory(int id, SupplierCategory supplierCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != supplierCategory.SupplierCategoryID)
            {
                return BadRequest();
            }

            db.Entry(supplierCategory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/SupplierCategories
        [ResponseType(typeof(SupplierCategory))]
        public IHttpActionResult PostSupplierCategory(SupplierCategory supplierCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SupplierCategories.Add(supplierCategory);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SupplierCategoryExists(supplierCategory.SupplierCategoryID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = supplierCategory.SupplierCategoryID }, supplierCategory);
        }

        // DELETE: api/SupplierCategories/5
        [ResponseType(typeof(SupplierCategory))]
        public IHttpActionResult DeleteSupplierCategory(int id)
        {
            SupplierCategory supplierCategory = db.SupplierCategories.Find(id);
            if (supplierCategory == null)
            {
                return NotFound();
            }

            db.SupplierCategories.Remove(supplierCategory);
            db.SaveChanges();

            return Ok(supplierCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SupplierCategoryExists(int id)
        {
            return db.SupplierCategories.Count(e => e.SupplierCategoryID == id) > 0;
        }
    }
}