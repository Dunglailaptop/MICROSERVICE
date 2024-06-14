using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using UserPermission.Service.Models;

namespace UserPermission.Service.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserPermissionController : ControllerBase
    {
        private readonly UserPermissionServiceContext _userPermissionServiceContext;

        public UserPermissionController(UserPermissionServiceContext userPermissionServiceContext){
             _userPermissionServiceContext = userPermissionServiceContext;
        }

        [HttpGet("GetListUserPermission")]
        public async Task<ActionResult> getListUserPermission(){
            var UserPermission = _userPermissionServiceContext.UserPermissions.ToList();

            return Ok(UserPermission);
        }

    }
}