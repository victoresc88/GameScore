﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GameScore.UI.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Details(int id)
        {
            return View();
        }
    }
}