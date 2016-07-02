using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SayCheezService.Models
{
    public class Picture
    {
        public DateTime time { get; set; }
        public byte[] photo { get; set; }
    }
}