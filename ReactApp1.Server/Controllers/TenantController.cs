
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactApp1.Server.Model;
using ReactApp1.Server.Repository;

namespace ReactApp1.Server.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        public ITenantRepository _repository;

        public TenantController(ITenantRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult<ResponseModel> Login(LoginInputModel? Input)
        {
            return _repository.Login(Input);
        }

        [HttpGet]
        [Route("GetTenant")]
        public ActionResult<ResponseModel> GetTenant()
        {
            try
            {
                return _repository.GetTenant();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut]
        [Route("UpdateTenant")]
        public ActionResult<ResponseModel> UpdateTenant(ThemeUpdate themeUpdate)
        {

            return _repository.UpdateTenant(themeUpdate);
        }
        [HttpPut]
        [Route("UpdateBanner")]
        public ActionResult<ResponseModel> UploadImage(IFormFile file, int userId)
        {

            return _repository.UploadImage(file, userId);
        }
        [HttpPut]
        [Route("UploadFavicon")]
        public ActionResult<ResponseModel> UploadFavicon(IFormFile file, int userId)
        {

            return _repository.UploadFavicon(file, userId);
        }
    }
}
