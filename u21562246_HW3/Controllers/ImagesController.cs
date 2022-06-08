using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u21562246_HW3.Models;

namespace u21562246_HW3.Controllers
{
    public class ImagesController : Controller
    {
        // GET: Images
        
        public ActionResult Index()
        {
            //code to Fetch all files in the Folder (Directory).
            string[] filePaths = System.IO.Directory.GetFiles(Server.MapPath("~/Media/Images/"));

            //Copy File names to Model collection.
            List<Models.FileModel> files = new List<FileModel>();
            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = System.IO.Path.GetFileName(filePath) });
            }

            return View(files);
        }

        //code to download files
        public FileResult Download(string FileName)
        {
            //Build the Images Path.
            string path = Server.MapPath("~/Media/Images/") + FileName;

            //Read the Images data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the Images to Download.
            return File(bytes, "application/octet-stream", FileName);
        }

        public ActionResult Delete(string FileName)
        {
            // code to delete Images 
            string fullPath = Request.MapPath("~/Media/Images/" + FileName);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
                ViewBag.Status = "Image was found and deleted";
            }
            else
            {

                ViewBag.Status = "Image was not found and hence cannot be deleted";
            }
            return RedirectToAction("Index");
        }
    }
}