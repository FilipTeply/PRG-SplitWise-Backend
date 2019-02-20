using SplitWise.Data;
using SplitWise.Model;
using SplitWise.Model.FacebookResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SplitWise.Services
{
    public class UserServices
    {
        private readonly SplitWiseContext _context;
        private const string ApiUrl = "https://graph.facebook.com/v3.2/";
        private HttpClient client = new HttpClient();


        public UserServices()
        {
            SplitWiseContext _context = new SplitWiseContext();
        }

        public UserServices(SplitWiseContext context)
        {
            _context = context;
        }

        public virtual bool TokenExists(string estoken)
        {
            return _context.Users.Any(u => u.EsToken == estoken);
        }

        public User FindUserByUserToken(string estoken)
        {
            var foundUser = _context.Users
                 //.Include(e => e.UserLanguages)
                 //.ThenInclude(l => l.Language)
                 //.Include(e => e.UserSettings)
                 .Where(u => u.EsToken == estoken).FirstOrDefault();
            return foundUser;
        }

        public virtual async Task<bool> LoginRequestIsValid(int userId, string facebookToken)
        {
            return userId.Equals((await GetFacebookProfileAsync(facebookToken)).UserId);
        }

        public async Task<FacebookProfile> GetFacebookProfileAsync(string facebookToken)
        {
            client = new HttpClient();
            HeadersSettingForSplitWiseApi();
            client.DefaultRequestHeaders.Add("Authorization", "token " + facebookToken);
            HttpResponseMessage facebookProfileResponse = await client.GetAsync(ApiUrl + "user");

            var profileLoggingIn = new FacebookProfile();

            if (facebookProfileResponse.IsSuccessStatusCode)
            {
                profileLoggingIn = await facebookProfileResponse.Content.ReadAsAsync<FacebookProfile>();
            }
            return profileLoggingIn;
        }

        public virtual string CreateSplitWiseToken()
        {
            string token;

            do
            {
                token = Guid.NewGuid().ToString();
            }
            while (_context.Users.Where(e => e.EsToken == token).Count() > 0);

            return token;
        }

        public void HeadersSettingForSplitWiseApi()
        {
            client.DefaultRequestHeaders.Add("User-Agent", "SplitWiseApp");
        }

        public virtual async Task<bool> UpdateUser(int userId, string facebookToken)
        {
            if (UserExists(userId))
            {
                UpdateToken(userId);
            }
            else
            {
                await CreateUser(facebookToken);
                //await UpdateLanguagesTableAndUserLanguageTable(username);
            }

            return true;
        }

        public void RemoveToken(User user)
        {
            user.EsToken = "";
            _context.Update(user);
            _context.SaveChanges();
        }

        public virtual bool UserExists(int userId)
        {
            return _context.Users.Where(e => e.UserId == userId).Count() > 0;
        }

        public virtual void UpdateToken(int userId)
        {
            _context.Find<User>(userId).EsToken = CreateSplitWiseToken();
            _context.SaveChanges();
        }
        
        public async Task<bool> CreateUser(string facebookToken)
        {
            FacebookProfile newProfile = await GetFacebookProfileAsync(facebookToken);
            User newUser = new User(newProfile);
            newUser.EsToken = CreateSplitWiseToken();
           // newUser.setUserRepos(await GetGithubProfilesReposAsync(newUser.Username));

            _context.Users.Add(newUser);
            _context.SaveChanges();
            return true;
        }

        public virtual string GetTokenOf(int userId)
        {
            return _context.Find<User>(userId).EsToken;
        }


    }
}
