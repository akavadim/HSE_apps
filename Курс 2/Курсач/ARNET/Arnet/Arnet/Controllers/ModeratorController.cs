﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Arnet.Web.Controllers
{
    public class ModeratorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}