
using Microsoft.AspNetCore.Mvc;
using ReactApp1.Server.Model;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace ReactApp1.Server.Repository
{
    public class TenantRepository:ITenantRepository
    {

        public ContextFile _context;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        public TenantRepository(ContextFile context, IConfiguration configuration, IWebHostEnvironment environment)
        {
            _context = context;
            _configuration = configuration;
            _environment = environment;
        }
        public ActionResult<ResponseModel> Login(LoginInputModel? Input)
        {
            try
            {
                var gettenant = _context.TenantDetails.Where(x=>x.Username==Input.UserName && x.Password==Input.Password).FirstOrDefault();

                if (gettenant ==null)
                {
                    return new ResponseModel
                    {
                        Message = "Tenant not found, please enter valid credentials",
                        Status = false
                    };
                }
                var response = new ResponseModel()
                {
                    Data = gettenant,
                    Message = "succses",
                    Status = true,
                    IsActive = true

                };
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public ActionResult<ResponseModel> GetTenant()
        {
            try {
                var getList = _context.TenantDetails.ToList();

                var response = new ResponseModel()
                {
                    Data = getList,
                    Message = "succses",
                    Status = true,
                    IsActive = true

                };
                return response;
            }
            catch(Exception ex) {
                throw;
            }
           
        }
        public ActionResult<ResponseModel> UploadImage(IFormFile file, int userId)
        {
            try
            {
                var webRootPath = _environment.WebRootPath;
                if (file == null || file.Length == 0)
                {
                    return new ResponseModel()
                    {
                        Data = null,
                        Message = "No file uploaded.",
                        Status = false,
                        IsActive = true
                    };
                }
                var directory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);
                var fileName = $"{userId}_{DateTime.Now.Ticks}_{Path.GetFileName(file.FileName)}";
                var imagePath = Path.Combine("Images", $"{userId}_*");
                var filePath = Path.Combine("wwwroot", "Images", fileName);
                var files = Directory.GetFiles(webRootPath, imagePath);

              
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyToAsync(stream);
                }
               // string filePath1 = @"D:\test\ReactApp1\ReactApp1.Server\wwwroot\Images\" + "" + fileName;
                byte[] imageArray = System.IO.File.ReadAllBytes(filePath);
                string base64ImageRepresentation = Convert.ToBase64String(imageArray);


                var img = Convert.FromBase64String(base64ImageRepresentation);

                var tenant = _context.TenantDetails.Where(x => x.UserId == userId).FirstOrDefault();
                tenant.Image = base64ImageRepresentation;
                _context.SaveChanges();
                return new ResponseModel()
                {
                    Data = tenant,
                    Message = "Image uploaded successfully.",
                    Status = true,
                    IsActive = true
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public ActionResult<ResponseModel> UploadFavicon(IFormFile file, int userId)
        {
            try
            {
                var webRootPath = _environment.WebRootPath;
                if (file == null || file.Length == 0)
                {
                    return new ResponseModel()
                    {
                        Data = null,
                        Message = "No file uploaded.",
                        Status = false,
                        IsActive = true
                    };
                }
                
                var directory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);
                var fileName = $"{userId}_{DateTime.Now.Ticks}_{Path.GetFileName(file.FileName)}";
                var filePath = Path.Combine(directory, fileName); // Corrected file path
                string path = $"{@"/wwwroot/images/"}{fileName}";
                var files = Directory.GetFiles(directory); // Corrected directory name
                                                           // var relativePath = Path.GetRelativePath(webRootPath, files[0]);
               
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyToAsync(stream);
                }
               // string filePath1 = @"D:\test\ReactApp1\ReactApp1.Server\wwwroot\Images\" + "" + fileName;
                byte[] imageArray = System.IO.File.ReadAllBytes(filePath);
                string base64ImageRepresentation = Convert.ToBase64String(imageArray);


                var img = Convert.FromBase64String(base64ImageRepresentation);
                var tenant = _context.TenantDetails.Where(x => x.UserId == userId).FirstOrDefault();
                // Save image details to the database
                tenant.Favicon = base64ImageRepresentation;
                _context.SaveChanges();
                // _repository.AddImage(image);
                return new ResponseModel()
                {
                    Data = tenant,
                    Message = "Image uploaded successfully.",
                    Status = true,
                    IsActive = true
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public ActionResult<ResponseModel> UpdateTenant(ThemeUpdate themeUpdate)
        {
            try
            {
                var tenant = _context.TenantDetails.Where(x=>x.UserId == themeUpdate.UserId).FirstOrDefault();

                if (tenant == null)
                {
                    return new ResponseModel
                    {
                        Message = "Tenant not found",
                        Status = false
                    };
                }
                tenant.ThemeName = themeUpdate.Theme;
                tenant.Image = themeUpdate.ImagePath;
                tenant.UpdatedDate = DateTime.Now;
                _context.SaveChanges();

                var response = new ResponseModel()
                {
                    Data = tenant,
                    Message = "Theme updated successfully",
                    Status = true,
                    IsActive = true
                };
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string GetBase64(string path)
        {
            string res = "";


            return res;
        }
    }
}
