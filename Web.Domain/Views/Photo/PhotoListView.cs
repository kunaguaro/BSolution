using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Web.Domain.Views.Photo
{
    public class PhotoListView
    {
        [Display(Name = "Id")]
        public int id { get; set; }

        [Display(Name = "Album")]
        public int albumId { get; set; }

        [Display(Name = "Url")]
        public string url { get; set; }

        [Display(Name = "Thumbnail Url")]
        public string thumbnailUrl { get; set; }
    }
}
