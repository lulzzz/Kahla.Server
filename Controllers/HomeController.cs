using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AiursoftBase;
using AiursoftBase.Attributes;
using System.IO;
using AiursoftBase.Models;

namespace Kahla.Server.Controllers
{
    [AiurRequireHttps]
    [AiurExceptionHandler]
    public class HomeController : AiurController
    {
        // [AiurForceAuth]
        public IActionResult Index()
        {
            return Protocal(ErrorType.Success, "Welcome to kahla server! View our wiki at: " + Values.WikiServerAddress);
        }
    }
}
