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
    public class LydoesController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/Lydoes
        public IQueryable<Lydo> GetLydoes()
        {
            return db.Lydoes;
        }

        // GET: api/Lydoes/5
        [ResponseType(typeof(Lydo))]
        public async Task<IHttpActionResult> GetLydo(int id)
        {
            Lydo lydo = await db.Lydoes.FindAsync(id);
            if (lydo == null)
            {
                return NotFound();
            }

            return Ok(lydo);
        }

        // PUT: api/Lydoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLydo(int id, Lydo lydo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lydo.Lydo_id)
            {
                return BadRequest();
            }

            db.Entry(lydo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LydoExists(id))
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

        // POST: api/Lydoes
        [ResponseType(typeof(Lydo))]
        public async Task<IHttpActionResult> PostLydo(Lydo lydo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lydoes.Add(lydo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = lydo.Lydo_id }, lydo);
        }

        // DELETE: api/Lydoes/5
        [ResponseType(typeof(Lydo))]
        public async Task<IHttpActionResult> DeleteLydo(int id)
        {
            Lydo lydo = await db.Lydoes.FindAsync(id);
            if (lydo == null)
            {
                return NotFound();
            }

            db.Lydoes.Remove(lydo);
            await db.SaveChangesAsync();

            return Ok(lydo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LydoExists(int id)
        {
            return db.Lydoes.Count(e => e.Lydo_id == id) > 0;
        }
    }
}