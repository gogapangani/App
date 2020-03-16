using System;
using System.ComponentModel.DataAnnotations;

namespace AdvertisementData
{
    public class Advertisement
    {
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }
    }
}
