using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allinibp.Services
{
    public class UtilsService : IUtilsService
    {
        private static Random rand = new Random();
        public Task<string> RandomString(int StringLength)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var randString = new string(Enumerable.Repeat(chars, StringLength).Select(s => s[rand.Next(s.Length)]).ToArray());

            return Task.FromResult<string>(randString);
        }
    }
}