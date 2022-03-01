using System.ComponentModel.DataAnnotations;

namespace NatureBlog.Web.Models
{
    public class BlogEntryViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
