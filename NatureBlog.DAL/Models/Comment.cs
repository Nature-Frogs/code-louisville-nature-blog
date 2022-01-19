using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.DAL.Models
{
    public class Comment
    {
        public string CommenterName { get; set; }
        public DateTimeOffset DateTimePosted { get; set; }
        public string CommentBody { get; set; }
    }
}
