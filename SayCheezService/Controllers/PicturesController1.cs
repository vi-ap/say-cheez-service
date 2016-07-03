using SayCheezService.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SayCheezService.Controllers
{
    public class PicturesController : ApiController
    {
        // GET: api/Pictures
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Pictures/5
        public Picture Get(int id)
        {
            return new Picture
            {
                Id = 0,
                Time = DateTime.Now,
                Content = getMinionPicture()
            };
        }

        // POST: api/Pictures
        public void Post([FromBody]byte[] pictureCaptured)
        {
            Debug.WriteLine(pictureCaptured);
        }

        // PUT: api/Pictures/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Pictures/5
        public void Delete(int id)
        {
        }

        private byte[] getMinionPicture()
        {
            Debug.WriteLine(HttpContext.Current.Server.MapPath("~/Content/minion-hitman.png"));
            FileStream stream = new FileStream(HttpContext.Current.Server.MapPath("~/Content/minion-hitman.png"), FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);

            byte[] photo = reader.ReadBytes((int)stream.Length);

            reader.Close();
            stream.Close();

            return photo;
        }
    }
}
