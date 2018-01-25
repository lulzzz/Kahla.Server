using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kahla.Server.Data;
using Kahla.Server.Models;
using Microsoft.AspNetCore.Identity;
using Aiursoft.Pylon.Attributes;
using Kahla.Server.Attributes;

namespace Kahla.Server.Controllers
{
    [AiurNoCache]
    [AiurRequireHttps]
    [AllowMethodHeader]
    [AiurExceptionHandler]
    [AiurAllowTargetOrigin("http://localhost:8001")]
    //[ForceValidateModelState]
    public class DebugApiController : ApiController
    {
        public DebugApiController(UserManager<KahlaUser> userManager, 
            SignInManager<KahlaUser> signInManager, 
            KahlaDbContext dbContext) : base(userManager, signInManager, dbContext)
        {
        }
    }
}
