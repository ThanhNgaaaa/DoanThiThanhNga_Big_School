using DoanThiThanhNga__Tuan3.DTOs;
using DoanThiThanhNga__Tuan3.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DoanThiThanhNga__Tuan3.Controllers
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext dbContext;
        public FollowingsController()
        {
            dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if(dbContext.Followings.Any(p=>p.FollowerId==userId&& p.FolloweeId==followingDto.FolloweeId)) {
                return BadRequest("Following already exsits");
            }
            var following =new Following
            {
                FollowerId = userId,
                FolloweeId= followingDto.FolloweeId,

            };
            dbContext.Followings.Add(following);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
