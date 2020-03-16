using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdvertisementsApi.Models;

namespace AdvertisementsApi.Data
{
    public class AdvertisementsApiContext : DbContext
    {
        public AdvertisementsApiContext (DbContextOptions<AdvertisementsApiContext> options)
            : base(options)
        {
        }

        public DbSet<AdvertisementsApi.Models.Advertisement> Advertisement { get; set; }
    }
}
