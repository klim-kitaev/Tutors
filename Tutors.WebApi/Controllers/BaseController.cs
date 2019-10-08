using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.Logging;

namespace Tutors.WebApi.Controllers
{

    public abstract class BaseController : ControllerBase
    {
        protected readonly ILogger _log;

        public BaseController(ILogger<PupilController> log)
        {
            _log = log ?? throw new ArgumentNullException(nameof(log));
        }

        /// <summary>
        /// Получить Id пользователя
        /// </summary>
        /// <returns></returns>
        protected int GetUserId() {

            var userId =  User.Identity.IsAuthenticated ? int.Parse(User.Identity.GetUserId()) : 0;
            _log.LogInformation("Get UserID {userId}", userId);
            return userId;
        }
    }
}