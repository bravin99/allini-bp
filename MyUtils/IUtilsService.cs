using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using allinibp.Data.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace allinibp.Services
{
    public interface IUtilsService
    {
        public Task<string> RandomString(int stringLength);
        public Task<DateOnly> ToDateOnly(DateTime date);
        public Task<string?> UploadImage(IBrowserFile file);
    }
}