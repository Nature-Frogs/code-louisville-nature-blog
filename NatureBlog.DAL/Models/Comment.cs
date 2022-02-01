using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.DAL.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        [ForeignKey(nameof(BlogPost))]
        public Guid BlogId { get; set; }
        public string? CommenterName { get; set; }
        public DateTime DateTimePosted { get; set; }
        public string? CommentBody { get; set; }
    }
}
