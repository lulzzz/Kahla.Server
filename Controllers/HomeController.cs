using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aiursoft.Pylon;
using Aiursoft.Pylon.Attributes;
using System.IO;
using Aiursoft.Pylon.Models;

namespace Kahla.Server.Controllers
{
    [AiurRequireHttps]    
    [AiurAllowTargetOrigin("https://kahla.app.aiursoft.com")]
    public class HomeController : AiurController
    {
        public IActionResult Index()
        {
            return Protocal(ErrorType.Success, "Welcome to kahla server! View our wiki at: " + Values.WikiServerAddress);
        }

        public IActionResult Error()
        {
            return Protocal(ErrorType.UnknownError, "Kahla server crushed! Please tell us!");
        }
    }
}
