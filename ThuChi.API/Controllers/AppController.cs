﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThuChi.API.Controllers
{
    /// <summary>
    /// Create an ActionResult and PartialView for each angular partial view you want to attatch to a route in the angular app.js file.
    /// </summary>
    public class AppController : Controller
    {
        public ActionResult Register()
        {
            return PartialView();
        }
        public ActionResult SignIn()
        {
            return PartialView();
        }
        public ActionResult Home()
        {
            return PartialView();
        }

        [Authorize]
        public ActionResult TodoManager()
        {
            return PartialView();
        }

        [Authorize]
        public ActionResult Nguoithuchis()
        {
            return PartialView();
        }

        [Authorize]
        public ActionResult Lydoes()
        {
            return PartialView();
        }

        [Authorize]
        public ActionResult Thuchis()
        {
            return PartialView();
        }
    }
}