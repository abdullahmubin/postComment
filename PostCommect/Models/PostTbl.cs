using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostCommect.Models
{
    public class PostTbl
    {
        public PostTbl()
        {
            commentTbl = new CommentTbl();
        }

        public int PostId { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string Post { get; set; }
        public string Author { get; set; }

        public CommentTbl commentTbl { get; set; }
    }
}