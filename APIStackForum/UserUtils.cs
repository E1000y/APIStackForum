using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace APIStackForum
{
    internal class UserUtils : IUserUtils
    {
        public int GetCurrentUserTokenId(ControllerBase cb)
        {
            return Int32.Parse(cb.HttpContext.User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value) ;
        }

        public bool IsMOD(ControllerBase cb)
        {
            return cb.HttpContext.User.IsInRole("MOD");
        }

    }
}
