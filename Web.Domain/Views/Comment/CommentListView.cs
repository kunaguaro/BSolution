using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Web.Domain.Views.Comment
{
    public class CommentListView
    {
        [Display(Name = "Id Post")]
        public int postId { get; set; }

        [Display(Name = "Id")]
        public int id { get; set; }

        [Display(Name = "Nombre")]
        public string name { get; set; }

        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "Body")]
        public string body { get; set; }
    }
}
