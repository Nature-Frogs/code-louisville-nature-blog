using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.Services.Models
{
    public class AddEntryResult
    {
        public bool IsSuccessful { get; set; }
        public int? BlogPostId { get; set; }
        public Exception? ServiceException { get; set; }
    }
}
