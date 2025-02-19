using Microsoft.AspNetCore.Mvc;
using PhotoCaptureApplication.Entities.Models;
using PhotoCaptureApplication.DAL;
using PhotoCaptureApplication.BL.Repositories;
using PhotoCaptureApplication.BL;

namespace PhotoCaptureApplication.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PhotoController : Controller
    {
        private PhotoBL _photoBL;

        public PhotoController(PhotoCaptureDataContext db)
        {
            _photoBL = new PhotoBL(db);
        }

        [HttpGet("test")]
        public string TestApp()
        {
            var test = "App is working!";
            return test;
        }

    }
}
