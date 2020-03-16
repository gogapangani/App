using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisementsApi.Models
{
    public class AdvertisementCreateModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Phone { get; set; }

        public IFormFile ImagePath { get; set; }
    }
}
