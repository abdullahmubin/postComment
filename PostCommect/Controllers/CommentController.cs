﻿using PostCommect.DBAccess;
using PostCommect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PostCommect.Controllers
{
    public class CommentController : ApiController
    {
        // GET: api/Comment
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Comment/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Comment
        public void Post(CommentTbl comTbl)
        {
            CommentDB comDb = new CommentDB();
            comDb.InsertData(comTbl);

        }

        // PUT: api/Comment/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Comment/5
        public void Delete(int id)
        {
        }
    }
}
