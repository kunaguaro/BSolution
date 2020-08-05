using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Web.Domain.Views.Album
{
    public class AlbumListView
    {

        [Display(Name = "Id")]
        public int id { get; set; }

        [Display(Name = "Titulo Album")]
        public string title { get; set; }
    }
}
