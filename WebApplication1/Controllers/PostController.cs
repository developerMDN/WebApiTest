using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api/post")]
    public class PostController : ApiController
    {
        List<Post> posts = new List<Post>();

        public PostController()
        {
            posts = Load.LoadData();
        }

        [Route("")]
        public IEnumerable<Post> Get()
        {
            return posts;
        }

        [Route("{id:int:min(1)}")]
        public IHttpActionResult Get(int id)
        {
            Post post = posts.FirstOrDefault<Post>(p => p.Id.Equals(id));

            if (post == null)
                return NotFound();

            return Ok(post);

        }

        [Route("{title}")]
        public IEnumerable<Post> Get(string title)
        {
            Post[] posts = this.posts
                .Where<Post>(p => p.Title.Contains(title))
                .ToArray<Post>();

            return posts;

        }

        [Route("")]
        public IEnumerable<Post> Post([FromBody] Post newPost)
        {
            List<Post> posts = this.posts.ToList<Post>();
            newPost.Id = posts.Count + 1;
            posts.Add(newPost);
            this.posts = posts;

            return this.posts;

        }


    }
}
