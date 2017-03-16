using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UploadImages.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public byte[] Image { get; set; }
        public string Description { get; set; }

        public string Manufactures { get; set; }
        public string Model { get; set; }

        //[Display(Name = "Date and Time")]
        //public DateTime Intime { get; set; }

        public string Compression { get; set; }

        [Display(Name = "Exposure Time")]
        public int Exposure { get; set; }

        [Display(Name = "Exif Version")]
        public double ExifVersion { get; set; }

        public double GeoLong { get; set; }
        public double GeoLat { get; set; }

    }
}