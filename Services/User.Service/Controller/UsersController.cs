using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using User.Service.Models;

namespace User.Service.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UsersServiceContext usersServiceContext;

        public UsersController(UsersServiceContext _userServiceContext) {
            usersServiceContext = _userServiceContext;
        }

        [HttpGet("GetListUser")]
        public async Task<ActionResult> getList()
        {
            var User = usersServiceContext.Users.ToList();
            return Ok(User);
        }
    }
}