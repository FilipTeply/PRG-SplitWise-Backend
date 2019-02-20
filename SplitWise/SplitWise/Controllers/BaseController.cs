using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SplitWise.Model;

namespace SplitWise.Controllers
{

    public class BaseController : ControllerBase
    {
        public BaseController()
        {
        }

        public User GetCurrentUser()
        {
            return HttpContext.Items["user"] as User;
        }
    }
}