using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SplitWise.Data;
using SplitWise.Model.FacebookResponses;
using SplitWise.Model.Responses;
using SplitWise.Services;

namespace SplitWise.Controllers
{
    public class UsersController : BaseController
    {
        private readonly SplitWiseContext _context;
        private readonly UserServices _userServices;
        private readonly ProfileServices _profileService;

        public UsersController(SplitWiseContext context, UserServices userServices, ProfileServices profileService)
        {
            _context = context;
            _userServices = userServices;
            _profileService = profileService;
        }

        [HttpGet("/available/{page:int?}")]
        public GeneralAPIResponseBody ShowAvailableProfiles(int page = 1)
        {
            GeneralAPIResponseBody responseBody = null;
            // responseBody = _userServices.GetAvailableResponseBodyForPage1(GetCurrentUser().Username);
            return responseBody;
        }

        [HttpGet("/profile")]
        public GeneralAPIResponseBody GetProfile()
        {
            return new FacebookProfile(GetCurrentUser());
        }
        [HttpGet("profile/{userid}")]
        public GeneralAPIResponseBody GetProfileByUsername([FromRoute] long userid)
        {
            return new FacebookProfile(_userServices.FindUserByUserId(userid));
        }

    }
}
