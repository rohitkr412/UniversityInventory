﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogicUniversity.Controllers
{
    public class DepartmentRepController : Controller
    {
        // GET: DepartmentRep
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            List<department> departments = BusinessLogic.GetDepartments();
            ViewData["departments"] = departments;

            return View();
        }
    }
}