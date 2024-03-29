﻿using DoanThiThanhNga__Tuan3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DoanThiThanhNga__Tuan3.ViewModels;

namespace DoanThiThanhNga__Tuan3.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;
        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var upComingCourse = _dbContext.Courses.Include(p => p.Lecturer).Include(c => c.Category).Where(c => c.DateTime > DateTime.Now);
            var viewModel = new CourseViewModel
            {
                UpCommingCourses = upComingCourse,
                ShowAction = User.Identity.IsAuthenticated
            };
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}