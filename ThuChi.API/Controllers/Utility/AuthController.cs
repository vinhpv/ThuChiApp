using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ThuChi.API.Models;

namespace ThuChi.API.Controllers.Utility
{
    public class AuthController : ApiController
    {
        protected DBContext db = new DBContext();
        //HttpContext httpContext = new HttpContext(new Http

        public RoleManager<IdentityRole> RoleManager { get; private set; }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        protected string GetUserID()
        {
            return Request.GetOwinContext().Authentication.User.Identity.GetUserId();
        }

        protected User GetCurentUser()
        {
            string userId = Request.GetOwinContext().Authentication.User.Identity.GetUserId();
            return UserManager.FindById(userId);
        }
    }
}
