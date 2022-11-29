using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Data;

namespace MVC_Apps.Controllers
{
    public class FileUploadController : Controller
    {
        /// <summary>
        /// The COntract that is used by "Hosting Env." 
        /// </summary>
        IWebHostEnvironment hostEnvironment;

        public FileUploadController(IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// IFromFile: Represents the File REceived from HttpRequest
        /// THis helps to read the file and Process it 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            try
            {
                // Check the File is received

                if (file == null)
                    throw new Exception("File is Not Received...");


                // Create the Directory if it is not exist
                string dirPath = Path.Combine(hostEnvironment.WebRootPath, "ReceivedFiles");
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                // MAke sure that only Excel file is used 
                string dataFileName = Path.GetFileName(file.FileName);

                string extension = Path.GetExtension(dataFileName);

                string[] allowedExtsnions = new string[] { ".png", ".jpeg" };

                if (!allowedExtsnions.Contains(extension))
                    throw new Exception("Sorry! This file is not allowed, make sure that file having extension as either.xls or.xlsx is uploaded.");

                // Make a Copy of the Posted File from the Received HTTP Request
                string saveToPath = Path.Combine(dirPath, dataFileName);

                using (FileStream stream = new FileStream(saveToPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                    
                
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
    }
}
