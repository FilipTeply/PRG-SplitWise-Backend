using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SplitWise.Data;
using SplitWise.Model.Responses;
using SplitWise.Services;

namespace SplitWise.Controllers
{
 
    public class SessionController : BaseController
    {
        private readonly SplitWiseContext _context;
        private readonly UserServices _userServices;
        public SessionController(SplitWiseContext context, UserServices userServices)
        {
            _context = context;
            _userServices = userServices;
        }

        [HttpPost("/login")]
        public async Task<GeneralAPIResponseBody> Login([FromBody] LoginRequestBody loginRequestBody)
        {
            GeneralAPIResponseBody responseBody;
            var userId = loginRequestBody.UserId;
            var fbToken = loginRequestBody.FbToken;

            if (!(userId > 0) || String.IsNullOrEmpty(fbToken))
            {
                Response.StatusCode = 400;
                responseBody =
                    !(userId > 0) ?
                    new ErrorResponseBody("user id is missing!") :
                    new ErrorResponseBody("es_token is missing!");
            }
            else if (await _userServices.LoginRequestIsValid(userId, fbToken))
            {
                await _userServices.UpdateUser(userId, fbToken);
                responseBody = new TokenResponseBody(_userServices.GetTokenOf(userId));
               
            }
            else
            {
                responseBody = new ErrorResponseBody("Unauthorized request!");
            }
            return responseBody;
        }

        [HttpDelete("/logout")]
        public async Task<GeneralAPIResponseBody> Logout()
        {
            _userServices.RemoveToken(GetCurrentUser());

            return new OKResponseBody("Logged out successfully!");
        }


    }
}