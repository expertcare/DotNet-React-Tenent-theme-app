
using Microsoft.AspNetCore.Mvc;
using ReactApp1.Server.Model;

namespace ReactApp1.Server.Repository
{
    public interface ITenantRepository
    {
        public ActionResult<ResponseModel> Login(LoginInputModel? Input);
        public ActionResult<ResponseModel> GetTenant();
        public ActionResult<ResponseModel> UpdateTenant(ThemeUpdate themeUpdate);
        public ActionResult<ResponseModel> UploadFavicon(IFormFile file, int userId);
        public ActionResult<ResponseModel> UploadImage(IFormFile file, int userId);

    }
}
