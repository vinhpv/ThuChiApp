using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ThuChi.API.Models;

namespace ThuChi.API.Controllers
{
    public class ThuchisController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/Thuchis
        public IQueryable<Thuchi> GetThuchis()
        {
            return db.Thuchis;
        }

        // GET: api/Thuchis/5
        [ResponseType(typeof(Thuchi))]
        public async Task<IHttpActionResult> GetThuchi(int id)
        {
            Thuchi thuchi = await db.Thuchis.FindAsync(id);
            if (thuchi == null)
            {
                return NotFound();
            }

            return Ok(thuchi);
        }

        // PUT: api/Thuchis/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutThuchi(int id, Thuchi thuchi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != thuchi.thuchi_id)
            {
                return BadRequest();
            }

            db.Entry(thuchi).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThuchiExists(id))
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

        // POST: api/Thuchis
        [ResponseType(typeof(Thuchi))]
        public async Task<IHttpActionResult> PostThuchi(Thuchi thuchi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Thuchis.Add(thuchi);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = thuchi.thuchi_id }, thuchi);
        }

        // DELETE: api/Thuchis/5
        [ResponseType(typeof(Thuchi))]
        public async Task<IHttpActionResult> DeleteThuchi(int id)
        {
            Thuchi thuchi = await db.Thuchis.FindAsync(id);
            if (thuchi == null)
            {
                return NotFound();
            }

            db.Thuchis.Remove(thuchi);
            await db.SaveChangesAsync();

            return Ok(thuchi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ThuchiExists(int id)
        {
            return db.Thuchis.Count(e => e.thuchi_id == id) > 0;
        }
    }
}