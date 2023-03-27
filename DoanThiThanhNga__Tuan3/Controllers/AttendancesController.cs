using DoanThiThanhNga__Tuan3.DTOs;
using DoanThiThanhNga__Tuan3.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI;

namespace DoanThiThanhNga__Tuan3.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext dbContext;
        public AttendancesController()
        {
            dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var userId= User.Identity.GetUserId();
            if(dbContext.Attendances.Any(a=>a.AttendeeId==userId && a.CourseId==attendanceDto.CourseId)) {
                return BadRequest("The attendance is already exist");
            }

            var attendance = new Attendance
            {
                CourseId = attendanceDto.CourseId,
                AttendeeId = userId
            };
            dbContext.Attendances.Add(attendance);
            dbContext.SaveChanges();
            return Ok();

        }

    }
}
