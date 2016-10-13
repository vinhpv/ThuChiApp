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
using ThuChi.API.Controllers.Utility;
using ThuChi.API.Models;

namespace ThuChi.API.Controllers
{
    [Authorize]
    public class NguoithuchisController : AuthController
    {

        // GET: api/Nguoithuchis
        public IQueryable<Nguoithuchi> GetNguoithuchis()
        {
            return db.Nguoithuchis;
        }

        // GET: api/Nguoithuchis/5
        [ResponseType(typeof(Nguoithuchi))]
        public async Task<IHttpActionResult> GetNguoithuchi(int id)
        {
            Nguoithuchi nguoithuchi = await db.Nguoithuchis.FindAsync(id);
            if (nguoithuchi == null)
            {
                return NotFound();
            }

            return Ok(nguoithuchi);
        }

        // PUT: api/Nguoithuchis/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNguoithuchi(int id, Nguoithuchi nguoithuchi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nguoithuchi.nguoithuchi_id)
            {
                return BadRequest();
            }

            db.Entry(nguoithuchi).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NguoithuchiExists(id))
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

        // POST: api/Nguoithuchis
        [ResponseType(typeof(Nguoithuchi))]
        public async Task<IHttpActionResult> PostNguoithuchi(Nguoithuchi nguoithuchi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Nguoithuchis.Add(nguoithuchi);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = nguoithuchi.nguoithuchi_id }, nguoithuchi);
        }

        // DELETE: api/Nguoithuchis/5
        [ResponseType(typeof(Nguoithuchi))]
        public async Task<IHttpActionResult> DeleteNguoithuchi(int id)
        {
            Nguoithuchi nguoithuchi = await db.Nguoithuchis.FindAsync(id);
            if (nguoithuchi == null)
            {
                return NotFound();
            }

            db.Nguoithuchis.Remove(nguoithuchi);
            await db.SaveChangesAsync();

            return Ok(nguoithuchi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NguoithuchiExists(int id)
        {
            return db.Nguoithuchis.Count(e => e.nguoithuchi_id == id) > 0;
        }
    }
}