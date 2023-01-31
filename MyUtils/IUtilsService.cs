using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allinibp.Services
{
    public interface IUtilsService
    {
        public Task<string> RandomString(int StringLength);
        public Task<DateOnly> ToDateOnly(DateTime date);
    }
}