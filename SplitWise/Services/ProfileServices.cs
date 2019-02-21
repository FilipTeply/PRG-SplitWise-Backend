using SplitWise.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SplitWise.Services
{
    public class ProfileServices
    {
        private SplitWiseContext _context;

        public ProfileServices()
        {
            SplitWiseContext _context = new SplitWiseContext();
        }

        public ProfileServices(SplitWiseContext context)
        {
            _context = context;
        }

        //public List<User> GetProfilesForUser(string username, int numberOfProfiles)
        //{
        //    return (from Users in _context.Users
        //            where Users.Username != username
        //            select Users).OrderBy(x => Guid.NewGuid()).Take(numberOfProfiles).ToList();
        //}
    }
}
