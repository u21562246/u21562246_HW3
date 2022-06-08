using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u21562246_HW3.Models;

namespace u21562246_HW3.Controllers
{
    public class FilesController : Controller
    {
        // GET: Files
        public ActionResult Index()
        {
            //code to Fetch all files in the Folder (Directory).
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Media/Documents/"));

            //Copy File names to Model collection.
            List<FileModel> files = new List<FileModel>();
            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }

            return View(files);
        }

        //code to download files
        public FileResult Download(string FileName)
        {
            //Build the File Path.
            string path = Server.MapPath("~/Media/Documents/") + FileName;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", FileName);
        }

        public ActionResult Delete(string FileName)
        {
            // code to delete file 
            string fullPath = Request.MapPath("~/Media/Documents/" + FileName);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath); 
                ViewBag.Status = "File was found and deleted";
            }
            else
            {

                ViewBag.Status = "File was not found and hence cannot be deleted";
            }
            return RedirectToAction("Index");
        }
    }
}