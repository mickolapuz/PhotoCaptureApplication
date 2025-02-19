using ExpenseTracker.DAL.Repositories;
using PhotoCaptureApplication.DAL;
using PhotoCaptureApplication.Entities.Models;

namespace PhotoCaptureApplication.BL.Repositories
{
    public class PhotoBL
    {
        public PhotoDAL _photoDAL;

        public PhotoBL(PhotoCaptureDataContext _db)
        {
            _photoDAL = new PhotoDAL(_db);
        }

        public List<PhotoModel> GetUsers()
        {
            return _photoDAL.GetAll();
        }

    }
}
