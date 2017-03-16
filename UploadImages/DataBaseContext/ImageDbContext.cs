using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using UploadImages.Models;

namespace UploadImages.DataBaseContext
{
    public class ImageDbContext : DbContext
    {
        public ImageDbContext() : base("DbConnection") { }

        public DbSet<Picture> Images { get; set; }
    }
}