using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u21562246_HW3.Models;

namespace u21562246_HW3.Controllers
{
    public class VideosController : Controller
    {
        // GET: Videos


        public ActionResult Index()
        {
            //code to Fetch all Videos in the Folder (Directory).
            string[] filePaths = System.IO.Directory.GetFiles(Server.MapPath("~/Media/Videos/"));

            //Copy Videos names to Model collection.
            List<ModelForFile> files = new List<ModelForFile>();
            foreach (string filePath in filePaths)
            {
                files.Add(new ModelForFile { NameOfSelectedFile = System.IO.Path.GetFileName(filePath) });
            }

            return View(files);
        }

        //code to download files
        public FileResult Download(string FileName)
        {
            //Build the Videos Path.
            string path = Server.MapPath("~/Media/Videos/") + FileName;

            //Read the Videos data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the Videos to Download.
            return File(bytes, "application/octet-stream", FileName);
        }

        public ActionResult Delete(string FileName)
        {
            // code to delete Videos 
            string fullPath = Request.MapPath("~/Media/Videos/" + FileName);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
                ViewBag.Status = "Video was found and deleted";
            }
            else
            {

                ViewBag.Status = "Video was not found and hence cannot be deleted";
            }
            return RedirectToAction("Index");
        }
    }
}