using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace SayCheezService.Models
{
    public class Picture
    {
        [Key]
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public byte[] Content { get; set; }
        public string SerializedContent { get; set; }

        public Bitmap getImage()
        {
            MemoryStream stream = new MemoryStream(Content);
            Bitmap image = new Bitmap(stream);
            stream.Close();
            return image;
        }
    }
}