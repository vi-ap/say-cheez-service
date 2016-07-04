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
using SayCheezService.Models;
using Newtonsoft.Json;

namespace SayCheezService.Controllers
{
    public class UploadsController : ApiController
    {
        private PictureContext db = new PictureContext();

        // GET: api/Uploads
        public IQueryable<Picture> GetPictures()
        {
            return db.Pictures;
        }

        // GET: api/Uploads/5
        [ResponseType(typeof(Picture))]
        public IHttpActionResult GetPicture(int id)
        {
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return NotFound();
            }

            return Ok(picture);
        }

        // POST: api/Uploads
        [ResponseType(typeof(Picture))]
        public IHttpActionResult PostPicture(Picture picture)
        {
            if (!ModelState.IsValid || String.IsNullOrEmpty(picture.SerializedContent))
            {
                return BadRequest(ModelState);
            }
            picture.Content = Convert.FromBase64String(picture.SerializedContent);
            db.Pictures.Add(picture);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = picture.Id }, picture);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PictureExists(int id)
        {
            return db.Pictures.Count(e => e.Id == id) > 0;
        }
    }
}