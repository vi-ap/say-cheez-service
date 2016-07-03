using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }
}