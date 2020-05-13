using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostCommect.Models
{
    public class CommentTbl
    {
        public int CommentId { get; set; }

        public int PostId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public string Author { get; set; }

        public int TotalLike { get; set; }

        public int TotalDislike { get; set; }

        public string Comment { get; set; }

        public string CommentAuthor { get; set; }

    }
}