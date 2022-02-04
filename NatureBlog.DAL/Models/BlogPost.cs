using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.DAL.Models
{
    public class BlogPost
    {
        
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }  
        public string Content { get; set; }
        public DateTimeOffset DateTime { get; set; }
//        public List<Category> Categories { get; set; }
//        public List <Comment> Comments { get; set; }
        public string PostedBy { get; set; }
    }
}
