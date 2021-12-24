using kgang.core.services;
using kgang.web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kgang.web.Controllers
{
    public class HomeController : Controller
    {
        UserService userService = new UserService();
        PostService postService = new PostService();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";
            PostsModel postsModel = GetUsers();
            return View(postsModel);
        }

        private PostsModel GetUsers()
        {
            var coreUsers = userService.GetUsers();
            var postsModel = new PostsModel();

            foreach (var coreUser in coreUsers)
            {
                postsModel.Users.Add(new UserModel { Name = coreUser.Name, ImagePathBase64 = coreUser.Picture });
            }

            return postsModel;
        }

        [HttpGet]
        public ActionResult UserChanged(string id)
        {
            ViewBag.Message = id;
            PostsModel postsModel = GetUsers();
            ViewBag.Base64String = postsModel.Users.Where(a => a.Name.Equals(id)).FirstOrDefault().ImagePathBase64;
            var posts = postService.GetPosts();
            LoadPosts(postsModel, posts);
            postsModel.Name = id;
            return View("Contact", postsModel);
        }

        private static void LoadPosts(PostsModel postsModel, List<core.aggregates.Post> posts)
        {
            foreach (var item in posts)
            {
                var post = new PostModel();
                post.Id = item.Id;
                post.Date = item.DateCreated;
                post.Content = item.Content;
                post.User = new UserModel { Name = item.UserName, ImagePathBase64 = item.Picture };

                foreach (var comment in item.Comments)
                {
                    post.Comments.Add(new PostModel { Content = comment.Content, Date = comment.DateCreated, User = new UserModel { Name = comment.UserName, ImagePathBase64 = comment.Picture } });
                }

                postsModel.Posts.Add(post);
            }
        }

        [HttpPost]
        public ActionResult AddPost(PostsModel membervalues)
        {
            if (membervalues.PostId > 0)
                postService.Comment(membervalues.Comment, membervalues.Name, membervalues.PostId);
            else
                postService.Post(membervalues.Post, membervalues.Name);

            PostsModel postsModel = GetUsers();
            ViewBag.Base64String = postsModel.Users.Where(a => a.Name.Equals(membervalues.Name)).FirstOrDefault().ImagePathBase64;
            var posts = postService.GetPosts();
            LoadPosts(postsModel, posts);
            return View("Contact", postsModel);
        }
        [HttpGet]
        public ActionResult AddComment(int postId, string comment, string name)
        {
            postService.Comment(comment, name, postId);
            PostsModel postsModel = GetUsers();
            ViewBag.Base64String = postsModel.Users.Where(a => a.Name.Equals(name)).FirstOrDefault().ImagePathBase64;
            var posts = postService.GetPosts();
            LoadPosts(postsModel, posts);
            return View("Contact", postsModel);
        }
        [HttpPost] 
        public ActionResult SaveUser(UserModel membervalues)
        {
            byte[] bytes;
            using (var memoryStream = new MemoryStream())
            {

                membervalues.ImageFile.InputStream.CopyTo(memoryStream);
                bytes = memoryStream.ToArray();
            }

            string base64 = Convert.ToBase64String(bytes);
            userService.RegisterUser(membervalues.Name, base64);
            return View("Index");
        }

    }
}