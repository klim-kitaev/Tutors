using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.Identity;

namespace Tutors.WebApi.Controllers
{

    public abstract class BaseController : ControllerBase
    {
        /// <summary>
        /// Получить Id пользователя
        /// </summary>
        /// <returns></returns>
        protected int GetUserId() => User.Identity.IsAuthenticated ? int.Parse(User.Identity.GetUserId()) : 0;
    }
}