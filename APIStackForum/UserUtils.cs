using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace APIStackForum
{
    internal class UserUtils : ControllerBase, IUserUtils
    {
        public int GetCurrentUserTokenId()
        {
            return Int32.Parse(HttpContext.User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value);
        }

        public bool IsMOD()
        {
            return HttpContext.User.IsInRole("MOD");
        }

    }
}
