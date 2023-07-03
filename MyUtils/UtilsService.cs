using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using allinibp.Data.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace allinibp.Services
{
    public class UtilsService : IUtilsService
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public UtilsService(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        private static Random _random = new Random();

        public Task<string> RandomString(int stringLength)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";

            var randString = new string(Enumerable.Repeat(chars, stringLength).Select(
                s => s[_random.Next(s.Length)]).ToArray());

            return Task.FromResult<string>(randString);
        }

        public Task<DateOnly> ToDateOnly(DateTime date)
        {
            var nDate = new DateOnly(date.Year, date.Month, date.Day);
            return Task.FromResult<DateOnly>(nDate);
        }
        
        public async Task<string?> UploadImage(IBrowserFile file)
        {
            try
            {
                var trustedFilename = Path.GetRandomFileName();
                var path = Path.Combine(_hostEnvironment.ContentRootPath, _hostEnvironment.EnvironmentName, "unsafe_uploads",
                    trustedFilename);
                FileStream filestream = new FileStream(path, FileMode.Create, FileAccess.Write);
                filestream.Close();
                return $"{path}.{file.ContentType}";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null!;
            }
        }
    }
}