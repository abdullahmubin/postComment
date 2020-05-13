using PostCommect.DBAccess;
using PostCommect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PostCommect.Controllers
{
    public class FinalResult
    {
        public FinalResult()
        {
            CommentList = new List<PostTbl>();
        }
        public int PostId { get; set; }
        public string Author { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string Post { get; set; }
        public List<PostTbl> CommentList = new List<PostTbl>();
    }
    public class PostController : ApiController
    {
        // GET: api/Post
        public List<FinalResult> Get()
        {
            List<PostTbl> allPost = new List<PostTbl>();
           
            var test = new List<PostTbl>();

            PostTblDB postDb = new PostTblDB();
            allPost = postDb.Selectalldata();
            

            var results = from p in allPost
                          group p by new { p.PostId, p.Author, p.CreatedDateTime, p.Post } into g
                          select new { PostId = g.Key.PostId, Author = g.Key.Author, CreatedDateTime = g.Key.CreatedDateTime, Post = g.Key.Post, postTbl = g.ToList() };

            List<FinalResult> FinalList = new List<FinalResult>();
            foreach (var item in results)
            {
                FinalResult okay = new FinalResult();

                okay.PostId = item.PostId;
                okay.Author = item.Author;
                okay.CreatedDateTime = item.CreatedDateTime;
                okay.Post = item.Post;
                okay.CommentList = item.postTbl;

                FinalList.Add(okay);
            }
           
            return FinalList;
        }

        // GET: api/Post/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Post
        public void Post(PostTbl postTbl)
        {
            PostTblDB postDb = new PostTblDB();
            postDb.InsertData(postTbl);
        }

        // PUT: api/Post/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/Post/5
        public void Delete(int id)
        {
        }
    }
}
