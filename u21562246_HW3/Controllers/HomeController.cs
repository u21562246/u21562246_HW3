using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace u21562246_HW3.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string btnOptionSelection, HttpPostedFileBase file)
        {
            ViewBag.Status = btnOptionSelection + " has been uploaded successfully";
            //code to check whther user wants to upload image
            if (btnOptionSelection == "Image")
            {
                //code to upload picture
                string NameOfPicture = System.IO.Path.GetFileName(file.FileName);
                string PathOfPicture = System.IO.Path.Combine(Server.MapPath("~/Media/Images"), NameOfPicture);
                // file is uploaded
                file.SaveAs(PathOfPicture);
            }
            if (btnOptionSelection == "video")
            {
                //code to upload video
                string NameOfPicture = System.IO.Path.GetFileName(file.FileName);
                string PathOfPicture = System.IO.Path.Combine(Server.MapPath("~/Media/Videos"), NameOfPicture);
                // file is uploaded
                file.SaveAs(PathOfPicture);

            }
            if (btnOptionSelection == "Document")
            {
                //code to upload Document
                string NameOfPicture = System.IO.Path.GetFileName(file.FileName);
                string PathOfPicture = System.IO.Path.Combine(Server.MapPath("~/Media/Documents"), NameOfPicture);
                // file is uploaded
                file.SaveAs(PathOfPicture);
            }

            return View();
        }

    }
}