﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nettbutikk.Controllers
{
    public class HandlevognController : Controller
    {
        // GET: Handlevogn
        public ActionResult Index()
        {
            var handlevogn = DbHandlevogn.getHandlevogn(Session);
            return View(handlevogn);
        }
    }
}